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
            bool isComleted;
            if (choice.Equals('1'))
            {
               isComleted = SampleTest();
                if (isComleted)
                {
                    Console.WriteLine("Do you want to run Complete Testcases (y/n) : ");
                    char yORn = (char)Console.ReadLine()[0];
                    if(yORn.Equals('y') || yORn.Equals('Y'))
                    {
                        CompleteTest();
                    }
                    else
                    {
                        return;
                    }
                }
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
        public static bool SampleTest()
        {
            bool isCompleted = true;

            #region Case1
            Console.WriteLine("Running TestCase 1");

            List<string> synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Algorithm Project\\Testcases\\Sample\\Case1\\Input\\1synsets.txt");
            
            List<string> hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Algorithm Project\\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");
            
            List<string> relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Algorithm Project\\Testcases\\Sample\\Case1\\Input\\3RelationsQueries.txt");
            
            List<string> outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Algorithm Project\\Testcases\\Sample\\Case1\\Input\\4OutcastQueries.txt");


            Console.WriteLine("Complete Test Case 1");
            #endregion

            #region Case 2
            #endregion

            #region Case 3
            #endregion

            #region Case 4
            #endregion

            #region Special Cases
            #endregion

            return isCompleted;
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
