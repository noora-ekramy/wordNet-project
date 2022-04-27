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

            #region testing Graph Construction for Efficient SCA
            Graph_Construction_For_Efficient_SCA New_Graph_E = new Graph_Construction_For_Efficient_SCA(lines, lines1);
            #endregion

            #region test Efficient SCA
            List<string> s = new List<string>
            {
            "0,0,0",
            "1,1,1",
            "2,2,2",
            "3,3,3",
            "4,4,4",
            "5,5,5",
            "6,6,6",
            "7,7,7",
            "8,8,8",
            "9,9,9",
            "10,10,10",
            "11,11,11",
            "12,12,12",
            "13,13,13",
            "14,14,14",
            "15,15,15",
            "16,16,16"
            };
            List<string> s1 = new List<string>
            {
            "0",
            "1,0",
            "2,1",
            "3,1",
            "4,2",
            "5,2",
            "6,2,3",
            "7,3",
            "8,4",
            "9,4",
            "10,4,6",
            "11,6",
            "12,7",
            "13,7",
            "14,8",
            "15,8",
            "16,0"
            };
            New_Graph_E = new Graph_Construction_For_Efficient_SCA(s, s1);
            int ans = Efficient_SCA.Efficient_Shortest_Common_Ancestor(1 ,16 , New_Graph_E.Graph);
            #endregion

            #region testing Mapping SynsetsID To Nouns
            List<string> Maping_AnswerFor1 = new List<string>();
            Maping_AnswerFor1 = MappingSynsetsIDToNouns.Mapping_SynsetsID_To_Nouns( New_Graph.Synsets, 1);
            #endregion


        }
    }
}
