#!/usr/bin/python3
import datetime
import os
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
    port = int(os.environ.get('PORT', 5000))
    api.run(host='0.0.0.0', port=port)
