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
    }

    static void Lab5a()
    {
        var rec1 = new Rectangle(1, 3, 6, 5);
        var rec2 = new Rectangle(4, 6, 1, 5); 
        var point1 = new Point(2, 3);
        var point2 = new Point(1, 6);
        var point3 = new Point(5, 7);
        var rec3 = new Rectangle(point1, point3); 
        var rec4 = new Rectangle(point1, point2); 

        Console.WriteLine(rec1);
        Console.WriteLine(rec2);
        Console.WriteLine(rec3);
        Console.WriteLine(rec4);

        try { var rec5 = new Rectangle(1, 1, 5, 7); }
        catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }

        Console.WriteLine(rec3.Contains(new Point(4, 4))); 
        Console.WriteLine(rec3.Contains(new Point(8, 4))); 
        Console.WriteLine(rec3.Contains(new Point(4, 8))); 
        Console.WriteLine(rec3.Contains(new Point(4, 1))); 
        Console.WriteLine(rec3.Contains(new Point(1, 4))); 
    }

    static void Lab5b()
    {
        var rectmap1 = new SmallSquareMap(7);

        try { var rectmap2 = new SmallSquareMap(25); }
        catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }

        Console.WriteLine(rectmap1.Exist(new Point(5, 2))); 
        Console.WriteLine(rectmap1.Exist(new Point(-4, 2))); 
        Console.WriteLine(rectmap1.Exist(new Point(4, 12))); 
        Console.WriteLine(rectmap1.Next(new Point(1, 3), Direction.Left)); 
        Console.WriteLine(rectmap1.Next(new Point(2, 6), Direction.Up)); 
        Console.WriteLine(rectmap1.NextDiagonal(new Point(1, 3), Direction.Left));
        Console.WriteLine(rectmap1.NextDiagonal(new Point(2, 6), Direction.Up));
        Console.WriteLine(rectmap1.NextDiagonal(new Point(0, 0), Direction.Up));
    }

    static void Lab8()
    {
        bool cleanmode = false;

        Console.OutputEncoding = Encoding.UTF8;
        SmallTorusMap map = new(8, 6);

        var strus = new Birds() { CanFly = false, Description = "Strus" };
        var kroliki = new Animals() { Description = "Kroliki" };
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Birds() { Description = "Wroble" }, strus, kroliki];
        List<Point> points = [new(2, 2), new(3, 1), new(0, 0), new(4, 4), new(1, 5)];
        string moves = "dlrludluurldldd";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();
        Console.ReadKey();
        while (!simulation.Finished)
        {
            if (cleanmode) Console.Clear();
            simulation.Turn();
            mapVisualizer.Draw();
            //stary kod - już nie działa. Zmień/napraw/usuń.
            mapVisualizer.DisplayCreatureInfo(simulation.MovedIMappableInfo.Info,
                                            simulation.TurnCounter,
                                            simulation.ReturnMoveTaken(),
                                            simulation.MovedIMappableInfo.Position.ToString());
            Console.ReadKey();
        }
    }

    static void Lab7testB()
    {
        //cleanmode
        Console.Write("Jeśli chcesz żeby konsola po ruchu rysowała się na nowo, wpisz 1. Jeśli nie - podaj cokolwiek: ");
        bool cleanmode = false;
        if (Console.ReadLine() == 1.ToString()) { cleanmode = true; Console.Clear(); }
        //cleanmode

        Console.OutputEncoding = Encoding.UTF8;
        SmallTorusMap map = new(5, 7);
        List<IMappable> creatures = [new Orc("Debjeva"), new Elf("Cuwfy"), new Elf("Cyńi Htajke")];
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
            /*mapVisualizer.DisplayCreatureInfo(simulation.ReturnMovedCreatureInfo(),
                                            simulation.ReturnMovedCreaturePosition(),
                                            simulation.TurnCounter,
                                            simulation.ReturnMoveTaken());*/
            Console.ReadKey();
        }
    }

    static void Lab9()
    {
        bool cleanmode = false; 

        Console.OutputEncoding = Encoding.UTF8;
        BigBounceMap map = new(8, 6);

        var strus = new Birds() { CanFly = false, Description = "Strus" };
        var orly = new Birds() { CanFly = true, Description = "orly" };
        var kroliki = new Animals() { Description = "kroliki", Size = 7 };
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), kroliki, strus, orly];
        List<Point> points = [new(0, 0), new(7, 5), new(2, 2), new(5, 5), new(4, 1)];
        string moves = "lrduuulrdduullrdrrud";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();
        Console.ReadKey();
        while (!simulation.Finished)
        {
            if (cleanmode) Console.Clear();
            simulation.Turn();
            mapVisualizer.Draw();
            mapVisualizer.DisplayCreatureInfo(simulation.MovedIMappableInfo.Info,
                                            simulation.TurnCounter,
                                            simulation.ReturnMoveTaken(),
                                            simulation.MovedIMappableInfo.Position.ToString());
            Console.ReadKey();
        }
    }

    static void Main(string[] args)
    {
        Lab9();
    }
}