using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenX1EqualsX2()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 8));
        Assert.Equal("Nie chcemy chudych prostokątów", exception.Message);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var rect = new Rectangle(2, 2, 6, 6);

        // Act
        var result = rect.ToString();

        // Assert
        Assert.Equal("(2, 2):(6, 6)", result);
    }

    [Theory]
    [InlineData(2, 2, 8, 6, 5, 4, true)]
    [InlineData(2, 2, 8, 6, 8, 3, true)]   
    [InlineData(2, 2, 8, 6, 5, 6, true)]
    [InlineData(2, 2, 8, 6, 4, 1, false)]
    public void Contains_ShouldReturnCorrectResult(int x1, int y1, int x2, int y2, int px, int py, bool expectedResult)
    {
        // Arrange
        var rect = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);

        // Act
        var result = rect.Contains(point);

        // Assert
        Assert.Equal(expectedResult, result);
    }

}
