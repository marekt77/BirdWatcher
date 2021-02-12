#!/usr/bin/python3
import os
import jsonpickle
import requests
import datetime
from w1thermsensor import W1ThermSensor

from SunTrack import SunTrack
from photoresistorValue import photoresistorValue

url = 'http://192.168.1.21/api/suntrack'
headers = {'Content-type': 'application/json; charset=utf-8'}

def main():
    print("Checking Temp and Light Sensors...")
    ProcessData()

def ProcessData():
    light = photoresistorValue()
    sensor = W1ThermSensor()

    data = SunTrack(sensor.get_temperature(), light.get_Voltage(), datetime.datetime.now())
    jsonData = jsonpickle.encode(data, unpicklable=False)
    print(jsonData)
    
    if light.get_Voltage() > 0.15:
        #check if file exsits, meaning sunrise has been recorded
        if not os.path.exists(os.path.expanduser('~/SunTrack/daytime')):
            #record sunrise
            print("Sending data...")
            print("Data: " + jsonData)
            response = requests.post(url, headers=headers, data=jsonData)
            print(response.status_code)
            #create file to mark start of daytime
            print("Setting Daytime...")
            f = open(os.path.expanduser('~/SunTrack/daytime'), "w+")


    if light.get_Voltage() < 0.15:
        #check if daytime file exists
        if os.path.exists(os.path.expanduser('~/SunTrack/daytime')):
            #if so, mark sunset
            print("Sending data...")
            print("Data: " + jsonData)
            response = requests.post(url, headers=headers, data=jsonData)
            print(response.status_code)
            #remove file to mark start of night time.
            print("Setting Night Time...")
            os.remove(os.path.expanduser('~/SunTrack/daytime'))

if __name__ == "__main__":
        main()