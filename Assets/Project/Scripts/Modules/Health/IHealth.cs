
using System;

public interface IHealth
{
    public event Action<HealthDamageEvent> OnDamage;
    public event Action<HealthHealEvent> OnHeal;

    public float Value { get; }
    public float MaxValue { get; }

    public void Damage(float amount);
    public void Heal(float amount);
}