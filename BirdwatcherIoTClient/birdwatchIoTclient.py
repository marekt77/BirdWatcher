import os
#import cv2
import numpy as np
from picamera.array import PiRGBArray
from picamera import PiCamera
from time import sleep

Video_Width = 1920
Video_Height = 1080

#Initialize Camera
camera = PiCamera()
camera.resolution = (Video_Width, Video_Height)
camera.framerate = 10
camera.rotation = 90

camera.start_preview()

sleep(2)

camera.capture('test.jpg')