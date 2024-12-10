using System.Drawing;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<IMappable>?[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new List<IMappable>[SizeX, SizeY];
    }
    public override void Add(IMappable iMappable, Point point)
    { 
        if (_fields[point.X, point.Y] is null) _fields[point.X, point.Y] = new List<IMappable>();
        _fields[point.X, point.Y].Add(iMappable);
    }
    public override void Remove( IMappable iMappable, Point point)
    { 
        _fields[point.X, point.Y]?.Remove(iMappable);
    }

    public override void Move(IMappable iMappable, Point oldpoint, Point newpoint)
    {
        var y = SizeY - newpoint.Y - 1;
        Remove(iMappable, oldpoint);
        Add(iMappable, newpoint);
    } 

    public override List<IMappable>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<IMappable>? At(Point point)
    {
        return _fields[point.X, point.Y];
    }
}