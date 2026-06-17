using UnityEngine;

public class ZombieMachine : BaseStateMachine
{
    private ZombieController _controller;

    public ZombieMachine(IGraph<IState, StateTransition> graph, ZombieController controller) : base(graph)
    {
        _controller = controller;

        ZombieAttackState attack = new ZombieAttackState(controller);
        ZombieChaseState chase = new ZombieChaseState(controller);
        ZombiePatrolState patrol = new ZombiePatrolState(controller);

        graph.AddVertex(attack);
        graph.AddVertex(chase);
        graph.AddVertex(patrol);

        StateTransition patrolToChase = new(chase, PatrolToChase);
        graph.AddEdge(patrol, patrolToChase);

        StateTransition chaseToAttack = new(attack, ChaseToAttack);
        graph.AddEdge(chase, chaseToAttack);

        StateTransition attackToChase = new(chase, AttackToChase);
        graph.AddEdge(attack, attackToChase);

        SetState(patrol);
    }

    private bool PatrolToChase()
    {
        float time = ZombieStrategy.Instance.GetTime();
        float range = FuzzyDetection.Evaluate(time, _controller.Height);

        Vector3 playerPosition = ZombieStrategy.Instance.GetPlayerPosition();
        return Vector3.Distance(playerPosition, _controller.transform.position) <= range;
    }

    private bool ChaseToAttack()
    {
        Vector3 playerPosition = ZombieStrategy.Instance.GetPlayerPosition();
        return Vector3.Distance(
            playerPosition, _controller.transform.position) <= _controller.Agent.stoppingDistance;
    }

    private bool AttackToChase()
    {
        return !ChaseToAttack();
    }
}