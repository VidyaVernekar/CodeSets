// See https://aka.ms/new-console-template for more information
using MathLibrary;

Console.WriteLine("Hello, World!");

int a = 0;
int b = 0;
int c = 0;
Console.WriteLine("Enter A");
a = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter B");
b = Convert.ToInt32(Console.ReadLine());
Basic basic = new Basic();
c = basic.Add(a,b);
Console.WriteLine(c);
