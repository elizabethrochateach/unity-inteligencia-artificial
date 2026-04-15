
using System.Collections.Generic;
using UnityEngine;

public class GraphTesting : MonoBehaviour
{
    private void Awake()
    {
        UnorderedGraph<char, char> charGraph = new UnorderedGraph<char, char>();

        charGraph.AddVertex('a');
        charGraph.AddVertex('b');
        charGraph.AddVertex('c');
        charGraph.AddVertex('d');
        charGraph.AddVertex('e');
        charGraph.AddVertex('f');

        charGraph.AddEdge('a', 'c');
        charGraph.AddEdge('a', 'f');
        charGraph.AddEdge('a', 'b');

        charGraph.AddEdge('b', 'c');
        charGraph.AddEdge('b', 'd');

        charGraph.AddEdge('c', 'a');
        charGraph.AddEdge('c', 'f');

        charGraph.AddEdge('d', 'a');
        charGraph.AddEdge('d', 'c');

        charGraph.AddEdge('e', 'a');

        charGraph.AddEdge('f', 'c');

        char[] vertex = new char[]{'a', 'b', 'c', 'd', 'e', 'f'};
        PrintGraph(vertex, charGraph);

        charGraph.RemoveVertex('a');
        PrintGraph(vertex, charGraph);
    }

    private void PrintGraph<T>(T[] vertex, IGraph<T, T> graph)
    {
        foreach(T v in vertex)
        {
            T[] neighbors = graph.GetNeighbors(v);
            if(neighbors == null)
                continue;

            string result = "";
            foreach(T n in neighbors)
                result += n;

            print($"{v}: {result}");
        }
    }
}