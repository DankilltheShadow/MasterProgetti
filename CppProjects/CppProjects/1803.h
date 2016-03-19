#pragma once


class BaseObj
{
public:
protected: BaseObj();
	~BaseObj();

public:
	static BaseObj* Create(int classId) {
		Register::
	}

private:

};

Class DerivedObj : public BaseObj{

}

class Register
{
private:
	Register& Register() {
		static Register instance;
		return instance;
	}
	Register(Register& other) = delete;

public:
	typedef BaseObj* (*ptr2Create) ();
	typedef std::map<int, ptr2Create>:iterator creatorsIter;

	void RegisterCreate(int id, ptr2Create createPtr) {
		creatorsIter[id] = createPtr;
	}

	ptr2Create GetCreate(int id) {
		creatorsIter it = creators.find(id);
		if (it != creator.end()) {
			return creatorIter[id];
		}
		else {
			return nullptr;
		}
	}

private:
	std::map<int, ptr2Create> creators;
};
