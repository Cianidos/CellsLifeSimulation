﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Collections.Generic;



namespace Simulation
{
    public class LifeCycle
    {
        public LinkedList<Instruction> InsructionList;
        public LinkedListNode<Instruction> CurrentNode;

        
        public LifeCycle()
        {
            InsructionList = new LinkedList<Instruction>();
            CurrentNode = InsructionList.First;
        }

        public LifeCycle(LifeCycle otherCycle)
        {
            InsructionList =
                new LinkedList<Instruction>(otherCycle.InsructionList);
            CurrentNode = InsructionList.First;
        }

        public LifeCycle AddInstruction(Instruction instruction)
        {
            InsructionList.AddLast(instruction);
            return this;
        }

        public void EndCycle(bool loop)
        {
            InsructionList.AddLast(!loop
                ? (sim, cycle) => { }
                : InstructionFabric.CtrlCurrentToBegin());
            CurrentNode = InsructionList.First;
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