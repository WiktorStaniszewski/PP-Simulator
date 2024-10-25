using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            string temp_name = value;
            if (temp_name == null) return;
            temp_name = temp_name.Trim();
            while (temp_name.Length < 3) temp_name += "#";
            if (temp_name.Length > 25) temp_name = temp_name[..25].Trim();
            if (!Char.IsUpper(temp_name[0])) {
                temp_name = Char.ToUpper(temp_name[0]) + temp_name.Substring(1);
            }
            while (temp_name.Length < 3) temp_name += "#";
            name = temp_name;
        }
    }
        
    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            int temp_int = value;
            if (temp_int < 1) temp_int = 1;
            else if (temp_int > 10) temp_int = 10;
            level = temp_int;
        }
    }

    public Creature() { }
    public Creature(string name, int level = 1) 
    {
        Name = name;
        Level = level;
    }
    
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {level}.");
    }
    public void Upgrade()
    {
        if (level != 10) level += 1;
        else return;
        
    }
    public string Info => $"{Name} [{level}]";
}
