using System;
using Xunit;

public class StringCalculatorAddTests
{
    [Fact]
    public void ExpectZeroForEmptyInput()
    {
        int expectedResult = 0;
        string input = "";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectOneForSingleOne()
    {
        int expectedResult = 1;
        string input = "1";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectSumForTwoNumbers()
    {
        int expectedResult = 3;
        string input = "1,2";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectExceptionForNegativeNumbers()
    {
       var exception = Assert.Throws<ArgumentException>(() =>
    {
        string input = "-1,2";
        StringCalculator.Add(input);
    });

    Assert.Contains("negatives not allowed: -1", exception.Message);
    }

    [Fact]
    public void ExpectSumWithNewlineDelimiter()
    {
        int expectedResult = 6;
        string input = "1\n2,3";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void IgnoreNumbersGreaterThan1000()
    {
        int expectedResult = 1;
        string input = "1,1001";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectSumWithCustomDelimiter()
    {
        int expectedResult = 3;
        string input = "//;\n1;2";
        int result = StringCalculator.Add(input);
        Assert.Equal(expectedResult, result);
    }
}
