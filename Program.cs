using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Timers;
using Timer = System.Timers.Timer;

public class Program
{
    static int counter = 0;

    public static string GenerateSaleId(DateTime timestamp)
    {
        char year = (char)('A' + (timestamp.Year - 2006));
        char month = (char)('A' + (timestamp.Month - 1));
        string day = ConvertToLetterNumberCombinations(timestamp.Day);
        string hour = ConvertToLetterNumberCombinations(timestamp.Hour);
       // string hour = timestamp.ToString("HH");
        string minutes = ConvertToLetterCombinations(timestamp.Minute);
        string seconds = ConvertToLetterCombinations(timestamp.Second);
        string millisecond = ConvertToLetterCombinationsMillisec(timestamp.Millisecond);
        // string millisecond = timestamp.Millisecond.ToString();

        string userID = ConvertToLetterCombinationsID(100000);
        string vendorlocationIDE = ConvertToLetterCombinationsID(1);
        int vendorlocationIDD = ConvertToIDCombinationsLetter("34");



        // string saleId = $"{year}-{month}-{day}-{hour}-{minutes}-{seconds}-{millisecond}";
      //  string saleId = $"{year}{month}{day}{hour}{minutes}{seconds}{millisecond}-{userID}-{vendorlocationIDE}-{vendorlocationIDD}";
        string saleId = $"{year}{month}{day}{hour}{minutes}{seconds}{millisecond}-{userID}-{vendorlocationIDE}";

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

        return result.PadLeft(2, 'A'); // Pad with leading zeros if needed
    }

    public static string ConvertToLetterCombinationsMillisec(int number)
    {
        if (number < 0 || number > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Invalid minutes/seconds value");
        }

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string result = "";

        while (number > 0)
        {
            number--;
            result = letters[number % 36] + result;
            number /= 36;
        }

        return result;
    }


    public static string ConvertToLetterCombinationsID(int number)
    {
        if (number < 0 || number > 10000000)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Invalid minutes/seconds value");
        }

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string result = "";

        while (number > 0)
        {
            number--;
            result = letters[number % 36] + result;
            number /= 36;
        }

        return result;
    }
    public static int ConvertToIDCombinationsLetter(string letter)
    {
        if (string.IsNullOrEmpty(letter))
        {
            throw new ArgumentException("Letter cannot be null or empty", nameof(letter));
        }

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        letter = letter.ToUpper();

        Dictionary<char, int> letterToNumber = new Dictionary<char, int>();
        for (int i = 0; i < letters.Length; i++)
        {
            letterToNumber[letters[i]] = i + 1;
        }

        int number = 0;
        for (int i = 0; i < letter.Length; i++)
        {
            if (!letterToNumber.TryGetValue(letter[i], out int value))
            {
                throw new ArgumentException("Invalid letter: " + letter[i], nameof(letter));
            }
            number = (number * 36) + value;
        }
        return number;
    }



    public static int ConvertToNumber(string letter)
{
    if (string.IsNullOrEmpty(letter))
    {
        throw new ArgumentException("Letter cannot be null or empty", nameof(letter));
    }

    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    letter = letter.ToUpper();

    int number = 0;
    for (int i = 0; i < letter.Length; i++)
    {
        number = (number * 36) + letters.IndexOf(letter[i]);
    }

    return number + 1;
}

    public static string ConvertToLetterCombination(int number)
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

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
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
        int counter=0;
        Timer timer = new Timer(1); // 1 millisecond interval
        timer.Elapsed += TimerElapsed;
        timer.AutoReset = true;
        timer.Start();

        Console.WriteLine("Press Enter to stop the program.");
        Console.ReadLine();

        timer.Stop();
        timer.Dispose();

    }


    static void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Code to be executed every millisecond
        string saleId = GenerateSaleId(DateTime.Now);

         Console.WriteLine($"Sale ID:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} -- {saleId} ");
      

      //  counter++;
     //   counter = counter + 1000;
     //   string combinedString = CombineCharacters(counter);
     //   Console.WriteLine(counter.ToString()+" -- "+combinedString.ToString());

        // Console.WriteLine($"Sale ID: {DateTime.Now.Ticks.ToString().Substring(0, 10)}");

    }


    static string CombineCharacters(int number)
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";

        int baseCount = letters.Length;
        string combinedString = "";

        while (number > 0)
        {
            int remainder = (number - 1) % baseCount;
            combinedString = letters[remainder] + combinedString;
            number = (number - 1) / baseCount;
        }

        return combinedString;
    }

}
