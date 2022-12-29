# Setup the Backend Infastructure

## RaspSQL

### Install and Configure PostgreSQL

`sudo apt-get install postgresql-9.6 postgresql-contrib libpq-dev`

#### Start and enable Services of postgresql

`sudo systemctl start postgresql`

`sudo systemctl enable postgresql`

#### Add Listen Address

This will configure PostGRE to listen to all network connections:

`sudo nano /etc/postgresql/9.6/main/postgresql.conf`

Edit the following line :

`listen_addresses = 'localhost'`

to

`listen_addresses = '*'`

Save File

#### Allow users to connect from any IP
Edit the `pg_hba.conf` file.
It allows access to all databases for all users with an encrypted password:

`sudo nano /etc/postgresql/9.6/main/pg_hba.conf`

Add the following line as the last line of pg_hba.conf.

`host  all  all 0.0.0.0/0 md5`

Save File
Then restart Postgre by running:

`sudo service postgresql restart`

#### Create Birdwatcher Database and User

The postgres user is created automatically when you install PostgreSQL. This user is the superuser for the PostgreSQL instance and it is equivalent to the MySQL root user.

To log in to the PostgreSQL server as the postgres user first you need to switch to the postgres user and then you can access a PostgreSQL prompt using the psql utility:

`sudo su - postgres`

`psql`

Create Birdwatcher Database:

`CREATE DATABASE BirdWatcher;`

Create User for BirdWatcher Client:

`CREATE USER dbbirdwatcher WITH ENCRYPTED PASSWORD '<Enter your Password here>';`

Grant User Create Database Privileges:

`ALTER USER dbbirdwatcher CREATEDB;`

Grant All Privileges to dbbirdwatcher user on BirdWatcher DB:

`GRANT ALL PRIVILEGES ON DATABASE BirdWatcher to dbbirdwatcher;`

Create Migration Using EF: (This will create all the tables/relationships needed)

Go to the BirdWatcherBackend project directory.

Create a file called: secretConfig.json, place the following inside:  Replace host with IP of your server and <password> with whatever password you have the user above.

```
{
    "ConnectionStrings": {
    "BirdWatcherDB": "host=<IP of Postgre Server>;database=BirdWatcher;user id=dbbirdwatcher;password=<Password>;"
    }
}
```

Save the file, and then run the following from the BirdWatcherClient directory:

`dotnet ef database update`

This will create the database/tables/relationships needed for the project.  If this runs correctly, your Postgre is now correctly installed and configured for use for this project.

---

### Configure File Share that will hold the captured images

#### Create Directory that will hold Log Images

`sudo mkdir -p /srv/data/BirdWatcher/LogImages`

#### Install and Configure Samba

`sudo apt-get install samba`

##### Setup File Share in Samba:

Edit the /etc/samba/smb.conf file:

`sudo nano /etc/samba/smb.conf`

Add the following to the bottom of the file:

```
[BirdwatcherShare]
    comment=Birdwatcher App Share
    path=/srv/data/BirdWatcher/LogImages
    available=yes
    browseable=Yes
    writeable=Yes
    read only=no
    write list = bw_client
    create mask=0755
    directory mask=0755
    public=yes
```

##### Create Samba User

Create a user called: bw_client (password: client_123)

`sudo adduser bw_client`
`sudo smbpasswd -a bw_client`

##### Create Birdwatcher Group

`sudo groupadd birdwatcher`
`sudo usermod -a -G birdwatcher bw_client`

##### Add folder to Birdwatcher Group

`sudo chgrp birdwatcher /srv/data/BirdWatcher/LogImages`

##### Giver read/write permissions to group

`sudo chmod g+rwx /srv/data/BirdWatcher/LogImages`

##### Restart Samba

`sudo /etc/init.d/samba restart`

RaspSQL is now configured and ready to for use in this project.

---

## RaspCompute

### Docker

#### Install Docker

`sudo apt-get install docker-ce`

Now we are going to add our user to the *docker* group, so we can run the docker command without *sudo*

`sudo usermod -aG docker $USER`

This will add the currently logged in user to the docker group.
Now let us test that Docker correctly installed and we can run it witout *sudo*

`docker run hello-world`

If Docker is installed properly, you will see a "Hello from Docker!" message.

#### Login to Docker Hub

In this project I assume you have a Docker Hub account for storing your container images.  You are free to use your own repo, but this guide will assume you are using Docker Hub.  If you do not have a Docker Hub account you can sign up for free [here.](https://www.docker.com/products/docker-hub)

`docker login --username=<YourDockerHubAccount>`

Next you will be prompted for your Docker Hub Password.  If you have logged in successfuly you will see a `Login Succeeded` message, and you are ready to pull images from your repository on Docker Hub.

---

### NGINX

#### Install NGINX

`sudo apt-get install nginx`

#### Configure NGINX

##### Create new site

We are setting up a reverse proxy in NGINX which will redirect all of the incomming traffic on port 80 to our docker container listening on port 5000.

First navigate to the following directory:

`cd /etc/nginx/sites-enabled`

Now remove the existing file:

`sudo rm default`

Create a new file:

`sudo nano default`

And type in the following:

```
server {
        listen 80;

        location / {
                proxy_pass         http://localhost:5000;
                proxy_http_version 1.1;
                proxy_set_header   Upgrade $http_upgrade;
                proxy_set_header   Connection keep-alive;
                proxy_set_header   Host $host;
                proxy_cache_bypass $http_upgrade;
                proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
                proxy_set_header   X-Forwarded-Proto $scheme;
        }
}
```

Save the file and exit.

##### Allow larger uploads

Edit nginx.conf file located at: /etc/nginx/nginx.conf

Add the following line to the http section:

```
# set client body size to 10M#
client_max_body_size 10M;
```

##### Add Firewall Rule for NGINX

`sudo ufw allow 'Nginx HTTP'`

Restart NGINX:

`sudo service nginx reload`

---

### Setup File Share

#### Create directory for captured images

`sudo mkdir -p /mnt/birdwatcher/images`
`sudo chmod -R 0777 /mnt/birdwatcher/images`

#### Edit fstab to mount at boot time:

`sudo nano /etc/fstab`

Add this line to file:

`//<RaspSQL IP Address>/BirdwatcherShare /mnt/birdwatcher/images cifs username=bw_client,password=client_123,file_mode=0777,dir_mode=0777 0 0`

### On your Dev Machine

#### Build the Container

Note: You cannot compile .net on arm yet, so you need to do this on your local machine

`docker build -t <YourDockerHubAccount>/birdwatcherbackend:latest .`

#### Push the container to your docker repo

`docker push <YourDockerHubAccount>/birdwatcherweb:latest`

### On the RaspCompute System

#### Pull the Container

`docker pull <YourDockerHubAccount>/birdwatcherweb:latest`

#### Run the Container

`docker run --restart=always -d -v /mnt/birdwatcher/images:/app/wwwroot/images/captured -p 5000:5000 <YourDockerHubAccount>/birdwatcherweb:latest`
