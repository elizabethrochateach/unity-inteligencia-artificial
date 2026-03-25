
public class NpcMachine : StateMachine<NpcState>
{
    public NpcMachine(IGraph<NpcState> graph, NpcController controller) : base(graph)
    {
        NpcIdleState idle = new NpcIdleState(controller);
        NpcPatrolState patrol = new NpcPatrolState(controller);
        NpcDeadState dead = new NpcDeadState(controller);

        graph.AddVertex(idle);
        graph.AddVertex(patrol);
        graph.AddVertex(dead);

        graph.AddEdge(idle, patrol);
        graph.AddEdge(patrol, idle);
        graph.AddEdge(idle, dead);
        graph.AddEdge(patrol, dead);

        Initialize(idle);
    }
}