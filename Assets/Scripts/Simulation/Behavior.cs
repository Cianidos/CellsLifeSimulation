// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
namespace Simulation
{
    public class Behavior
    {
        public Behavior(string tag) : this(new BehaviorTag(tag))
        { }

        public Behavior(BehaviorTag tag)
        {
            Tag = tag;
            Table = new ReactionTable();
            Cycle = new LifeCycle();
            Properties = new LifeProperties();
        }

        public Behavior(Behavior otherBehavior)
        {
            Tag = otherBehavior.Tag;
            Table = otherBehavior.Table;
            Cycle = new LifeCycle(otherBehavior.Cycle);
            Properties = new LifeProperties(otherBehavior.Properties);
        }
    
        public BehaviorTag Tag;
        public ReactionTable Table;
        public LifeCycle Cycle;
        public LifeProperties Properties;

        public void ReactTo(Sim me, Request request)
        {
            Table.GetReaction(request.Author.Behavior.Tag,
                me.Behavior.Tag, request.Message);
        }

        public void NextInstruction(Sim me)
        {
            Cycle.Next(me);
        }
    }
}
