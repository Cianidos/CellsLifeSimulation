// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Collections.Generic;

namespace Simulation
{
    public class LifeProperties
    {
        public LifeProperties(LifeProperties otherProperties)
        {
            Props = new Dictionary<PropertyTag, int>(otherProperties.Props);
        }
        public LifeProperties()
        {
            Props = new Dictionary<PropertyTag, int>();
        }

        private readonly Dictionary<PropertyTag, int> Props;
        public void AddProperty(PropertyTag name, int value_by_default)
        {
            if (!Props.ContainsKey(name))
                Props.Add(name, value_by_default);
        }

        public void ChangeValue(PropertyTag name, int value)
        {
            if (!Props.ContainsKey(name))
                throw new KeyNotFoundException();
            else
                Props[name] = value;
        }

        public void IncrementValue(PropertyTag name, int increment)
        {
            ChangeValue(name, GetPropertyValue(name) + increment);
        }

        public int GetPropertyValue(PropertyTag name)
        {
            if (!Props.ContainsKey(name))
                throw new KeyNotFoundException();
            else
                return Props[name];
        }

        public bool IsPropertyIn(PropertyTag name)
        {
            return Props.ContainsKey(name);
        }
    }
}
