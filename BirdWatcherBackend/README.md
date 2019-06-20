# Setting up Raspberry Pi to run the backend API Service

## NGINX

### Install NGINX:

`sudo apt-get install nginx`

### Configure NGINX:

### Allow larger uploads:

#### Edit nginx.conf file located at: /etc/nginx/nginx.conf

Add the following line to the http section:

```# set client body size to 10M #
client_max_body_size 10M;
```

Restart NGINX:
`sudo service nginx reload`

### Create directory for captured images:

`sudo mkdir -p /mnt/birdwatcher/images`
`sudo chmod -R 0777 /mnt/birdwatcher/images`

Add this line to file:

`//192.168.1.20/BirdwatcherShare /mnt/birdwatcher/images cifs username=bw_client,password=client_123,file_mode=0777,dir_mode=0777 0 0`

## On your Dev Machine:

### Build the Container: 
Note: You cannot compile .net on arm yet, so you need to do this on your local machine

`docker build -t mtyrpa/birdwatcherbackend:latest .`

### Push the container to your docker repo:

`docker push mtyrpa/birdwatcherbackend:latest`
	
## On the RaspCompute System:

### Pull the Container:

`docker pull mtyrpa/birdwatcherbackend:latest`

### Run the Container:

`docker run --restart=always -d -v /mnt/birdwatcher/images:/app/wwwroot/images/captured -p 5000:5000 mtyrpa/birdwatcherbackend:latest`
