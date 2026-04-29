
using System;

public class DecisionNode : BehaviourNode
{
    private Func<bool> _decision;

    public DecisionNode(Func<bool> decision)
    {
        _decision = decision;
    }

    public override BehaviourState Update()
    {
        return _decision() ? BehaviourState.Success : BehaviourState.Failure;
    }
}