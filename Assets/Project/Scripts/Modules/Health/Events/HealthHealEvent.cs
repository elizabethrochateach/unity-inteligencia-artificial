
public class HealthHealEvent
{
    public IHealth Health { get; private set; }
    public float Heal { get; private set; }

    public HealthHealEvent(IHealth health, float heal)
    {
        Health = health;
        Heal = heal;
    }
}