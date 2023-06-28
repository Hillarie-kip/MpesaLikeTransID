using System;

public class Program
{
    public static string GenerateSaleId(DateTime timestamp)
    {
        char year = (char)('A' + (timestamp.Year - 2022));
        char month = (char)('A' + (timestamp.Month - 1));
        string day = ConvertToRomanNumerals(timestamp.Day);
        string hour = timestamp.ToString("HH");
        string minutes = ConvertToLetterCombinations(timestamp.Minute);
        string seconds = ConvertToLetterCombinations(timestamp.Second);

        string saleId = $"R{year}E{month}L{day}H{hour}M{minutes}S{seconds}";

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
        if (number < 1 || number > 59)
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

    public static void Main(string[] args)
    {
        DateTime timestamp = new DateTime(2022, 6, 6, 6, 12, 0);

        string saleId = GenerateSaleId(DateTime.Now);

        Console.WriteLine($"Sale ID: {saleId}");
    }
}
