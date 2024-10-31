using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Orc : Creature {
    private int hunt_counter = 1;
    private int rage;
    public int Rage
    {
        get => rage;
        set
        {
            rage = value > 10 ? 10 : value < 0 ? 0 : value;
        }
    }
    public void Hunt()
    {
        if (hunt_counter % 2 == 0 && hunt_counter != 0 && rage < 10) rage += 1;
        hunt_counter++;
        Console.WriteLine($"{Name} is hunting");
    }
    public Orc() { }
    public Orc(string name, int rage = 1, int level = 1) : base(name, level)
    {
        Level = level;
        Name = name;
        Rage = rage;
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, " +
            $"my level is {Level}, my rage is {Rage}.");
    }
    public override int Power
    {
        get {
            return Level * 7 + rage * 3;
        }
    
    }



    /*
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() : base("Unknown Orc", 10) => Rage = 6;
    */
}
