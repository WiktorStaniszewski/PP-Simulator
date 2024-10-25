using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    public string ?Name { get; set; }
    public int Level { get; set; } = 1;
    public string Info => $"{Name} [{Level}]";
    
    public Creature() { }
    public Creature(string name, int level) 
    {
        Name = name;
        Level = level;
    }
    
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

}
