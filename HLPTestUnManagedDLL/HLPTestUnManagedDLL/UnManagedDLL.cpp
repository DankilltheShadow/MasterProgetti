#include "UnManagedDLL.h"
#include <stdlib.h>

extern "C" {
	DLL_EXPORT void FillArray(int iaArray[], int iSize, int iMinValue = 0, int iMaxValue = 10)
	{
		for (int _iIterator = 0; _iIterator < iSize; ++_iIterator) {
			iaArray[_iIterator] = rand() % iMaxValue + iMinValue;
		}
	}
}