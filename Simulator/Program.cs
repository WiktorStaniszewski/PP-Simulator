namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting simulator!\n");
        Creature c = new Creature("Mike Wazowski", 2);
        c.SayHi();    
    }
}
