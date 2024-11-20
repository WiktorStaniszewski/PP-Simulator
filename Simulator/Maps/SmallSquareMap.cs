using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d))) return p.Next(d);
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
        return p;
    }
}
