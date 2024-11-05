﻿namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount;
    public int Agility
    {
        get { return _agility; }
        private set
        {
            if (value < 0) _agility = 0;
            else if (value > 10) _agility = 10;
            else _agility = value;
        }
    }

    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility++;
        }
    }

    public override int Power => 8 * Level + 2 * Agility;


    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);

    public override string Info
    {
        get { return $"{Name} [{Level}][{Agility}]"; }
    }
}