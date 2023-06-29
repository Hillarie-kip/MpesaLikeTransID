using System;
using System.Globalization;
using System.Timers;
using Timer = System.Timers.Timer;

public class Program
{
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
        string userID = ConvertToLetterCombinationsID(10);
        string vendorlocationIDE = ConvertToLetterCombinationsID(1111);
        int vendorlocationIDD = ConvertToIDCombinationsLetter("34");

        

        // string saleId = $"{year}-{month}-{day}-{hour}-{minutes}-{seconds}-{millisecond}";
        string saleId = $"{year}{month}{day}{hour}{minutes}{seconds}{millisecond}-{userID}-{vendorlocationIDE}-{vendorlocationIDD}";

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

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890";
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

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890";
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

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890";
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

    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890";
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
        Timer timer = new Timer(1000); // 1 millisecond interval
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


       // Console.WriteLine($"Sale ID: {DateTime.Now.Ticks.ToString().Substring(0, 10)}");


    }
}
