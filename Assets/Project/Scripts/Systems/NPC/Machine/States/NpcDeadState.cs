
using UnityEngine;

public class NpcDeadState : NpcState
{
    public NpcDeadState(NpcController controller) : base(controller)
    {
        
    }

    public override void OnEnter()
    {
        Debug.Log("Enter Dead");

        _controller.Animator.SetBool("dead", true);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        
    }
}