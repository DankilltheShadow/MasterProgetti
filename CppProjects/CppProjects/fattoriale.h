#pragma once

#include <assert.h> 


long recursiveFactorial(int recurredNumber)
{
	assert(recurredNumber >= 0);

	long retValue = 1;
	if (recurredNumber > 1) {
		retValue = recurredNumber*recursiveFactorial(recurredNumber - 1);
	}

	return retValue;
}

long iterativeFactorial(int recurredNumber) {
	assert(recurredNumber >= 0);

	long risFatt = 1;

	for (int iterator = recurredNumber; iterator > 1; --iterator) {
		risFatt *= iterator;
	}

	return risFatt;
}