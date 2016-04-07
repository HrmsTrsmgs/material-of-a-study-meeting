// テンプレートメタプログラミング.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

template<unsigned int N>
struct Fibonacci
{
	enum Const : unsigned int
	{
		Value = Fibonacci<N - 1>::Value + Fibonacci<N - 2>::Value
	};
};

template<>
struct Fibonacci<0>
{
	enum Const : unsigned int
	{
		Value = 1
	};
};

template<>
struct Fibonacci<1>
{
	enum Const : unsigned int
	{
		Value = 1
	};
};

unsigned int F1()
{
	return Fibonacci<1>::Value;
}

unsigned int F2()
{
	return Fibonacci<2>::Value;
}

unsigned int F3()
{
	return Fibonacci<3>::Value;
}

unsigned int F4()
{
	return Fibonacci<4>::Value;
}

unsigned int F5()
{
	return Fibonacci<5>::Value;
}

int main()
{
	auto a1 = F1();
	auto a2 = F2();
	auto a3 = F3();
	auto a4 = F4();
	auto a5 = F5();

    return 0;
}

