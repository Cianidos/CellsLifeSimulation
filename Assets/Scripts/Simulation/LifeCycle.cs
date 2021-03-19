// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Collections.Generic;



namespace Simulation
{
    
    /// <summary>
    /// Represent program of internal behavior of <see cref="Sim"/>.
    /// <see cref="Instruction"/>s, that contains in <see cref="LifeCycle"/>, can control execution sequence of LifeCycle.
    /// </summary>
    public class LifeCycle
    {
        public readonly LinkedList<Instruction> InstructionList;
        public LinkedListNode<Instruction> CurrentNode;


        public LifeCycle()
        {
            InstructionList = new LinkedList<Instruction>();
            CurrentNode = InstructionList.First;
        }

        public LifeCycle(LifeCycle otherCycle)
        {
            InstructionList =
                new LinkedList<Instruction>(otherCycle.InstructionList);
            CurrentNode = InstructionList.First;
        }

        /// <summary>
        /// Chain building method 
        /// </summary>
        /// <example>
        /// <code>
        /// ...
        /// lifeCycle
        /// .AddInstruction(instruction1)
        /// .AddInstruction(instruction2)
        /// ...
        /// </code>
        /// </example>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public LifeCycle AddInstruction(Instruction instruction)
        {
            InstructionList.AddLast(instruction);
            return this;
        }

        /// <summary>
        /// Add last <see cref="Instruction"/> in cycle
        /// </summary>
        /// <param name="loop"></param>
        public void EndCycle(bool loop)
        {
            InstructionList.AddLast(!loop
                ? (sim, cycle) => { }
            : InstructionFactory.CtrlCurrentToBegin());
            CurrentNode = InstructionList.First;
        }

        public void Next(Sim me)
        {
            if (CurrentNode.Next != null)
            {
                CurrentNode.Value(me, this);
                CurrentNode = CurrentNode.Next;
            }
        }
    }
}
