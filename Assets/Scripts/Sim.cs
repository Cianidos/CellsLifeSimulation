using System;
using UnityEngine;

public class Sim : MonoBehaviour
{
    public Simulation.Behavior Behavior;


    private void LifeCycle()
    {
        Behavior.NextInstruction()(this);
    }
    private void ReceiveMessage(Message other)
    {
        Simulation.Request request = new Simulation.Request(other.CallerSim, other.ValueMessage);
        Behavior.ReactTo(this, request);
    }

    private void Update()
    {
        LifeCycle();
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