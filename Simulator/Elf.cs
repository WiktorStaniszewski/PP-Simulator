using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature 
{
    public override string Symbol { get { return "E"; } }
    private int sing_counter=1;
    private int agility = 1;
    public int Agility
    {
        get => agility;
        private set
        {
            agility = Validator.Limiter(value, 0, 10);
            //agility = value > 10 ? 10 : value < 0 ? 0 : value;
        }
    }
    public override int Power => Level * 8 + agility * 2;
    public override string Info => $"{Name} [{Level}][{Agility}]";
    public void Sing()
    {
        if (sing_counter % 3 == 0 && sing_counter != 0 && agility<10) agility += 1;
        sing_counter++;
    }
    public Elf() : base() { }
    public Elf(string name, int level = 1, int agility=0) : base(name, level)
    {
        Name = name;
        Level = level;
        Agility = agility;
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

}