#include "pch.h"
#include <ranges>
#include <iostream>

using namespace std;
using namespace std::views;
using namespace testing;

TEST(Ranges, single) {
	auto numbers = single(5);
	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(5));
}

TEST(Ranges, itoa) {
	auto numbers = views::iota(1, 5);
	
	auto actual = vector(begin(numbers), end(numbers));
	EXPECT_THAT(actual, ElementsAre(1, 2, 3, 4));
	
	auto numbers2 = views::iota(1) | take(5);
	auto actual2 = vector(begin(common(numbers2)), end(common(numbers2)));

	EXPECT_THAT(actual2, ElementsAre(1, 2, 3, 4, 5));
}

TEST(Ranges, filter) {
	auto numbers = views::iota(1, 10);
	auto odd = numbers | filter([](auto x) { return x % 2 == 1; });
	auto actual = vector(begin(odd), end(odd));

	EXPECT_THAT(actual, ElementsAre(1, 3, 5, 7, 9));
}