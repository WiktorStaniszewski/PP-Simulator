using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "";
    public required string Description
    {
        get => description;
        init
        {
            if (value == null) return;
            description = Validator.Shortener(value, 3,15,'#');
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
