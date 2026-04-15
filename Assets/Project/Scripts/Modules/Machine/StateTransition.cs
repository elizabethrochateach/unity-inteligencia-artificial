
using System;

public class StateTransition
{
    public StateObject Target { get; private set; }
    public Func<bool> Trigger { get; private set; }

    public StateTransition(StateObject target, Func<bool> trigger)
    {
        Target = target;
        Trigger = trigger;
    }
}