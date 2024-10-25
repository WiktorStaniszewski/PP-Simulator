using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Animals
{
    private string description = "";
    public required string Description
    {
        get => description;
        init
        {
            string temp_desc = value;
            if (temp_desc == null) return;
            temp_desc = temp_desc.Trim();
            while (temp_desc.Length < 3) temp_desc += "#";
            if (temp_desc.Length > 15) temp_desc = temp_desc[..15];
            if (!Char.IsUpper(temp_desc[0])) {
                temp_desc = Char.ToUpper(temp_desc[0]) + temp_desc.Substring(1);
            }
            while (temp_desc.Length < 3) temp_desc += "#";
            description = temp_desc.Trim();
        }
    }
    public uint Size { get; set; } = 3;
    public string Info => $"{Description} <{Size}>";
}
