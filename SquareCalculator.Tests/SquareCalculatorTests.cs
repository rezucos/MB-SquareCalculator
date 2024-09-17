using SquareCalculator.Abstract;
using SquareCalculator.Concrete.Figures;

namespace SquareCalculator.Tests;

public class SquareCalculatorTests
{
    [Fact]
    public void CalculateCircleSquareTest()
    {
        // Arrange
        double expectedResult = 1256.6370614359173;
        
        var circle = new Circle(20);

        // Act
        double result = circle.Square;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CalculateTriangleSquareTest()
    {
        // Arrange
        double expectedResult = 6;

        var triangle = new Triangle(3, 4, 5);

        // Act
        double result = triangle.Square;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CheckOnNonRectangular()
    {
        // Arrange
        bool expectedResult = false;

        var triangle = new Triangle(5, 5, 5);

        // Act
        bool result = triangle.IsRectangular;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(5, 4, 3, true)]
    [InlineData(4, 5, 3, true)]
    [InlineData(3, 4, 5, true)]
    public void CheckOnRectangular(int a, int b, int c, bool expectedResult)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);

        // Act
        bool result = triangle.IsRectangular;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void UnknownFigureType()
    {
        // Arrange
        List<Figure> figures =
        [
            new Circle(3),
            new Triangle(10, 6, 8)
        ];

        List<double> answers = [
            28.274333882308138,
            24
        ];

        List<double> results = [];

        // Act
        foreach (Figure f in figures) {
            results.Add(f.Square);
        }

        // Assert
        for (int i = 0; i < answers.Count; i++) {
            Assert.Equal(answers[i], results[i]);
        }
    }
}
