
public abstract class StateMachine<T> where T : StateObject
{
    private IGraph<T> _graph;
    private T _current;

    public StateMachine(IGraph<T> graph)
    {
        _graph = graph;
    }

    public void Initialize(T initialState)
    {
        _current = initialState;
        _current?.OnEnter();
    }

    public void Update()
    {
        T[] neighbors = _graph.GetNeighbors(_current);
        if(neighbors != null || neighbors.Length > 0)
        {
            foreach(var state in neighbors)
            {
                if(!state.Trigger)
                    continue;

                _current?.OnExit();
                _current = state;
                _current?.OnEnter();
            }
        }

        _current?.OnUpdate();
    }
}