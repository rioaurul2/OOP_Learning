class Program
{
    static void Main(string[] args)
    {
        int counter = 1;

        foreach(string arg in args) 
        {
            Console.WriteLine($" arg {counter} = {arg}");
            counter++;
        }

        

    }
}