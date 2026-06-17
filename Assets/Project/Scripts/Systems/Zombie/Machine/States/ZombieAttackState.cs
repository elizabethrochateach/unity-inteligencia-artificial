using System.Collections;
using UnityEngine;


public class ZombieAttackState : ZombieState
{
    public ZombieAttackState(ZombieController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
       
    }

    public override void OnUpdate(float deltaTime)
    {
        Vector3 playerPosition = ZombieStrategy.Instance.GetPlayerPosition();
        float distance = Vector3.Distance(playerPosition, _controller.transform.position);

        float aggressiveness = FuzzyAggressiveness.Evaluate(
            _controller.Health, distance, _controller.Infection);
        float speed = FuzzySpeed.Evaluate(_controller.Hunger, _controller.Thirst);

        float damage = FuzzyDamage.Evaluate(aggressiveness, speed);
        Debug.Log($"Damage: {damage}");
    }

    public override void OnExit()
    {
        
    }
}