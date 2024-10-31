using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature {
    private int sing_counter=1;
    private int agility = 1;
    public int Agility
    {
        get => agility;
        private set
        {
            agility = value > 10 ? 10 : value < 0 ? 0 : value;
        }
    }
    public void Sing()
    {
        if (sing_counter % 3 == 0 && sing_counter != 0 && agility<10) agility += 1;
        sing_counter++;
        Console.WriteLine($"{Name} is singing");
    }
    public Elf() { }
    public Elf(string name, int agility, int level = 1) : base(name, level) {
        Name = name;
        Level = level;
        Agility = agility;
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, " +
            $"my level is {Level}, my agility is {Agility}.");
    }
    public override int Power
    {
        get
        {
            return Level * 8 + agility * 2;
        }
    }

    /*
    public override void SayHi()
    {
        Console.WriteLine($"Hi, i'm {Name}, my level is {Level}, my agility is {Agility}");
    }
    */

}