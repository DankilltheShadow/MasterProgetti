#pragma once

#define DLL_EXPORT __declspec(dllexport)

extern "C" {
	DLL_EXPORT void FillArray(int[], int, int, int);
}