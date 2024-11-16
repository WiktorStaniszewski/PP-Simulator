using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    private readonly Rectangle map_rectangle;
    public SmallTorusMap (int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("The size does not meet the requirements.");
        Size = size;
        map_rectangle = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p)
    {
        return map_rectangle.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point newPoint = p.Next(d);
        if (Exist(newPoint)) return newPoint;

        return d switch
        {
            Direction.Up => new Point(newPoint.X, 0),
            Direction.Down => new Point(newPoint.X, Size - 1),
            Direction.Left => new Point(Size - 1, newPoint.Y),
            Direction.Right => new Point(0, newPoint.Y),
            _ => throw new InvalidDataException()
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point newDiagPoint = p.NextDiagonal(d);
        if (Exist(newDiagPoint)) return newDiagPoint;
        
        Point OtherSide(int x, int y)
        {
            return new Point((x+Size)%Size, (y+Size)%Size);
        }
        return d switch
        {
            Direction.Up => OtherSide(p.X + 1, p.Y + 1),
            Direction.Down => OtherSide(p.X - 1, p.Y - 1),
            Direction.Left => OtherSide(p.X - 1, p.Y + 1),
            Direction.Right => OtherSide(p.X + 1, p.Y - 1),
            _ => throw new InvalidDataException()
        };
    }
}
