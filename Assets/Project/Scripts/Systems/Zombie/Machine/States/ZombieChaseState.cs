using System.Collections;
using UnityEngine;

public class ZombieChaseState : ZombieState
{
    public ZombieChaseState(ZombieController controller) : base(controller)
    {

    }

    public override void OnEnter()
    {
        
    }

    public override void OnUpdate(float deltaTime)
    {
        float speed = FuzzySpeed.Evaluate(_controller.Hunger, _controller.Thirst);
        _controller.Agent.speed = speed * _controller.SpeedMultiplier;

        Vector3 position = ZombieStrategy.Instance.GetPlayerPosition();
        _controller.Agent.SetDestination(position);
    }

    public override void OnExit()
    {
        
    }
}