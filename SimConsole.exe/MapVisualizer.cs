using Simulator;
using Simulator.Maps;

namespace SimConsole;

public static class MapVisualizer
{
    public static string GetMap(Map map)
    {
        string temp = "";

        temp += DrawTop(map.SizeX);
        for (int i = 0; i < map.SizeY; i++)
        {
            temp += DrawCreaturesMap(i, map.SizeX, map);

            if (i != map.SizeY - 1)
                temp += DrawMiddle(map.SizeX);
        }
        temp += DrawBottom(map.SizeX);

        return temp;
    }

    private static string DrawTop(int SizeX)
    {
        string temp = "";

        temp += Box.TopLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.TopMid;
        }
        temp += Box.Horizontal;
        temp += Box.TopRight;

        temp += "\n";

        return temp;
    }

    private static string DrawBottom(int SizeX)
    {
        string temp = "";

        temp += Box.BottomLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.BottomMid;
        }
        temp += Box.Horizontal;
        temp += Box.BottomRight;

        temp += "\n";

        return temp;
    }

    private static string DrawMiddle(int SizeX)
    {
        string temp = "";

        temp += Box.MidLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.Cross;
        }
        temp += Box.Horizontal;
        temp += Box.MidRight;

        temp += "\n";

        return temp;
    }

    private static string DrawCreaturesMap(int row, int SizeX, Map map)
    {
        string temp = "";

        temp += Box.Vertical;
        for (int i = 0; i < SizeX; i++)
        {
            List<IMappable>? creaturesAt = map.At(i, map.SizeY - 1 - row);
            char toDraw;
            if (creaturesAt != null && creaturesAt.Count > 0)
            {
                toDraw = creaturesAt.Count > 1 ? 'X' : creaturesAt.First().Symbol;
            }
            else
            {
                toDraw = ' ';
            }

            temp += $"{toDraw}{Box.Vertical}";

        }
        temp += "\n";

        return temp;
    }
}