// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using UnityEditor.U2D.Path.GUIFramework;

namespace Simulation
{
    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier of behavior.
    /// </summary>
    public class BehaviorTag
    {
        public BehaviorTag(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }

    
    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier of message(request).
    /// </summary>
    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }

    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier in Sim's properties.
    /// Name of property.
    /// </summary>
    public class Property
    {
        public Property(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }

    /// <summary>
    /// Block of lifeCycle instruction chain, that determine actions of Sim.
    /// </summary>
    /// <param name="sim">owner of instruction</param>
    /// <param name="lifeCycle">lifeCycle that contains this instruction</param>
    public delegate void Instruction(Sim sim, LifeCycle lifeCycle);

    /// <summary>
    /// This is what Sim(receiver) do if he receive message of other Sim(caller).
    /// </summary>
    /// <param name="callerSim"></param>
    /// <param name="receiverSim"></param>
    public delegate void Reaction(Sim callerSim, Sim receiverSim);
}
