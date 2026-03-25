
using System.Collections.Generic;

public class OrderedGraph<T> : IGraph<T>
{
    private Dictionary<T, List<T>> _vertex;

    public OrderedGraph()
    {
        _vertex = new();
    }

    public void AddVertex(T vertex)
    {
        if(_vertex.ContainsKey(vertex))
            return;
        _vertex.Add(vertex, new List<T>());
    }

    public void RemoveVertex(T vertex)
    {
        if(!_vertex.ContainsKey(vertex))
            return;

        foreach(KeyValuePair<T, List<T>> kvp in _vertex)
        {
            RemoveEdge(kvp.Key, vertex);
            RemoveEdge(vertex, kvp.Key);
        }

        _vertex.Remove(vertex);
    }

    public void AddEdge(T from, T to)
    {
        if(!_vertex.ContainsKey(from) || !_vertex.ContainsKey(to))
            return;
        _vertex[from].Add(to);
    }

    public void RemoveEdge(T from, T to)
    {
        if(!_vertex.ContainsKey(from) || !_vertex.ContainsKey(to))
            return;
        _vertex[from].Remove(to);
    }

    public bool HasEdge(T from, T to)
    {
        if(!_vertex.TryGetValue(from, out List<T> neighbors) || !_vertex.ContainsKey(to))
            return false;
        return neighbors.Contains(to);
    }

    public T[] GetNeighbors(T vertex)
    {
        if(!_vertex.TryGetValue(vertex, out List<T> neighbors))
            return null;
        return neighbors.ToArray();
    }
}