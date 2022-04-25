using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace wordNet_project
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testing Graph constructors
            Console.WriteLine("Hello World!");

            List<string> lines = new List<string>();
            lines = ReadFromFile.Read_From_File("..\\..\\..\\Testcases\\Sample\\Case1\\Input\\1synsets.txt");
            List<string> lines1 = new List<string>();
            lines1 = ReadFromFile.Read_From_File("..\\..\\..\\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");
            Graph_construction New_Graph = new Graph_construction(lines, lines1);
            #endregion

            #region testing Maping Nouns to IDs
            List<int> Maping_Answer = new List<int>();
            Maping_Answer = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs( New_Graph.Words, "a");
            #endregion




        }
    }
}
