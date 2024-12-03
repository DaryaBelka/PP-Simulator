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
        SmallTorusMap torusMap = new(6, 5);

        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Dog", Size = 3 },
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(4, 1),

        };

        string moves = "dlrludl";

        Simulation simulation = new Simulation(torusMap, creatures, points, moves);

        MapVisualizer mapVisualizer = new MapVisualizer(torusMap);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");

        mapVisualizer.Draw();
        var turn = 1;

        turn++;
    }
}
