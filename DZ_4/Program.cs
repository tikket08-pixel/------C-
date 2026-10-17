using System;

Console.WriteLine("Введите число:");
int n = int.Parse(Console.ReadLine());

long result;
bool ok = FactorialOut(n, out result);

if (ok)
    Console.WriteLine($"Факториал {n} = {result}");
else
    Console.WriteLine("Переполнение!");

bool FactorialOut(int n, out long result)
{
    result = 1;
    try
    {
        checked
        {
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
        }
        return true;
    }
    catch (OverflowException)
    {
        result = 0;
        return false;
    }
}
