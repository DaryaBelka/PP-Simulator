using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);

        List<Creature> creatures = new List<Creature>
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2), 
            new Point(3, 1)
        };

        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, creatures, points, moves);

        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");
 
        mapVisualizer.Draw(); 
    }
}
