namespace Simulator;

public class Animals
{
    public uint Size { get; set; } = 3;
    private string _description = "Unknown";
    public required string Description

    {
        get { return _description; }
        init
        {
            if (value == null)
            {
                _description = "Unknown";
                return;
            }

            value = value.Trim();
            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 15)
                value = value.Substring(0, 15).TrimEnd();

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1); ;


            _description = value;
        }
    }


    //public string Info
    //{
    //    get
    //    {
    //        return Description + " <" + Size + ">";
    //    }
    //}

    public virtual string Info => $"{Description} <{Size}>"; //np. Dogs <3>

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}