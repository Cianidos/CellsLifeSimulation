using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation;


namespace Simulation
{
    public class Request
    {
        public Request(Sim author, Message message)
        {
            Tag = author.Behavior.Tag;
            Message = message;
            Author = author;
        }

        public BehaviorTag Tag { get; set; }
        public Message Message { get; set; }
        public Sim Author { get; set; }
    }
}
