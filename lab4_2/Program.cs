using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding =
            System.Text.Encoding.UTF8;

        double x = ReadDouble("Начало отрезка X: ");
        double y = ReadDouble("Конец отрезка Y: ");

        LineSegment line = new LineSegment(x, y);

        Console.WriteLine();
        Console.WriteLine("ЗАДАНИЕ 6");
        Console.WriteLine("Отрезок: " + line);

        double number = ReadDouble(
            "Число для проверки: ");

        Console.WriteLine(
            "Результат: " + line.Contains(number));

        Console.WriteLine();
        Console.WriteLine("ЗАДАНИЕ 7");

        Console.WriteLine("Длина: " + !line);

        LineSegment copy = line;
        copy++;

        Console.WriteLine("После ++: " + copy);
        Console.WriteLine("(int): " + (int)line);
        Console.WriteLine("(double): " + (double)line);

        int d = ReadInt("Введите d: ");

        Console.WriteLine("Отрезок + d: " + (line + d));
        Console.WriteLine("d + отрезок: " + (d + line));

        int value = ReadInt("Число для <: ");

        Console.WriteLine(
            "Попадает в отрезок: " + (line < value));
    }

    static double ReadDouble(string message)
    {
        double value;

        while (true)
        {
            Console.Write(message);

            if (double.TryParse(
                Console.ReadLine(), out value) &&
                !double.IsNaN(value) &&
                !double.IsInfinity(value))
                return value;

            Console.WriteLine("Ошибка! Повторите ввод.");
        }
    }

    static int ReadInt(string message)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Введите целое число!");
        }
    }
}