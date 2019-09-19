#!/usr/bin/python3

import jsonpickle
import requests
import datetime

from devTempLight import devTempLight
from Temperature import Temperature
from photoresistorValue import photoresistorValue

def main():
        print("Checking Temp and Light Sensors...")
        ProcessData()

def ProcessData():
        light = photoresistorValue()
        temp = Temperature()

        data = devTempLight(temp.getTemperature(), light.get_Voltage(), datetime.datetime.now())
        jsonData = jsonpickle.encode(data, unpicklable=False)
        print(jsonData)

if __name__ == "__main__":
        main()
