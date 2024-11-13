using System;
using System.Runtime.ExceptionServices;

namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    public string Name { 
        get { return _name; }
        init { 
            if (value == null)
            {
                _name = "Unknown";
                return;
            }
            
            value = value.Trim(); // Usuń nadmiarowe spacje na początku i końcu

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 25)
                value = value.Substring(0, 25).TrimEnd();
 
            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1); ;
           
            _name = value;
        }
    }

    public int Level {
        get { return _level; }
        init
        {
            if (value < 1) _level = 1;
            else if (value > 10) _level = 10;
            else _level = value;

      }
    }
    
    public Creature(string name, int level = 1)
    {
    Name = name; Level = level;
}

    public Creature() {
    }

    public string Greeting { get; }
    public abstract int Power { get; }

    public abstract string Info
    {
        get;
    }   
    
    public void Upgrade()
    { 
        if (Level < 10 )
            _level ++;    
      
    }


    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public string[] Go(string directionSeq) =>
        Go(DirectionParser.Parse(directionSeq));

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}
