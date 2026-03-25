
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    [Header("Idle")]
    [SerializeField] private float minIdleChangeTime;
    [SerializeField] private float maxIdleChangeTime;

    [Header("Patrol")]
    [SerializeField] private float probabilityToPatrol;
    [SerializeField] private float maxPatrolDistance;

    public bool _isMoving;

    public Animator Animator => animator;
    public NavMeshAgent Agent => agent;
    
    public float ProbailityToPatrol => probabilityToPatrol;
    public float MinIdleChangeTime => minIdleChangeTime;
    public float MaxIdleChangeTime => maxIdleChangeTime;
    public float MaxPatrolDistance => maxPatrolDistance;

    private StateMachine<NpcState> _machine;

    private void Awake()
    {
        IGraph<NpcState> _graph = new OrderedGraph<NpcState>();
        _machine = new NpcMachine(_graph, this);
    }

    private void Update()
    {
        _machine.Update();
    }
}