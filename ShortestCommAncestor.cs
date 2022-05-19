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
        private List<int> pathRecorded;
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
        }

        public ShortestCommAncestor(List<List<int>> Graph)
        {
            this.Graph = Graph;
        }

        // Uses DFS (not optimally)
        public int getSCA(int ID1, int ID2) // Total = O(M^2*C)
        {
            shortestAncestorID = -1;
            shortestLength = int.MaxValue;
            shortestPath = new List<int>();
            commonParents = new List<int>();
            pathRecorded = new List<int>();
            commonPaths1 = new List<List<int>>();
            commonPaths2 = new List<List<int>>();
            status = new Color[Graph.Count];

            // Return length 0 as both input nodes are the same one
            if (ID1 == ID2) // O(1)
            {
                shortestAncestorID = ID1;
                shortestPath.Add(ID1);
                shortestLength = 0;
                return ID1;
            }

            // First DFS visit colors all ancestors of first synset
            VisitVertexA(ID1, ID2, ID1, ID1); // O(M^2*C)
            pathRecorded = new List<int>();
            // Second DFS visit colors all ancestors of second synset and detects it's common paths and ancestors
            VisitVertexA(ID1, ID2, ID2, ID2); // O(M^2*C)
            pathRecorded = new List<int>();
            // Third DFS visit detects common paths of first synset
            VisitVertexA(ID1, ID2, ID1, ID1); // O(M^2*C)
            pathRecorded = new List<int>();

            List<int> shortestPath1 = new List<int>();
            List<int> shortestPath2 = new List<int>();

            // Joins and finds minimum path from all common paths
            for (int i = 0; i < commonPaths1.Count; i++) // O(M), Total = O(M^2)
            {
                commonPaths1[i].RemoveAt(commonPaths1[i].Count - 1);
                commonPaths2[i].Reverse(); // O(M)

                if (commonPaths1[i].Count + commonPaths2[i].Count < shortestPath.Count || shortestPath.Count == 0)
                {
                    shortestPath = new List<int>(commonPaths1[i].Count + commonPaths2.Count);
                    shortestPath.AddRange(commonPaths1[i]); // O(M)
                    shortestPath.AddRange(commonPaths2[i]); // O(M)
                    shortestAncestorID = commonParents[i];
                    shortestLength = shortestPath.Count - 1;
                }

                commonPaths2[i].Reverse(); // O(M)
            }
            return shortestAncestorID;
        }

        
        // Recursive function to explore vertices
        void VisitVertexA(int ID1, int ID2, int v, int searchID) // O(M), Total = O(M^2*C)
        {
            List<int> curPath = new List<int>();
            if (v == ID1 && searchID == ID1) // O(1)
            {
                pathRecorded.Add(v);
            }
            else if (v == ID2 && searchID == ID2) // O(1)
            {
                pathRecorded.Add(v);
            }

            // Adds current vertex to current ID1 path
            if (searchID == ID1)
            {
                if (status[v] == Color.BLUE || status[v] == Color.BLACK) // Checks if vertex is a common ancestor
                {
                    List<int> path = new List<int>();
                    path.AddRange(pathRecorded); // O(M)

                    // Detects if common parent is already recorded
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
                curPath.AddRange(pathRecorded); // O(M)
            }
            // Adds current vertex to current ID2 path
            if (searchID == ID2)
            {
                if (status[v] == Color.GREEN || status[v] == Color.BLACK) // Checks if vertex is a common ancestor
                {
                    List<int> path = new List<int>();
                    path.AddRange(pathRecorded); // O(M)

                    // Detects if common parent is already recorded
                    if (!commonParents.Contains(v)) // O(M)
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
                curPath.AddRange(pathRecorded); // O(M)
            }
            foreach (int vertex in Graph[v]) // O(C), Total O(M*C)
            {
                curPath.Add(vertex);

                pathRecorded.Clear();
                pathRecorded.AddRange(curPath); // O(M)

                // Explore child vertex
                VisitVertexA(ID1, ID2, vertex, searchID);
                curPath.Remove(vertex);
            }
        }
    }
}
