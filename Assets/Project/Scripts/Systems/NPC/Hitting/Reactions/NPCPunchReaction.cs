
using System;
using UnityEngine;

public class NPCPunchReaction : HittableReaction
{
    [SerializeField] private Animator animator;
    [SerializeField] private int shoveIndex; 

    public override Type DataType => typeof(PunchHitData);

    public override void Execute(object data)
    {
        if(data is not PunchHitData)
            return;

        animator.SetFloat("right_shove_index", shoveIndex);
        animator.SetTrigger("right_shove");
    }
}