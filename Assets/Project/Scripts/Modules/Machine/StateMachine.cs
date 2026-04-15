
public abstract class StateMachine
{
    private IGraph<StateObject, StateTransition> _graph;
    private StateObject _current;

    public StateMachine(IGraph<StateObject, StateTransition> graph)
    {
        _graph = graph;
    }

    public void Initialize(StateObject initialState)
    {
        _current = initialState;
        _current?.OnEnter();
    }

    public void Update()
    {
        StateTransition[] transitions = _graph.GetNeighbors(_current);
        if(transitions != null || transitions.Length > 0)
        {
            foreach(var transition in transitions)
            {
                if(!transition.Trigger())
                    continue;

                _current?.OnExit();
                _current = transition.Target;
                _current?.OnEnter();
            }
        }

        _current?.OnUpdate();
    }
}