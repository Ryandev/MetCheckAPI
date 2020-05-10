
using System;
using System.IO;
using System.Reflection;


namespace UnitTest
{
    public static class Asset
    {
        public static string TestDirectory => Path.GetDirectoryName( typeof(Asset).GetTypeInfo().Assembly.Location );

        public static string PathForResource(string resourceName)
        {
            return Path.Combine(TestDirectory, "Resources", resourceName);
        }

    }
}
