
using System.Collections.Generic;

public class OrderedGraph<TVertex, TEdge> : IGraph<TVertex, TEdge>
{
    private Dictionary<TVertex, List<TEdge>> _vertex;

    public OrderedGraph()
    {
        _vertex = new();
    }

    public void AddVertex(TVertex vertex)
    {
        if(_vertex.ContainsKey(vertex))
            return;
        _vertex.Add(vertex, new List<TEdge>());
    }

    public void RemoveVertex(TVertex vertex)
    {
        if(!_vertex.ContainsKey(vertex))
            return;
        _vertex.Remove(vertex);
    }

    public void AddEdge(TVertex from, TEdge edge)
    {
        if(!_vertex.ContainsKey(from))
            return;
        _vertex[from].Add(edge);
    }

    public void RemoveEdge(TVertex from, TEdge edge)
    {
        if(!_vertex.ContainsKey(from))
            return;
        _vertex[from].Remove(edge);
    }

    public bool HasEdge(TVertex from, TEdge edge)
    {
        if(!_vertex.TryGetValue(from, out List<TEdge> neighbors))
            return false;
        return neighbors.Contains(edge);
    }

    public TEdge[] GetNeighbors(TVertex vertex)
    {
        if(!_vertex.TryGetValue(vertex, out List<TEdge> neighbors))
            return null;
        return neighbors.ToArray();
    }
}