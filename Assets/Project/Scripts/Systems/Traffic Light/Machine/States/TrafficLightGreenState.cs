using System.Collections;
using UnityEngine;

public class TrafficLightGreenState : StateObject
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightGreenState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0;
        _controller.GreenLightRenderer.material.color = Color.green;
    }

    public override void OnUpdate()
    {
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
        _controller.GreenLightRenderer.material.color = Color.black;
    }
}