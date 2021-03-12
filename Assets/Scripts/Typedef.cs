using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public class BehaviorTag
    {
        public BehaviorTag(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }

    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }
}
