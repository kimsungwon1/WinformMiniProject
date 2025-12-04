#include "ImageFilters.h"
#include "pch.h"
#include <opencv2/opencv.hpp>
#include <iostream>
#include <cstdlib>
#include <vector>

using namespace cv;
using namespace std;

_declspec(dllexport) void GetGaussianBluredImage(unsigned char* cArrImageData, unsigned char* cArrOutputData, int nHeight, int nWidth, int nMemLen)
{
	std::vector<unsigned char> buf(cArrImageData, cArrImageData + nMemLen);
	cv::Mat matMade(nHeight, nWidth, CV_8UC3, cArrImageData);

	cv::Mat dst = cv::Mat(nHeight, nWidth, CV_8UC3);
	cv::GaussianBlur(matMade, dst, Size(7, 7), 0);
	
	memcpy(cArrOutputData, dst.data, dst.total() * dst.elemSize());
}
