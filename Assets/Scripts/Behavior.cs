using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Behavior
{
    public string Tag;

    private Dictionary<string, Dictionary<string, Action>> reactionTable;

    public void ReactTo(string otherTag, string otherMessage, Sim other)
    {
        throw new NotImplementedException();
    }
}
