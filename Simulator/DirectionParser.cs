using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string text)
    {
        List<Direction> finalDir = new();

        foreach (var charac in text) 
        { 
            switch (charac.ToString().ToLower())
            {
                case "u":
                    finalDir.Add(Direction.Up);
                    break;
                case "d":
                    finalDir.Add(Direction.Down);
                    break;
                case "l":
                    finalDir.Add(Direction.Left);
                    break;
                case "r":
                    finalDir.Add(Direction.Right);
                    break;
                default:
                    break;
            }

        }
        return finalDir;
    }

}
