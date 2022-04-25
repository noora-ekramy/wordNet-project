using System;
using System.Collections.Generic;
using System.Text;

namespace wordNet_project
{
    class Efficient_Calculation_of_Distance_and_SCA_between_Two_Nouns
    {

        public struct parent_info
        {
            public int name;
            public int chiled;
        }
        public static int Efficient_SCA_between_Two_Nouns(string noun_W, string noun_V , List<List<int>> Graph ,
            Dictionary<string, List<int>> Words)
        {
            #region initialization
            Dictionary<int, int> BFS_list_DIC = new Dictionary<int, int>();
            List<parent_info> BFS_list = new List<parent_info>();
            List<int> synsets_W = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words,noun_W);
            List<int> synsets_V = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words, noun_V);

            #region set initial values to BFS_list and BFS_list_DIC

            for(int i = 0; i < synsets_W.Count; i++)
            {
                parent_info W;
                W.name = synsets_W[i];
                W.chiled = synsets_W[i];
                BFS_list_DIC[synsets_W[i]] = synsets_W[i];
                BFS_list.Add(W);
            }
            
            for(int i = 0; i < synsets_V.Count; i++)
            {
                parent_info V;
                V.name = synsets_V[i];
                V.chiled = synsets_V[i];
                BFS_list_DIC[synsets_V[i]] = synsets_V[i];
                BFS_list.Add(V);
            }
            
            #endregion

            #endregion

            int ans = BFS(BFS_list, Graph, BFS_list_DIC);

            return ans;
        }
        public static int BFS(List<parent_info> BFS_list, List<List<int>> Graph , Dictionary<int, int> BFS_list_DIC)
        {

            for (int i = 0; i < BFS_list.Count; i++)
            {
                for (int j = 0; j < Graph[BFS_list[i].name].Count; j++)
                {
                    if (BFS_list_DIC.ContainsKey(Graph[BFS_list[i].name][j]) == true)
                    {
                        if (BFS_list_DIC[Graph[BFS_list[i].name][j]] == BFS_list[i].chiled)
                        {
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                        }
                        else
                        {
                            return Graph[BFS_list[i].name][j];
                        }
                    }
                    else
                    {
                        BFS_list_DIC[Graph[BFS_list[i].name][j]] = BFS_list[i].chiled;
                        parent_info Current_Node;
                        Current_Node.name = Graph[BFS_list[i].name][j];
                        Current_Node.chiled = BFS_list[i].chiled;
                        BFS_list.Add(Current_Node);

                    }

                }
            }
            return -1;
        }
    }
}
