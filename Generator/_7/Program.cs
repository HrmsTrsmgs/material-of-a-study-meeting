using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static IEnumerable<int> GetNumbers()
        {
            return new _GetNumbsers();
        }

        static void Main(string[] args)
        {
            foreach (var i in GetNumbers())
            {
                Console.WriteLine(i);
            }
        }

        class _GetNumbsers : IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                return new _GetNumbersEnumrator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        class _GetNumbersEnumrator : IEnumerator<int>
        {
            int status = 0;
            public int Current { get; private set; } = 0;

            public bool MoveNext()
            {
                switch (status)
                {
                    case 0:
                        status = 1;
                        Current = 1;
                        return true;
                    case 1:
                        status = 2;
                        Current = 3;
                        return true;
                    case 2:
                        status = 3;
                        Current = 6;
                        return true;
                    default:
                        status = 4;
                        return false;
                }
            }

            public void Dispose()
            {
                status = 3;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator.Current { get { return Current; } }
        }
    }
}
