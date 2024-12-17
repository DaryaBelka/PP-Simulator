using Simulator.Maps;
using Simulator;

namespace SimWeb;
public class App
{
    public static SimulationHistory SimulationHistory { get; set; }
    static App()
    {
        var map = new BigTorusMap(8, 6);
        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbit", Size = 3 },
            new Birds { Description = "Eagle", Size = 2, CanFly = true  },
            new Birds { Description = "Ostrich", Size = 5, CanFly = false },
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(4, 1),
            new Point(1, 3),
            new Point(6, 4),
        };
        string moves = "dlrlldlrudlrurl";
        var simulation = new Simulation(map, creatures, points, moves);
        SimulationHistory = new SimulationHistory(simulation);
    }
}