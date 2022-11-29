#include <iostream>

void func01()
{
    int a = 5;
}

void func02()
{
    int a = 5;
    int b = a + 3;
}

void func03()
{
    int a = 3;
    int b = 3;
    int c = 3;
    a = 5;
    b = 5;
    c = 5;
}

void func04()
{
    int a = 3;
    int b = 3;
    int c = 3;
    int d = 3;
    int e = 3;
    int f = 3;
    int g = 3;
    int h = 3;
    int i = 3;
}

void func05()
{
    int a[4];
    a[0] = 3;
    a[1] = 3;
    a[2] = 3;
    a[3] = 3;
}

void func06()
{
    int a[4];
    a[1] = 3;
    int b[4];
    b[1] = 3;
}

void func07()
{
    int a[4];
    a[1] = 3;
    int b[5];
    b[1] = 3;
    int c[256];
    c[1] = 3;
    int d[256];
    d[1] = 3;
}

void func08(int a)
{
    int b = a;
}

void func09()
{
    func08(1);
}

int func10()
{
    return 1;
}

void func11()
{
    int a = func10();
}

int func12()
{
    int a = 3;
    int b = a + 5;
    return b;
}

void func13()
{
    int a = func12();
}

int func14()
{
    int a = 3;
    int b = 5;

    if (a < b) {
        return a;
    } 
    else {
        return b;
    }
}

void func15()
{
    int i = 100;
    while (i--) {
        int a = 3;
    }
}

int func16()
{
    int ret = 0;
    for (int i = 0; i < 10; i++) {
        ret += i + 1;
    }
    return ret;
}

void func17()
{
    int a = 3;
    int* p = &a;
    int b = *p;
}

class Class1
{
public:
    int a = 0;
    int b = 0;
};

void func18()
{
    Class1 c;
    int a = c.a;
    int b = c.b;
}

void func19()
{
    Class1* p = new Class1();
    int a = p->a;
    int b = p->b;
}

int main()
{
    func01();
    func02();
    func03();
    func04();
    func05();
    func06();
    func07();
    func09();
    func11();
    func13();
    func14();
    func15();
    func16();
    func17();
    func18();
    func19();
}