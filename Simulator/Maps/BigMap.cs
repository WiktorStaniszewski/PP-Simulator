namespace Simulator.Maps;

public abstract class BigMap : Map
{
    readonly Dictionary<Point, List<IMappable>> _fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable iMappable, Point point)
    { //dodaje potwora na pole
        if (!_fields.ContainsKey(point)) _fields.Add(point, new List<IMappable>());
        _fields[point].Add(iMappable);
    }

    public override List<IMappable>? At(int x, int y)
    {
        var p = new Point(x, y);
        if (!_fields.ContainsKey(p)) return null;
        return _fields[p];
    }
    public override List<IMappable>? At(Point point)
    {
        if (!_fields.ContainsKey(point)) return null;
        return _fields[point];
    }

    public override void Move(IMappable iMappable, Point oldpoint, Point newpoint)
    {
        Remove(iMappable, oldpoint);
        Add(iMappable, newpoint);
    }

    public override void Remove(IMappable iMappable, Point point)
    { //usuwa potwora z pola
        _fields[point]?.Remove(iMappable);
    }

    //trzrba przemyśleć implementacje tego - w bigbouncemap jest wyjaśnione jaki problem jest
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