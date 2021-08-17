using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQのサンプル
{
    public class ProgramLanuage
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";

        public IEnumerable<Person> Creaters { get; init; } = new List<Person> { };
    }
}
