using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Simulation
{
    using Property = System.String;
    public class LifeProperties
    {
        public LifeProperties()
        {
            Props = new Dictionary<string, int>();
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
