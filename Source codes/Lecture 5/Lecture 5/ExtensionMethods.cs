﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lecture_5
{
    public static class ExtensionMethods
    {
        //Deep clone

        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new())
            {
                BinaryFormatter formatter = new();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

    }
}
