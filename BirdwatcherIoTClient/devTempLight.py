class devTempLight:
    def __init__(self, Temperature, PhotoresistorValue, Timestamp ):
        self.Temperature = Temperature
        self.PhotoresistorValue = PhotoresistorValue
        self.Timestamp = Timestamp

    def getTemperature(self):
         print("Hello WOrld!")