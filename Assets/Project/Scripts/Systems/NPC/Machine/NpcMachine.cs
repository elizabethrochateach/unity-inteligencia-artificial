
using Unity.VisualScripting;

public class NpcMachine : StateMachine
{
    private NpcController _controller;

    public NpcMachine(IGraph<StateObject, StateTransition> graph, NpcController controller) : base(graph)
    {
        _controller = controller;

        NpcIdleState idle = new NpcIdleState(controller);
        NpcPatrolState patrol = new NpcPatrolState(controller);
        NpcDeadState dead = new NpcDeadState(controller);

        graph.AddVertex(idle);
        graph.AddVertex(patrol);
        graph.AddVertex(dead);

        StateTransition idleToPatrol = new(patrol, IdleToPatrol);
        graph.AddEdge(idle, idleToPatrol);

        StateTransition patrolToIdle = new(idle, PatrolToIdle);
        graph.AddEdge(patrol, patrolToIdle);

        StateTransition anyToDead = new(dead, AnyToDead);
        graph.AddEdge(idle, anyToDead);
        graph.AddEdge(patrol, anyToDead);

        Initialize(idle);
    }

    private bool IdleToPatrol()
    {
        float alpha = UnityEngine.Random.Range(0.0f, 1.0f);
        return alpha < _controller.ProbailityToPatrol;
    }

    private bool PatrolToIdle()
    {
        return !_controller._isMoving;
    }

    private bool AnyToDead()
    {
        return _controller.Health.Value == 0;
    }
}