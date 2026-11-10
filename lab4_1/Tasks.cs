using System;
using System.Collections.Generic;
using System.IO;

class Tasks
{
    public static void RemoveValue(
        List<int> list, int value)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == value)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static void ReverseBetween(
        LinkedList<int> list, int value)
    {
        LinkedListNode<int>? first = null;
        LinkedListNode<int>? last = null;

        LinkedListNode<int>? node = list.First;

        while (node != null)
        {
            if (node.Value == value)
            {
                if (first == null)
                {
                    first = node;
                }

                last = node;
            }

            node = node.Next;
        }

        if (first == null || last == null ||
            first == last)
        {
            return;
        }

        LinkedListNode<int>? left = first.Next;
        LinkedListNode<int>? right = last.Previous;

        while (left != null && right != null &&
               left != right && left.Previous != right)
        {
            int temp = left.Value;
            left.Value = right.Value;
            right.Value = temp;

            left = left.Next;
            right = right.Previous;
        }
    }

    public static void ClassifyFilms(
        List<string> films,
        List<HashSet<int>> viewers,
        out List<string> all,
        out List<string> some,
        out List<string> none)
    {
        all = new List<string>();
        some = new List<string>();
        none = new List<string>();

        for (int i = 0; i < films.Count; i++)
        {
            int watched = 0;

            foreach (HashSet<int> viewer in viewers)
            {
                if (viewer.Contains(i))
                {
                    watched++;
                }
            }

            if (watched == viewers.Count)
            {
                all.Add(films[i]);
            }
            else if (watched > 0)
            {
                some.Add(films[i]);
            }
            else
            {
                none.Add(films[i]);
            }
        }
    }

    public static List<char> FindConsonants(string text)
    {
        string alphabet = "бвгджзйлмнр";

        Dictionary<char, int> counts =
            new Dictionary<char, int>();

        string word = "";

        foreach (char symbol in text.ToLowerInvariant())
        {
            if (char.IsLetter(symbol))
            {
                word += symbol;
            }
            else
            {
                CountWord(word, alphabet, counts);
                word = "";
            }
        }

        CountWord(word, alphabet, counts);

        List<char> result = new List<char>();

        foreach (char letter in alphabet)
        {
            if (counts.ContainsKey(letter) &&
                counts[letter] > 1)
            {
                result.Add(letter);
            }
        }

        return result;
    }

    static void CountWord(
        string word,
        string alphabet,
        Dictionary<char, int> counts)
    {
        foreach (char letter in alphabet)
        {
            if (word.Contains(letter))
            {
                if (!counts.ContainsKey(letter))
                {
                    counts[letter] = 0;
                }

                counts[letter]++;
            }
        }
    }

    public static void CreateEmployeeFile(
        string path, List<string> lines)
    {
        File.WriteAllLines(path, lines);
    }

    public static double AverageEmployeesByDepartment(
        string path)
    {
        string[] lines = File.ReadAllLines(path);

        int count = int.Parse(lines[0]);

        HashSet<string> departments =
            new HashSet<string>();

        for (int i = 1; i <= count; i++)
        {
            string[] data = lines[i].Split(
                ' ', StringSplitOptions.RemoveEmptyEntries);

            departments.Add(data[2].Substring(0, 6));
        }

        if (departments.Count == 0)
        {
            return 0;
        }

        return (double)count / departments.Count;
    }
}