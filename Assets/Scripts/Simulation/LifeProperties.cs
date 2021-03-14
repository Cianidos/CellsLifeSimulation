// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Collections.Generic;

namespace Simulation
{
    //using Property = System.String;
    public class LifeProperties
    {
        public LifeProperties(LifeProperties otheProperties)
        {
            Props = new Dictionary<Property, int>(otheProperties.Props);
        }
        public LifeProperties()
        {
            Props = new Dictionary<Property, int>();
        }

        private Dictionary<Property, int> Props;
        public void AddProperty(Property name, int value_by_default)
        {
            if (!Props.ContainsKey(name))
                Props.Add(name, value_by_default);
        }

        public void ChangeValue(Property name, int value)
        {
            if (!Props.ContainsKey(name))
                throw new KeyNotFoundException();
            else
                Props[name] = value;
        }

        public int GetPropertyValue(Property name)
        {
            if (!Props.ContainsKey(name))
                throw new KeyNotFoundException();
            else
                return Props[name];
        }

        public bool IsPropertyIn(Property name)
        {
            return Props.ContainsKey(name);
        }
    }
}
