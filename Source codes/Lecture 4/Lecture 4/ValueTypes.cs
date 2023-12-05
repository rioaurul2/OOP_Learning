using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_4
{
    class ValueTypes
    {
        bool boolValueType = false;//by default
        byte byteValueType = 0;//by default
        char charValueType = '\0';//by default
        decimal decimalValueType = 0;//by default
        double doubleValueType = 0;//by default
        enum enumValueType
        {
            enumValueType0 = 0,
            enumValueType1 = 1,
        }
        float floatValueType = 0;//by default
        int intValueType = 0;
        long longValueType = 0;
        sbyte sbyteValueType = 0;
        short shortValueType = 0;
        struct structValueType
        {
            string name;
            int age;
        }

        uint uintValueType = 0;
        ulong ulongValueType = 0;
        ushort ushortValueType = 0;
    }

    class referenceTypes
    {
        class classReferenceType
        {

        }//empty

        interface IInterfaceReferenceType {
            void ReferenceMethodExample();
        }

        public delegate void delegateReferenceType(string msg);

        object objectReferenceType;
        string stringReferenceType;
    }
}
