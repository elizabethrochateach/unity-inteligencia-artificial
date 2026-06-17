
public abstract class ZombieState : IState
{
    protected ZombieController _controller;

    public ZombieState(ZombieController controller)
    {
        _controller = controller;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate(float deltaTime);
    public abstract void OnExit();
    
}