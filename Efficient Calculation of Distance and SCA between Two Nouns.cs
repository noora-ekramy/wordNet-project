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
            public int dis;
        }
        public struct dic_struct
        {
            public int chiled;
            public int dis;
        }
        public int Distance = 0;
        public int Efficient_SCA_between_Two_Nouns(string noun_W, string noun_V , List<List<int>> Graph ,
            Dictionary<string, List<int>> Words)
        {
            #region initialization
            Dictionary<int, dic_struct> BFS_list_DIC = new Dictionary<int, dic_struct>();
            List<parent_info> BFS_list = new List<parent_info>();
            List<int> synsets_W = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words,noun_W);
            List<int> synsets_V = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words, noun_V);
            for(int i = 0; i < synsets_W.Count; i++ )
                for(int j = 0; j < synsets_V.Count; j++ )
                {
                    if(synsets_W[i] == synsets_V[j])
                    {
                        return synsets_W[i];
                    }
                }

            #region set initial values to BFS_list and BFS_list_DIC

            for(int i = 0; i < synsets_W.Count; i++)
            {
                parent_info W;
                W.name = synsets_W[i];
                W.chiled = 0;
                W.dis = 0;
                dic_struct W_d;
                W_d.chiled = 0;
                W_d.dis = 0;
                BFS_list_DIC[synsets_W[i]] = W_d;
                BFS_list.Add(W);
            }
            
            for(int i = 0; i < synsets_V.Count; i++)
            {
                parent_info V;
                V.name = synsets_V[i];
                V.chiled = 1;
                V.dis = 0;
                dic_struct V_d;
                V_d.chiled = 1;
                V_d.dis = 0;
                BFS_list_DIC[synsets_V[i]] = V_d;
                BFS_list.Add(V);
            }
            
            #endregion

            #endregion

            int ans = BFS(BFS_list, Graph, BFS_list_DIC);

            return ans;
        }
        public int BFS(List<parent_info> BFS_list, List<List<int>> Graph
            , Dictionary<int, dic_struct> BFS_list_DIC)
        {
            int min_dis = 1000000;
            int node = -1;

            for (int i = 0; i < BFS_list.Count; i++)
            {
                for (int j = 0; j < Graph[BFS_list[i].name].Count; j++)
                {
                    if (BFS_list_DIC.ContainsKey(Graph[BFS_list[i].name][j]) == true)
                    {
                        if (BFS_list_DIC[Graph[BFS_list[i].name][j]].chiled == BFS_list[i].chiled)
                        {
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                            Current_Node.dis = Math.Min(BFS_list[i].dis + 1, BFS_list_DIC[Graph[BFS_list[i].name][j]].dis);
                            BFS_list.Add(Current_Node);

                        }
                        else
                        {

                            Distance = BFS_list[i].dis + BFS_list_DIC[Graph[BFS_list[i].name][j]].dis + 1;
                            if (Distance < min_dis)
                            {
                                min_dis = Distance;
                                node = Graph[BFS_list[i].name][j];
                            }
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                            Current_Node.dis = BFS_list[i].dis + 1;
                            BFS_list.Add(Current_Node);
                        }
                    }
                    else
                    {

                        dic_struct cur_dic;
                        cur_dic.chiled = BFS_list[i].chiled;
                        cur_dic.dis = BFS_list[i].dis + 1;
                        BFS_list_DIC[Graph[BFS_list[i].name][j]] = cur_dic;
                        parent_info Current_Node;
                        Current_Node.name = Graph[BFS_list[i].name][j];
                        Current_Node.chiled = BFS_list[i].chiled;
                        Current_Node.dis = BFS_list[i].dis + 1;
                        BFS_list.Add(Current_Node);


                    }

                }
            }
            Distance = min_dis;
            return node;
        }

    }
}
