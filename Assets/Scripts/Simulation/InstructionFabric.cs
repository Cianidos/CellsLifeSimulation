using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Simulation
{
    using Instruction = Action<Sim, LifeCycle>;
    
    
    /// <summary>
    /// Class that makes completed and ready to use Instructions for LifeCycle
    /// </summary>
    public static class InstructionFabric
    {
        /// <summary>
        /// Make instantiation instruction
        /// </summary>
        /// <param name="behavior">behavior of object of instance</param>
        /// <param name="position">position relative to parent</param>
        /// <returns>Instruction that instantiate new object</returns>
        public static Instruction InstanceSome(Behavior behavior, Vector2 position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make instruction that instantiate new object of behavior near parent in random position
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns>Instruction that instantiate new object</returns>
        public static Instruction InstanceRandomNear(Behavior behavior)
        {
            // example, remake this
            return (sim, cycle) =>
            {
                Instantiator.InstantiateSim(behavior,
                    sim.transform.position + new Vector3(
                        Random.Range(-1.0f, 1.0f),
                        Random.Range(-1.0f, 1.0f), 0) * 2);
            };
            throw new NotImplementedException();
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Set lifecycle current instruction into index
        /// </summary>
        /// <param name="index">position of other instruction in lifecycle</param>
        /// <returns>Instruction</returns>
        public static Instruction CtrlCurrentToIndex(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Set lifecycle current instruction into first position
        /// </summary>
        /// <returns>Instruction</returns>
        public static Instruction CtrlCurrentToBegin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Control instruction, determine order of instruction execution
        /// Execute next instruction if conditionFunc result is true
        /// else skip next
        /// </summary>
        /// <param name="conditionFunc">condition of execution of next instruction</param>
        /// <returns>Instruction</returns>
        public static Instruction CtrlNextIf(Func<bool> conditionFunc)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Property oriented instruction
        /// Set Property into value
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="value">new value</param>
        /// <returns>Instruction</returns>
        public static Instruction PropSet(Property property, int value)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Property oriented instruction
        /// Increment property value 
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="increment">Step of increment</param>
        /// <returns></returns>
        public static Instruction PropIncrement(Property property, int increment = 1)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
