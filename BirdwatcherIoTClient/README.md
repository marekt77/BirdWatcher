# Birdwatcher IoT Client - BirdWatcher

### Enable Camera

`sudo raspi-config`

Go to interface options, and enable the PiCamera interface.  Save and Exit.

### Install Tensorflow

Enter the following command:

`sudo pip3 install tensorflow`

If that does not work you can download the wheel file manually:

`mkdir tf`
`cd tf`

Go [here](https://github.com/lhelontra/tensorflow-on-arm/releases)

Download the latest version.  (As of this writing I was using version 13)

`wget https://github.com/lhelontra/tensorflow-on-arm/releases/download/v1.13.1/tensorflow-1.13.1-cp35-none-linux_armv7l.whl`

Then run the installer:

`sudo pip3 install ~/tf/tensorflow-1.13.1-cp35-none-linux_armv7l.whl`

### Install Object Detection Dependencies:

`sudo pip3 install pillow lxml jupyter matplotlib cython contextlib2`

### Install OpenCV:

`sudo apt-get install libjpeg-dev libtiff5-dev libjasper-dev libpng12-dev`

`sudo apt-get install libavcodec-dev libavformat-dev libswscale-dev libv4l-dev`

`sudo apt-get install libxvidcore-dev libx264-dev`

`sudo apt-get install qt4-dev-tools`

`pip3 install opencv-python` 

### Compile and Install Protobuf

*verify that this works: `sudo apt install python3-protobuf`

Sice there is no Protobuf package available for the Raspberry Pi, we have to download and compile it from the source manually.

First, we need to get the packages needed to compile Protobuf from the source:

`sudo apt-get install autoconf automake libtool curl`

Next, we download the protobuf source code:
*(As of this writing the latest version was: 3.8.0)*

`wget https://github.com/protocolbuffers/protobuf/releases/download/v3.8.0/protobuf-all-3.8.0.tar.gz`

Unpack the archive:

`tar -zxvf protobuf-all-3.8.0.tar.gz`

Now go into the directory where the files unpacked:

`cd protobuf-3.8.0`

Configure the build:

`./configure`

We will not build the package.  **Note: This step will take a LONG time to complete.  About 60min or so.**

`make`

Once that step is complete, run:  **Note: This step will take longer than the previosus one.**

`make check`

**Note: There maybe some errors during this process.  Most likely everything is fine and protobuf will still run.

Next we issue the following:

`sudo make install`

Now move into the python directory and export the library path:

`cd python`
`export LD_LIBRARY_PATH=../src/.libs`

Then run the following:

`python3 setup.py build --cpp_implementation`

`python3 setup.py test --cpp_implementation`

`sudo python3 setup.py install --cpp_implementation`

Now issue the following PATH commands:

`export PROTOCOL_BUFFERS_PYTHON_IMPLEMENTATION=cpp`

`export PROTOCOL_BUFFERS_PYTHON_IMPLEMENTATION_VERSION=3`

Finally run:

`sudo ldconfig`

We are done!  Protobuf should be installed on your raspberry pi.  Verify that it is working by running:

`protoc`

### Setup the Tensorflow Directory Structure and PYTHONPATH Variable

Create the `Tensorflow` directory in your home directory, from where the BirdWatcher App will run and Live.  In your home directory type: **Note: I chose tensorflow13 because that is the version of tensorflow that this project was built to support**

`mkdir tensorflow13`

`cd tensorflow13`

Now we are going to download the tensorflow models repository from GitHub:

`git clone --recurse-submodules https://github.com/tensorflow/models.git`
