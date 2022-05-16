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
                Console.WriteLine("\n\n\nRuning unsing Efficient SCA.......");
                bool a = SampleTest_using_Efficient_SCA();
                if (isComleted)
                {
                    Console.WriteLine("Do you want to run Complete Testcases (y/n) : ");
                    char yORn = (char)Console.ReadLine()[0];
                    if (yORn.Equals('y') || yORn.Equals('Y'))
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
           
            bool flag = false;
            //----------------------------------------------------------
            #region Case1
            Console.WriteLine("Running TestCase 1.................");
            //loading data from files
            List<string> synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case1\Input\1synsets.txt");

            List<string> hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");

            List<string> relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\3RelationsQueries.txt");

            List<string> outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\4OutcastQueries.txt");
            // loading output data from files
            List<string> Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Output\\Output1.txt");

            List<string> Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase1");
            Console.WriteLine("Test Case 1 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            //------------------------------------------------------

            #region Case 2
            Console.WriteLine("Running TestCase 2............");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case2\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Input\\3RelationsQueries.txt");


            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Output\\Output1.txt");
            //---------------------------------------------------
            flag = Testing(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase2");
            Console.WriteLine("Test Case 2 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion
            //-------------------------------------------------------------
            #region Case 3
            Console.WriteLine("Running TestCase 3............");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case3\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\3RelationsQueries.txt");
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\4OutcastQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Output\\Output1.txt");
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Output\\Output2.txt");

            //---------------------------------------------------
            flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase3");
            Console.WriteLine("Test Case 3 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            //-------------------------------------------------
            #region Case 4
            Console.WriteLine("Running TestCase 4.........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case4\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\3RelationsQueries.txt");
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\4OutcastQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Output\\Output1.txt");
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Output\\Output2.txt");


            //---------------------------------------------------

            flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase4");
            Console.WriteLine("Test Case 4 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion

            #region Special Cases
            #region 2 commons case (Bidirectional)
            Console.WriteLine("Running Bidirectional TestCase .........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Other special cases\2 commons case (Bidirectional)\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Input\\3RelationsQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Output\\Output1.txt");


            //---------------------------------------------------

            flag = Testing(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Bidirectional TestCase");

            Console.WriteLine("Test Case  Many-Many (Noun in more than 1 synset) TestCase Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region Many-Many (Noun in more than 1 synset)
            Console.WriteLine("Running Bidirectional TestCase .........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Other special cases\Many-Many (Noun in more than 1 synset)\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Input\\3RelationsQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Output\\Output1.txt");


            //---------------------------------------------------

            flag = Testing(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Many-Many (Noun in more than 1 synset) TestCase");

            Console.WriteLine("Test Case  Many-Many (Noun in more than 1 synset) TestCase Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion


            #endregion

            return flag;
        }
        public static bool SampleTest_using_Efficient_SCA()
        {
           
            bool flag = false;
            //----------------------------------------------------------
            #region Case1
            Console.WriteLine("Running TestCase 1.................");
            //loading data from files
            List<string> synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case1\Input\1synsets.txt");

            List<string> hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");

            List<string> relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\3RelationsQueries.txt");

            List<string> outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Input\\4OutcastQueries.txt");
            // loading output data from files
            List<string> Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Output\\Output1.txt");

            List<string> Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case1\\Output\\Output2.txt");
            //----------------------------------------------------------

            flag = Testing_Efficient(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase1");


            Console.WriteLine("Test Case 1 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            //------------------------------------------------------

            #region Case 2
            Console.WriteLine("Running TestCase 2............");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case2\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Input\\3RelationsQueries.txt");


            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case2\\Output\\Output1.txt");
            //---------------------------------------------------
            flag = Testing_Efficient(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase2");

            Console.WriteLine("Test Case 2 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion
            //-------------------------------------------------------------
            #region Case 3
            Console.WriteLine("Running TestCase 3............");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case3\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\3RelationsQueries.txt");
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Input\\4OutcastQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Output\\Output1.txt");
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case3\\Output\\Output2.txt");

            //---------------------------------------------------
            flag = Testing_Efficient(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase3");

            Console.WriteLine("Test Case 3 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            //-------------------------------------------------
            #region Case 4
            Console.WriteLine("Running TestCase 4.........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Case4\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\3RelationsQueries.txt");
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Input\\4OutcastQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Output\\Output1.txt");
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Case4\\Output\\Output2.txt");


            //---------------------------------------------------
            flag = Testing_Efficient(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "testCase4");

            Console.WriteLine("Test Case 4 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion

            #region Special Cases
            #region 2 commons case (Bidirectional)
            Console.WriteLine("Running Bidirectional TestCase .........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Other special cases\2 commons case (Bidirectional)\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Input\\3RelationsQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\2 commons case (Bidirectional)\\Output\\Output1.txt");

            //---------------------------------------------------

            flag = Testing_Efficient(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Bidirectional TestCase");

            Console.WriteLine("Test Case  Many-Many (Noun in more than 1 synset) TestCase Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region Many-Many (Noun in more than 1 synset)
            Console.WriteLine("Running Bidirectional TestCase .........");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Sample\Other special cases\Many-Many (Noun in more than 1 synset)\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Input\\3RelationsQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Sample\\Other special cases\Many-Many (Noun in more than 1 synset)\\Output\\Output1.txt");

            //---------------------------------------------------
            flag = Testing_Efficient(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, " Many-Many (Noun in more than 1 synset) TestCase");


            Console.WriteLine("Test Case  Many-Many (Noun in more than 1 synset) TestCase Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion


            #endregion

            return flag;
        }
        #endregion

        #region Complete Test
        public static void CompleteTest()
        {
           // CompletTest_using_SCA();
            CompletTest_using_Efficient_SCA();
            
        }
        public static void CompletTest_using_SCA()
        {
            Console.WriteLine("\n\n\nRunning Complet testcases................ ");
            #region Small
            #region case1_100_100
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running case1_100_100.................");
            //loading data from files
            //---------------------------------------------------------
            List<string> synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\1-Small\Case1_100_100\Input\1synsets.txt");

            List<string> hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\2hypernyms.txt");

            List<string> relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\3RelationsQueries.txt");

            List<string> outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\4OutcastQueries.txt");
            // loading output data from files
            List<string> Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\\Output\\Output1.txt");

            List<string> Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\\Output\\Output2.txt");
            //----------------------------------------------------------
            bool flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "case1_100_100");

            Console.WriteLine("case1_100_100 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region case2_1000_500
            Console.WriteLine("Running case2_1000_500.................");
            //loading data from files
             synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\1-Small\Case2_1000_500\Input\1synsets.txt");

            hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\2hypernyms.txt");

            relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\3RelationsQueries.txt");

            outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output1.txt");

            Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "case2_1000_500");

            Console.WriteLine("case2_1000_500 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion
           
            #endregion

            #region Medium
           #region Case1_10000_5000
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running Case1_10000_5000.................");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\2-Medium\Case1_10000_5000\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\3RelationsQueries.txt");

            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\\Output\\Output1.txt");

            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\\Output\\Output2.txt");
            //----------------------------------------------------------
             flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case1_10000_5000");

            Console.WriteLine("Test Case 1 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region case2_1000_500
            Console.WriteLine("Running TestCase 2.................");
            //loading data from files
            synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\1-Small\Case2_1000_500\Input\1synsets.txt");

            hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\2hypernyms.txt");

            relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\3RelationsQueries.txt");

            outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output1.txt");

            Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "TestCase 2");

            Console.WriteLine("Test Case 1 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion
            #endregion

            #region Larg

            #endregion

            Console.WriteLine("Complet testcases Completed");
        }
        public static void CompletTest_using_Efficient_SCA()
        {
            Console.WriteLine("\n\n\nRunning Complet testcases................ ");
            #region Small
            #region case1_100_100
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running case1_100_100.................");
            //loading data from files
            List<string> synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\1-Small\Case1_100_100\Input\1synsets.txt");

            List<string> hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\2hypernyms.txt");

            List<string> relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\3RelationsQueries.txt");

            List<string> outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\Input\\4OutcastQueries.txt");
            // loading output data from files
            List<string> Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\\Output\\Output1.txt");

            List<string> Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case1_100_100\\Output\\Output2.txt");
            //----------------------------------------------------------
            bool flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "case1_100_100");

            Console.WriteLine("case1_100_100 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region case2_1000_500
            Console.WriteLine("Running case2_1000_500.................");
            //loading data from files
            synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\1-Small\Case2_1000_500\Input\1synsets.txt");

            hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\2hypernyms.txt");

            relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\3RelationsQueries.txt");

            outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output1.txt");

            Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\1-Small\Case2_1000_500\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "case2_1000_500");

            Console.WriteLine("case2_1000_500 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion

            #endregion
            Console.WriteLine("Medium");
            #region Medium
            
            #region Case1_10000_5000
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running Medium Case1_10000_5000.................");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\2-Medium\Case1_10000_5000\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\3RelationsQueries.txt");

            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\\Output\\Output1.txt");

            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case1_10000_5000\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case1_10000_5000");

            Console.WriteLine("Case1_10000_5000 Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region Case2_10000_50000
            Console.WriteLine("Running Case2_10000_50000.................");
            //loading data from files
            synsets = new List<string>();
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\2-Medium\Case2_10000_50000\Input\1synsets.txt");

            hypernyms = new List<string>();
            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case2_10000_50000\Input\\2hypernyms.txt");

            relationQueries = new List<string>();
            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case2_10000_50000\Input\\3RelationsQueries.txt");

            outcastQueries = new List<string>();
            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case2_10000_50000\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = new List<string>();
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case2_10000_50000\\Output\\Output1.txt");

            Output2 = new List<string>();
            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\2-Medium\Case2_10000_50000\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case2_10000_50000");

            Console.WriteLine("Case2_10000_50000 Completed :)");
            Console.WriteLine("------------------------------------");
            #endregion

            #endregion
            Console.WriteLine("Larg");
            #region Larg

            #region Case1_82K_100K_5000RQ
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running Case1_82K_100K_5000RQ.................");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\3-Large\Case1_82K_100K_5000RQ\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case1_82K_100K_5000RQ\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case1_82K_100K_5000RQ\Input\\3RelationsQueries.txt");

            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case1_82K_100K_5000RQ\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case1_82K_100K_5000RQ\\Output\\Output1.txt");

            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case1_82K_100K_5000RQ\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case1_82K_100K_5000RQ");

            Console.WriteLine("Case1_82K_100K_5000RQ Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region Case2_82K_300K_1500RQ
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running Case2_82K_300K_1500RQ.................");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\3-Large\Case2_82K_300K_1500RQ\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case2_82K_300K_1500RQ\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case2_82K_300K_1500RQ\Input\\3RelationsQueries.txt");

            outcastQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case2_82K_300K_1500RQ\Input\\4OutcastQueries.txt");
            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case2_82K_300K_1500RQ\\Output\\Output1.txt");

            Output2 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case2_82K_300K_1500RQ\\Output\\Output2.txt");
            //----------------------------------------------------------
            flag = Testing_Efficient_complet(true, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case2_82K_300K_1500RQ");

            Console.WriteLine("Case2_82K_300K_1500RQ Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #region Case3_82K_300K_5000RQ
            // bool flag = false;
            //----------------------------------------------------------
            Console.WriteLine("Running Case3_82K_300K_5000RQ.................");
            //loading data from files
            synsets = ReadFromFile.Read_From_File(@"\Testcases\Complete\3-Large\Case3_82K_300K_5000RQ\Input\1synsets.txt");

            hypernyms = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case3_82K_300K_5000RQ\Input\\2hypernyms.txt");

            relationQueries = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case3_82K_300K_5000RQ\Input\\3RelationsQueries.txt");

            // loading output data from files
            Output1 = ReadFromFile.Read_From_File(@"\Testcases\\Complete\3-Large\Case3_82K_300K_5000RQ\\Output\\Output1.txt");


            //----------------------------------------------------------
            flag = Testing_Efficient_complet(false, synsets, hypernyms, relationQueries, outcastQueries, Output1, Output2, "Case3_82K_300K_5000RQ");

            Console.WriteLine("Case3_82K_300K_5000RQ Completed :)");
            Console.WriteLine("------------------------------------");

            #endregion
            #endregion
         
            Console.WriteLine("Complet testcases Completed");
        }

        #endregion

        public static void Distans_And_SCA_Un_Efficient(ref int dis , ref int SCA_id , string Word_A , string Word_B , Graph_Construction_For_Efficient_SCA Graph)
        {
            int min_dis = 10000000;
            int SCA_ID = -1;
            ShortestCommAncestor SCA = new ShortestCommAncestor(Graph.Graph);
            List<int> noun_1_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Graph.Words, Word_A);
            List<int> noun_2_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Graph.Words, Word_B);
            for (int i = 0; i < noun_1_synsets.Count; i++)
            {
                for(int j = 0; j < noun_2_synsets.Count ; j++ )
                {
                    int a = SCA.getSCA(noun_1_synsets[i], noun_2_synsets[j]);
                    int b = SCA.shortestLength;
                    if (b < min_dis)
                    {
                        min_dis = b;
                        SCA_ID = a;
                     
                    }
                }
            }
            dis = min_dis;
            SCA_id = SCA_ID;
        }
        public static void Distans_And_SCA_Efficient(ref int dis, ref int SCA_id, string Word_A, string Word_B, Graph_Construction_For_Efficient_SCA Graph)
        {
            int min_dis = 10000000;
            int SCA_ID = -1;

            Efficient_SCA SCA = new Efficient_SCA();
            List<int> noun_1_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Graph.Words, Word_A);
            List<int> noun_2_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Graph.Words, Word_B);
            for (int i = 0; i < noun_1_synsets.Count; i++)
            {
                for (int j = 0; j < noun_2_synsets.Count; j++)
                {
                    int a = SCA.Efficient_Shortest_Common_Ancestor(noun_1_synsets[i], noun_2_synsets[j] , Graph.Graph);
                    int b = SCA.Distance;
                    if (b < min_dis)
                    {
                        min_dis = b;
                        SCA_ID = a;

                    }
                }
            }
            dis = min_dis;
            SCA_id = SCA_ID;
        }
        public static void outcastQueries_Efficient(ref string a , string [] words , Graph_Construction_For_Efficient_SCA Graph)
        {
            int max_dis = 0;
            string word = "";
            foreach(string i in words)
            {
                int all_dis = 0;
                int Id = 0;
                foreach (string j in words)
                {
                    int dis = 0;
                    Distans_And_SCA_Efficient(ref dis, ref Id, i, j, Graph);
                    all_dis += dis;


                }
                if(all_dis>max_dis)
                {
                    word = i;
                    max_dis = all_dis;
                }
            }
            a = word;
           
        }
        public static void outcastQueries_Un_Efficient(ref string a, string[] words , Graph_Construction_For_Efficient_SCA Graph)
        {
            int max_dis = 0;
            string word = "";
            foreach (string i in words)
            {
                int all_dis = 0;
                int Id = 0;
                foreach (string j in words)
                {
                    int dis = 0;
                    Distans_And_SCA_Un_Efficient(ref dis, ref Id, i, j, Graph);
                    all_dis += dis;


                }
                if (all_dis > max_dis)
                {
                    word = i;
                    max_dis = all_dis;
                }
            }
            a = word;
           
        }
        public static bool Testing(bool isoutcastQueries , List<string> synsets , List<string> hypernyms ,
            List<string> relationQueries , List<string> outcastQueries, List<string> Output1, List<string> Output2 , 
            String TestcaseName)
        {
            bool flag = true;
            Graph_Construction_For_Efficient_SCA test_Graph = new Graph_Construction_For_Efficient_SCA(synsets, hypernyms);

            int cases_type_1 = int.Parse(relationQueries[0]);

            for (int i = 1; i <= cases_type_1; i++)
            {
                string[] Splited_Line = relationQueries[i].Split(',');
                string[] output_one_line = Output1[i - 1].Split(',');
                int _dis = 0, _SCA_ID = 0;

                Distans_And_SCA_Un_Efficient(ref _dis, ref _SCA_ID, Splited_Line[0], Splited_Line[1], test_Graph);
                bool fnd = false;
                string[] output_simi_line = output_one_line[1].Split(" OR ");
                foreach (string k in output_simi_line)
                {
                    List<int> output_noun_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(test_Graph.Words, k);
                    foreach (int j in output_noun_synsets)
                    {

                        if (_SCA_ID == j) fnd = true;
                    }
                }
                if (_dis != int.Parse(output_one_line[0]) || !fnd)
                {
                    Console.WriteLine("Wrong answer at test"+ TestcaseName + "  number :" + i + "FND_dis:" + _dis + ", E_dis:" + int.Parse(output_one_line[0]));
                    Console.WriteLine("synset_ID:" + _SCA_ID);
                    flag = false;
                    // break;
                }
            }
            if (isoutcastQueries)
            {
                int cases_type_2 = int.Parse(outcastQueries[0]);
                for (int i = 1; i < cases_type_2; i++)
                {
                    string[] Splited_Line = outcastQueries[i].Split(',');
                    string[] output_one_line = Output2[i - 1].Split(" OR ");
                    bool cast_FND = false;
                    string s_word = "";
                    outcastQueries_Un_Efficient(ref s_word, Splited_Line, test_Graph);
                    foreach (string l in output_one_line)
                        if (l == s_word)
                            cast_FND = true;




                    if (cast_FND == false)
                    {
                        Console.WriteLine("Wrong answer at test 1 number :" + i + "  outcastQueries ");
                        flag = false;
                        // break;
                    }
                }
            }
            return flag;

        }
        public static bool Testing_Efficient(bool isoutcastQueries, List<string> synsets, List<string> hypernyms,
    List<string> relationQueries, List<string> outcastQueries, List<string> Output1, List<string> Output2,
    String TestcaseName)
        {
            bool flag = true;
            Graph_Construction_For_Efficient_SCA test_Graph = new Graph_Construction_For_Efficient_SCA(synsets, hypernyms);

            int cases_type_1 = int.Parse(relationQueries[0]);

            for (int i = 1; i <= cases_type_1; i++)
            {
                string[] Splited_Line = relationQueries[i].Split(',');
                string[] output_one_line = Output1[i - 1].Split(',');
                int _dis = 0, _SCA_ID = 0;

                Distans_And_SCA_Efficient(ref _dis, ref _SCA_ID, Splited_Line[0], Splited_Line[1], test_Graph);
                bool fnd = false;
                string[] output_simi_line = output_one_line[1].Split(" OR ");
                foreach (string k in output_simi_line)
                {
                    List<int> output_noun_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(test_Graph.Words, k);
                    foreach (int j in output_noun_synsets)
                    {

                        if (_SCA_ID == j) fnd = true;
                    }
                }
                if (_dis != int.Parse(output_one_line[0]) || !fnd)
                {
                    Console.WriteLine("Wrong answer at test" + TestcaseName + "  number :" + i + "  FND_dis:" + _dis + ", E_dis:" + int.Parse(output_one_line[0]));
                    Console.WriteLine("synset_ID:" + _SCA_ID);
                    flag = false;
                    // break;
                }
            }
            if (isoutcastQueries)
            {
                int cases_type_2 = int.Parse(outcastQueries[0]);
                for (int i = 1; i < cases_type_2; i++)
                {
                    string[] Splited_Line = outcastQueries[i].Split(',');
                    string[] output_one_line = Output2[i - 1].Split(" OR ");
                    bool cast_FND = false;
                    string s_word = "";
                    outcastQueries_Efficient(ref s_word, Splited_Line, test_Graph);
                    foreach (string l in output_one_line)
                        if (l == s_word)
                            cast_FND = true;




                    if (cast_FND == false)
                    {
                        Console.WriteLine("Wrong answer at test 1 number :" + i + "  outcastQueries ");
                        flag = false;
                        // break;
                    }
                }
            }
            return flag;

        }
        public static bool Testing_Efficient_complet(bool isoutcastQueries, List<string> synsets, List<string> hypernyms,
    List<string> relationQueries, List<string> outcastQueries, List<string> Output1, List<string> Output2,
    String TestcaseName)
        {
            bool flag = true;
            Graph_Construction_For_Efficient_SCA test_Graph = new Graph_Construction_For_Efficient_SCA(synsets, hypernyms);

            int cases_type_1 = int.Parse(relationQueries[0]);

            for (int i = 1; i <= cases_type_1; i++)
            {
                string[] Splited_Line = relationQueries[i].Split(',');
                string[] output_one_line = Output1[i - 1].Split(',');
                int _dis = 0, _SCA_ID = 0;

                Distans_And_SCA_Efficient(ref _dis, ref _SCA_ID, Splited_Line[0], Splited_Line[1], test_Graph);
                bool fnd = false;
                string[] output_simi_line = output_one_line[1].Split(" ");
                foreach (string k in output_simi_line)
                {
                    List<int> output_noun_synsets = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(test_Graph.Words, k);
                    foreach (int j in output_noun_synsets)
                    {

                        if (_SCA_ID == j) fnd = true;
                    }
                }
                if (_dis != int.Parse(output_one_line[0]) || !fnd)
                {
                    Console.WriteLine("Wrong answer at test" + TestcaseName + "  number :" + i + "  FND_dis:" + _dis + ", E_dis:" + int.Parse(output_one_line[0]));
                    Console.WriteLine("synset_ID:" + _SCA_ID);
                    flag = false;
                    // break;
                }
            }
            if (isoutcastQueries)
            {
                int cases_type_2 = int.Parse(outcastQueries[0]);
                for (int i = 1; i < cases_type_2; i++)
                {
                    string[] Splited_Line = outcastQueries[i].Split(',');
                    string[] output_one_line = Output2[i - 1].Split(" ");
                    bool cast_FND = false;
                    string s_word = "";
                    outcastQueries_Efficient(ref s_word, Splited_Line, test_Graph);
                    foreach (string l in output_one_line)
                        if (l == s_word)
                            cast_FND = true;




                    if (cast_FND == false)
                    {
                        Console.WriteLine("Wrong answer at test 1 number :" + i + "  outcastQueries ");
                        flag = false;
                        // break;
                    }
                }
            }
            return flag;

        }
    }


}
