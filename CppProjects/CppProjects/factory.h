#pragma once
#include <string>
#include <map>

typedef Product*(*ptrCreate)();

class Factory
{
private:
	Factory() {};

	static std::map<int, ptrCreate> ProductIdMap;
public:
	static Factory& getInstance()
	{
		static Factory instance;

		return instance;
	}

	Factory(Factory const&) = delete;
	void operator=(Factory const&) = delete;

	virtual Factory* Create(int id) {
		if (ProductIdMap.count(id) == 0) {
			return nullptr;
		}
		else {
			return ProductIdMap[id]();
		}
	};
	virtual Factory* Register(int id, ptrCreate p) {
		ProductIdMap[id] = p;
	};
};

class Product {
public:
	virtual Product* Create() = 0;
};

class ProductOne : public Product {
public:
	static const int id = 1;
	virtual Product* Create() {
		return new ProductOne;
	}
};

