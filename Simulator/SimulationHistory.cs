using Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }
    private void Certifier(Dictionary<Point, char> dict)
    {
        foreach (var chara in _simulation.IMappables)
        {
            if (dict.ContainsKey(chara.Position)) dict[chara.Position] = 'X';
            else dict.Add(chara.Position, chara.Symbol);
        }
        TurnLogs.Add(new SimulationTurnLog()
        {
            Mappable = _simulation.MovedIMappableInfo.ToString(),
            Move = _simulation.ReturnMoveTaken(),
            Symbols = dict
        });
    }

    private void Run()
    {
        var chars = new Dictionary<Point, char>();
        Certifier(chars);

        while (!_simulation.Finished)
        {
            _simulation.Turn();
            chars = new Dictionary<Point, char>();
            Certifier(chars);
        }
    }
}