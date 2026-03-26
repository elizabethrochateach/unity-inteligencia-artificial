
using System;
using UnityEngine;

public abstract class HittableReaction : MonoBehaviour
{
    public abstract Type DataType { get; }
    public abstract void Execute(object data);
}