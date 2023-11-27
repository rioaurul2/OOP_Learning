using Lecture_2;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        DictionaryIntExample intHelper = new();

        intHelper.GenerateDictionary(1000, 1, 110);
        //intHelper.PrintDictionary();

        DictionaryCharExample charHelper = new();

        charHelper.GenerateDictionary(1000, 0, 26);
        //charHelper.PrintDictionary();

        DictionaryStringAndCharExample dictionaryStringAndCharExample = new();

        dictionaryStringAndCharExample.ExtensionClassExample();

        Console.WriteLine("Please write a number to see its randomly assigned character");
        string  insertedNumber = Console.ReadLine();

        while (string.IsNullOrEmpty(insertedNumber))
        {
            Console.WriteLine("Please write a number lower than 1000 to see its randomly assigned character");
            Console.ReadLine();
        }

        dictionaryStringAndCharExample.GenerateDictionary(1000);

        try
        {
            Console.WriteLine(
                    $"Your entered number is: {insertedNumber.JustAJoke()} " +
                    $"- its randomly assigned character is '{dictionaryStringAndCharExample.dictionaryStringAndCharData[insertedNumber]}'" +
                    $" and elapsed time was {dictionaryStringAndCharExample.timer.ElapsedMilliseconds.ToString("N0")} milisecons"
                );
        } catch (KeyNotFoundException ex)
        {
            Console.WriteLine("You inserted a number bigger than the maximum admisible number or you inserted a string, this is a learning project so I didn't add a solution for all errors");
        }

        ListWithTupleExample.FakeDictionaryInit();
        Console.WriteLine(ListWithTupleExample.timer.ElapsedMilliseconds.ToString("N0"));

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
    public readonly Stopwatch timer = new();
    private readonly Random randGenerator = new();
    private readonly List<char> charList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToList();
    public Dictionary<string, char> dictionaryStringAndCharData = new();

    public void GenerateDictionary(int numberOfNumbers)
    {
        timer.Start();
        for (int i = 0; i < numberOfNumbers; i++)
        {
            dictionaryStringAndCharData.Add(i.ToString(), charList[randGenerator.Next(0, charList.Count - 1)]);
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

        Console.WriteLine($"\n\rThe numbers were generated in {timer.ElapsedMilliseconds.ToString("N0")} milliseconds");
        timer.Reset();
    } 
}

public class ListWithTupleExample
{
    public static List<Tuple<string, char>> fakeDictionary = new();
    public static readonly Stopwatch timer = new();
    private static readonly Random randGenerator = new();
    private static readonly List<char> charList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToList();

    public static void FakeDictionaryInit()
    {
        timer.Start();
        for (int i = 0; i < 10000; i++)
        {
            fakeDictionary.Add(new Tuple <string, char>(i.ToString(), charList[randGenerator.Next(0, charList.Count - 1)]));
        }
        timer.Stop();
    }
}