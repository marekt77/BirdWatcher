import json
import jsonpickle
import requests
import datetime

from devTempLight import devTempLight
#from Temperature import Temperature
#from photoresistorValue import photoresistorValue

def main():
        print("Starting BirdWatcher IoT Client...")

        #light = photoresistorValue()
        #temp = Temperature()

        #data = devTempLight(temp.getTemperature(), light.get_Voltage(), datetime.datetime.now())

        data = devTempLight(23, 345, datetime.datetime.now())
        
        #jsonData = jsonpickle.encode(data, unpicklable=False)
        #print(jsonData)
        #sendDevData(data)

def sendDevData(tmpObject):
        #req = requests.post('http://api/user', data=None, json=None)
        req = requests.get('https://192.168.1.21',verify=False, cert=('testCerts/marek.crt', 'testCerts/marek.key'))
        print("HTTP Status Code: " + str(req.status_code))
        print(req.headers)
        print(req.text)


if __name__ == "__main__":
        main()