using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrolState : ZombieState
{
    private Vector3 _target;

    public ZombiePatrolState(ZombieController controller) : base(controller)
    {

    }

    public override void OnEnter()
    {
        _target = GenerateTarget();
        _controller.Agent.SetDestination(_target);
    }

    public override void OnUpdate(float deltaTime)
    {
        float speed = FuzzySpeed.Evaluate(_controller.Hunger, _controller.Thirst);
        _controller.Agent.speed = speed * _controller.SpeedMultiplier;

        float distace = Vector3.Distance(_controller.transform.position, _target);
        if (distace <= 0.1f)
        {
            _target = GenerateTarget();
            _controller.Agent.SetDestination(_target);
        }
    }

    public override void OnExit()
    {
        
    }

    private Vector3 GenerateTarget()
    {
        float distance = Random.Range(_controller.MinPatrolDistance, _controller.MaxPatrolDistance);
        Vector3 position = _controller.transform.position + Random.onUnitSphere * distance;
        if(!NavMesh.SamplePosition(position, out var hit, _controller.MaxPatrolDistance, NavMesh.AllAreas))
            return _controller.transform.position;
        return hit.position;
    }
}