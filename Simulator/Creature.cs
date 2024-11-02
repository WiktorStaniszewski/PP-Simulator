﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature //abstract zastepuje virtual - przy virtual mozna zrobic override'a ale nie musimy, a przy abstract wymusza zrobienie override'a i musi byc w abstrakcyjnej klasie
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            if (value == null) return;
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }
        
    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public Creature() { }
    public Creature(string name, int level = 1) 
    {
        Name = name;
        Level = level;
    }

    //Abstrakty
    public abstract int Power { get; }
    public abstract string Info { get; }

    public abstract void SayHi();
    public void Upgrade()
    {
        if (level != 10) level++;
        else return;
        
    }


    //Go functions
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions) Go(direction);
    }
    public void Go(string mov)
    {
        Direction[] movs = DirectionParser.Parse(mov);
        Go(movs);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
