using System.Collections.Generic;

namespace Simulation
{

// takes Sim who call and Sim who are called
    using Reaction = System.Action<Sim, Sim>;

// determine Sims reactions on other Sim's requests
    public class ReactionTable
    {
        // caller receiver message -> reaction
        private
            Dictionary<string,
                Dictionary<string,
                    Dictionary<string, Reaction>>> container;

        // add specific reaction with full path
        public void AddReaction(BehaviorTag caller, Message message, BehaviorTag receiver, Reaction react)
        {
            throw new System.NotImplementedException();
        }

        // add default reaction on caller message
        // default reactions works if no specific reaction
        public void AddDefaultReactionOn(BehaviorTag caller, Message message, Reaction react)
        {
            throw new System.NotImplementedException();
        }

        // add default reaction on all caller messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionOn(BehaviorTag caller, Reaction react)
        {
            throw new System.NotImplementedException();
        }

        // add default reaction of receiver for all messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionOf(Message message, BehaviorTag receiver, Reaction react)
        {
            throw new System.NotImplementedException();
        }
        
        // add default reaction of receiver on all messages
        // default reactions works if no specific reaction
        public void AddDefaultReactionOf(BehaviorTag receiver, Reaction react)
        {
            throw new System.NotImplementedException();
        }

        public Reaction GetReaction(BehaviorTag caller, Message message, BehaviorTag receiver)
        {
            throw new System.NotImplementedException();
        }
    }
}