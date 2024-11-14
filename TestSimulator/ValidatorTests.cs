using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]    
    [InlineData(0, 1, 10, 1)]   
    [InlineData(15, 1, 10, 10)]
    [InlineData(20, 10, 20, 20)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Walidatory.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", 3, 5, '-', "---")]
    [InlineData("   pracownia", 5, 10, ' ', "Pracownia")]
    [InlineData("Informatyka stosowana", 5, 10, ' ', "Informatyk")]  
    [InlineData("IS", 5, 10, ' ', "IS   ")]          
    [InlineData("Hello", 5, 10, ' ', "Hello")]        
    [InlineData("A", 3, 5, '*', "A**")]               
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Walidatory.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}
