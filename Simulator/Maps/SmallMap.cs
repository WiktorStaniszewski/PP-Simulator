using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<IMappable>?[,] _fields;
    protected SmallMap(int sizeX,  int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too long");
        _fields = new List<IMappable>?[sizeX,sizeY];
    }
    public override void Move(IMappable iMappable, Point startPosition, Point finalPosition)
    {
        Remove(iMappable, startPosition);
        Add(iMappable, finalPosition);
    }
    public override void Add(IMappable iMappable, Point position)
    {
        _fields[position.X, position.Y] = new List<IMappable>();
        _fields[position.X, position.Y]?.Add(iMappable);
    }
    public override void Remove(IMappable iMappable, Point position)
    {
        _fields[position.X, position.Y]?.Remove(iMappable);
    }
    public override List<IMappable>? At(Point position) => _fields[position.X, position.Y];
}
