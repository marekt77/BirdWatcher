#!/usr/bin/python3

import jsonpickle
import requests
import datetime
import shutil
import socket
import os

from watcherhealthcheck import WatcherHealthCheck

url = 'http://192.168.1.21/api/watcherhealth'
headers = {'Content-type': 'application/json; charset=utf-8'}


def main():
    print("Start Health Check...")

    diskInfo = getDiskSpace()
    data = WatcherHealthCheck(socket.gethostname(), getIP(), getCPU_Temp(), getGPU_Temp(), diskInfo["total"], diskInfo["used"], diskInfo["free"], datetime.datetime.now())
    jsonData = jsonpickle.encode(data, unpicklable=False)

    #send data:
    response = requests.post(url, headers=headers, data=jsonData)
    print(response.status_code)
    #report done
    print("Report done...")


def getDiskSpace():
    diskInfo = dict();
    
    diskInfo['total'], diskInfo['used'], diskInfo['free'] = shutil.disk_usage(__file__)

    return diskInfo

def getIP():
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    s.connect(("8.8.8.8", 80))
    return s.getsockname()[0]

def getCPU_Temp():
    myCMD = 'echo "$(cat /sys/class/thermal/thermal_zone0/temp)"'
    tmpCPU = float(os.popen(myCMD).read())

    return tmpCPU/1000

def getGPU_Temp():
    myCMD = 'echo "$(/opt/vc/bin/vcgencmd measure_temp)"'
    txtGPU = os.popen(myCMD).read()
    txtGPU = txtGPU.replace("temp=", "").replace("'C", "")
    return float(txtGPU)

if __name__ == "__main__":
        main()