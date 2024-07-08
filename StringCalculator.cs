using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        string[] delimiters = GetDelimiters(numbers, out numbers);

        string[] numberStrings = SplitNumbers(numbers, delimiters);

        List<int> parsedNumbers = ParseNumbers(numberStrings);

        return parsedNumbers.Sum();
    }

    private  static string[] GetDelimiters(string numbers, out string trimmedNumbers)
    {
        string[] defaultDelimiters = { ",", "\n" };
        trimmedNumbers = numbers;

        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf('\n');
            string customDelimiter = numbers.Substring(2, delimiterIndex - 2);
            trimmedNumbers = numbers.Substring(delimiterIndex + 1);
            return new string[] { customDelimiter };
        }

        return defaultDelimiters;
    }

    private   static string[] SplitNumbers(string numbers, string[] delimiters)
    {
        return Regex.Split(numbers, string.Join("|", delimiters));
    }

    private static List<int> ParseNumbers(string[] numberStrings)
    {
        List<int> parsedNumbers = new List<int>();

        foreach (string numStr in numberStrings)
        {
            if (!string.IsNullOrEmpty(numStr))
            {
                int num = int.Parse(numStr);
                ValidateNumber(num);
                parsedNumbers.Add(num);
            }
        }

        return parsedNumbers;
    }

    private static void ValidateNumber(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException($"negatives not allowed: {num}");
        }
        else if (num > 1000)
        {
            // Numbers greater than 1000 are ignored
        }
    }
}
