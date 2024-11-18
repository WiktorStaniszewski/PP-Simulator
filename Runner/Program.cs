﻿using Simulator.Maps;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Lab5b();
    }

    static void Lab4a()
    {
        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);


        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("L                        egolas", agility: 2);
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
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
        Creature c = new Elf("Elandor", 5, 3);
        Console.WriteLine(c);  // ELF: Elandor [5]

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
        try
        {
            Rectangle rect = new Rectangle(new Point(5, 5), new Point(1, 1));
            Console.WriteLine(rect);

            Point pointInside = new Point(3, 3);
            Point pointOutside = new Point(6, 6);

            Console.WriteLine($"Point {pointInside} is inside: {rect.Contains(pointInside)}");
            Console.WriteLine($"Point {pointOutside} is inside: {rect.Contains(pointOutside)}");

            Rectangle invalidRect = new Rectangle(5, 1, 5, 1);
        }
        catch (ArgumentException ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(15);
            Point currentPoint = new Point(1, 15);
            Console.WriteLine(map.Exist(currentPoint));

            Console.WriteLine(currentPoint);
            currentPoint = map.Next(currentPoint, Direction.Down);
            Console.WriteLine(currentPoint);
            currentPoint = map.NextDiagonal(currentPoint, Direction.Down);
            Console.WriteLine(currentPoint);

            for (int i = 0; i < 15 ; i++)
            {
                currentPoint = map.NextDiagonal(currentPoint, Direction.Down);
                Console.WriteLine($"\n{currentPoint}");
            }

        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}