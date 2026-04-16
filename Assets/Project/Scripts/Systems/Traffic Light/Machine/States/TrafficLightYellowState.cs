using System.Collections;
using UnityEngine;

public class TrafficLightYellowState : StateObject
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightYellowState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0;
        _controller.YellowLightRenderer.material.color = Color.yellow;
    }

    public override void OnUpdate()
    {
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
        _controller.YellowLightRenderer.material.color = Color.black;
    }
}