
public interface IGraph<TVertex, TEdge>
{
    public void AddVertex(TVertex vertex);
    public void RemoveVertex(TVertex vertex);

    public void AddEdge(TVertex from, TEdge edge);
    public void RemoveEdge(TVertex from, TEdge edge);
    public bool HasEdge(TVertex from, TEdge edge);

    public TEdge[] GetNeighbors(TVertex vertex);
}