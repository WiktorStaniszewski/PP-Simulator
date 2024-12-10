using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature : IMappable //abstract zastepuje virtual - przy virtual mozna zrobic override'a ale nie musimy, a przy abstract wymusza zrobienie override'a i musi byc w abstrakcyjnej klasie
{
    public char Symbol => GetType().Name[0];
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public virtual void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
        map.Add(this, Position);
    }
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

    public abstract string Greeting();
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    public void Upgrade()
    {
        if (level != 10) level++;
        else return;
        
    }
    public virtual void SelectMap(Map map, Point point)
    {
        Map = map;
        Position = point;
        map.Add(this, Position);
    }
    //Go stringi
    public void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException("Map not selected");
        Point NextPosition = Map.Next(Position, direction);

        Map.Move(this, Position, NextPosition);
        Position = NextPosition;
    }
}
