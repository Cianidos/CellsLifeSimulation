// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Collections.Generic;

namespace Simulation
{
    /// <summary>
    /// Determine Sims reactions on other Sim's requests
    /// </summary>
    public class ReactionTable
    {
        public ReactionTable()
        {
            container =
                new Dictionary<string,
                    Dictionary<string, Dictionary<string, Reaction>>>
                {
                    {
                        @default,
                        new Dictionary<string, Dictionary<string, Reaction>>()
                    }
                };

            container[@default].Add(@default, new Dictionary<string, Reaction>());
            container[@default][@default].Add(@default, ((sim, sim1) => { }));
        }


        // caller receiver message -> reaction
        private readonly
            Dictionary<string,
                Dictionary<string,
                    Dictionary<string, Reaction>>> container;

        private const string @default = "default";

        /// <summary>
        /// Absolute specific reaction adding
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="react"></param>
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
                container[caller][receiver][message] = react;
        }

#nullable enable
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
#nullable disable

        /// <summary>
        /// add specific reaction with full path
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="react"></param>
        public ReactionTable AddReaction(BehaviorTag caller,
            BehaviorTag receiver, Message message, Reaction react)
        {
            AddReaction(caller.Value, receiver.Value, message.Value, react);
            return this;
        }


        /// <summary>
        /// add default reaction on caller message
        /// default reactions works if no specific reaction
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        /// <param name="react"></param>
        public ReactionTable AddDefaultReactionOn(BehaviorTag caller,
            Message message, Reaction react)
        {
            AddReaction(caller.Value, @default, message.Value, react);
            return this;
        }

        /// <summary>
        /// add default reaction on all caller messages
        /// default reactions works if no specific reaction
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="react"></param>
        public ReactionTable AddDefaultReactionOn(BehaviorTag caller, Reaction react)
        {
            AddReaction(caller.Value, @default, @default, react);
            return this;
        }

        /// <summary>
        /// add default reaction of receiver for all messages
        /// default reactions works if no specific reaction
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="react"></param>
        public ReactionTable AddDefaultReactionFrom(BehaviorTag receiver,
            Message message, Reaction react)
        {
            AddReaction(@default, receiver.Value, message.Value, react);
            return this;
        }

        /// <summary>
        /// add default reaction of receiver on all messages
        /// default reactions works if no specific reaction
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="react"></param>
        public ReactionTable AddDefaultReactionFrom
            (BehaviorTag receiver, Reaction react)
        {
            AddReaction(@default, receiver.Value, @default, react);
            return this;
        }

        /// <summary>
        /// return reaction specified for caller receiver and message
        /// if reaction not specified for some of those
        /// default with maximum specific version are used
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Reaction GetReaction(BehaviorTag caller,
            BehaviorTag receiver, Message message)
        {
#nullable enable
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

#nullable disable
            res = FindReaction(@default,
                @default, @default);
            return res;
        }
    }
}