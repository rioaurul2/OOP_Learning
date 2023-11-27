class Program
{
    private static readonly Random RandomNumber = new();

    public static void Main()
    {
        PrintRandomNumber();
        PrintRandomNumber(10);
        PrintRandomNumber(100, 200);
    }

    public static void PrintRandomNumber()//empty signature
    {
        Console.WriteLine(RandomNumber.Next(10));
    }

    public static void PrintRandomNumber(int someNumber)
    {
        Console.WriteLine(RandomNumber.Next(someNumber));
    }

    public static void PrintRandomNumber(int min, int max)
    {
        Console.WriteLine(RandomNumber.Next(min, max));
    }
}

