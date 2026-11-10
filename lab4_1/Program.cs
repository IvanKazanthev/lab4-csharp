using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Run1();
        Console.WriteLine();
        Run2();
        Console.WriteLine();
        Run3();
        Console.WriteLine();
        Run4();
        Console.WriteLine();
        Run5();
    }

    static int ReadInt(string message, int min = 0)
    {
        int n;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out n)
                && n >= min)
                return n;

            Console.WriteLine("Ошибка! Повторите ввод.");
        }
    }

    static string ReadText(string message)
    {
        string s;

        do
        {
            Console.Write(message);
            s = Console.ReadLine() ?? "";
        }
        while (string.IsNullOrWhiteSpace(s));

        return s.Trim();
    }

    static void Run1()
    {
        Console.WriteLine("ЗАДАНИЕ 1");

        int n = ReadInt("Количество элементов: ", 1);
        List<int> list = new List<int>();

        for (int i = 0; i < n; i++)
            list.Add(ReadInt("Элемент: ", int.MinValue));

        int value = ReadInt("Удалить число: ", int.MinValue);

        Tasks.RemoveValue(list, value);

        foreach (int x in list)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    static void Run2()
    {
        Console.WriteLine("ЗАДАНИЕ 2");

        int n = ReadInt("Количество элементов: ", 1);
        LinkedList<int> list = new LinkedList<int>();

        for (int i = 0; i < n; i++)
            list.AddLast(ReadInt("Элемент: ", int.MinValue));

        int value = ReadInt("Введите E: ", int.MinValue);

        Tasks.ReverseBetween(list, value);

        foreach (int x in list)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    static void Run3()
    {
        Console.WriteLine("ЗАДАНИЕ 3");

        int n = ReadInt("Количество фильмов: ", 1);
        List<string> films = new List<string>();

        for (int i = 0; i < n; i++)
            films.Add(ReadText("Фильм: "));

        int m = ReadInt("Количество зрителей: ", 1);
        List<HashSet<int>> viewers =
            new List<HashSet<int>>();

        for (int i = 0; i < m; i++)
        {
            while (true)
            {
                Console.WriteLine(
                    "Зритель " + (i + 1) +
                    ". Номера через ;, 0 — ничего");

                string[] parts =
                    (Console.ReadLine() ?? "").Split(';');

                HashSet<int> watched = new HashSet<int>();
                bool valid = true;

                if (parts.Length == 1 &&
                    parts[0].Trim() == "0")
                {
                    viewers.Add(watched);
                    break;
                }

                foreach (string part in parts)
                {
                    int x;

                    if (!int.TryParse(part.Trim(), out x)
                        || x < 1 || x > n)
                    {
                        valid = false;
                        break;
                    }

                    watched.Add(x - 1);
                }

                if (valid && watched.Count > 0)
                {
                    viewers.Add(watched);
                    break;
                }

                Console.WriteLine("Неверный ввод!");
            }
        }

        List<string> all, some, none;

        Tasks.ClassifyFilms(
            films, viewers, out all, out some, out none);

        Print("Смотрели все:", all);
        Print("Смотрели некоторые:", some);
        Print("Не смотрел никто:", none);
    }

    static void Run4()
    {
        Console.WriteLine("ЗАДАНИЕ 4");

        if (!File.Exists("text.txt"))
        {
            Console.WriteLine("Нет файла text.txt");
            return;
        }

        foreach (char c in Tasks.FindConsonants(
            File.ReadAllText("text.txt")))
            Console.Write(c + " ");

        Console.WriteLine();
    }

    static void Run5()
    {
        Console.WriteLine("ЗАДАНИЕ 5");

        int n = ReadInt("Количество сотрудников: ", 1);
        List<string> lines = new List<string>();
        lines.Add(n.ToString());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Сотрудник " + (i + 1));

            string surname;

            while (true)
            {
                surname = ReadText("Фамилия: ");
                bool ok = surname.Length <= 20;

                foreach (char c in surname)
                    if (!char.IsLetter(c))
                        ok = false;

                if (ok) break;
                Console.WriteLine("Неверная фамилия!");
            }

            string initials;

            while (true)
            {
                initials = ReadText("Инициалы (И.И.): ");

                if (initials.Length == 4 &&
                    char.IsLetter(initials[0]) &&
                    initials[1] == '.' &&
                    char.IsLetter(initials[2]) &&
                    initials[3] == '.')
                    break;

                Console.WriteLine("Неверные инициалы!");
            }

            string phone;

            while (true)
            {
                phone = ReadText("Телефон (555-66-77): ");
                string[] p = phone.Split('-');

                if (p.Length == 3 &&
                    p[0].Length == 3 &&
                    p[1].Length == 2 &&
                    p[2].Length == 2 &&
                    Digits(p[0] + p[1] + p[2]))
                    break;

                Console.WriteLine("Неверный телефон!");
            }

            lines.Add(surname + " " + initials + " " + phone);
        }

        Tasks.CreateEmployeeFile("employees.txt", lines);

        Console.WriteLine("Среднее число сотрудников: " +
            Tasks.AverageEmployeesByDepartment(
                "employees.txt").ToString("F2"));
    }

    static bool Digits(string s)
    {
        foreach (char c in s)
            if (!char.IsDigit(c))
                return false;

        return true;
    }

    static void Print(string title, List<string> films)
    {
        Console.WriteLine(title);

        if (films.Count == 0)
            Console.WriteLine("Нет");

        foreach (string film in films)
            Console.WriteLine(film);
    }
}