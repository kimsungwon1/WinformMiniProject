#pragma once
#include <opencv/cv.hpp>
#include <string>

extern "C" __declspec(dllexport) /*__stdcall*/ void GetGaussianBluredImage(char* cArrImageData, char* cArrOutputData, int nHeight, int nWidth, int nMemLen);