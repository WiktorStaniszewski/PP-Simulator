using Simulator.Maps;
using Simulator;
namespace Simulator;
public class Simulation
{
    private int turnCount = 0;
    private readonly List<Direction> allMoves;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of iMappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of iMappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first iMappable, second for second and so on.
    /// When all iMappables make moves, 
    /// next move is again for first iMappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => turnCount == allMoves.Count;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable => IMappables[turnCount % IMappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => allMoves[turnCount].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if iMappables' list is empty,
    /// if number of iMappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> iMappables,
        List<Point> positions, string moves)
    { /* implement */ 
        if (iMappables.Count == 0) throw new ArgumentException("No iMappables - cannot start a simulation.");
        if (iMappables.Count != positions.Count) throw new ArgumentException("Number of positions does not match the number of iMappables.");
        Map = map;
        IMappables = iMappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < iMappables.Count; i++)
        {
            IMappables[i].InitMapAndPosition(Map, Positions[i]);
            Map.Add(IMappables[i], Positions[i]);
        }
            allMoves = DirectionParser.Parse(Moves);
    }

    /// <summary>
    /// Makes one move of current iMappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("Simulation finished!");
        IMappable iMappable = CurrentIMappable;

        CurrentIMappable.Go(allMoves[turnCount++]);

    }
}