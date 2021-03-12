// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using UnityEngine;

namespace Simulation
{
    public class Instantiator : MonoBehaviour
    {
        public static GameObject SimPrefab;
        public static GameObject MessagePrefab;

        public static void InstantiateSim(Behavior behavior, Vector3 position)
        {
            var obj = Instantiate(SimPrefab, position, Quaternion.identity);
            obj.AddComponent<Sim>();
            var sim = obj.GetComponent<Sim>();
            sim.Behavior = behavior;
        }

        public static void InstantiateMessage(Request request, float lifeTimeInSeconds, float radius)
        {
            var obj = Instantiate(MessagePrefab, request.Author.transform.position,
                Quaternion.identity);
            obj.AddComponent<global::Message>();
            var mesComponent = obj.GetComponent<global::Message>();
            mesComponent.lifeTime = lifeTimeInSeconds;
            mesComponent.request = request;
            obj.transform.localScale = Vector3.one * radius;
        }
    }
}
