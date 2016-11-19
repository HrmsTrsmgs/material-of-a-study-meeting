// アセンブリ言語見てみる.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

int func1()
{
	return 0;
}

int func2()
{
	return 42;
}

void func3()
{
	int i = 3;
	if (i < 3) {
		i = 5;
	}
}

void func4()
{
	int i = 3;
	while (i < 5) {
		i++;
	}
}
void func5()
{
	for (int i = 0; i < 5; i++) {

	}
}

void func6() 
{
	int i = 3;
	switch (i) {
	case 1:
		i = 5;
	case 2:
		i = 7;
	case 3:
		i = 8;
	default:
		i = 10;
	}
}



int main()
{
	func1();
	func2();
	func3();
	func4();
	func5();
	func6();
    return 0;
}

