
using System;
using UnityEngine;

public class NPCShotReaction : HittableReaction
{
    [SerializeField] private Animator animator;
    [SerializeField] private int shoveIndex; 

    public override Type DataType => typeof(ShotHitData);

    public override void Execute(object data)
    {
        if(data is not ShotHitData)
            return;

        animator.SetFloat("right_shove_index", shoveIndex);
        animator.SetTrigger("right_shove");
    }
}