using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace wordNet_project
{
    class ShortestCommAncestor
    {
        private int shortestAncestorID;
        public int shortestLength;
        public List<int> shortestPath;
        public List<List<int>> Graph;
        private List<List<int>> pathsOf1;
        private List<List<int>> pathsOf2;
        private List<List<int>> commonPaths1;
        private List<List<int>> commonPaths2;
        private List<int> commonParents;
        private Color[] status;

        enum Color
        {
            WHITE,
            GREEN, // For input id1
            BLUE, // For input id2
            BLACK, // For explored input node
            RED // For common
        }

        public ShortestCommAncestor(List<List<int>> Graph)
        {
            this.Graph = Graph;
        }

        // Uses DFS (not optimally)
        public int getSCA(int ID1, int ID2)
        {
            shortestAncestorID = -1;
            shortestLength = int.MaxValue;
            shortestPath = new List<int>();
            commonParents = new List<int>();
            pathsOf1 = new List<List<int>>();
            commonPaths1 = new List<List<int>>();
            commonPaths2 = new List<List<int>>();
            pathsOf2 = new List<List<int>>();
            status = new Color[Graph.Count];

            // Return length 0 as both input nodes are the same one
            if (ID1 == ID2)
            {
                shortestAncestorID = ID1;
                shortestPath.Add(ID1);
                shortestLength = 0;
                return ID1;
            }
            // Initialize all vertices
            for (int i = 0; i < Graph.Count; i++)
                status[i] = Color.WHITE;

            VisitVertexA(ID1, ID2, ID1, ID1);
            VisitVertexA(ID1, ID2, ID2, ID2);
            VisitVertexA(ID1, ID2, ID1, ID1);

            List<int> shortestPath1 = new List<int>();
            List<int> shortestPath2 = new List<int>();
            int minPathLen = int.MaxValue;

            for (int i = 0; i < commonPaths1.Count; i++)
            {
                commonPaths1[i].RemoveAt(commonPaths1[i].Count - 1);
                commonPaths2[i].Reverse();

                if (commonPaths1[i].Count + commonPaths2[i].Count < shortestPath.Count || shortestPath.Count == 0)
                {
                    shortestPath = new List<int>(commonPaths1[i].Count + commonPaths2.Count);
                    shortestPath.AddRange(commonPaths1[i]);
                    shortestPath.AddRange(commonPaths2[i]);
                    shortestAncestorID = commonParents[i];
                    shortestLength = shortestPath.Count - 1;
                }

                commonPaths2[i].Reverse();
            }

            return shortestAncestorID;
        }

        
        // Recursive function to explore vertices
        void VisitVertexA(int ID1, int ID2, int v, int searchID)
        {
            List<int> curPath = new List<int>();
            if (v == ID1)
            {
                List<int> path = new List<int>();
                path.Add(v);
                pathsOf1.Add(path);
            }
            if (v == ID2)
            {
                List<int> path = new List<int>();
                path.Add(v);
                pathsOf2.Add(path);
            }

            // Adds current vertex to current ID1 path
            if (searchID == ID1)
            {
                if (status[v] == Color.BLUE || status[v] == Color.BLACK) // Checks if vertex is a common ancestor
                {
                    List<int> path = new List<int>();
                    path.AddRange(pathsOf1[pathsOf1.Count - 1]);

                    if (!commonParents.Contains(v))
                    {
                        commonParents.Add(v);
                        commonPaths1.Add(path);
                        commonPaths2.Add(new List<int>());
                    }
                    else
                    {
                        if (commonPaths1[commonParents.IndexOf(v)].Count == 0)
                            commonPaths1[commonParents.IndexOf(v)] = path;
                        else if (path.Count < commonPaths1[commonParents.IndexOf(v)].Count)
                            commonPaths1[commonParents.IndexOf(v)] = path;
                    }
                    status[v] = Color.BLACK;
                }
                else
                    status[v] = Color.GREEN;
                curPath.AddRange(pathsOf1[pathsOf1.Count - 1]);
            }
            // Adds current vertex to current ID2 path
            if (searchID == ID2)
            {
                if (status[v] == Color.GREEN || status[v] == Color.BLACK) // Checks if vertex is a common ancestor
                {
                    List<int> path = new List<int>();
                    path.AddRange(pathsOf2[pathsOf2.Count - 1]);
                    
                    if (!commonParents.Contains(v))
                    {
                        commonPaths2.Add(path);
                        commonPaths1.Add(new List<int>());
                        commonParents.Add(v);
                    }
                    else
                    {
                        if (path.Count < commonPaths2[commonParents.IndexOf(v)].Count)
                            commonPaths2[commonParents.IndexOf(v)] = path;
                    }
                    status[v] = Color.BLACK;
                }
                else
                    status[v] = Color.BLUE;
                curPath.AddRange(pathsOf2[pathsOf2.Count - 1]);
            }
            
            foreach (int vertex in Graph[v])
            {
                curPath.Add(vertex);
                
                if (searchID == ID1) // If exploring child vertex of ID1 then add new path for ID2
                {
                    pathsOf1.Add(new List<int>());
                    pathsOf1[pathsOf1.Count - 1].AddRange(curPath);
                }
                if (searchID == ID2) // If exploring child vertex of ID2 then add new path for ID2
                {
                    pathsOf2.Add(new List<int>());
                    pathsOf2[pathsOf2.Count - 1].AddRange(curPath);
                }
                // Explore child vertex
                VisitVertexA(ID1, ID2, vertex, searchID);
                curPath.Remove(vertex);
            }
        }
    }
}
