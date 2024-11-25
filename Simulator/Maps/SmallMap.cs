using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<Creature>?[,] _fields;
    protected SmallMap(int sizeX,  int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too long");
        _fields = new List<Creature>?[sizeX,sizeY];
    }
    public override void Move(Creature creature, Point startPosition, Point finalPosition)
    {
        Remove(creature, startPosition);
        Add(creature, finalPosition);
    }
    public override void Add(Creature creature, Point position)
    {
        _fields[position.X, position.Y] = new List<Creature>();
        _fields[position.X, position.Y]?.Add(creature);
    }
    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y]?.Remove(creature);
    }
    public override List<Creature>? At(Point position) => _fields[position.X, position.Y];
}
