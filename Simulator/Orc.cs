using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Orc : Creature
{
    private int hunt_counter = 1;
    private int rage;
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
            //rage = value > 10 ? 10 : value < 0 ? 0 : value;
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Level = level;
        Name = name;
        Rage = rage;
    }
    public override int Power => Level * 7 + rage * 3;
    public override string Info => $"{Name} [{Level}][{Rage}]";

    public void Hunt()
    {
        if (hunt_counter % 2 == 0 && hunt_counter != 0 && rage < 10) rage ++;
        hunt_counter++;
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    
}