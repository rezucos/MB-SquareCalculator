using SquareCalculator.Abstract;

namespace SquareCalculator.Concrete.Figures;

public sealed class Circle(double r) : Figure
{
    private const double PI = Math.PI;
    public double Radius { get; private set; } = r;

    protected override double CalculateSquare()
    {
        return PI * Math.Pow(Radius, 2);
    }

    protected override void Validate()
    {
        if (Radius <= 0)
            throw new ArgumentOutOfRangeException("Radius must be greater than 0");
    }
}
