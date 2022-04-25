using System;
using System.Collections.Generic;
using System.Text;

namespace wordNet_project
{
    class Efficient_SCA
    {
        public struct parent_info
        {
            public int name;
            public int chiled;
        }
        public static int Efficient_Shortest_Common_Ancestor(int synset_W , int synset_V ,
           List<List<int>> Graph )
        {
            #region initialization
            Dictionary<int , int> BFS_list_DIC = new  Dictionary<int, int>();
            List<parent_info> BFS_list = new List<parent_info>();
            #region set initial values to BFS_list and BFS_list_DIC
            parent_info W;
            W.name = synset_W;
            W.chiled = synset_W;
            BFS_list.Add(W);
            parent_info V;
            V.name = synset_V;
            V.chiled = synset_V;
            BFS_list_DIC[synset_W] = synset_W;
            BFS_list_DIC[synset_V] = synset_V;
            BFS_list.Add(V);
            #endregion
            #endregion
            int ans = BFS(BFS_list, Graph, BFS_list_DIC);
            return ans;
        }
        public static int BFS(List<parent_info> BFS_list , List<List<int>> Graph
             , Dictionary<int, int> BFS_list_DIC )
        {

            for(int i = 0; i < BFS_list.Count; i++ )
            {
                for(int j =0; j < Graph[BFS_list[i].name].Count; j++)
                {
                    if(BFS_list_DIC.ContainsKey(Graph[BFS_list[i].name][j])==true)
                    {
                        if(BFS_list_DIC[Graph[BFS_list[i].name][j]]== BFS_list[i].chiled)
                        {
                            parent_info Current_Node;
                            Current_Node.name = Graph[BFS_list[i].name][j];
                            Current_Node.chiled = BFS_list[i].chiled;
                            BFS_list.Add(Current_Node);
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
