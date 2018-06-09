# Open CV  3.4 Unity 3D Tensorflow/Caffe Project

This project consists of two folders:
	Unity Project:
	A Unity 3D environment (2017.3.1) I use to do object detection using pre-compiled OpenCVDotNet wrapper dll
	
	DeepLab:
	C++ and Winform projects used to compile and test loading a Caffe MobileNet SSD model to do opject detection
	
Prerequisites:
	Windows 10 Home
	Visual Studio 2017 Community ( you maybe able to try 2015 as well)
	.Net framework 4.6 or above
	Unity 2017 3.1 or above
	Have the ability of compiling C++ projects/SDKs and such

	
Installation:
Download and install Open CV 3.4 into a directory eg. "C:\Open CV 3.4"
Create environment variable %OPEN_CV_3_4% which points to "C:\Open CV 3.4\opencv"
Download this project zip or do git clone

 
Compile:
Load "DeepLab\OpenCvDotNet.sln"
Right click OpenCVDotNet project and try and compile
If that works ..... YAY !!!!!!!!!
Then try and run WinformProject

You should see a Window and a button to detect objects, click this and select a jpg that i have copied into you build directory

If the picture box loads and the test box fills up with detections, you are done !!!!!!!

Integration with Unity:
The Unity project provided should already have the models and labels files and dlls to do object detection. You can just
copy your "OpenCVDotNet" dll over existing one after compiling if you are brave enough to make changes.
Take a look in the unity main folder to find the original DLL 






Have fun !!!! and keep in mind I have a day job ;)


