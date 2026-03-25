
public interface IGraph<T>
{
    public void AddVertex(T vertex);
    public void RemoveVertex(T vertex);

    public void AddEdge(T from, T to);
    public void RemoveEdge(T from, T to);
    public bool HasEdge(T from, T to);

    public T[] GetNeighbors(T vertex);
}