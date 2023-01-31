FROM arm32v7/python:3.7.16-slim-buster

WORKDIR /app

COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt

COPY . /app

ENTRYPOINT ["python"]

CMD ["WeatherStation.py"]
