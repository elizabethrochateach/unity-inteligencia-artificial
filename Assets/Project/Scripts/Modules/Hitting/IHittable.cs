
using System;

public interface IHittable
{
    public event Action<HittableHitEvent> OnHit;
    public void Hit(object data);
}