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

        public void ReactTo(BehaviorTag otherTag, Message otherMessage, Sim other)
        {
            throw new NotImplementedException();
        }
    }
}
