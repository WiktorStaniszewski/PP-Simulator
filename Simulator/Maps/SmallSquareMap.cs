namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }


    public override bool Exist(Point p)
    {
        if (p.X > SizeX - 1 || p.Y > SizeY - 1 || p.X < 0 || p.Y < 0) return false;
        return true;
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d))) return p.Next(d);
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
        return p;
    }
}