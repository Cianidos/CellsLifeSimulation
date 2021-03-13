// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Simulation;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var table = new ReactionTable();
        var cellBehaviorFirst = new Behavior("first");
        cellBehaviorFirst.Table = table;

        var firCycle = new LifeCycle();
        firCycle.InsructionList.AddLast(((sim, cycle) =>
        {
            Instantiator.InstantiateSim(cellBehaviorFirst,
                sim.transform.position + new Vector3(Random.Range(-1.0f, 1.0f),
                    Random.Range(-1.0f, 1.0f), 0) * 2);
        }));
        firCycle.EndCycle();

        cellBehaviorFirst.Cycle = firCycle;
        cellBehaviorFirst.Properties = new LifeProperties();

        Instantiator.InstantiateSim(cellBehaviorFirst, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
