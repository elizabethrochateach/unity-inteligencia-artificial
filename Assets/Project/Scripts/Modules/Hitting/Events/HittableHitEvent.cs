
public class HittableHitEvent
{
    public IHittable Hittable { get; private set; }
    public object Data { get; private set; }

    public HittableHitEvent(IHittable hittable, object data)
    {
        Hittable = hittable;
        Data = data;
    }
}