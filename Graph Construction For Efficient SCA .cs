using System;
using System.Collections.Generic;
using System.Text;

namespace wordNet_project
{
    class Graph_Construction_For_Efficient_SCA
    {
        public Dictionary<string, List<int>> Words;
        public List<List<string>> Synsets;
        public List<List<int>> Graph;
        public int Root;
        //O(N*n + N*A)
        public Graph_Construction_For_Efficient_SCA(List<string> Synsets_Input, List<string> Hypernyms_Input)
        {
            //O(1)
            this.Words = new Dictionary<string, List<int>>();
            //O(1)
            this.Synsets = new List<List<string>>();
            //O(1)
            this.Graph = new List<List<int>>(Synsets_Input.Count);
            //O(N)
            for (int i = 0; i < Synsets_Input.Count; i++)
            {
                Graph.Add(new List<int> { });
            }
            //O(N*A)
            parse_synset_input(Synsets_Input);
            //O(N*N)
            parse_hypernyms_input(Hypernyms_Input);
        }
        //N: number of synsets 
        //A max number of wordes in one synset 
        //O(A*N)
        public void parse_synset_input(List<string> Synsets_Input)
        {
            //loop through all synsets
            //O(A*N)
            foreach (string i in Synsets_Input)
            {
                //O(1)
                List<string> Current_Synset_Words = new List<string>();
                //O(1)
                string[] Splited_Line = i.Split(',');
                //O(1)
                int ID = int.Parse(Splited_Line[0]);
                //O(1)
                Splited_Line = Splited_Line[1].Split(" ");

                // loop trough the senset words
                //O(A)
                foreach (string j in Splited_Line)
                {
                    //O(1)
                    if (Words.ContainsKey(j) == true)
                    {
                        Words[j].Add(ID);
                    }
                    //O(1)
                    else
                    {
                        Words[j] = new List<int>();
                        Words[j].Add(ID);
                    }
       
                }
                //O(1)
                Synsets.Add(Current_Synset_Words);
            }
        }
        //O(N*N)
        public void parse_hypernyms_input(List<string> Hypernyms_Input)
        {
            //loop through all relations
            //O(N*M)
            foreach (string i in Hypernyms_Input)
            {
                //O(1)
                int ID;
                //O(1)
                List<int> Current_Synset_Relations = new List<int>();
                //O(1)
                string[] splited_line = i.Split(',');
                //O(1)
                ID = int.Parse(splited_line[0]);
                //O(1)
                if (splited_line.Length == 1)
                {
                    this.Root = ID;
                    continue;
                }
                //O(N)
                foreach (string j in splited_line)
                {
                    if (int.Parse(j) == ID) continue;
                    Graph[ID].Add(int.Parse(j));
                }


            }
        }
    }
}
