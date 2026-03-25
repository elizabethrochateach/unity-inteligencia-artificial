
using System.Collections.Generic;
using System.Linq;

public class UnorderedGraph<T> : IGraph<T>
{
    private Dictionary<T, HashSet<T>> _vertex;

    public UnorderedGraph()
    {
        _vertex = new();
    }

    public void AddVertex(T vertex)
    {
        if(_vertex.ContainsKey(vertex))
            return;
        _vertex.Add(vertex, new HashSet<T>());
    }

    public void RemoveVertex(T vertex)
    {
        if(!_vertex.ContainsKey(vertex))
            return;

        foreach(KeyValuePair<T, HashSet<T>> kvp in _vertex)
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
        if(!_vertex.TryGetValue(from, out HashSet<T> neighbors) || !_vertex.ContainsKey(to))
            return false;
        return neighbors.Contains(to);
    }

    public T[] GetNeighbors(T vertex)
    {
        if(!_vertex.TryGetValue(vertex, out HashSet<T> neighbors))
            return null;
        return neighbors.ToArray();
    }
}