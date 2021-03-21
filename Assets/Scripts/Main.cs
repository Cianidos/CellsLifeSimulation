// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Simulation;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var cellBehaviorFirst = new Behavior("first");
        cellBehaviorFirst.Cycle
            .AddInstruction(
                InstructionFactory.InstanceRandomNear(cellBehaviorFirst))
            .EndCycle(false);
        Instantiator.InstantiateSim(cellBehaviorFirst, Vector3.zero);


        //var food = new Behavior("food");
        //food.Properties.AddProperty(new PropertyTag("amount"), 20);
        //food.Cycle
        //    .AddInstruction(InstructionFactory.PropIncrement(new PropertyTag("amount"), 10))
        //    .AddInstruction(InstructionFactory.CtrlNextIf(
        //        (sim) =>
        //            sim.Behavior.Properties.GetPropertyValue(
        //                new PropertyTag("amount")) < 100))
        //    .AddInstruction(InstructionFactory.CtrlCurrentToIndexRelative(2))
        //    .AddInstruction(InstructionFactory.InstanceRandomNear(food))
        //    .AddInstruction(InstructionFactory.PropIncrement(new PropertyTag("amount"), -50))
        //    .AddInstruction(InstructionFactory.CtrlNextIf(
        //        (sim =>
        //            sim.Behavior.Properties.GetPropertyValue(
        //                new PropertyTag("amount")) <= 0)))
        //    .AddInstruction(InstructionFactory.SelfDestruction())
        //    .EndCycle(true);


        //var eater = new Behavior("eater");
        //eater.Properties.AddProperty(new PropertyTag("health"), 50);
        //eater.Cycle
        //    .AddInstruction((sim, cycle) =>
        //        sim.GetComponent<Rigidbody2D>()
        //            .AddForce(new Vector2(Random.Range(-1.0f, 1.0f),
        //                Random.Range(-1.0f, 1.0f)) * 50)
        //    )
        //    .AddInstruction(InstructionFactory.CtrlNextIf((sim =>
        //        sim.Behavior.Properties.GetPropertyValue(
        //            new PropertyTag("health")) < 100)))
        //    .AddInstruction(InstructionFactory.CtrlCurrentToIndexRelative(2))
        //    .AddInstruction(
        //        InstructionFactory.PropIncrement(new PropertyTag("health"), -50))
        //    .AddInstruction(InstructionFactory.InstanceRandomNear(eater))
        //    .EndCycle(true);

        //var table = new ReactionTable();
        //table.AddReaction(eater.Tag, food.Tag,
        //    new Simulation.MessageTag("collide"),
        //    (callerSim, receiverSim) =>
        //    {
        //        callerSim.Behavior.Properties.IncrementValue(new PropertyTag("health"), 10);
        //        receiverSim.Behavior.Properties.IncrementValue(new PropertyTag("amount"), -20);
        //    });

        //food.Table = table;
        //eater.Table = table;

        //Instantiator.InstantiateSim(eater, Vector3.zero);
        //Instantiator.InstantiateSim(food, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
