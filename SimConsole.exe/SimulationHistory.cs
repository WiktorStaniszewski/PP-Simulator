using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationHistory
{
    private readonly Simulation simulation;
    private readonly List<IMappable> allMappables;
    private readonly List<string> currentMapState;
    private readonly List<string> moves;

    public SimulationHistory(Simulation simulation)
    {
        this.simulation = simulation;

        allMappables = new List<IMappable?>();
        currentMapState = new List<string>();
        moves = new List<string>();

        currentMapState.Add(MapVisualizer.GetMap(simulation.Map));
        allMappables.Add(null);
        moves.Add("Brak ruchu");

        while (!simulation.Finished)
        {
            allMappables.Add(simulation.CurrentIMappable);
            moves.Add(simulation.CurrentMoveName);
            simulation.Turn();

            currentMapState.Add(MapVisualizer.GetMap(simulation.Map));
        }
    }
        public void DispalyMoveInfo(int moveNumber)
        {
            if (moveNumber >= currentMapState.Count) { throw new ArgumentOutOfRangeException("move number exceedes number of moves"); }

            Console.WriteLine($"Move Number: {moveNumber}"
                + $"\nWhat Moved : {allMappables[moveNumber]}"
                + $"\nWhere Moved : {moves[moveNumber]}"
                + $"\n\n{currentMapState[moveNumber]}");
        }
}
