using System;

public class Program
{
    public static string GenerateSaleId(DateTime timestamp)
    {
        char year = (char)('A' + (timestamp.Year - 2004));
        char month = (char)('A' + (timestamp.Month - 1));
        string day = ConvertToLetterNumberCombinations(timestamp.Day);
        string hour = timestamp.ToString("HH");
        string minutes = ConvertToLetterCombinations(timestamp.Minute);
        string seconds = ConvertToLetterCombinations(timestamp.Second);
        // string millisecond = ConvertToLetterCombinations(timestamp.Millisecond);
        string millisecond = timestamp.Millisecond.ToString();



        string saleId = $"{year}-{month}-{day}-{hour}-{minutes}-{seconds}";

        return saleId;
    }

    public static string ConvertToRomanNumerals(int number)
    {
        if (number < 1 || number > 31)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Invalid day value");
        }

        string[] romanNumerals = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI", "XXVII", "XXVIII", "XXIX", "XXX", "XXXI" };

        return romanNumerals[number - 1];
    }

    public static string ConvertToLetterCombinations(int number)
    {
        if (number < 0 || number > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Invalid minutes/seconds value");
        }

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";

        while (number > 0)
        {
            number--;
            result = letters[number % 26] + result;
            number /= 26;
        }

        return result;
    }
    public static string ConvertToLetterNumberCombinations(int number)
    {
        if (number < 1 || number > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Invalid minutes/seconds value");
        }

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string result = "";

        while (number > 0)
        {
            number--;
            result = letters[number % 36] + result;
            number /= 36;
        }

        return result;
    }

    public static void Main(string[] args)
    {
      
        string saleId = GenerateSaleId(DateTime.Now);

        Console.WriteLine($"Sale ID: {saleId}");


        Console.WriteLine($"Sale ID: {DateTime.Now.Ticks.ToString().Substring(0, 10)}");

        
    }
}
