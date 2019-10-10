# BirdWatcher

The idea and inspiration for this project came from my mom’s birdfeeder at her house in Wisconsin.  She can see the feeder from her kitchen window and spends some of her morning looking at the feeder and trying to identify what birds are showing up and for how long.  She takes great joy at seeing the various species of birds come to her feeder to get some seeds.

Two years ago, during the keynote at Microsoft’s Build conference they demoed image detection running on an Edge device, specifically a Raspberry Pi.  A few months later, while visiting my mom, she called me over to show me some of the birds that were feeding.  Aside from a cardinal and sparrow, neither of us could identify any of the other birds.  Sometime later, the idea popped in my head: “wouldn’t it be cool if that image detection thing I saw at Build could be applied to the birdfeeder…”

Fast forward to today, and this is the result of that idea.  After much time learning and researching Tensorflow, looking at other examples, and building a hardware prototype that uses a Video Camera hooked up to a Raspberry Pi to look at the birdfeeder and then attempt to identify and catalog the birds that come to feed there.  This project would not exist if not for Evan Juras and his Object Detection demos on GitHub: https://github.com/EdjeElectronics

About 90% of the project is written in C# and runs on .Net Core 2.2, the Object Detection part that runs on the Raspberry Pi is written in Python.  

Why C#? Well I was able to use one language for 90% of the project from the backend API to the end user apps that are written in Xamarin and target iOS, Android, and Windows 10 (UWP).

This project is built to run on three Raspberry Pi 3b+ computers.  They are organized as follows:

1. RaspCompute - This module will run the API Backend
2. RaspSQL - This module will run the PostgreSQL Database Server and contain the network share where the captured images are stored
3. RaspClient - This module will run the BirdwatcherIoTClient software and will have a PiCamera, and the following sensors attached: Temperature and a photoresistor.

All three modules are running on the Raspian, and the document contains the instructions on how to install and configure the base image for use in all three.

Instructions on building the BirdWatcher Device can be found in the project's [Wiki](https://github.com/marekt77/BirdWatcher/wiki). 

---

## Installing and Configuring

### Install Raspian

Download the latest image of Raspian from the [Raspberry Pi website](https://www.raspberrypi.org/downloads/raspbian/).
We are looking to use Raspbian Stretch Lite

Once the iso file has downloaded, you will need to transfer it onto an SD card for use in the Raspberry Pi.

If you are using Windows, the quickest and easiest way to do this is to use Rufus, which can be downloaded from [here](https://rufus.ie/).
If you are on Linux or are using a Mac, you can find instructions on how to install the iso on to the SD card [here](https://www.raspberrypi.org/documentation/installation/installing-images/README.md).

I recommend using a decent and fast SD card, with the following sizes based on the role:

Role|SD Size
---|---
RaspCompute|32GB
RaspClient|32GB
RaspSQL|128GB

Once you have written the SD card, and booted up your Raspberry Pi, go ahead an login using the default userID and password in Raspbian:

UserID: `pi`
Password: `raspberry`

### Create New User

`sudo adduser <username>`

### Add User to Sudoers

`sudo visudo`

Find the line root    `ALL=(ALL:ALL) ALL`, under the commented header `#User privilege specification`.

Add this line: `<userid>   ALL=NOPASSWD: ALL`

Log out and log in as new user

### Delete default pi user

`sudo userdel -r pi`

### Setup Networking

`sudo raspi-config`

Configure Local:

1. Set the local to where you are located, in in the US use: en_US.UTF-8 UTF-8
2. Setup hostname
3. Change Time Zone
4. Change Keyboard Layout
5. Change WiFi Country

Finish and Reboot

#### Setup WiFi

Login and edit  wpa-supplicant file:

`sudo nano /etc/wpa_supplicant/wpa_supplicant.conf`

Add the following:

```
network={
    ssid="SchoolNetworkSSID"
    psk="passwordSchool"
    id_str="school"
}
```

If you are using a hidden network use this:

```
network={
    ssid="yourHiddenSSID"
    scan_ssid=1
    psk="Your_wifi_password"
    id_str="school"
}
```

Save the file and exit.

Reboot

Check if network is working:

`ping www.google.com`

### Update OS and Packages

`sudo apt-get update`
`sudo apt-get upgrade`

### Setup Static IP

`sudo nano /etc/dhcpcd.conf`

At the bottom of the file you will need to add settings such as:
Note: Use eth0 for ethernet or wlan0 for wifi

```
	interface eth0
	static ip_address=192.168.2.31/24
	static routers=192.168.2.1
	static domain_name_servers=192.168.2.1 8.8.8.8 4.2.2.1
```

Save and Reboot
	
### Enable SSH access

`sudo raspi-config`

Go to Interfacing Options:

Select P2 SSH

Select Ok

Exit raspi-config

Test by trying to ssh to the Raspberry Pi by going to another computer:

`ssh <userid>@<staticIP you chose>`

If you are able to login everything is working ok.

### Install Python 3 pip:

`sudo apt-get install python3-pip`

The general setup of Raspbian is now complete, you can now move on to the individual sections to configure either the RaspComp, RaspSQL, or RaspClient nodes.

RaspCompute and RaspSQL instructions are found in the README.md file under the BridwatcherBackend directory, and RaspClient instructions are found in the BirdwatcherIoTClient directory.
