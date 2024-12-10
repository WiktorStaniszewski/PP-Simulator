namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public override string Info => $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>";

    public override char Symbol => CanFly ? 'B' : 'b';
    public override void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException("Map not set!");

        Point NextPos = Map.NextDiagonal(Position, direction);

        if (NextPos == Position) return;

        Map.Move(this, Position, NextPos);
        Position = NextPos;
    }
}