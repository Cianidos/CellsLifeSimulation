// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Collections.Generic;



namespace Simulation
{
using Instruction = Action<Sim, LifeCycle>;
    public class LifeCycle
    {
        public LifeCycle()
        {
            InsructionList = new LinkedList<Instruction>();
            CurrentNode = InsructionList.First;
        }

        public LinkedList<Instruction> InsructionList;
        public LinkedListNode<Instruction> CurrentNode;
        public void Next(Sim me)
        {
            if (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                CurrentNode.Value(me, this);
            }
        }
    }
}
