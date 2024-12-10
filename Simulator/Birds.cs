using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals, IFlying
{
    public override string Symbol
    {
        get
        {
            if (canFly == true) return "B";
            else if (canFly == false) return "b";
            else return "q";
        }
    }
    private bool canFly = true;
    public bool CanFly
    {
        get { return canFly; }
        set { canFly = value; }
    }
    public override string Info
    {
        get
        {
            string fly = "", output = " ";
            if (canFly) fly = "fly+";
            else fly = "fly-";
            output = $"{Description} ({fly}) <{Size}>";
            return output;
        }
    }
    public override void Go(Direction dir)
    {
        if (Map == null) throw new Exception("Stwor nie znajduje się na zadnej mapie.");
        var nextpoint = new Point();
        if (!canFly)
        {
            nextpoint = Map.NextDiagonal(Position, dir);
        }
        else
        {
            nextpoint = Map.Next(Map.Next(Position, dir), dir);
        }
        Map.Move(this, Position, nextpoint);
        Position = nextpoint;
    }
}