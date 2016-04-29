#pragma once
#include <iostream>
#include <functional>
#include <string>

class listOfRecord{
public:
	struct Record {
		std::hash <int> hash;
		Record *next;
		bool valid;
	};
	
	Record& getByIndex(unsigned char);
	bool isValid(unsigned char) const;
	void setRecord(const Record&, unsigned char);
	
};