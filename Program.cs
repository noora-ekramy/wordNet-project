using System;
using System.Collections.Generic;
using System.Text;
namespace wordNet_project
{
    class Program
    {
        static void Main(string[] args)
        {
            #region teating Graph constructors
            Console.WriteLine("Hello World!");
            List<string> lines = new List<string>();
            lines = ReadFromFile.Read_From_File("D:\\level 3\\semester 6\\algorithm\\project\\OneDrive_2022-04-23\\[5] WordNet Semantics\\Testcases\\Testcases\\Sample\\Case1\\Input\\1synsets.txt");
            List<string> lines1 = new List<string>();
            lines1 = ReadFromFile.Read_From_File("D:\\level 3\\semester 6\\algorithm\\project\\OneDrive_2022-04-23\\[5] WordNet Semantics\\Testcases\\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");
            Graph_construction New_Graph = new Graph_construction(lines, lines1);  
            #endregion




        }
    }
}
