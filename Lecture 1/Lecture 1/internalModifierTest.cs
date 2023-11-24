using InternalTest;

namespace Lecture_2
{

    public class InternalModifierTest
    {
        readonly InternalModifierTestNewNameSpace printSomething = new(); 

        public void testInternalModdifier()
        {
            printSomething.PrintToScreenInternal();
        }
    }

}
