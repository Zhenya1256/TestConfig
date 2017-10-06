using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using SimpleConfig;

namespace MyConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var entety = ConfigurationHolder.ApiConfiguration;
         
            System.Console.ReadKey();

        }
    }
}
