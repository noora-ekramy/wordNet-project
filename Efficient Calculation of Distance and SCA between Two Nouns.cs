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
        //O(A*B + m)
        // where A and B are the number of synsets that each noun belongs to.
        public int Efficient_SCA_between_Two_Nouns(string noun_W, string noun_V , List<List<int>> Graph ,
            Dictionary<string, List<int>> Words)
        {
            #region initialization
            Dictionary<int, dic_struct> BFS_list_DIC = new Dictionary<int, dic_struct>();
            List<parent_info> BFS_list = new List<parent_info>();
            List<int> synsets_W = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words,noun_W);
            List<int> synsets_V = MappingNounToSynsetsIDs.Maping_Noun_To_SynsetsIDs(Words, noun_V);
            //O(A*B)
            for(int i = 0; i < synsets_W.Count; i++ )
                for(int j = 0; j < synsets_V.Count; j++ )
                {
                    if(synsets_W[i] == synsets_V[j])
                    {
                        return synsets_W[i];
                    }
                }
            #region set initial values to BFS_list and BFS_list_DIC
            //O(A)
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
            //O(B)
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
            //O(M)
            int ans = BFS(BFS_list, Graph, BFS_list_DIC);
            return ans;
        }
        public int BFS(List<parent_info> BFS_list, List<List<int>> Graph
          , Dictionary<int, dic_struct> BFS_list_DIC)
        {
            int min_dis = 1000000;
            int node = -1;
            //m = number of visited synsets from W and V till the root
            // loop over the BFS_list
            for (int i = 0; i < BFS_list.Count; i++) // O(m)
            {
                //loop over current sysnset roots
                for (int j = 0; j < Graph[BFS_list[i].name].Count; j++) // in total O(m)
                {
                    #region check if the current sysnet was visted befor
                    if (BFS_list_DIC.ContainsKey(Graph[BFS_list[i].name][j]) == true) //O(1)
                    {
                        #region check if the current synset has the same chiled as its leaves
                        if (BFS_list_DIC[Graph[BFS_list[i].name][j]].chiled == BFS_list[i].chiled)//O(1)
                        {
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                            Current_Node.dis = Math.Min(BFS_list[i].dis + 1, BFS_list_DIC[Graph[BFS_list[i].name][j]].dis);
                            BFS_list.Add(Current_Node);

                        }
                        #endregion
                        #region else a solution was found
                        else//O(1)
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
                        #endregion
                    }
                    #endregion
                    //O(1)
                    #region else add current synset to the BFS_List and BFS_Dic 
                    else//O(1)
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
                    #endregion

                }
            }
            Distance = min_dis;
            return node;
        }

    }
}
