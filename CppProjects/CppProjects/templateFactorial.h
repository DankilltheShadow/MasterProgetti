#pragma once



template <unsigned int n>
struct Factorial
{
	enum { value = n * Factorial<n - 1>::value };
};

template <>
struct Factorial<0>
{
	enum { value = 1 };
};