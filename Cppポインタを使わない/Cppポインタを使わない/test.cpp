#include "pch.h"
#include <array>
#include <numeric>
#include <ranges>
#include <iostream>
using namespace std;
using namespace views;




class BigClass {
public:
	int big[120'000] = {0};
};

void Func1(BigClass b) {
	cout << b.big[0];
}

TEST(�|�C���^���g��Ȃ�, ����Ȓl�n��) {
	BigClass b;
	Func1(b);
}

void Func2(BigClass* b) {
	cout << b->big[0];
}

TEST(�|�C���^���g��Ȃ�, ����ȃ|�C���^�n��) {
	BigClass b;
	Func2(&b);
}

void Func3(BigClass& b) {
	cout << b.big[0];
}

TEST(�|�C���^���g��Ȃ�, ����ȎQ�Ɠn��) {
	BigClass b;
	Func3(b);
}

void Func4(vector<int> v) {
	cout << v[0];
}


TEST(�|�C���^���g��Ȃ�, vector�l�n��) {
	vector<int> v;
	v.assign(1'000'000, 1);
	Func4(v);
}

void Func5(vector<int> v) {
	cout << v[0];
}

TEST(�|�C���^���g��Ȃ�, vector�Q�Ɠn��) {
	vector<int> v;
	v.assign(1'000'000, 1);
	Func5(v);
}

TEST(�|�C���^���g��Ȃ�, char������) {
	auto a{ "abcde" };
	char b[6]{ 0 };
	auto p{ b };
	while (*p++ = *a++);

	ASSERT_EQ(0, strcmp(b, "abcde"));
}

TEST(�|�C���^���g��Ȃ�, ������) {
	string a{ "abcde" };
	auto b{ "abcde"s };
	auto c = b;
	ASSERT_TRUE("abcde"s == c);
	
	ASSERT_EQ("bcd"s, "abcde"s.substr(1, 3));
}

TEST(�|�C���^���g��Ȃ�, �z��) {
	int numbers[] { 1, 2, 3, 5, 8, 13, 21, 0 };
	auto p = numbers;
	int sum = 0;
	while(*p)
	{
		sum += *(p++);
	}

	ASSERT_EQ(sum, 1 + 2 + 3 + 5 + 8 + 13 + 21);
}

TEST(�|�C���^���g��Ȃ�, rangedfor) {
	int numbers[]{ 1, 2, 3, 5, 8, 13, 21 };

	auto sum = 0;
	for (auto number : numbers)
	{
		sum += number;
	}

	ASSERT_EQ(sum, 1 + 2 + 3 + 5 + 8 + 13 + 21);
}

TEST(�|�C���^���g��Ȃ�, vector) {
	vector<int> numbers{ 1, 2, 3, 5, 8, 13, 21 };

	auto sum = 0;
	for (auto number : numbers)
	{
		sum += number;
	}

	ASSERT_EQ(sum, 1 + 2 + 3 + 5 + 8 + 13 + 21);
}

TEST(�|�C���^���g��Ȃ�, arr) {
	array<int, 7> numbers { 1, 2, 3, 5, 8, 13, 21 };
	
	auto sum = 0;
	for (auto number : numbers)
	{
		sum += number;
	}

	ASSERT_EQ(sum, 1 + 2 + 3 + 5 + 8 + 13 + 21);
}

TEST(�|�C���^���g��Ȃ�, range) {
	auto numbers =
		views::iota(1, 10) 
		| filter([](auto n) { return n % 2 == 0; })
		| views::transform([](auto n) { return n * n; });
	for (auto number : numbers) {
		cout << number;u
	}
}

TEST(�|�C���^���g��Ȃ�, stl) {
	array<int, 7> numbers{ 1, 2, 3, 5, 8, 13, 21 };

	auto sum = std::accumulate(begin(numbers), end(numbers), 0);

	ASSERT_EQ(sum, 1 + 2 + 3 + 5 + 8 + 13 + 21);
}