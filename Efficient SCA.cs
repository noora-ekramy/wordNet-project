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
        public  int Distance=0;
        public int Efficient_Shortest_Common_Ancestor(int synset_W , int synset_V ,
           List<List<int>> Graph )
        {
                
            Distance = 0;
            if (synset_W == synset_V)
                return synset_W;
            #region initialization
            Dictionary<int , dic_struct> BFS_list_DIC = new  Dictionary<int, dic_struct>();
            List<parent_info> BFS_list = new List<parent_info>();
            
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
            int ans = BFS(BFS_list, Graph, BFS_list_DIC);
            return ans;
        }
        public int BFS(List<parent_info> BFS_list , List<List<int>> Graph
             , Dictionary<int, dic_struct> BFS_list_DIC )
        {
            int min_dis = 1000000;
            int node = -1;
            for(int i = 0; i < BFS_list.Count; i++ )
            {
                for(int j =0; j < Graph[BFS_list[i].name].Count; j++)
                {
                    if(BFS_list_DIC.ContainsKey(Graph[BFS_list[i].name][j])==true)
                    {
                        if(BFS_list_DIC[Graph[BFS_list[i].name][j]].chiled== BFS_list[i].chiled)
                        {
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                            Current_Node.dis=Math.Min( BFS_list[i].dis+1, BFS_list_DIC[Graph[BFS_list[i].name][j]].dis);
                            BFS_list.Add(Current_Node);
                        }
                        else
                        {
                            
                            Distance = BFS_list[i].dis + BFS_list_DIC[Graph[BFS_list[i].name][j]].dis +1;
                            if (Distance < min_dis)
                            {
                                min_dis = Distance;
                                node = Graph[BFS_list[i].name][j];
                            }
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
