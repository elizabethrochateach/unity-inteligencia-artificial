
using System.Collections.Generic;

public class SelectorNode : BehaviourNode
{
    private List<BehaviourNode> _children;

    public SelectorNode(List<BehaviourNode> children)
    {
        _children = children;
    }

    public override BehaviourState Update()
    {
        foreach(var child in _children)
        {
            BehaviourState state = child.Update();

            if(state == BehaviourState.Success)
                return BehaviourState.Success;

            if(state == BehaviourState.Running)
                return BehaviourState.Running;
        }

        return BehaviourState.Failure;
    }
}