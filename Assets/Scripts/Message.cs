// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using UnityEngine;

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
