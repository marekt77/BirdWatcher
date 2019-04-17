import json
import jsonpickle
import requests
import datetime
import ssl

from devTempLight import devTempLight
from Temperature import Temperature
from photoresistorValue import photoresistorValue

def main():
        print("Starting BirdWatcher IoT Client...")

        light = photoresistorValue()
        temp = Temperature()

        data = devTempLight(temp.getTemperature(), light.get_Voltage(), datetime.datetime.now())
        
        jsonData = jsonpickle.encode(data, unpicklable=False)
        print(jsonData)
        sendDevData(jsonData)

def sendDevData(jsonData):
        #working URL
        url = 'https://192.168.1.21/api/devTempLight'

        headers = {'Content-type': 'application/json'}
        req = requests.post(url, headers = headers, json=jsonData, verify=False, cert=('testCerts/marek.crt', 'testCerts/marek.key'))

        print(req.status_code)
        


if __name__ == "__main__":
        main()
