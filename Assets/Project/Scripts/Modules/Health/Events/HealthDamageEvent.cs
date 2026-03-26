
public class HealthDamageEvent
{
    public IHealth Health { get; private set; }
    public float Damage { get; private set; }

    public HealthDamageEvent(IHealth health, float damage)
    {
        Health = health;
        Damage = damage;
    }
}