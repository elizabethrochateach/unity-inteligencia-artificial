
using System;
using System.Collections.Generic;
using UnityEngine;

public class HandledHittable : MonoBehaviour, IHittable
{
    public event Action<HittableHitEvent> OnHit;

    [SerializeField] private HittableReaction[] reactions;

    private Dictionary<Type, HittableReaction> _reactionsByType;

    private void Awake()
    {
        _reactionsByType = new();
        foreach(var reaction in reactions)
            _reactionsByType.Add(reaction.DataType, reaction);
    }

    public void Hit(object data)
    {
        if(data == null)
            return;

        Type dataType = data.GetType();
        if(_reactionsByType.TryGetValue(dataType, out var reaction))
            reaction.Execute(data);

        var evt = new HittableHitEvent(this, data);
        OnHit?.Invoke(evt);
    }
}