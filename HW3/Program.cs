using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter Strings: ");
        string input = Console.ReadLine();

        string[] parts = input.Split(',');

        foreach (string part in parts)
        {
            string s = part.Trim();
            if (s.Length == 0) continue;

            var counts = GetCounts(s);

            Console.WriteLine("\nOutput: " + s);

            var seen = new HashSet<char>();
            var output = new List<string>();

            foreach (char c in s)
            {
                if (c == ' ' || c == ',') continue;

                char lower = char.ToLower(c);
                if (!seen.Contains(lower))
                {
                    seen.Add(lower);
                    output.Add($"{c}={counts[lower]}"); 
                }
            }
            Console.WriteLine(string.Join(", ", output));
        }
        Console.ReadKey();
    }

    static Dictionary<char, int> GetCounts(string text)
    {
        var counts = new Dictionary<char, int>();
        foreach (char c in text.ToLower())
        {
            if (c == ' ' || c == ',') continue;
            if (!counts.ContainsKey(c))
                counts[c] = 1;
            else
                counts[c]++;
        }
        return counts;
    }

}
