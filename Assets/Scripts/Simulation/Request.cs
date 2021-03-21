// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Simulation
{
    /// <summary>
    /// Simple class-container for <see cref="MessageTag"/> and it's author (<see cref="Sim"/>)
    /// </summary>
    /// <remarks>
    /// See also: <seealso cref="global::Message"/>
    /// </remarks>
    public class Request
    {
        public Request(Sim author, MessageTag message)
        {
            AuthorTag = author.Behavior.Tag;
            Message = message;
            Author = author;
        }

        public BehaviorTag AuthorTag { get; }
        public MessageTag Message { get; }
        public Sim Author { get; }
    }
}
