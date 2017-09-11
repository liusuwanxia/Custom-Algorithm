using System;
using System.Collections.Generic;

namespace Custom_Algorithm
{
    public class BreadthFirstSearch
    {
        public static bool BFS(Dictionary<string, string[]> graph, string start)
        {
            //init queue
            Queue<string> queue = new Queue<string>();
            foreach (string node in graph[start])
            {
                queue.Enqueue(node);
            }
            //init processed node list
            List<string> processed = new List<string>();

            while (queue.Count != 0)
            {
                string node = queue.Dequeue();

                if (processed.Contains(node)) continue;

                if (node.EndsWith("m"))
                {
                    Console.WriteLine(node + "is a mango seller");
                    return true;
                }
                else
                {
                    Console.WriteLine(node);
                    string[] more = graph[node];
                    foreach (var item in more)
                    {
                        queue.Enqueue(item);
                    }
                    processed.Add(node);
                }
            }
            return false;
        }

        public static void InitGraph()
        {
            Dictionary<string, string[]> graph = new Dictionary<string, string[]>();
            string[] you_relation = { "bob", "alice", "claire" };
            graph["you"] = you_relation;
            string[] bob_relation = { "anuj", "peggy" };
            graph["bob"] = bob_relation;
            string[] alice_relation = { "peggy" };
            graph["alice"] = alice_relation;
            string[] claire_relation = { "jonny", "thom" };
            graph["claire"] = claire_relation;
            string[] anuj_relation = { };
            graph["anuj"] = anuj_relation;
            string[] peggy_relation = { };
            graph["peggy"] = peggy_relation;
            string[] thom_relatioon = { };
            graph["thom"] = thom_relatioon;
            graph["jonny"] = thom_relatioon;

            bool isSearched = BreadthFirstSearch.BFS(graph, "you");
            Console.WriteLine(isSearched);
        }
    }
}
