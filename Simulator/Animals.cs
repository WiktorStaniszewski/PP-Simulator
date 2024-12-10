using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals : IMappable
{
    public virtual char Symbol => 'A';
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }

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

    public virtual void Go(Direction dir)
    {
        if (Map == null) throw new Exception("Stwora nie ma na mapach");
        var nextpoint = Map.Next(Position, dir);
        Map.Move(this, Position, nextpoint);
        Position = nextpoint;
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
