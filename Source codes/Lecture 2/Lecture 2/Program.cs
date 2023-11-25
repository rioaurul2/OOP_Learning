using System.Diagnostics;

class Program
{
    static void Main()
    {
        DictionaryIntExample intHelper = new();
        intHelper.GenerateDictionary(1000, 1, 110);
        intHelper.PrintDictionary();

        DictionaryCharExample charHelper = new();
        charHelper.GenerateDictionary(1000, 0, 26);
        charHelper.PrintDictionary();

        DictionaryStringAndCharExample dictionaryStringAndCharExample = new();

        Console.WriteLine("Please write a number to see its randomly assigned character");
        string  insertedNumber = Console.ReadLine();

        while (string.IsNullOrEmpty(insertedNumber))
        {
            Console.ReadLine();
            Console.WriteLine("Please write a number to see its randomly assigned character");
        }

        dictionaryStringAndCharExample.GenerateDictionary(1000);

        Console.WriteLine($" Your entered number is: {insertedNumber} - its randomly assigned character is '{dictionaryStringAndCharExample.dictionaryStringAndCharData[insertedNumber]}'");

    }
}

public class DictionaryIntExample
{
    private Stopwatch timer = new Stopwatch();
    private Random randGenerator = new Random();
    private Dictionary<int, int> dictionaryIntData = new();

    public void GenerateDictionary(int numberOfNumbers, int minValue, int maxValue)
    {
        timer.Start();
        for (int i = 0; i < numberOfNumbers; i++)
        {
            var number = GenerateRandomNumber(minValue, maxValue);
            AddToDictionary(number);
        }
        timer.Stop();
    }

    public void PrintDictionary()
    {
        var sortedDictionary = dictionaryIntData.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var number in sortedDictionary)
        {
            Console.WriteLine($"The number {number.Key} appears {number.Value} times");
        }

        Console.WriteLine($"\n\r\n\rThe numbers were generated in {timer.ElapsedMilliseconds.ToString("N0")} milliseconds");
        timer.Reset();
    }

    private int GenerateRandomNumber(int min, int max)
    {
        return randGenerator.Next(min, max);
    }

    private void AddToDictionary(int numberToAdd)
    {
        dictionaryIntData[numberToAdd] = dictionaryIntData.TryGetValue(numberToAdd, out var count) ? count + 1 : 1;
    }
}

public class DictionaryCharExample
{
    private Stopwatch timer = new();
    private Random randGenerator = new();
    private List<char> charList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToList();
    private Dictionary<char, int> dictionaryCharData = new();

    public void GenerateDictionary(int numberOfNumbers, int minValue, int maxValue)
    {
        timer.Start();
        for (int i = 0; i < numberOfNumbers; i++)
        {
            char letter = GenerateRandomChar(minValue, maxValue);
            AddToDictionary(letter);
        }
        timer.Stop();
    }

    public void PrintDictionary()
    {
        var sortedDictionary = dictionaryCharData.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var letter in sortedDictionary)
        {
            Console.WriteLine($"The number {letter.Key} appears {letter.Value} times");
        }

        Console.WriteLine($"\n\r\n\rThe chars were generated in {timer.ElapsedMilliseconds.ToString("N0")} milliseconds");
        timer.Reset();
    }

    private char GenerateRandomChar(int min, int max)
    {
        try
        {
            return charList[randGenerator.Next(min, max)];

        } catch (Exception e)
        {
            return '1';
        }
    }

    private void AddToDictionary(char letter)
    {
        dictionaryCharData[letter] = dictionaryCharData.TryGetValue(letter, out var count) ? count + 1 : 1;
    }
}

public class DictionaryStringAndCharExample
{
    private Stopwatch timer = new();
    private Random randGenerator = new();
    private List<char> charList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToList();
    public Dictionary<string, char> dictionaryStringAndCharData = new();

    public void GenerateDictionary(int numberOfNumbers)
    {
        timer.Start();
        for (int i = 0; i < numberOfNumbers; i++)
        {
            AddToDictionary(i.ToString());
        }
        timer.Stop();
    }

    public void PrintDictionary()
    {
        var sortedDictionary = dictionaryStringAndCharData.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var number in sortedDictionary)
        {
            Console.WriteLine($"The number {number.Key} appears {number.Value} times");
        }

        Console.WriteLine($"\n\r\n\rThe numbers were generated in {timer.ElapsedMilliseconds.ToString("N0")} milliseconds");
        timer.Reset();
    } 

    private void AddToDictionary(string key)
    {
        dictionaryStringAndCharData.Add(key, charList[randGenerator.Next(0, charList.Count - 1)]);
    }
}