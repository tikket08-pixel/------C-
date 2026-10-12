using System;

int a = 5;
int b = 10;

Console.WriteLine($"До обмена: a = {a}, b = {b}");

Swap(ref a, ref b);

Console.WriteLine($"После обмена: a = {a}, b = {b}");

void Swap(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}