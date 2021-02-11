#!/usr/bin/python3

import jsonpickle
import requests
import datetime
from w1thermsensor import W1ThermSensor

from SunTrack import SunTrack
from photoresistorValue import photoresistorValue

url = 'http://192.168.1.21/api/SunTrack'

def main():
    print("Checking Temp and Light Sensors...")
