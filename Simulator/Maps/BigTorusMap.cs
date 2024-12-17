using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        Point newPoint = p.Next(d);
        if (Exist(newPoint)) return newPoint;

        return d switch
        {
            Direction.Up => new Point(newPoint.X, 0),
            Direction.Down => new Point(newPoint.X, SizeX - 1),
            Direction.Left => new Point(SizeY - 1, newPoint.Y),
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
            return new Point((x + SizeX) % SizeX, (y + SizeX) % SizeX);
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
