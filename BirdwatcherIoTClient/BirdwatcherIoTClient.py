
######## Raspberry Pi Bird Identifier using TensorFlow Object Detection API #########
#
# Author: Marek Tyrpa
# Date: 05/22/2019
# Description:
#
# This program will attempt to identify 12 common species of birds in the 
# US Midwest, and will send a positive ID to the BirdwatcherBackEnd API.
# It is implemented using Tensorflow.
#
# The framework is based off the Object_detection_picamera.py script located here:
# https://github.com/EdjeElectronics/TensorFlow-Object-Detection-on-the-Raspberry-Pi/blob/master/Object_detection_picamera.py

# Import packages
import os
import cv2
import string
import random
import numpy as np
from picamera.array import PiRGBArray
from picamera import PiCamera
import tensorflow as tf
import argparse
import sys
import threading
import jsonpickle
import requests
import datetime
import time

# Import my sensor libraries:
from Temperature import Temperature
from photoresistorValue import photoresistorValue
from BirdLog import BirdLog

# Set up camera constants
IM_WIDTH = 1280
IM_HEIGHT = 720

#Initialize variable to count # of frames a bird was detected
bird_identified = 0

#set URL of API Server:
url = 'https://192.168.1.21/'

# This is needed since the working directory is the object_detection folder.
sys.path.append('..')

# Import utilites
from utils import label_map_util
from utils import visualization_utils as vis_util

# Name of the directory containing the object detection module we're using
MODEL_NAME = 'ssd_mobilenet_v2_coco_2018_03_29'

# Grab path to current working directory
CWD_PATH = os.getcwd()

# Path to frozen detection graph .pb file, which contains the model that is used
# for object detection.
PATH_TO_CKPT = os.path.join(CWD_PATH,"frozen_graphs","ssd_mobilenet_v2_coco_2018_03_29",'frozen_inference_graph.pb')

# Path to label map file
PATH_TO_LABELS = os.path.join(CWD_PATH,'labelmap','birds_labelmap.pbtxt')

# Number of classes the object detector can identify
NUM_CLASSES = 12

## Load the label map.
# Label maps map indices to category names, so that when the convolution
# network predicts `5`, we know that this corresponds to `airplane`.
# Here we use internal utility functions, but anything that returns a
# dictionary mapping integers to appropriate string labels would be fine
label_map = label_map_util.load_labelmap(PATH_TO_LABELS)
categories = label_map_util.convert_label_map_to_categories(label_map, max_num_classes=NUM_CLASSES, use_display_name=True)
category_index = label_map_util.create_category_index(categories)

# Load the Tensorflow model into memory.
detection_graph = tf.Graph()
with detection_graph.as_default():
    od_graph_def = tf.GraphDef()
    with tf.gfile.GFile(PATH_TO_CKPT, 'rb') as fid:
        serialized_graph = fid.read()
        od_graph_def.ParseFromString(serialized_graph)
        tf.import_graph_def(od_graph_def, name='')

    sess = tf.Session(graph=detection_graph)

# Define input and output tensors (i.e. data) for the object detection classifier

# Input tensor is the image
image_tensor = detection_graph.get_tensor_by_name('image_tensor:0')

# Output tensors are the detection boxes, scores, and classes
# Each box represents a part of the image where a particular object was detected
detection_boxes = detection_graph.get_tensor_by_name('detection_boxes:0')

# Each score represents level of confidence for each of the objects.
# The score is shown on the result image, together with the class label.
detection_scores = detection_graph.get_tensor_by_name('detection_scores:0')
detection_classes = detection_graph.get_tensor_by_name('detection_classes:0')

# Number of objects detected
num_detections = detection_graph.get_tensor_by_name('num_detections:0')

# Initialize frame rate calculation
frame_rate_calc = 1
freq = cv2.getTickFrequency()
font = cv2.FONT_HERSHEY_SIMPLEX

def getBirdByID(ID, birds):
    return [element for element in birds if element['id'] == ID]

