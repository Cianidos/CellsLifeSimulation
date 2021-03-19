// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Simulation
{
    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier of behavior.
    /// </summary>
    /// <remarks>See also: <see cref="Behavior"/></remarks>
    public class BehaviorTag
    {
        public BehaviorTag(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }


    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier of message(request).
    /// </summary>
    /// <remarks>See also: <see cref="Message"/> <see cref="Request"/></remarks>
    public class MessageTag
    {
        public MessageTag(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    /// <summary>
    /// Class wrapper for string.
    /// Unique identifier in <see cref="Sim"/>'s properties.
    /// Name of property.
    /// </summary>
    /// <remarks>See also: <see cref="LifeProperties"/></remarks>
    public class PropertyTag
    {
        public PropertyTag(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }

    /// <summary>
    /// Block of <see cref="LifeCycle"/> instruction chain, that determine actions of <see cref="Sim"/>.
    /// </summary>
    /// <param name="sim">owner of instruction</param>
    /// <param name="lifeCycle">lifeCycle that contains this instruction</param>
    public delegate void Instruction(Sim sim, LifeCycle lifeCycle);

    /// <summary>
    /// This is what <see cref="Sim"/>(receiver) do if he receive <see cref="Message"/> of other Sim(caller).
    /// </summary>
    /// <remarks>See also: <see cref="ReactionTable"/></remarks>
    /// <param name="callerSim"></param>
    /// <param name="receiverSim"></param>
    public delegate void Reaction(Sim callerSim, Sim receiverSim);
}
