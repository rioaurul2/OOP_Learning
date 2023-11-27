using System.Runtime.CompilerServices;

namespace Lecture_2
{
    public static class StaticExtensions
    {
        public static int ToInt32(this string srGG)
        {
            Int32.TryParse(srGG, out int irReturnNumber);

            return irReturnNumber;
        }

        public static string JustAJoke(this string srGG)
        {
            return "A stupid number like you and";
        }

        //Example
        public static void ExtensionClassExample(this DictionaryStringAndCharExample srGG)
        {
            Console.WriteLine("DictionaryStringAndCharExample class was extended succesfully, the added method is 'ExtensionClassExample()'\n\r");
        }
    }
}