def bird_logger(frame):

    global bird_identified

    # Perform the actual detection by running the model with the image as input
    (boxes, scores, classes, num) = sess.run(
        [detection_boxes, detection_scores, detection_classes, num_detections],
        feed_dict={image_tensor: frame_expanded})

    # Draw the results of the detection (aka 'visulaize the results')
    # Note: the min_score_thresh sets the precentage required for a positive id
    # Example: 0.40 means if the model is 40% sure it will return a positive ID
    vis_util.visualize_boxes_and_labels_on_image_array(
        frame,
        np.squeeze(boxes),
        np.squeeze(classes).astype(np.int32),
        np.squeeze(scores),
        category_index,
        use_normalized_coordinates=True,
        line_thickness=8,
        min_score_thresh=0.40)

    if (((int(classes[0][0]) >= 1) or (int(classes[0][0]) <= 12 ))):
        bird_identified = bird_identified + 1
    
    #If bird is present for 10 frames or more, log the entry
    if(bird_identified > 10):
        print("Image ID: " + str(int(classes[0][0])))
        
        print("Bird Found! Bird Type: " + getBirdByID(int(classes[0][0]), category_index)['name'])
        #save image:
        tmpFilePath = '/home/pi/images/' + id_generator() + '.png'

        #save image as tmp file...
        cv2.imwrite(tmpFilePath, frame)
        
        #send file to API
        serverFilename = ''
        with open(tmpFilePath) as fh:
            #setup request
            url_postfile = url + 'api/BirdLogs/PostLogPicture'
            headers = {'Content-type': 'image/png'}
            
            imageData = fh.read()
            
            req = requests.post(url_postfile, headers = headers, data = imageData cert=('/home/marekt/BirdWatcherIoT/testCerts/marek.crt', '/home/marekt/BirdWatcherIoT/testCerts/marek.key'), verify=False)
            
            #if file was uploaded correctly, delete the tmp image file:
            if status_code == 200:
                os.remove(tmpFilePath)
                #set the filename returned from the server.
                serverFilename = ''

        #now post the bird log.

        

        bird_identified = 0

    return frame

def sendBirdLog(data):
    url = url + 'api/BirdLogs'

    headers = {'Content-type': 'application/json'}
    req = requests.post(url, headers = headers, data=data, cert=('/home/marekt/BirdWatcherIoT/testCerts/marek.crt', '/home/marekt/BirdWatcherIoT/testCerts/marek.key'), verify=False)


def assembleData(serverPicture, Birds):
    temp = Temperature()

    data = BirdLog(Timestamp = datetime.datetime.now(), Temperature = .getTemperature(), serverPicture, 0.0,0,0,'', Birds)
    jsonData = jsonpickle.encode(data, unpickable=False)
    sendBirdLog(jsonData)


def id_generator(size=6, chars=string.ascii_uppercase + string.digits):
    return ''.join(random.choice(chars) for _ in range(size))

class RunCamera(threading.Thread):
    
    def __init__(self):
        threading.Thread.__init__(self)
        self.paused = False
        self.pause_cond = threading.Condition(threading.Lock())

    def run(self):
        camera = PiCamera()
        camera.resolution = (IM_WIDTH,IM_HEIGHT)
        camera.framerate = 10
        rawCapture = PiRGBArray(camera, size=(IM_WIDTH,IM_HEIGHT))
        rawCapture.truncate(0)

        while True:
            with self.pause_cond:
                while self.paused:
                    self.pause_cond.wait()
                #Start Video Capture and processing:
                for frame1 in camera.capture_continuous(rawCapture, format="bgr",use_video_port=True):
                    t1 = cv2.getTickCount()
                    # Acquire frame and expand frame dimensions to have shape: [1, None, None, 3]
                    # i.e. a single-column array, where each item in the column has the pixel RGB value

                    frame = np.copy(frame1.array)
                    frame.setflags(write=1)
                    frame_expanded = np.expand_dims(frame, axis=0)
                    
                    #Send frame to bird_logger of ID
                    frame = bird_logger(frame)

                    cv2.putText(frame,"FPS: {0:.2f}".format(frame_rate_calc),(30,50),font,1,(255,255,0),2,cv2.LINE_AA)

                    # All the results have been drawn on the frame, so it's time to display it.
                    cv2.imshow('Object detector', frame)

                    t2 = cv2.getTickCount()
                    time1 = (t2-t1)/freq
                    frame_rate_calc = 1/time1
                    
                    rawCapture.truncate(0)
    
    def pause(self):
        self.paused = True
        self.pause_cond.acquire()

    def resume(self):
        self.paused = False
        self.pause_cond.notify()
        self.pause_cond.release()

def main():
    light = photoresistorValue()

    #download Birds Catalog
    #<todo>
    
    VideoFeedThread = RunCamera()
    VideoFeedThread.start()
    
    while 1:
        time.sleep(60)

        # check if it there is still daylight based on the light sensor  If it is too dark, pause the camera detection else
        # start it back up.
        if light.get_Voltage() <= 2.0:
            VideoFeedThread.pause()
        else:
            if VideoFeedThread.is_alive() is False:
                VideoFeedThread.resume()

if __name__ == "__main__":
        main()