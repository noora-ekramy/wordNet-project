using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace wordNet_project
{
    class Graph_construction
    {
       
        public Dictionary<string ,  List<int>> Words;
        public List<List<string>> Synsets;
        public List<List<int>> Graph;
        public int Root;
        public Graph_construction(List<string> Synsets_Input, List<string> Hypernyms_Input)
        {
            this.Words = new Dictionary<string, List<int>>();
            this.Synsets = new List<List<string>>();
            this.Graph = new List<List<int>>(Synsets_Input.Count);
            for (int i = 0; i < Synsets_Input.Count; i++)
            {
                Graph.Add(new List<int> { });
            }
            parse_synset_input(Synsets_Input);
            parse_hypernyms_input(Hypernyms_Input);
        }
        public void parse_synset_input(List<string> Synsets_Input)
        {
            //loop through all synsets
            foreach(string i in Synsets_Input )
            {
                List<string> Current_Synset_Words=new List<string>();
                string [] Splited_Line = i.Split(',');
                int ID = int.Parse(Splited_Line[0]);
                Splited_Line = Splited_Line[1].Split(" ");

                // loop trough the senset words
                foreach(string j in Splited_Line)
                {
                    string[] splited_words = j.Split("_");
                    //loop trrough all the words word
                    foreach (string k in splited_words)
                    {
                        Current_Synset_Words.Add(k);
                        if( Words.ContainsKey(k) == true)
                        {
                            Words[k].Add(ID);
                        }
                        else
                        {
                            Words[k] = new List<int>();
                            Words[k].Add(ID);
                        }
                            
                            
                    }
                }

                Synsets.Add(Current_Synset_Words);
            }
        }
        public void parse_hypernyms_input(List<string> Hypernyms_Input)
        {
            //loop through all relations
            foreach (string i in Hypernyms_Input)
            {
                int ID;
                List<int> Current_Synset_Relations = new List<int>();
                string[] splited_line = i.Split(',');
                ID = int.Parse(splited_line[0]);
                if (splited_line.Length == 1)
                {
                    this.Root = ID;
                    continue;
                }
                foreach (string j in splited_line)
                {
                    if (int.Parse(j) == ID) continue;
                    Graph[int.Parse(j)].Add(ID);
                }

                
            }
        }
    }
}
