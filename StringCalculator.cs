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

        string[] delimiters = GetDelimiters(numbers, out string trimmedNumbers);

        string[] numberStrings = SplitNumbers(trimmedNumbers, delimiters);

        List<int> parsedNumbers = ParseNumbers(numberStrings);

        return parsedNumbers.Sum();
    }

    public static string[] GetDelimiters(string numbers, out string trimmedNumbers)
    {
        string[] defaultDelimiters = { ",", "\n" };
        trimmedNumbers = numbers;

        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf('\n');
            string customDelimiterString = numbers.Substring(2, delimiterIndex - 2);
            List<string> customDelimiters = ExtractCustomDelimiters(customDelimiterString);
            trimmedNumbers = numbers.Substring(delimiterIndex + 1);
            return customDelimiters.ToArray();
        }

        return defaultDelimiters;
    }

    private static List<string> ExtractCustomDelimiters(string customDelimiterString)
    {
        List<string> customDelimiters = new List<string>();
        if (customDelimiterString.StartsWith("[") && customDelimiterString.EndsWith("]"))
        {
            // Multiple custom delimiters
            customDelimiters.AddRange(
                customDelimiterString.Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim('[', ']'))
            );
        }
        else
        {
            // Single custom delimiter
            customDelimiters.Add(customDelimiterString);
        }

        return customDelimiters;
    }

    public static string[] SplitNumbers(string numbers, string[] delimiters)
    {
        return Regex.Split(numbers, string.Join("|", delimiters.Select(Regex.Escape)));
    }

    public static List<int> ParseNumbers(string[] numberStrings)
    {
        List<int> parsedNumbers = new List<int>();

        foreach (string numStr in numberStrings)
        {
            if (!string.IsNullOrEmpty(numStr))
            {
                num = int.Parse(numStr);
                if(num<0){
                ValidateNumber(num);
                }else if(num>1000){
                    num=0;
                }
                parsedNumbers.Add(num);
            }
        }

        return parsedNumbers;
    }

    private static void ValidateNumber(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException($"negatives not allowed: {num1}");
        }
        else if (num > 1000)
        {
             num = 0;
            // Numbers greater than 1000 are ignored
        }
    }
}
