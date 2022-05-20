using System;
using System.Collections.Generic;
using System.Text;

namespace wordNet_project
{
    public class Efficient_SCA
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
        //O(m)

        public int Efficient_Shortest_Common_Ancestor(int synset_W, int synset_V,
           List<List<int>> Graph)
        {
            //O(1)
            Distance = 0;
            if (synset_W == synset_V)
                return synset_W;
            //O(1)
            #region initialization
            //O(1)
            Dictionary<int, dic_struct> BFS_list_DIC = new Dictionary<int, dic_struct>();
            //O(1)
            List<parent_info> BFS_list = new List<parent_info>();
            //O(1)
            #region set initial values to BFS_list and BFS_list_DIC

            parent_info W;
            dic_struct W_d;
            W.name = synset_W;
            W.chiled = synset_W;
            W.dis = 0;
            W_d.chiled = synset_W;
            W_d.dis = 0;
            BFS_list.Add(W);

            parent_info V;
            dic_struct V_d;
            V_d.chiled = synset_V;
            V_d.dis = 0;
            V.name = synset_V;
            V.chiled = synset_V;
            V.dis = 0;
            BFS_list_DIC[synset_W] = W_d;
            BFS_list_DIC[synset_V] = V_d;
            BFS_list.Add(V);
            #endregion

            #endregion
            //O(m)
            int ans = BFS(BFS_list, Graph, BFS_list_DIC);
            //O(1)
            return ans;
        }
        //O(m)
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
