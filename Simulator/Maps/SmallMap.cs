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
    public override void Move(IMappable iMappable, Point oldpoint, Point newpoint)
    {
        var y = SizeY - newpoint.Y - 1;
        Remove(iMappable, oldpoint);
        Add(iMappable, newpoint);
    } 
}