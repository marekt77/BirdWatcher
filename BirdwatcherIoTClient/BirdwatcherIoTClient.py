#!/usr/bin/python3

import jsonpickle
import requests
import datetime

from devTempLight import devTempLight
from Temperature import Temperature
from photoresistorValue import photoresistorValue

def main():
        print("Starting BirdWatcher IoT Client...")
        ProcessData()

def ProcessData():
        light = photoresistorValue()
        temp = Temperature()

        data = devTempLight(temp.getTemperature(), light.get_Voltage(), datetime.datetime.now())
        jsonData = jsonpickle.encode(data, unpicklable=False)
        print(jsonData)
        sendDevData(jsonData)
        
def sendDevData(data):
        #working URL
        url = 'https://192.168.1.21/api/devTempLights'

        headers = {'Content-type': 'application/json'}
        req = requests.post(url, headers = headers, data=data, cert=('testCerts/marek.crt', 'testCerts/marek.key'), verify=False)

        print(req.status_code)

def checkConnection():
        #req = requests.get('https://192.168.1.21',verify=False, cert=('testCerts/marek.crt', 'testCerts/marek.key'))
        req = requests.get('https://192.168.1.21/api/devTempLights',verify=False, cert=('testCerts/marek.crt', 'testCerts/marek.key'))
        print("HTTP Status Code: " + str(req.status_code))
        print(req.headers)
        print(req.content)

if __name__ == "__main__":
        main()
