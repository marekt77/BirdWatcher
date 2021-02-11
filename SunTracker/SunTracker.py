#!/usr/bin/python3

import jsonpickle
import requests
import datetime
from w1thermsensor import W1ThermSensor

from SunTrack import SunTrack
from photoresistorValue import photoresistorValue

url = 'http://192.168.1.21/api/suntrack'
path = 'timeofday.txt'

def main():
    print("Checking Temp and Light Sensors...")

def ProcessData():
    light = photoresistorValue()
    sensor = W1ThermSensor()
    
    if light > 0.15:
        #it is sunrise
        print("It is sunrise.")

    if light < 0.15:
        #it is sunset
        print("it is sunset")

    data = SunTrack(sensor.get_temperature(), light.get_Voltage(), datetime.datetime.now())
    jsonData = jsonpickle.encode(data, unpicklable=False)
    print(jsonData)

    response = requests.posts(url, json=jsonData)
    print(response.json())