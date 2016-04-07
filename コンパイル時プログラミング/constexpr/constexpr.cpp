// constexpr.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

constexpr unsigned int Fibonacci(unsigned int n)
{
	return
		n <= 1 ? 1
		: Fibonacci(n - 1) + Fibonacci(n - 2);
}

unsigned int F1()
{
	return Fibonacci(1);
}

unsigned int F2()
{
	return Fibonacci(2);
}

unsigned int F3()
{
	return Fibonacci(3);
}

unsigned int F4()
{
	return Fibonacci(4);
}

unsigned int F5()
{
	return Fibonacci(5);
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

