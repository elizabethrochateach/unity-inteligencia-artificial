using System.Collections.Generic;

public class SequenceNode : BehaviourNode
{
    private List<BehaviourNode> _children;
    private int _current;

    public SequenceNode(List<BehaviourNode> children)
    {
        _children = children;
    }

    public override BehaviourState Update()
    {
        for(; _current<_children.Count; _current++)
        {
            BehaviourState state = _children[_current].Update();

            if(state == BehaviourState.Running)
                return BehaviourState.Running;

            if(state == BehaviourState.Failure)
            {
                _current = 0;
                return BehaviourState.Failure;
            }
        }

        _current = 0;
        return BehaviourState.Success;
    }
}