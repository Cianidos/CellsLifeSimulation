// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Simulation
{
    /// <summary>
    /// Class that helps to make Instructions for LifeCycle
    /// </summary>
    public static class InstructionFactory
    {
        /// <summary>
        /// Make instantiation instruction
        /// </summary>
        /// <param name="behavior">instance object behaviour</param>
        /// <param name="position">position relative to parent</param>
        /// <returns>Instruction that instantiate new object</returns>
        public static Instruction InstanceSome(Behavior behavior, 
            Vector2 position)
        {
            return (sim, cycle) =>
            {
                Instantiator.InstantiateSim(behavior, 
                    new Vector3(position.x, position.y, 0));
            };
        }

        /// <summary>
        /// Make instruction that instantiate new object of behavior near
        /// parent in random position
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns>Instruction that instantiate new object</returns>
        public static Instruction InstanceRandomNear(Behavior behavior)
        {
            return (sim, cycle) =>
            {
                Instantiator.InstantiateSim(behavior,
                    sim.transform.position + RandomNearVector3(2.0F));
            };
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Set lifecycle current instruction into index
        /// </summary>
        /// <param name="index">position of other instruction in
        /// lifecycle, couldn't be less than 0</param>
        /// <returns>Instruction</returns>
        public static Instruction CtrlCurrentToIndex(uint index)
        {
            return (sim, cycle) =>
            {
                var first = cycle.InstructionList.First;
                for (int i = 0; i < index; ++i)
                {
                    first = first?.Next;
                }

                first ??= cycle.InstructionList.First;
                cycle.CurrentNode = first;
            };
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Set lifecycle current instruction into index relative this index
        /// (may be less then 0)
        /// when 0 do nothing
        /// </summary>
        /// <param name="index">position of other instruction in
        /// lifecycle relative this</param>
        /// <returns>Instruction</returns>
        public static Instruction CtrlCurrentToIndexRelative(int index)
        {
            if (index >= 0)
                return (sim, cycle) =>
                {
                    var current = cycle.CurrentNode;
                    for (int i = 0; i < index; ++i)
                    {
                        current = current?.Next;
                    }

                    current ??= cycle.CurrentNode;
                    cycle.CurrentNode = current;
                };
            else
            {
                return (sim, cycle) =>
                {
                    var current = cycle.CurrentNode;
                    for (int i = index; i < 0; ++i)
                    {
                        current = current?.Previous;
                    }

                    current ??= cycle.CurrentNode;
                    cycle.CurrentNode = current;
                };
            }
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Set lifecycle current instruction into first position
        /// </summary>
        /// <returns>Instruction</returns>
        public static Instruction CtrlCurrentToBegin()
        {
            return (sim, cycle) =>
            {
                cycle.CurrentNode = cycle.InstructionList.First;
            };
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Execute next instruction if conditionFunc result is true
        /// else skip next
        /// </summary>
        /// <param name="conditionFunc">condition of execution of next
        /// instruction</param>
        /// <returns>Instruction</returns>
        public static Instruction CtrlNextIf(Func<Sim, bool> conditionFunc)
        {
            return (sim, cycle) =>
            {
                var tmp = cycle.CurrentNode;
                if (!conditionFunc(sim))
                    cycle.CurrentNode = cycle.CurrentNode.Next;
                cycle.CurrentNode ??= tmp;
            };
        }

        /// <summary>
        /// Property oriented instruction
        /// Set Property to value
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="value">new value</param>
        /// <returns>Instruction</returns>
        public static Instruction PropSet(Property property, int value)
        {
            return (sim, cycle) =>
            {
                if(sim.Behavior.Properties.IsPropertyIn(property))
                    sim.Behavior.Properties.ChangeValue(property, value);
                else 
                    sim.Behavior.Properties.AddProperty(property, value);
            };
        }

        /// <summary>
        /// Property oriented instruction
        /// Increment property value 
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="increment">Step of increment</param>
        /// <returns></returns>
        public static Instruction PropIncrement
            (Property property, int increment = 1)
        {
            return (sim, cycle) =>
            {
                sim.Behavior.Properties.IncrementValue(property, increment);
            };
        }

        /// <summary>
        /// Instantiate Message in parent position
        /// </summary>
        /// <param name="message">Message type</param>
        /// <param name="lifeTime">Time before message self destruction</param>
        /// <param name="radius">Size of message</param>
        /// <returns></returns>
        public static Instruction MsgPost(Message message, float lifeTime,
            float radius)
        {
            return (sim, cycle) =>
            {
                Instantiator.InstantiateMessage(new Request(sim, message),
                    lifeTime, radius);
            };
        }

        /// <summary>
        /// Sim will destroyed when cycle riches this instruction
        /// </summary>
        /// <returns></returns>
        public static Instruction SelfDestruction()
        {
            return (sim, cycle) =>
            {
                Object.Destroy(sim);
            };
        }

        private static Vector3 RandomNearVector3(float dist = 1)
        {
            return new Vector3(Random.Range(-1.0f, 1.0f),
                Random.Range(-1.0f, 1.0f), 0) * dist;
        }
    }
}
