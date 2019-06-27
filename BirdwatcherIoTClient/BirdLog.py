class BirdLog:
    
    def __init__(self, Timestamp, Temperature, Picture, Location_Latitude, Location_Longitude, UserGUID, Birds):
        self.Temperature = Temperature
        self.Picture = Picture
        self.Location_Latitude = Location_Latitude
        self.Location_Longitude = Location_Longitude
        self.UserGUID = UserGUID
        self.Birds = Birds