#include <iostream>
#include <stdlib.h>
//#include "factory.h"
#define N_BIT_IN_BYTE 8

void main() {


	int a = 1;
	int b = 2000000000;

	int res = std::abs(a - b >> (sizeof(int) * N_BIT_IN_BYTE-1));
	std::cout << res <<std::endl;
	int c = a * (res) + b * (1 - res);

	std::cout << c;
	system("pause");
}