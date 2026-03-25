
public abstract class NpcState : StateObject
{
    protected NpcController _controller;

    public NpcState(NpcController controller)
    {
        _controller = controller;
    }
}