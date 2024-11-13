using System;
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

    public abstract string Greeting();
    public void Upgrade()
    {
        if (level != 10) level++;
        else return;
        
    }


    //Go functions
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public string[] Go(Direction[] directions)
    {
        List<string> list = new List<string>();
        foreach (var direction in directions) list.Add(Go(direction));
        return list.ToArray();
    }
    public string[] Go(string mov)
    {
        List<string> list = new List<string>();
        foreach (var direction in DirectionParser.Parse(mov)) list.Add(Go(direction));
        return list.ToArray();
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
