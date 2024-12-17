namespace Simulator.Maps;

public abstract class BigMap : Map
{
    new readonly Dictionary<Point, List<IMappable>> _fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Move(IMappable iMappable, Point oldpoint, Point newpoint)
    {
        Remove(iMappable, oldpoint);
        Add(iMappable, newpoint);
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