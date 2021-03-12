﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
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
        Behavior.ReactTo(this, other.request);
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