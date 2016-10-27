using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public async void Main()
        {
            var i = await FuncAsync();
        }

        public async Task<int> FuncAsync()
        {
            //いろいろ処理
            await Task.Delay(100);
            int i = 3;
            return i;
        }
    }

    class Program2
    {
        async Task FuncAsync1()
        {
            await Task.Delay(100);
        }

        async Task FuncAsync2()
        {
            await Task.Delay(100);
        }

        async Task FuncAsync3()
        {
            await Task.Delay(100);
        }

        //public async Task FuncAsync()
        //{
        //    await FuncAsync1();
        //    await FuncAsync2();
        //    await FuncAsync3();
        //}

        public Task FuncAsync(dynamic obj)
        {
            if (obj.status == 0) goto end1;
            if (obj.status == 1) goto end2;
            if (obj.status == 2) goto end3;


            var t1 = FuncAsync1();
            obj.t1 = t1;

            return new Task(obj);
            end1:

            var t2 = FuncAsync2();
            obj.t2 = t2;

            return new Task(obj);
            end2:

            var t3 = FuncAsync3();
            obj.t3 = t3;

            return new Task(obj);
            end3:

            return new Task(obj);
        }

public Task FuncAsync(dynamic obj)
{
    switch (obj.status)
    {

        case 0:
            var t1 = FuncAsync1();
            obj.t1 = t1;

            return new Task(obj);
        case 1:


            var t2 = FuncAsync2();
            obj.t2 = t2;

            return new Task(obj);
        case 2:

            var t3 = FuncAsync3();
            obj.t3 = t3;

            return new Task(obj);
        case 3:

            return new Task(obj);
    }
}
    }
}
