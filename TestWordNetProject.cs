using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace wordNet_project
{
    class TestWordNetProject
    {

        public void Test()
        {
            
            Console.WriteLine("WordNet Project:\n[1] Sample test cases\n[2] Complete testing\n");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];

            if (choice.Equals('1'))
            {
                SampleTest();
            }
            else if (choice.Equals('2'))
            {
                CompleteTest();
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }
        }

        #region Sample Test
        public static void SampleTest()
        {
            //Console.WriteLine("Sample Test!");
        }
        #endregion

        #region Complete Test
        public static void CompleteTest()
        {
            //Console.WriteLine("Complete Test!");
        }
        #endregion
    }

}
