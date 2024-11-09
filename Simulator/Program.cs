namespace Simulator;

class Program
{
    static void Main()
    {
        Lab5a();
        Lab5b();
    }
    static void Lab5a()
    {
        try
        {
            var r1 = new Rectangle(1, 3, 5, 7);
            Console.WriteLine($"{r1}");

            var p1 = new Point(3, 4);
            var p2 = new Point(7, 8);
            var r2 = new Rectangle(p1, p2);
            Console.WriteLine($"{r2}");

            var point1 = new Point(3, 4);
            var point2 = new Point(9, 10);
            Console.WriteLine($"Punkt {point1} jest w prostokącie: {r1.Contains(point1)}");
            Console.WriteLine($"Punkt {point2} jest w prostokącie: {r1.Contains(point2)}");

            var r3 = new Rectangle(2, 2, 2, 2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Lab5b()
    {
        try
        {
            var map = new SmallSquareMap(8);
            Console.WriteLine($"Map size: {map.Size}");

            var point1 = new Point(6, 7);
            var point2 = new Point(10, 15);
            Console.WriteLine($"Point {point1} is in the map: {map.Exist(point1)}"); 
            Console.WriteLine($"Point {point2} is in the map: {map.Exist(point2)}");

            var poczPoint = new Point(6, 5);
            var nextPoint = map.Next(poczPoint, Direction.Left);
            Console.WriteLine($"Next point: {nextPoint}");

            var diagonalPoint = map.NextDiagonal(poczPoint, Direction.Up);
            Console.WriteLine($"Diagonal point: {diagonalPoint}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}