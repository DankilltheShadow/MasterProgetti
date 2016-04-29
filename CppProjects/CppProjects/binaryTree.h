#pragma once
#include <stack>
#include <iostream>
#include <queue>

class BinaryTreeComponent
{
	

public:
	BinaryTreeComponent(int v) : value(v) {}
	~BinaryTreeComponent();

private:
	int value;
};

BinaryTreeComponent::~BinaryTreeComponent()
{
}

struct Node {
	int value;
	Node* leftChildren;
	Node* rightChildren;
};

class BinaryTree
{
public:
	BinaryTree();
	~BinaryTree();

	void InsertNode(int);
	void InOrder();
	void PreOrder();
	void PostOrder();
	void BreadthFirst();

private:
	Node* Root;
};

BinaryTree::BinaryTree()
{
	Root = nullptr;
}

BinaryTree::~BinaryTree()
{
}

void BinaryTree::InsertNode(int value)
{
	Node* tmpPtr = Root;
	while (tmpPtr != nullptr)
	{
		if (tmpPtr->value > value) {
			tmpPtr = tmpPtr->leftChildren;
		}
		else
		{
			tmpPtr = tmpPtr->rightChildren;
		}
	}
	tmpPtr = new Node();
	tmpPtr->value = value;
}

void BinaryTree::InOrder() {
	std::stack<Node*> nodeStack;
	Node *tmpNode = Root;
	while (!nodeStack.empty() || tmpNode != nullptr) {
		if (tmpNode != nullptr) {
			nodeStack.push(tmpNode);
			tmpNode = tmpNode->leftChildren;
		}
		else {
			tmpNode = nodeStack.top();
			nodeStack.pop();
			std::cout << tmpNode->value << " ";
			tmpNode = tmpNode->rightChildren;
		}
	}
}

void BinaryTree::PreOrder()
{
	if (Root == nullptr)
		return;

	std::stack<Node*> nodeStack;
	nodeStack.push(Root);

	while (!nodeStack.empty())
	{
		Node* tmpNode = nodeStack.top();
		std::cout << tmpNode->value << " ";
		nodeStack.pop();

		if (tmpNode->rightChildren != nullptr)
			nodeStack.push(tmpNode->rightChildren);
		if (tmpNode->leftChildren != nullptr)
			nodeStack.push(tmpNode->leftChildren);
	}
}

void BinaryTree::PostOrder()
{
	if (Root == nullptr)
		return;

	std::stack<Node*> nodeStack;
	std::stack<Node*> output;
	nodeStack.push(Root);

	while (!nodeStack.empty()) {
		Node *currNode = nodeStack.top();
		output.push(currNode);
		nodeStack.pop();
		if (currNode->leftChildren)
			nodeStack.push(currNode->leftChildren);
		if (currNode->rightChildren)
			nodeStack.push(currNode->rightChildren);
	}
	while (!output.empty()) {
		std::cout << output.top()->value << " ";
		output.pop();
	}
}

void BinaryTree::BreadthFirst()
{
	if (Root == nullptr)
		return;

	std::queue<Node*> nodeQueue;
	nodeQueue.push(Root);


	while (!nodeQueue.empty()) {
		Node *currNode = nodeQueue.front();
		std::cout << currNode->value << " ";
		nodeQueue.pop();

		if (currNode->leftChildren != nullptr)
			nodeQueue.push(currNode->leftChildren);
		if (currNode->rightChildren != nullptr)
			nodeQueue.push(currNode->rightChildren);
	}
}
