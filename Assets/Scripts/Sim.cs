// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using Simulation;
using System.Collections;
using UnityEngine;


/// <summary>
/// Central class of simulation.
/// It is actor, agent, that is main object of simulation.
/// Sim represent actor with <see cref="Simulation.Behavior"/>.
/// Behavior determine what Sim do smt and when Sim do smt.
/// </summary>
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
    /// <summary>
    /// Method calls when Sim collides with <c>Message</c> object
    /// </summary>
    /// <param name="other"></param>
    private void ReceiveMessage(Message other)
    {
        Behavior.ReactTo(this, other.request);
    }
    /// <summary>
    /// Method calls when Sim collides with other Sim
    /// </summary>
    /// <param name="other"></param>
    private void ReceiveMessageCollide(Sim other)
    {
        Behavior.ReactTo(this, new Request(other, new Simulation.MessageTag("collide")));
    }

    IEnumerator LifeCycleCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        LifeCycle();
    }

    private void Update()
    {
    }

    /// <summary>
    /// Unity Message method. Used in Message system as message handler.
    /// </summary>
    /// <param name="other"></param>
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
    }
}