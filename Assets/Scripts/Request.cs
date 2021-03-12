// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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
