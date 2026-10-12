
High_Number();

void High_Number()

{
    Console.WriteLine("введите числа:");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    if (a > b)
    {
      Console.WriteLine($"наибольшее число:{a}");
        return;
    }
    else
    {
        Console.WriteLine($"наибольшее число:{b}");
        return;
    }
}