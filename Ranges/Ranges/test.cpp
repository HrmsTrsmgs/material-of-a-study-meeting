#include <ranges>
#include <iostream>

#include "gmock/gmock.h"
#include "gtest/gtest.h"

using namespace std;
using namespace std::views;
using namespace testing;

TEST(Ranges, single) {
	auto numbers = single(5);
	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(5));
}

TEST(Ranges, iota) {
	auto numbers = views::iota(1, 5);
	
	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(1, 2, 3, 4));
	
	auto numbers2 = views::iota(1) | take(5);

	auto actual2 = vector(begin(common(numbers2)), end(common(numbers2)));

	EXPECT_THAT(actual2, ElementsAre(1, 2, 3, 4, 5));
}

TEST(Ranges, filter) {
	
	auto numbers = 
		views::iota(1, 10) 
		| filter([](auto x) { return x % 2 == 1; });

	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(1, 3, 5, 7, 9));
}

TEST(Ranges, transform) {

	auto numbers = 
		views::iota(1, 6) 
		| views::transform([](auto x) { return x % 2 == 1; });

	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(true, false, true, false, true));
}

TEST(Ranges, take) {
	auto numbers = 
		views::iota(1) 
		| take(6);;

	auto actual = vector(begin(common(numbers)), end(common(numbers)));

	EXPECT_THAT(actual, ElementsAre(1, 2, 3, 4, 5, 6));
}

TEST(Ranges, take_while) {
	auto numbers =
		views::iota(1)
		| take_while([](auto x) {return x < 6; });

	auto actual = vector(begin(common(numbers)), end(common(numbers)));

	EXPECT_THAT(actual, ElementsAre(1, 2, 3, 4, 5));
}

TEST(Ranges, drop) {
	auto numbers =
		views::iota(1)
		| drop(5)
		| take(6);

	auto actual = vector(common(numbers).begin(), common(numbers).end());

	EXPECT_THAT(actual, ElementsAre(6, 7, 8, 9, 10, 11));
}

TEST(Ranges, drop_while) {
	auto numbers =
		views::iota(1)
		| drop_while([](auto x) {return x < 6; })
		| take(5);

	auto actual = vector(common(numbers).begin(), common(numbers).end());

	EXPECT_THAT(actual, ElementsAre(6, 7, 8, 9, 10));
}

TEST(Ranges, join) {
	vector<vector<int>> listlist{ {1, 2}, {3, 4, 5}, {6} };
	auto numbers = listlist | join;

	auto actual = vector(begin(numbers), end(numbers));

	EXPECT_THAT(actual, ElementsAre(1, 2, 3, 4, 5, 6));
}