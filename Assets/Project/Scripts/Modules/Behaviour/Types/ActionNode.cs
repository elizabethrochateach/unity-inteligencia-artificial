using System;

public class ActionNode : BehaviourNode
{
    private Func<BehaviourState> _action;

    public ActionNode(Func<BehaviourState> action)
    {
        _action = action;
    }

    public override BehaviourState Update()
    {
        return _action();
    }
}