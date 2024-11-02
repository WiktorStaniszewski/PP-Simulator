using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
        if (value < min) return min;
        else if (value > max) return max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();
        if (value.Length < min) value = value.PadRight(min, placeholder);
        if (value.Length > max) value = value.Substring(0, max);
        value = $"{value[0].ToString().ToUpper()}{value.Substring(1)}";
        return value.Trim();
    }
}
