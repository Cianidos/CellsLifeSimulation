// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Simulation
{
    public class Instantiator : MonoBehaviour
    {
        private void Awake()
        {
            _SimPrefab = SimPrefab;
            _MessagePrefab = MessagePrefab;
        }

        private static GameObject _SimPrefab; 
        private static GameObject _MessagePrefab;

        public GameObject SimPrefab;
        public GameObject MessagePrefab;

        public static void InstantiateSim(Behavior behavior, Vector3 position)
        {
            var obj = Instantiate(_SimPrefab, position, Quaternion.identity);
            obj.AddComponent<Sim>();
            var sim = obj.GetComponent<Sim>();
            sim.Behavior = behavior;
            obj.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(Random.Range(-1.0f, 1.0f),
                    Random.Range(-1.0f, 1.0f) * 50));
            obj.layer = LayerMask.NameToLayer("Objects");
            sim.OnInstatiatorDone();
        }

        public static void InstantiateMessage(Request request,
            float lifeTimeInSeconds, float radius)
        {
            var obj = Instantiate(_MessagePrefab,
                request.Author.transform.position,
                Quaternion.identity);
            obj.AddComponent<global::Message>();
            var mesComponent = obj.GetComponent<global::Message>();
            mesComponent.lifeTime = lifeTimeInSeconds;
            mesComponent.request = request;
            obj.transform.localScale = Vector3.one * radius;
            obj.layer = LayerMask.NameToLayer("Messages");
        }
    }
}
