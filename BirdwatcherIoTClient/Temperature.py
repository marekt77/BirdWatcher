from w1thermsensor import W1ThermSensor

class Temperature:
    sensor = W1ThermSensor()

    def getTemperature(self):
        return self.sensor.get_temperature()