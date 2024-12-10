namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        (int, int) goNext = direction switch
        {
            Direction.Up => (0, 1),
            Direction.Right => (1, 0),
            Direction.Down => (0, -1),
            Direction.Left => (-1, 0),
            _ => throw new NotImplementedException(),
        };

        return new Point(X + goNext.Item1, Y + goNext.Item2);
    }

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        (int, int) goNextDiagonal = direction switch
        {
            Direction.Up => (1, 1),
            Direction.Right => (1, -1),
            Direction.Down => (-1, -1),
            Direction.Left => (-1, 1),
            _ => throw new NotImplementedException()
        };

        return new Point(X + goNextDiagonal.Item1, Y + goNextDiagonal.Item2);
    }

    public static bool operator ==(Point a, Point b)
    {
        return (a.X == b.X) && (a.Y == b.Y);
    }

    public static bool operator !=(Point a, Point b)
    {
        return (a.X != b.X) || (a.Y != b.Y);
    }
}