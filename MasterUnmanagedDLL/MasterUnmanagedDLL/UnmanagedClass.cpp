#include "UnmanagedClass.h"
#include <algorithm>

extern "C" {
	DLL_EXPORT int Multiply(int iA, int iB)
{
	return iA * iB;
}
	DLL_EXPORT void Sort(int aiData[], int iLength)
	{
		std::sort(aiData, aiData + iLength);
	}
}
