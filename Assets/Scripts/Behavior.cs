using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulation
{
    public class Behavior
    {
        public BehaviorTag Tag;
        public ReactionTable Table;
        public LifeCycle Cycle;

        public void ReactTo(Sim me, Request request)
        {
            Table.GetReaction(request.Author.Behavior.Tag, me.Behavior.Tag, request.Message);
        }

        public Action<Sim> NextInstruction()
        {
            return Cycle.Next();
        }
    }
}
