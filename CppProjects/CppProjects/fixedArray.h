#pragma once
#include <iostream>
#include <vector>

class fixedVector {

	fixedVector(unsigned int&): size(){}
	~fixedVector() {}

	int& GetElement(unsigned int);
	unsigned int getSize() const;
	

private:
	unsigned int size;
	std::vector<int> fVector;
};