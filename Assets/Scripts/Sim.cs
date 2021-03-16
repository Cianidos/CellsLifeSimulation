// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Simulation;
using System;
using System.Collections;
using UnityEngine;

public class Sim : MonoBehaviour
{
    private Simulation.Behavior _behavior;
    private Coroutine LifeCycleContainer;

    public Behavior Behavior
    {
        get => _behavior;
        set => _behavior = new Simulation.Behavior(value);
    }

    public void OnInstantiationDone()
    {
        LifeCycleContainer = StartCoroutine(nameof(LifeCycleCoroutine));
    }

    private void LifeCycle()
    {
        Behavior.NextInstruction(this);
    }
    private void ReceiveMessage(Message other)
    {
        Behavior.ReactTo(this, other.request);
    }
    private void ReceiveMessageCollide(Sim other)
    {
        Behavior.ReactTo(this, new Request(other, new Simulation.Message("collide")));
    }

    IEnumerator LifeCycleCoroutine()
    {
        yield return new WaitForSeconds(2);
        LifeCycle();
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

        var sim = other.gameObject.GetComponent<Sim>();
        if (message != null)
        {
            ReceiveMessageCollide(sim);
        }
        throw new NotImplementedException();
    }
}