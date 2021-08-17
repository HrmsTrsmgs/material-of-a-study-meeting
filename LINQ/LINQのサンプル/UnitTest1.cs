using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace LINQのサンプル
{
    public class UnitTest1
    {
        ITestOutputHelper output { get; }

        static Context context { get; } = new();

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
            context.Database.EnsureCreated();

            context.RemoveRange(context.People.ToArray());

            context.RemoveRange(context.ProgramLanuages.ToArray());

            context.AddRange(Languages);
            context.SaveChanges();
        }


        [Fact]
        public void 基本()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result =
                from number in numbers
                where number % 2 == 0
                select number * 2;

            foreach(var number in result)
            {
                output.WriteLine(number.ToString());
            }
        }

        ProgramLanuage[] Languages { get; } = new[] {
            new ProgramLanuage
            {
                Name = "C",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Dennis",
                        MiddleName = "MacAlistair",
                        LastName = "Ritchie",
                        YearOfBirth = 1941,
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "Python",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Guido",
                        MiddleName = "van",
                        LastName = "Rossum",
                        YearOfBirth = 1956,
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "Java",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "James",
                        MiddleName = "Arthur",
                        LastName = "Gosling",
                        YearOfBirth = 1955
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "C++",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Bjarne",
                        LastName = "Stroustrup",
                        YearOfBirth = 1950
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "C#",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Anders",
                        LastName = "Hejlsberg",
                        YearOfBirth = 1960
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "Visual Basic",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Alan",
                        LastName = "Cooper",
                        YearOfBirth = 1952
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "JavaScript",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Brendan",
                        LastName = "Eich",
                        YearOfBirth = 1961
                    }
                }
            },
            new ProgramLanuage
            {
                Name = "PHP",
                Creaters = new[]
                {
                    new Person
                    {
                        FirstName = "Rasmus",
                        LastName = "Lerdorf",
                        YearOfBirth = 1968
                    }
                }
            }
        };


        IEnumerable<Person> TestData =>
            from language in Languages
            from creater in language.Creaters
            select creater;



        [Fact]
        public void Where()
        {
            var result =
                from person in TestData
                where person.FirstName.StartsWith("A")
                select new { person.FirstName, person.LastName };

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void メソッド構文()
        {
            //var result =
            //    from person in TestData
            //    where person.FirstName.StartsWith("A")
            //    select new { person.FirstName, person.LastName };

            var result =
                TestData
                .Where(person => person.FirstName.StartsWith("A"))
                .Select(person => new { person.FirstName, person.LastName });
            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void 集計()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result =
                from number in numbers
                where number % 2 == 0
                select number * 2;

            foreach (var number in result)
            {
                output.WriteLine(number.ToString());
            }

            var array = result.ToArray();

            Assert.Throws<InvalidOperationException>(
                () => result.Single());

            var first = result.FirstOrDefault();
            var last = result.Last();
            var max = result.Max();
            var ave = result.Average();

        }

        [Fact]
        public void OrderBy()
        {

            var result =
                from person in TestData
                orderby person.FirstName, person.LastName descending
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void SelectMany()
        {
            var result =
                from language in Languages
                from creater in language.Creaters
                select creater;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void Let()
        {
            var result =
                from person in TestData
                let initial = person.FirstName.Substring(0, 1) + person.LastName.Substring(0, 1)
                where new[] { "DR", "JG", "AH" }.Contains(initial)
                orderby initial
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void Sub()
        {
            var result =
                from person in TestData
                where person.FirstName.Substring(0, 1) == (
                    from subPerson in TestData
                    select subPerson.FirstName.Substring(0, 1)
                ).Max()
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void GroupBy()
        {
            var result =
                from person in TestData
                orderby person.FirstName, person.LastName descending
                group person by person.FirstName.Substring(0, 1) into g
                select g;

            foreach (var group in result)
            {
                foreach (var person in group)
                {
                    output.WriteLine(person.ToString());
                }
            }
        }

        [Fact]
        public void DbWhere()
        {
            var result =
                from person in context.People
                where person.FirstName.StartsWith("A")
                select new { person.FirstName, person.LastName };

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void DbOrderBy()
        {
            var result =
                from person in context.People
                orderby person.FirstName, person.LastName descending
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void DbSelectMany()
        {
            var result =
                from language in context.ProgramLanuages
                from creater in language.Creaters
                select creater;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void DbLet()
        {
            var result =
                from person in context.People
                let initial = person.FirstName.Substring(0, 1) + person.LastName.Substring(0, 1)
                where new[] { "DR", "JG", "AH" }.Contains(initial)
                orderby initial
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

        [Fact]
        public void DbSub()
        {
            var result =
                from person in context.People
                where person.FirstName.Substring(0, 1) == (
                    from subPerson in context.People
                    select subPerson.FirstName.Substring(0, 1)
                ).Max()
                select person;

            foreach (var person in result)
            {
                output.WriteLine(person.ToString());
            }
        }

    }
}
