// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Simulation;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cellBehaviorFirst = new Behavior("first");

        var firCycle = new LifeCycle();
        firCycle.InsructionList.AddLast(((sim, cycle) =>
        {
        }));
        
        var table = new ReactionTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
