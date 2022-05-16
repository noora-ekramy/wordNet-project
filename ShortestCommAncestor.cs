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
        private List<List<int>> commonPaths;
        private List<int> commonParents;
        private Color[] status;
        private bool isDirectlyConnected; // For if the two input IDs are direct neighbours

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
            isDirectlyConnected = false;
            shortestAncestorID = -1;
            shortestLength = int.MaxValue;
            shortestPath = new List<int>();
            commonParents = new List<int>();
            pathsOf1 = new List<List<int>>();
            commonPaths = new List<List<int>>();
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

            // Explore all vertices
            for (int v = 0; v < Graph.Count; v++)
            {

                //if (status[v] == Color.WHITE)
                //    VisitVertex(ID1, ID2, v, -1);
                if (v == ID1 || v == ID2)
                    VisitVertexA(ID1, ID2, v, v);
                if (isDirectlyConnected) // End as shortest common ancestor is found
                    return shortestAncestorID;
            }

            List<int> shortestPath1 = new List<int>();
            List<int> shortestPath2 = new List<int>();
            int minPathLen = int.MaxValue;

            foreach (int parent in commonParents)
            {
                // Get shortest path for a common parent in paths of 1
                foreach (List<int> path in pathsOf1)
                {
                    if (path.Contains(parent))
                    {
                        for (int i = path.Count - 1; i > 0; i--)
                        {
                            if (parent != path[i])
                                path.RemoveAt(i);
                            else
                                break;
                        }
                        if (path.Count < minPathLen)
                        {
                            minPathLen = path.Count;
                            shortestPath1 = path;
                            minPathLen = shortestPath1.Count;
                        }
                    }
                }

                minPathLen = int.MaxValue;

                // Get shortest path for a common parent in paths of 2
                foreach (List<int> path in pathsOf2)
                {
                    if (path.Contains(parent))
                    {
                        for (int i = path.Count - 1; i > 0; i--)
                        {
                            if (parent != path[i])
                                path.RemoveAt(i);
                            else
                            {
                                path.RemoveAt(i);
                                break;
                            }
                        }
                        if (path.Count < minPathLen)
                        {
                            minPathLen = path.Count;
                            shortestPath2 = path;
                            minPathLen = shortestPath2.Count;
                        }
                    }
                }
                minPathLen = int.MaxValue;
                commonPaths.Add(new List<int>(shortestPath1.Count + shortestPath2.Count));
                shortestPath2.Reverse();

                commonPaths[commonPaths.Count - 1].AddRange(shortestPath1);
                commonPaths[commonPaths.Count - 1].AddRange(shortestPath2);

                shortestPath2.Reverse();
            }

            int count = 0;
            // Find the shortest path in common paths
            foreach (List<int> path in commonPaths)
            {
                if (path[path.Count - 1] == path[path.Count - 2])
                    path.RemoveAt(path.Count - 1);
                if (path.Count < minPathLen)
                {
                    minPathLen = path.Count;
                    shortestPath = path;
                    shortestAncestorID = commonParents[count];
                    shortestLength = shortestPath.Count - 1;
                }
                count++;
            }
            return shortestAncestorID;
        }

        int pathLength1 = 0;
        int pathLength2 = 0;
        // Recursive function to explore vertices
        void VisitVertexA(int ID1, int ID2, int v, int searchID)
        {
            if (isDirectlyConnected) // Don't explore any more vertices
                return;

            // Adds current vertex to current ID1 path
            if (searchID == ID1)
            {
                pathLength1++;
                if (pathsOf1.Count != 0)
                {
                    pathsOf1[pathsOf1.Count - 1].Add(v);
                }
                if (status[v] == Color.BLUE) // Checks if vertex is a common ancestor
                {
                    if (!commonParents.Contains(v))
                        commonParents.Add(v);
                    status[v] = Color.BLACK;
                }
                else
                    status[v] = Color.GREEN;
            }
            // Adds current vertex to current ID2 path
            if (searchID == ID2)
            {
                pathLength2++;
                if (pathsOf2.Count != 0)
                {
                    pathsOf2[pathsOf2.Count - 1].Add(v);
                }
                if (status[v] == Color.GREEN || status[v] == Color.BLACK) // Checks if vertex is a common ancestor
                {
                    if (!commonParents.Contains(v))
                        commonParents.Add(v);
                    status[v] = Color.BLACK;
                }
                else
                    status[v] = Color.BLUE;
            }

            foreach (int vertex in Graph[v])
            {
                if (v == ID1) // If exploring child vertex of ID1 then add new path for ID2
                {
                    status[v] = Color.GREEN; // Changes color to not revisit
                    List<int> path = new List<int>();
                    path.Add(v);
                    pathsOf1.Add(path);
                    if (vertex == ID2)
                    {
                        isDirectlyConnected = true;
                        shortestAncestorID = ID2;
                        shortestPath.Add(ID2);
                        shortestPath.Add(ID1);
                        shortestLength = 1;
                        return;
                    }
                }
                if (v == ID2) // If exploring child vertex of ID2 then add new path for ID2
                {
                    status[v] = Color.BLUE;  // Changes color to not revisit
                    List<int> path = new List<int>();
                    path.Add(v);
                    pathsOf2.Add(path);
                    if (vertex == ID1) // If the vertex is ID1, then ID1 itself is the shortest ancestor of itself and ID2
                    {
                        isDirectlyConnected = true;
                        shortestAncestorID = ID1;
                        shortestPath.Add(ID1);
                        shortestPath.Add(ID2);
                        shortestLength = 1;
                        return;
                    }
                }
                // Explore child vertex
                VisitVertexA(ID1, ID2, vertex, searchID);
            }
            if (pathLength1 > 0)
                pathLength1--;
            if (pathLength2 > 0)
                pathLength2--;
        }
    }
}
