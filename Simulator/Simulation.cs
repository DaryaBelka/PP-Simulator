using Simulator.Maps;
using System.Diagnostics.Metrics;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;


    private int _index = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { 
        get => Creatures[_index % Creatures.Count]; 
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName {
        get => Moves[_index % Moves.Length].ToString().ToLower();
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Creature list cannot be empty.");
        }

        if (positions == null || positions.Count != creatures.Count)
        {
            throw new ArgumentException("The number of initial positions does not match the number of creatures.");
        }

        if (string.IsNullOrEmpty(moves))
        {
            throw new ArgumentException("Moves string cannot be empty or null.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        // Initialize creatures' starting positions on the map.
        for (int i = 0; i < Creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is already finished.");
        }

        char moveChar = Moves[_index % Moves.Length];

        Direction direction;
        try
        {
            direction = DirectionParser.Parse(moveChar.ToString())[0];
        }
        catch (Exception)
        {
            throw new InvalidOperationException($"Invalid move character: '{moveChar}'. Valid moves: 'U', 'D', 'L', 'R'.");
        }

        CurrentCreature.Go(direction);
        _index++;

        if (_index >= Moves.Length)
        {
            Finished = true;
        }
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}
