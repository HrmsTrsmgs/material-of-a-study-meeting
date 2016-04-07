// テンプレート.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

template<class T>
class my_vector
{
	size_t m_size = 0;
	T *m_value = nullptr;
public:
	my_vector()
	{
		// 省略
	}
	~my_vector()
	{
		// 省略
	}
	T operator[](size_t n)
	{
		// 省略
	}
	void push_back(T t)
	{
		// 省略
	}
};

template<class T, size_t>
class my_array
{};

int main()
{
	my_vector<int> is;
	my_vector<double> ds;

	my_array<int, 5> a;
    return 0;
}

