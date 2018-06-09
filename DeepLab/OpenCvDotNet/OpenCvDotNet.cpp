// Main OpenCV PInvoke DLL file.
// A lot of this code came from the internet in various
// shapes and sizes. I wrapped the code into a callable dll
// from C#
// Some of the code is dead code from other projects and I did not take
// the time to strip it out. But it maybe used in later versions


#include "stdafx.h"
#include <objbase.h>
#include "OpenCvDotNet.h"
#include "Functions.h"

using namespace cv;
using namespace cv::dnn;

#include <fstream>
#include <iostream>
#include <cstdlib>
using namespace std;

const size_t inWidth = 300;
const size_t inHeight = 300;
const float WHRatio = inWidth / (float)inHeight;
const float inScaleFactor = 0.007843f;
const float meanVal = 127.5;

//Used by SSD code
const char* classNames[] = { "background",
"aeroplane", "bicycle", "bird", "boat",
"bottle", "bus", "car", "cat", "chair",
"cow", "diningtable", "dog", "horse",
"motorbike", "person", "pottedplant",
"sheep", "sofa", "train", "tvmonitor" };


//---------------- Helper Method --------------------------------------------------------
static Mat BitmapToMatX(System::Drawing::Bitmap^ bitmap)
{
	IplImage* tmp;

	System::Drawing::Imaging::BitmapData^ bmData = bitmap->LockBits(System::Drawing::Rectangle(0, 0, bitmap->Width, bitmap->Height), System::Drawing::Imaging::ImageLockMode::ReadWrite, bitmap->PixelFormat);

	if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format8bppIndexed)
	{
		tmp = cvCreateImage(cvSize(bitmap->Width, bitmap->Height), IPL_DEPTH_8U, 1);
		tmp->imageData = (char*)bmData->Scan0.ToPointer();
	}
	else if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format24bppRgb)
	{
		tmp = cvCreateImage(cvSize(bitmap->Width, bitmap->Height), IPL_DEPTH_8U, 3);
		tmp->imageData = (char*)bmData->Scan0.ToPointer();
	}

	bitmap->UnlockBits(bmData);
	return cv::cvarrToMat(tmp);

}
//---------------- Helper Method --------------------------------------------------------
static char* convertToCharBuff(std::string source)
{
	int len = strlen(source.c_str());
	char* buff = (char*)CoTaskMemAlloc(len + 2);
	buff[0] = '\0';
	strcpy(buff, source.c_str());
	return buff;
}

//---------------- Helper Method --------------------------------------------------------
OPENCVDOTNET_API char* ReturnString()
{
	return convertToCharBuff("outputanswer");
}

// ------------------- Main function ----------------------------------------------------
OPENCVDOTNET_API char* DetectObjectsInImage(unsigned char* bytes, int size)
{
	vector<unsigned char> inputImageBytes(bytes, bytes + size);
	Mat img = imdecode(inputImageBytes, CV_LOAD_IMAGE_COLOR);

	std::string result;

	if (img.empty())
	{
		return convertToCharBuff("Can't decode image");
	}

	std::string modelTxt = "MobileNetSSD_deploy.prototxt.txt";
	std::string modelBin = "MobileNetSSD_deploy.caffemodel";

	dnn::Net net = dnn::readNetFromCaffe(modelTxt, modelBin);

	if (net.empty())
	{
		return convertToCharBuff("Can't load model files ");
	}

	//Convert Mat to batch of images
	Mat inputBlob = blobFromImage(img, inScaleFactor, Size(inWidth, inHeight), meanVal, false);

	//set the network input											  
	net.setInput(inputBlob, "data");

	//compute output
	Mat detection = net.forward("detection_out"); //compute output

	std::vector<double> layersTimings;

	Mat detectionMat(detection.size[2], detection.size[3], CV_32F, detection.ptr<float>());

	float confidenceThreshold = 0.0;

	for (int i = 0; i < detectionMat.rows; i++)
	{
		float confidence = detectionMat.at<float>(i, 2);

		if (confidence > confidenceThreshold)
		{
			size_t objectClass = (size_t)(detectionMat.at<float>(i, 1));

			int xLeftBottom = static_cast<int>(detectionMat.at<float>(i, 3) * img.cols);
			int yLeftBottom = static_cast<int>(detectionMat.at<float>(i, 4) * img.rows);
			int xRightTop = static_cast<int>(detectionMat.at<float>(i, 5) * img.cols);
			int yRightTop = static_cast<int>(detectionMat.at<float>(i, 6) * img.rows);

			ostringstream ss;
			ss << confidence;

			result.append("[object ");
			std::string  label = std::string(classNames[objectClass]);
			result.append(label);
			result.append(", confidence= " + ss.str());

			ostringstream dim;
			dim << " , x1= " << xLeftBottom << ", y1= " << yLeftBottom << ", x2=" << xRightTop << ", y2= " << yRightTop;
			result.append(dim.str());
			result.append("] ");

		}
	}

	return convertToCharBuff(result);

}
