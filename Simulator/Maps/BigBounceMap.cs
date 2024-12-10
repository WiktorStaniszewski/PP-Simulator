namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override Point Next(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.Next(d);

        (x, y) = ImplementBounce(SizeX, SizeY, check, p);
        if ((x, y) == (0, 0)) return p;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.NextDiagonal(d);

        (x, y) = ImplementBounce(SizeX, SizeY, check, p);
        if ((x, y) == (0, 0)) return p;
        return new Point(x, y);
    }

    private (int, int) ImplementBounce(int SizeX, int SizeY, Point outcome, Point current)
    {
        int x, y;
        if (!_map.Contains(outcome))
        {
            x = 2 * current.X - outcome.X;
            y = 2 * current.Y - outcome.Y;
            if (!_map.Contains(new Point(x, y))) { return (0, 0); }
            return (x, y);
        }
        return (outcome.X, outcome.Y);
    }
}