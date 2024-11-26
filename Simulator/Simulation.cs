using Simulator.Maps;
using Simulator;

public class Simulation
{
    private int turnCount = 0;
    private readonly List<Direction> allMoves;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => turnCount == allMoves.Count;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[turnCount % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => allMoves[turnCount].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    { /* implement */ 
        if (creatures.Count == 0) throw new ArgumentException("No creatures - cannot start a simulation.");
        if (creatures.Count != positions.Count) throw new ArgumentException("Number of positions does not match the number of creatures.");
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            if (Creatures[i].Map != Map)
                Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
        allMoves = DirectionParser.Parse(Moves);
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("Simulation finished!");
        Creature creature = CurrentCreature;

        CurrentCreature.Go(allMoves[turnCount++]);

    }
}