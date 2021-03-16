// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Collections.Generic;



namespace Simulation
{
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

        public LifeCycle AddInstruction(Instruction instruction)
        {
            InstructionList.AddLast(instruction);
            return this;
        }

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
