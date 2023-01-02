#!/usr/bin/python3
import datetime
from flask import Flask, json
from w1thermsensor import W1ThermSensor

from TempReading import TempReading

api = Flask(__name__)

@api.route('/api/temperature', methods=['GET'])
def get_temperature():
  tempSensor = W1ThermSensor()
  data = TempReading(tempSensor.get_temperature(), datetime.datetime.now())

  return json.dumps(data.__dict__)

if __name__ == '__main__':
    api.run()