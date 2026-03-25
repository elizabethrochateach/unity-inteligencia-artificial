
public class AdjacencyMatrixGraph
{
    private bool[,] _adjacencies;

    public AdjacencyMatrixGraph(int vertexCount)
    {
        _adjacencies = new bool[vertexCount, vertexCount];
    }

    public void AddEdge(int from, int to)
    {
        if(IsNotInRange(from) || IsNotInRange(to))
            return;
        _adjacencies[from, to] = true;
    }

    public bool HasEdge(int from, int to)
    {
        if(IsNotInRange(from) || IsNotInRange(to))
            return false;
        return _adjacencies[from, to];
    }

    private bool IsNotInRange(int index)
    {
        return index < 0 || index >= _adjacencies.Length;
    }
}