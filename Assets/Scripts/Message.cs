// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using UnityEngine;

/// <summary>
/// Represent non-material object, that carries <see cref="Simulation.Request"/> to <see cref="Sim"/>s.
/// Part of Reaction model, that transfer signals between Sims.
/// </summary>
class Message : MonoBehaviour
{
    public Simulation.Request request;
    public float lifeTime;

    private void Awake()
    {
        Invoke(nameof(SelfDestruction), lifeTime);
    }

    private void SelfDestruction()
    {
        Destroy(this);
    }
}
