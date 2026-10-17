using System;

namespace Lab5_4
{
    class Program
    {
        static long Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }

        static void Main()
        {
            Console.WriteLine("Упражнение 5.4");
            Console.WriteLine("Рекурсивное вычисление факториала.");
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n + "! = " + Factorial(n));
            Console.ReadLine();
        }
    }
}