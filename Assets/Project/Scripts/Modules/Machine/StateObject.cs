
public abstract class StateObject
{
    public abstract bool Trigger { get; }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}