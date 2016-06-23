using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicのList
{
    static class ListExtensions
    {
        public static void AddExpando(this IList<dynamic> self, int count)
        {
            for(int i = 0; i < count; ++i)
            {
                self.AddExpando();
            }
        }

        public static void AddExpando(this IList<dynamic> self)
        {
            self.Add(new ExpandoObject());
        }
    }
}
