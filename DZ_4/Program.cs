using System;

namespace Lab5
{
    enum Grumpiness { Низкий, Средний, Высокий, ОченьВысокий }

    struct Ded
    {
        public string name;
        public Grumpiness level;
        public string[] phrases;
        public int bruises;

        public Ded(string n, Grumpiness l, string[] ph)
        {
            name = n;
            level = l;
            phrases = ph;
            bruises = 0;
        }

        public static int GetBruises(ref Ded d, params string[] swear)
        {
            int count = 0;
            for (int i = 0; i < d.phrases.Length; i++)
            {
                for (int j = 0; j < swear.Length; j++)
                {
                    if (d.phrases[i].Contains(swear[j]))
                    {
                        count++;
                        break;
                    }
                }
            }
            d.bruises = d.bruises + count;
            return count;
        }
    }

    class Program
    {
        static long Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }

        static long Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static long ArraySum(params int[] arr)
        {
            long sum = 0;
            for (int i = 0; i < arr.Length; i++) sum = sum + arr[i];
            return sum;
        }

        static void ArrayProduct(ref int[] arr, out long product)
        {
            product = 1;
            for (int i = 0; i < arr.Length; i++) product = product * arr[i];
        }

        static void ArrayAverage(int[] arr, out double avg)
        {
            long sum = 0;
            for (int i = 0; i < arr.Length; i++) sum = sum + arr[i];
            avg = (double)sum / arr.Length;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine();
            Console.WriteLine("Упражнение 5.4");
            Console.WriteLine("Рекурсивное вычисление факториала.");
            Console.Write("Введите n: ");
            int fn = int.Parse(Console.ReadLine());
            Console.WriteLine(fn + "! = " + Factorial(fn));

            Console.WriteLine();
            Console.WriteLine("Домашнее задание 5.1");
            Console.WriteLine("НОД двух и трёх натуральных чисел.");
            Console.Write("Введите a и b через пробел: ");
            string[] p = Console.ReadLine().Split(' ');
            int a1 = int.Parse(p[0]);
            int b1 = int.Parse(p[1]);
            Console.WriteLine("НОД(" + a1 + ", " + b1 + ") = " + GCD(a1, b1));

            Console.Write("Введите a, b, c через пробел: ");
            p = Console.ReadLine().Split(' ');
            int a2 = int.Parse(p[0]);
            int b2 = int.Parse(p[1]);
            int c2 = int.Parse(p[2]);
            Console.WriteLine("НОД(" + a2 + ", " + b2 + ", " + c2 + ") = " + GCD(a2, b2, c2));

            Console.WriteLine();
            Console.WriteLine("Домашнее задание 5.2");
            Console.WriteLine("Рекурсивное n-е число Фибоначчи.");
            Console.Write("Введите n: ");
            int fibN = int.Parse(Console.ReadLine());
            Console.WriteLine("F(" + fibN + ") = " + Fibonacci(fibN));

            Console.WriteLine();
            Console.WriteLine("Задача 1");
            Console.WriteLine("Массив из 20 случайных чисел, поменять два элемента местами.");
            int[] arr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Введите два индекса (0-19): ");
            p = Console.ReadLine().Split(' ');
            int i1 = int.Parse(p[0]);
            int i2 = int.Parse(p[1]);
            int temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
            Console.WriteLine("Массив после обмена:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Задача 2");
            Console.WriteLine("Демонстрация params, ref, out.");
            int[] nums = { 2, 3, 4, 5 };
            Console.Write("Массив: ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Сумма (params): " + ArraySum(nums));
            long prod;
            ArrayProduct(ref nums, out prod);
            Console.WriteLine("Произведение (ref/out): " + prod);
            double avg;
            ArrayAverage(nums, out avg);
            Console.WriteLine("Среднее арифметическое (out): " + avg);

            Console.WriteLine();
            Console.WriteLine("Задача 4");
            Console.WriteLine("Структура Дед: подсчёт фингалов от бабки.");
            DedTask();

            Console.WriteLine();
            Console.WriteLine("Задача 3");
            Console.WriteLine("Рисование цифры (0-9) символом #. Для выхода введите exit или закрыть.");
            DrawDigitTask();
        }

        static void DrawDigitTask()
        {
            string[,] patterns = new string[10, 5]
            {
                { 
                  "###", 
                  "# #", 
                  "# #",
                  "# #", 
                  "###" 
                },
                { 
                  "  #", 
                  "  #",
                  "  #", 
                  "  #", 
                  "  #" 
                },
                { 
                  "###", 
                  "  #", 
                  "###", 
                  "#  ", 
                  "###" 
                },
                {
                  "###", 
                  "  #", 
                  "###", 
                  "  #", 
                  "###" 
                },
                { "# #",
                  "# #", 
                  "###", 
                  "  #", 
                  "  #" 
                },
                { 
                    "###", 
                    "#  ", 
                    "###", 
                    "  #", 
                    "###" 
                },
                { 
                    "###", 
                    "#  ", 
                    "###", 
                    "# #", 
                    "###" 
                },
                { 
                    "###", 
                    "  #", 
                    "  #", 
                    "  #", 
                    "  #" 
                },
                { 
                    "###", 
                    "# #", 
                    "###", 
                    "# #", 
                    "###" 
                },
                { 
                    "###", 
                    "# #", 
                    "###", 
                    "  #", 
                    "###" 
                }
            };

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "exit" || input == "закрыть")
                {
                    Console.WriteLine("Выход из программы...");
                    Environment.Exit(0);
                }

                int number = int.Parse(input);

                if (number < 0 || number > 9)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9!");
                    System.Threading.Thread.Sleep(3000);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Цифра " + number + ":");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(patterns[number, i]);
                    }
                }
            }
        }

        static void DedTask()
        {
            Ded[] grandfathers = new Ded[5];
            grandfathers[0] = new Ded("Иван", Grumpiness.Низкий, new string[] { "Проститутки!" });
            grandfathers[1] = new Ded("Пётр", Grumpiness.Средний, new string[] { "Гады!", "Проститутки!" });
            grandfathers[2] = new Ded("Сидор", Grumpiness.Высокий, new string[] { "Гады!", "Паразиты!", "Проститутки!" });
            grandfathers[3] = new Ded("Николай", Grumpiness.ОченьВысокий, new string[] { "Проститутки!", "Гады!", "Паразиты!", "Мерзавцы!" });
            grandfathers[4] = new Ded("Василий", Grumpiness.Средний, new string[] { "Паразиты!", "Мерзавцы!" });

            string[] swearWords = { "Проститутки!", "Гады!", "Паразиты!" };
            Console.Write("Список матерных слов: ");
            for (int i = 0; i < swearWords.Length; i++)
            {
                Console.Write(swearWords[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < grandfathers.Length; i++)
            {
                int b = Ded.GetBruises(ref grandfathers[i], swearWords);
                Console.WriteLine("Дед: " + grandfathers[i].name + " (ворчливость: " + grandfathers[i].level + ")");
                Console.Write("  Фразы: ");
                for (int j = 0; j < grandfathers[i].phrases.Length; j++)
                {
                    Console.Write(grandfathers[i].phrases[j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("  Фингалов от бабки: " + b);
                Console.WriteLine();
            }
        }
    }
}