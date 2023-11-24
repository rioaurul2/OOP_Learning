using Lecture_2;
using Lecture_1___dll_test;
using System.Diagnostics;
using System.Text;

Console.WriteLine("Hello, World!");
PrintToScreenRandomNumber printSomething = new();
printSomething.PrintToScreen();

PrintToScreenRandomNumberChild printSomethingChild = new();
printSomethingChild.PrintToScreen();

InternalModifierTest internalModifierTest = new();
internalModifierTest.testInternalModdifier();

Dll_PrintToScreenRandomNumber dllInternalModifierTest = new();
dllInternalModifierTest.PrintToScreen();
//dllInternalModifierTest.printToScreenProtected(); Metoda nu functioneaza deoarece modificatorul ei de acces este internal si face parte in alt asembly(dll)

PrintScreenStatic.printScreenStatic();

Console.Clear(); // comment This line if you want to see the previous examples

Car myCar = new();

Console.WriteLine($"Default model: {myCar.carModel}");
Console.WriteLine($"Default price: {myCar.Price}");

myCar.carModel = "second model car";
myCar.Price = 1500;

Console.WriteLine($"Changed model: {myCar.carModel}");
Console.WriteLine($"Changed price: {myCar.Price}");

//Getter and setter defaults
//default
Console.WriteLine($"Default price: {myCar.Year}");

//first case
myCar.Year = 2018;
Console.WriteLine($"Default price: {myCar.Year}");

//second case
myCar.Year = 2039;
Console.WriteLine($"Default price: {myCar.Year}");

DictionaryExample dictionaryExample = new();

dictionaryExample.printDictionary();

class PrintToScreenRandomNumber
{
    Random myRandomGen = new();

    public virtual void PrintToScreen()
    {
        Console.WriteLine(myRandomGen.Next().ToString("N0"));
    }
    internal void PrintToScreenIntternal()
    {
        Console.WriteLine("Message from Internal Modifier:");
        printToScreenPrivate();
    }

    private void printToScreenPrivate()
    {
        Console.WriteLine("It's me, Private"+myRandomGen.Next().ToString("N3"));
    }

    protected void printToScreenProtected()
    {
        Console.WriteLine(myRandomGen.Next().ToString("N6"));
    }
}

static class PrintScreenStatic
{
    public static void printScreenStatic() 
    {
        Console.WriteLine("Message from static class from a static method");
    }

    //public  void printScreenNoStatic()
    //{
    //     Console.WriteLine("Message from static class from a non-static method");
    //}  ERROR because I cand declare an instance in a Static class
}

class PrintToScreenRandomNumberChild : PrintToScreenRandomNumber //simple example of inheritance
{
    public override void PrintToScreen()
    {
        printToScreenProtected();
    }
}

namespace InternalTest
{
    public class InternalModifierTestNewNameSpace
    {
        public void PrintToScreenPublic()
        {
            Console.WriteLine("Message from InternaTest namespace:");
        } 

        internal void PrintToScreenInternal()
        {
            Console.WriteLine("Message from InternaTest namespace:");
        }
    }
}

// PropertyAccessors class example

class Car
{
    public string carModel = "Toyota"; // Este un "FIELD"

    public int Price { get; set; }

    private int _year;

    public int Year
    {
        get
        {
            if (_year < 1980)
            {
                return 2000;
            } else if(_year >= DateTime.Now.Year)
            {
                return DateTime.Now.Year;
            }

            return _year;
        }

        set { _year = value - 10;}
    }
}

//dictionary example
public class DictionaryExample
{
    static Random myRandom = new();

    private static void randomNumberTest()
    {
        Dictionary<int, int> dicNumbers = new();
        Stopwatch timer = new();

        timer.Start();
        for (int i = 0; i < 10000; i++)
        {
            var dicNumber = myRandom.Next();
            try
            {
                dicNumbers[dicNumber] = dicNumbers.ContainsKey(dicNumber) ? dicNumbers[dicNumber] + 1 : 1;

            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        timer.Stop();

        Console.WriteLine(timer.Elapsed.TotalMilliseconds);

        writeDictionariToAFile_inncorect_way(dicNumbers, "writeDictionariToAFile_inncorect_way.txt");

        writeDictionariToAFile_corect_way(dicNumbers, "writeDictionariToAFile_corect_way.txt");

        WriteDictionaryToAFile_CorrectWay(dicNumbers, "writeDictionariToAFile_corect_way.txt");
    }

    public void printDictionary()
    {
        randomNumberTest();
    }


    private static void writeDictionariToAFile_inncorect_way( Dictionary<int, int> dicNums, string srFileName)
    {

        Stopwatch timer = new();
        StringBuilder srBuild = new();

        timer.Start();

        foreach(var dicNum in dicNums ) {

            srBuild.AppendLine($"Number {dicNum.Key} generated by {dicNum.Value} times");
        }

        File.WriteAllText(srFileName, srBuild.ToString());
        timer.Stop();

        Console.WriteLine($" Elapsed time in miliseconds Incorrect Way: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    private static void writeDictionariToAFile_corect_way(Dictionary<int, int> dicNums, string srFileName)
    {

        Stopwatch timer = new();
        string temp ="";

        timer.Start();

        foreach (var dicNum in dicNums)
        {

            temp += $"Number {dicNum.Key} generated by {dicNum.Value} times\r\n";
        }

        File.WriteAllText(srFileName, temp);
        timer.Stop();

        Console.WriteLine($" Elapsed time in miliseconds Proper Way: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    private static void WriteDictionaryToAFile_CorrectWay(Dictionary<int, int> dicNums, string fileName)
    {
        Stopwatch timer = new Stopwatch();
        StringBuilder srBuild = new StringBuilder();

        timer.Start();

        foreach (var dicNum in dicNums)
        {
            srBuild.AppendLine($"Number {dicNum.Key} generated by {dicNum.Value} times");
        }

        // Using StreamWriter to ensure proper resource disposal
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.Write(srBuild.ToString());
        }

        timer.Stop();

        Console.WriteLine($"Elapsed time in milliseconds Correct Way: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }
}


