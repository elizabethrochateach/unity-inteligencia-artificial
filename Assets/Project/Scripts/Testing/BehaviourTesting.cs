using System.Collections.Generic;
using UnityEngine;

public class BehaviourTesting : MonoBehaviour
{
    [SerializeField] private bool decisionValue;
    [SerializeField] private bool actionValue;
    [SerializeField] private bool optionAValue;
    [SerializeField] private bool optionBValue;

    private BehaviourNode _root;

    private void Awake()
    {
        _root = new SelectorNode(
            new List<BehaviourNode>(new BehaviourNode[]
            {
                new DecisionNode(() => decisionValue),
                new ActionNode(() =>
                {
                    print("Realizando una acción");
                    return actionValue ? BehaviourState.Success : BehaviourState.Failure;
                }),
                new SequenceNode(new List<BehaviourNode>(new BehaviourNode[]
                {
                    new ActionNode(() =>
                    {
                        print("Realizando opción A");
                        return optionAValue ? BehaviourState.Success : BehaviourState.Failure;
                    }),
                    new ActionNode(() =>
                    {
                        print("Realizando opción B");
                        return optionBValue ? BehaviourState.Success : BehaviourState.Failure;
                    })
                }))
            })
        );
    }

    private void Update()
    {
        _root.Update();
    }
}