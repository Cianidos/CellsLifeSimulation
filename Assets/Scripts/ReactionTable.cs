using System.Collections.Generic;

namespace Simulation
{

// takes Sim who call and Sim who are called
    using Reaction = System.Action<Sim, Sim>;

// determine Sims reactions on other Sim's requests
    public class ReactionTable
    {
        public ReactionTable()
        {
            container = new Dictionary<string, Dictionary<string, Dictionary<string, Reaction>>>();
        }
        // caller receiver message -> reaction
        private
            Dictionary<string,
                Dictionary<string,
                    Dictionary<string, Reaction>>> container;

        private string @default = "default";

        private void AddReaction(string caller, string receiver, 
            string message, Reaction react)
        {
            if (!container.ContainsKey(caller))
                container.Add(caller, new Dictionary<string,
                    Dictionary<string, Reaction>>());

            if (!container[caller].ContainsKey(receiver))
                container[caller].Add(receiver, 
                    new Dictionary<string, Reaction>());

            if (!container[caller][receiver].ContainsKey(message))
                container[caller][receiver].Add(message, react);
            else
                container[caller][receiver].Add(message, react);
        }

        private Reaction? FindReaction(string caller, string receiver,
            string message)
        {
            if (!container.ContainsKey(caller))
                return null;

            if (!container[caller].ContainsKey(receiver))
                return null;

            if (!container[caller][receiver].ContainsKey(message))
                return null;
            else
                return container[caller][receiver][message];
        }

        // add specific reaction with full path
        public void AddReaction(BehaviorTag caller,
            BehaviorTag receiver, Message message, Reaction react)
        {
            AddReaction(caller.Value, receiver.Value, message.Value, react);
        }

        // add default reaction on caller message
        // default reactions works if no specific reaction
        public void AddDefaultReactionOn(BehaviorTag caller, 
            Message message, Reaction react)
        {
            AddReaction(caller.Value, @default, message.Value, react);
        }

        // add default reaction on all caller messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionOn(BehaviorTag caller, Reaction react)
        {
            AddReaction(caller.Value, @default, @default, react);
        }

        // add default reaction of receiver for all messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionFrom(BehaviorTag receiver, 
            Message message, Reaction react)
        {
            AddReaction(@default, receiver.Value, message.Value, react);
        }
        
        // add default reaction of receiver on all messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionFrom
            (BehaviorTag receiver, Reaction react)
        {
            AddReaction(@default, receiver.Value, @default, react);
        }

        public Reaction? GetReaction(BehaviorTag caller, 
            BehaviorTag receiver, Message message)
        {
            Reaction? res = FindReaction(caller.Value, 
                receiver.Value, message.Value);
            if (res != null)
                return res;

            res = FindReaction(caller.Value, 
                receiver.Value, @default);
            if (res != null)
                return res;
            
            res = FindReaction(caller.Value,
                @default, message.Value);
            if (res != null)
                return res;
            
            res = FindReaction(caller.Value,
                @default, @default);
            if (res != null)
                return res;

            res = FindReaction(@default,
                receiver.Value, message.Value);
            if (res != null)
                return res;

            res = FindReaction(@default,
                receiver.Value, @default);
            if (res != null)
                return res;

            res = FindReaction(@default,
                @default, message.Value);
            if (res != null)
                return res;

            res = FindReaction(@default,
                @default, @default);
            if (res != null)
                return res;

            return null;
        }
    }
}