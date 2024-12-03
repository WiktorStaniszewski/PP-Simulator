using SimConsole;
using Simulator;
using Simulator.Maps;
using System.Text;

namespace Simulator;

internal class Program
{
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        //o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            //o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        //e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            //e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        var rec1 = new Rectangle(1, 3, 6, 5); //x1, x2, y1, y2 -> (1,5) (3,6)
        var rec2 = new Rectangle(4, 6, 1, 5); //x1, x2, y1, y2 -> (4,1) (6,5)
        var point1 = new Point(2, 3);
        var point2 = new Point(1, 6);
        var point3 = new Point(5, 7);
        var rec3 = new Rectangle(point1, point3); //(2,3) (5,7)
        var rec4 = new Rectangle(point1, point2); //(2,3) (1,6) -> (1,3) (2,6) 

        Console.WriteLine(rec1);
        Console.WriteLine(rec2);
        Console.WriteLine(rec3);
        Console.WriteLine(rec4);

        try { var rec5 = new Rectangle(1, 1, 5, 7); }
        catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }

        Console.WriteLine(rec3.Contains(new Point(4, 4))); //T
        Console.WriteLine(rec3.Contains(new Point(8, 4))); //F
        Console.WriteLine(rec3.Contains(new Point(4, 8))); //F
        Console.WriteLine(rec3.Contains(new Point(4, 1))); //F
        Console.WriteLine(rec3.Contains(new Point(1, 4))); //F
    }

    static void Lab5b()
    {
        var rectmap1 = new SmallSquareMap(7);

        try { var rectmap2 = new SmallSquareMap(25); }
        catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }

        Console.WriteLine(rectmap1.Exist(new Point(5, 2))); //T
        Console.WriteLine(rectmap1.Exist(new Point(-4, 2))); //F
        Console.WriteLine(rectmap1.Exist(new Point(4, 12))); //F
        Console.WriteLine(rectmap1.Next(new Point(1, 3), Direction.Left)); //(0,3)
        Console.WriteLine(rectmap1.Next(new Point(2, 6), Direction.Up)); //(2,6)
        Console.WriteLine(rectmap1.NextDiagonal(new Point(1, 3), Direction.Left));//(0,4)
        Console.WriteLine(rectmap1.NextDiagonal(new Point(2, 6), Direction.Up));//(2,6)
        Console.WriteLine(rectmap1.NextDiagonal(new Point(0, 0), Direction.Up));//(1,1)
    }

    static void Lab7testA()
    {
        bool cleanmode = true; //true to że czyści konsolkę co readkey. Jak coś to podmienię zwyczajnie na false - ewentualnie usunę

        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();
        Console.ReadKey();
        while (!simulation.Finished)
        {
            if (cleanmode) Console.Clear();
            simulation.Turn();
            mapVisualizer.Draw();
            Console.ReadKey();
        }
    }

    static void Lab7testB()
    {
        //cleanmode
        Console.Write("");
        bool cleanmode = false;
        if (Console.ReadLine() == 1.ToString()) { cleanmode = true; Console.Clear(); }
        //cleanmode

        Console.OutputEncoding = Encoding.UTF8;
        SmallTorusMap map = new(5, 7);
        List<IMappable> creatures = [new Orc("wqqwwwee  ss"), new Elf("ffff"), new Elf("dsadsa")];
        List<Point> points = [new(0, 2), new(3, 1), new(4, 4)];
        string moves = "rrldudlldu";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();
        Console.ReadKey();
        while (!simulation.Finished)
        {
            if (cleanmode) Console.Clear();
            simulation.Turn();
            mapVisualizer.Draw();
            Console.ReadKey();
        }
    }


    static void Main(string[] args)
    {
        Lab7testB();
    }
}