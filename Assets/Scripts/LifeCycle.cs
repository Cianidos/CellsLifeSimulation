using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Simulation
{
using Instruction = Action<Sim, LifeCycle>;
    public class LifeCycle
    {
        public LinkedList<Instruction> InsructionList;
        public LinkedListNode<Instruction> CurrentNode;
        public void Next(Sim me)
        {
            CurrentNode = CurrentNode.Next;
            CurrentNode.Value(me, this);
        }
    }
}
