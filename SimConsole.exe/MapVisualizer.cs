using Simulator;
using Simulator.Maps;
namespace SimConsole;

//do zrobienia - rozjebane to je
public class MapVisualizer
{
    public Map Map { get; init; }
    public MapVisualizer(Map _map)
    {
        Map = _map;
    }
    public void Draw()
    {
        DrawMapRows(-1);
        for (int j = 0; j < Map.SizeY; j++) 
        {
            if (j == 0) DrawMapRows(0);
            else DrawMapRows(1);
            for (int i = 0; i < Map.SizeX * 2 + 1; i++)
            { 
                if (i == 0) Console.Write($"{j,-3}");
                if (i % 2 == 0) Console.Write(Box.Vertical);
                else
                {
                    if (Map.At(i / 2, j) is not null)
                    {
                        if (Map.At(i / 2, j).Count > 1) Console.Write("X");
                        else if (Map.At(i / 2, j).Count == 0) Console.Write(" ");
                        else Console.Write(Map.At(i / 2, j)[0].Symbol);
                    }
                    else Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        DrawMapRows(2);
        Console.WriteLine();

    }

    private void DrawMapRows(int position) 
    {
        if (position == -1) Console.Write("y\\x");
        else Console.Write("   ");
        for (int i = 0; i < Map.SizeX * 2 + 1; i++)
        {
            if (position == 0)
            {
                if (i == 0) Console.Write(Box.TopLeft);
                else if (i == Map.SizeX * 2) Console.Write(Box.TopRight);
                else if (i % 2 == 0) Console.Write(Box.TopMid);
                else Console.Write(Box.Horizontal);
            }
            else if (position == 1)
            {
                if (i == 0) Console.Write(Box.MidLeft);
                else if (i == Map.SizeX * 2) Console.Write(Box.MidRight);
                else if (i % 2 == 0) Console.Write(Box.Cross);
                else Console.Write(Box.Horizontal);
            }
            else if (position == 2)
            {
                if (i == 0) Console.Write(Box.BottomLeft);
                else if (i == Map.SizeX * 2) Console.Write(Box.BottomRight);
                else if (i % 2 == 0) Console.Write(Box.BottomMid);
                else Console.Write(Box.Horizontal);
            }
            else if (position == -1)
            {
                if (i % 2 == 1) Console.Write(i / 2);
                else Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

    public void DisplayCreatureInfo(string info, int turn, string dir, string position = "<TBA>")
    {
        Console.WriteLine($"Tura {turn}.");
        Console.WriteLine($"{info} ruszył na pozycje {position}.");
        Console.WriteLine($"W kierunku: {dir}");
    }
}