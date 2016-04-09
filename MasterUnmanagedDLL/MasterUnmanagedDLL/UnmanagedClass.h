#define DLL_EXPORT __declspec(dllexport)
extern "C" {
	DLL_EXPORT int Multiply(int iA, int iB);

	DLL_EXPORT void Sort(int aiData[], int iLength);
}