// �e���v���[�g.cpp : �R���\�[�� �A�v���P�[�V�����̃G���g�� �|�C���g���`���܂��B
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
		// �ȗ�
	}
	~my_vector()
	{
		// �ȗ�
	}
	T operator[](size_t n)
	{
		// �ȗ�
	}
	void push_back(T t)
	{
		// �ȗ�
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

