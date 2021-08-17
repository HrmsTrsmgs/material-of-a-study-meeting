using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQのサンプル
{
    public class Person
    {
        public int Id { get; init; }

        public string FirstName { get; init; } = "";

        public string? MiddleName { get; init; }
        public string LastName { get; init; } = "";
        public int YearOfBirth { get; init; }

        public override string ToString() =>
            $"{FirstName} {(MiddleName == null ? MiddleName + " " : "")}{LastName}";
    }
}
