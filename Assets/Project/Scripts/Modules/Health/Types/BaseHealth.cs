
using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour, IHealth
{
    public event Action<HealthDamageEvent> OnDamage;
    public event Action<HealthHealEvent> OnHeal;

    [SerializeField] private float value;
    [SerializeField] private float maxValue;

    public float Value => value;
    public float MaxValue => maxValue;

    public void Damage(float amount)
    {
        if(amount <= 0)
            return;

        float damage = Mathf.Clamp(amount, 0, value);
        value -= damage;

        var evt = new HealthDamageEvent(this, damage);
        OnDamage?.Invoke(evt);
    }

    public void Heal(float amount)
    {
        if(amount <= 0)
            return;

        float remaining = maxValue - value;
        float heal = Mathf.Clamp(amount, 0, remaining);
        value += heal;

        var evt = new HealthHealEvent(this, heal);
        OnHeal?.Invoke(evt);
    }
}