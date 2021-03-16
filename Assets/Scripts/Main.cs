// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Simulation;
using UnityEngine;
using Message = Simulation.Message;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var table = new ReactionTable();
        //var cellBehaviorFirst = new Behavior("first") {Table = table};

        //var firCycle = new LifeCycle();
        //firCycle.InstructionList.AddLast(((sim, cycle) =>
        //{
        //    Instantiator.InstantiateSim(cellBehaviorFirst,
        //        sim.transform.position + new Vector3(Random.Range(-1.0f, 1.0f),
        //            Random.Range(-1.0f, 1.0f), 0) * 2);
        //}));

        //firCycle.EndCycle(false);

        //cellBehaviorFirst.Cycle = firCycle;
        //cellBehaviorFirst.Properties = new LifeProperties();

        //Instantiator.InstantiateSim(cellBehaviorFirst, Vector3.zero);
        

        var food = new Behavior("food");
        food.Properties.AddProperty(new Property("amount"),20);
        food.Cycle
            .AddInstruction(InstructionFactory.PropIncrement(new Property("amount"), 10))
            .AddInstruction(InstructionFactory.CtrlNextIf(
                (sim) =>
                    sim.Behavior.Properties.GetPropertyValue(
                        new Property("amount")) < 100))
            .AddInstruction(InstructionFactory.CtrlCurrentToIndexRelative(2))
            .AddInstruction(InstructionFactory.InstanceRandomNear(food))
            .AddInstruction(InstructionFactory.PropIncrement(new Property("amount"), -50))
            .AddInstruction(InstructionFactory.CtrlNextIf(
                (sim =>
                    sim.Behavior.Properties.GetPropertyValue(
                        new Property("amount")) <= 0)))
            .AddInstruction(InstructionFactory.SelfDestruction())
            .EndCycle(true);

        
        var eater = new Behavior("eater");
        eater.Properties.AddProperty(new Property("health"), 50);
        eater.Cycle
            .AddInstruction((sim, cycle) =>
                sim.GetComponent<Rigidbody2D>()
                    .AddForce(new Vector2(Random.Range(-1.0f, 1.0f),
                        Random.Range(-1.0f, 1.0f)) * 50)
            )
            .AddInstruction(InstructionFactory.CtrlNextIf((sim =>
                sim.Behavior.Properties.GetPropertyValue(
                    new Property("health")) < 100)))
            .AddInstruction(InstructionFactory.CtrlCurrentToIndexRelative(2))
            .AddInstruction(
                InstructionFactory.PropIncrement(new Property("health"), -50))
            .AddInstruction(InstructionFactory.InstanceRandomNear(eater))
            .EndCycle(true);

        var table = new ReactionTable();
        table.AddReaction(eater.Tag, food.Tag,
            new Simulation.Message("collide"), 
            (callerSim, receiverSim) =>
            {
                callerSim.Behavior.Properties.IncrementValue(new Property("health"), 10);
                receiverSim.Behavior.Properties.IncrementValue(new Property("amount"), -20);
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
