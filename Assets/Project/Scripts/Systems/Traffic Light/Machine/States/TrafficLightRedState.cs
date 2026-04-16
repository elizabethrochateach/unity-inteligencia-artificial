using System.Collections;
using UnityEngine;

public class TrafficLightRedState : StateObject
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightRedState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0;
        _controller.RedLightRenderer.material.color = Color.red;
    }

    public override void OnUpdate()
    {
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
        _controller.RedLightRenderer.material.color = Color.black;
    }
}