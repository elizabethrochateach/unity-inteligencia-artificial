using UnityEngine;
using UnityEngine.AI;


public class ZombieController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    [Header("Fuzzy")]
    [SerializeField] private float health;
    [SerializeField] private float infection;
    [SerializeField] private float hunger;
    [SerializeField] private float thirst;
    [SerializeField] private float height;

    [Header("Settings")]
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float minPatrolDistance;
    [SerializeField] private float maxPatrolDistance;

    private IGraph<IState, StateTransition> _graph;
    private ZombieMachine _machine;

    public NavMeshAgent Agent => agent;
    public float Health => health;
    public float Infection => infection;
    public float Hunger => hunger;
    public float Thirst => thirst;
    public float Height => height;
    public float SpeedMultiplier => speedMultiplier;
    public float MinPatrolDistance => minPatrolDistance;
    public float MaxPatrolDistance => maxPatrolDistance;

    private void Awake()
    {
        _graph = new UnorderedGraph<IState, StateTransition>();
        _machine = new ZombieMachine(_graph, this);
    }

    private void Update()
    {
        _machine.Update(Time.deltaTime);
    }
}