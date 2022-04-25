using System;
using System.Collections.Generic;
using System.Text;
namespace wordNet_project
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testing Graph constructors
            Console.WriteLine("Hello World!");
            List<string> lines = new List<string>();
            lines = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Testcases\\Sample\\Case1\\Input\\1synsets.txt");
            List<string> lines1 = new List<string>();
            lines1 = ReadFromFile.Read_From_File("C:\\Users\\User\\OneDrive\\Desktop\\Testcases\\Sample\\Case1\\Input\\2hypernyms.txt");
            Graph_construction New_Graph = new Graph_construction(lines, lines1);
            #endregion

            #region testing Maping Nouns to IDs
            List<int> Maping_Answer = new List<int>();
            Maping_Answer = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs( New_Graph.Words, "a");
            #endregion

            #region testing Mapping SynsetsID To Nouns
            List<string> Maping_AnswerFor1 = new List<string>();
            Maping_AnswerFor1 = MappingSynsetsIDToNouns.Mapping_SynsetsID_To_Nouns( New_Graph.Synsets, 1);
            #endregion



        }
    }
}
