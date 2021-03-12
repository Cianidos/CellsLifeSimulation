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
        public Dictionary<Property, int> Props;
        public void AddProperty(Property name, int value_by_default)
        {
            throw new NotImplementedException();
        }

        public void ChangeValue(PropertyAttribute name, int value)
        {
            throw new NotImplementedException();
        }

        public int GetPropertyValue(Property name)
        {
            throw new NotImplementedException();
        }

        public bool IsPropertyIn(Property name)
        {
            throw new NotImplementedException();
        }
    }
}
