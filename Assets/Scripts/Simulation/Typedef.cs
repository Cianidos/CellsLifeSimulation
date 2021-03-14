// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using UnityEditor.U2D.Path.GUIFramework;

namespace Simulation
{
    public class BehaviorTag
    {
        public BehaviorTag(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }

    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }

    public class Property
    {
        public Property(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }

}
