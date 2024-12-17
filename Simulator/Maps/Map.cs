using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public virtual void Add(IMappable iMappable, Point position)
    {
        if (!_fields.ContainsKey(position)) _fields.Add(position, new List<IMappable>());
        _fields[position].Add(iMappable);
    }
    public virtual void Remove(IMappable iMappable, Point point)
    {
        _fields[point]?.Remove(iMappable);
    }
    public abstract void Move(IMappable iMappable, Point startPosition, Point finalPosition);
    public virtual List<IMappable>? At(int x, int y)
    {
        Point p = new(x, y);
        if (!_fields.ContainsKey(p)) return null;
        return _fields[p];
    }
    public virtual List<IMappable>? At(Point position)
    {
        if (!_fields.ContainsKey(position)) return null;
        return _fields[position];
    }


    protected readonly Rectangle _map;
    protected Dictionary<Point, List<IMappable>> _fields;
    protected Map(int sizeX, int sizeY)
    {
        
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too thin");
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);
    
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);
    
    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}