using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Animals
{
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;
    public string Info() => $"{Description} <{Size}>";
}
