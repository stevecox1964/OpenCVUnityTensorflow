// OpenCvDotNet.h

#pragma once

#include <opencv\cv.h>
#include <opencv\highgui.h>

using namespace System;


#define OPENCVDOTNET_API __declspec(dllexport)

extern "C"
{
	//This is where are PInvoke calls originate
	OPENCVDOTNET_API char* DetectObjectsInImage(unsigned char* bytes, int size);
	OPENCVDOTNET_API char* ReturnString();
}
