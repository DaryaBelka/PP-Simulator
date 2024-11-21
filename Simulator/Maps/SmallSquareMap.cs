namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        if (sizeX != sizeY)
        {
            throw new ArgumentException("SmallSquareMap must have equal width and height");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);
        return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;

    }
}
