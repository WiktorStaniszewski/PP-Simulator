using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    {
        BigBounceMap bigBounceMap = new BigBounceMap(8, 6);

        Elf elf = new Elf();
        Orc orc = new Orc();
        Animals rabbits = new() { Description = "Rabbittos" };
        Birds ostrichs = new() { Description = "Ostrichchos" };
        Birds eagles = new() { Description = "Eaglos" };

        List<IMappable> mappables = new() { elf, orc, rabbits, ostrichs, eagles };
        List<Point> points = [new(7, 2), new(4, 5), new(4, 2), new(7, 5), new(3, 3)];

        string moves = "rrrrrdllrlrdurldurllldddurrr";

        Simulation simulation = new(bigBounceMap, mappables, points, moves);
        SimulationHistory simulationHhistory = new(simulation);

        simulationHhistory.DispalyMoveInfo(5);
        simulationHhistory.DispalyMoveInfo(10);
        simulationHhistory.DispalyMoveInfo(15);
        simulationHhistory.DispalyMoveInfo(20);

    }
}