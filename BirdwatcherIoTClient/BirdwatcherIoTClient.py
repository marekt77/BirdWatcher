import json
import jsonpickle
import requests
import datetime
#from w1thermsensor import W1ThermSensor
from devTempLight import devTempLight
from photoresistorValue import photoresistorValue

def main():
        print("Starting BirdWatcher IoT Client...")
        data = devTempLight(23, 345, datetime.datetime.now())
        jsonData = jsonpickle.encode(data, unpicklable=False)
        print(jsonData)
        #sendDevData(5, 32)

def getTemperature():
        sensor = W1ThermSensor()
        return sensor.get_temperature()

def sendDevData(tmpObject):
        req = requests.get('https://www.google.com')
        print("HTTP Status Code: " + str(req.status_code))
        print(req.headers)


if __name__ == "__main__":
        main()