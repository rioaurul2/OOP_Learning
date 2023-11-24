namespace Lecture_1___dll_test
{
    public class Dll_PrintToScreenRandomNumber
    {
        Random myRandomGen = new();

        public virtual void PrintToScreen()
        {
            Console.WriteLine(myRandomGen.Next().ToString("N0"));
            printToScreenPrivate();
        }
        internal void PrintToScreenIntternal()
        {
            Console.WriteLine("Message from dll Internal Modifier:");
            printToScreenPrivate();
        }

        private void printToScreenPrivate()
        {
            Console.WriteLine(" dll It's me, Private" + myRandomGen.Next().ToString("N3"));
        }

        protected void printToScreenProtected()
        {
            Console.WriteLine(myRandomGen.Next().ToString("N6"));
        }
    }
}