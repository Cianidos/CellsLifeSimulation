using System;
using System.Collections;
using UnityEngine;

public class Sim : MonoBehaviour
{
    public Simulation.Behavior Behavior;
    public Coroutine LifeCycleContainer;

    private void LifeCycle()
    {
        Behavior.NextInstruction(this);
    }
    private void ReceiveMessage(Message other)
    {
        Simulation.Request request = 
            new Simulation.Request(other.CallerSim, other.ValueMessage);
        Behavior.ReactTo(this, request);
    }

    IEnumerator LifeCycleCoroutine()
    {
        LifeCycle();
        yield return new WaitForSeconds(1);
    }

    private void Awake()
    {
        LifeCycleContainer = StartCoroutine(nameof(LifeCycleCoroutine));
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var message = other.gameObject.GetComponent<Message>();
        if (message != null)
        {
            ReceiveMessage(message);
        }
        throw new NotImplementedException();
    }
}