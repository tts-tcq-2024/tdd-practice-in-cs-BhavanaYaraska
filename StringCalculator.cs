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

        // Default delimiters are comma and newline
        string[] delimiters = { ",", "\n" };

        // Check if custom delimiter is specified
        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf('\n');
            string customDelimiter = numbers.Substring(2, delimiterIndex - 2);
            numbers = numbers.Substring(delimiterIndex + 1);
            delimiters = new string[] { customDelimiter };
        }

        // Split numbers string using delimiters and convert to integers
        string[] numberStrings = Regex.Split(numbers, string.Join("|", delimiters));
        List<int> parsedNumbers = new List<int>();

        foreach (string numStr in numberStrings)
        {
            if (!string.IsNullOrEmpty(numStr))
            {
                int num = int.Parse(numStr);
                if (num < 0)
                    throw new ArgumentException($"negatives not allowed: {num}");

                if (num <= 1000)
                    parsedNumbers.Add(num);
            }
        }

        return parsedNumbers.Sum();
    }
}
