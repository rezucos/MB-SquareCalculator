using SquareCalculator.Abstract;

namespace SquareCalculator.Concrete.Figures;

public sealed class Triangle(double a, double b, double c) : Figure
{
    public double SideA { get; private set; } = a;
    public double SideB { get; private set; } = b;
    public double SideC { get; private set; } = c;
    public bool IsRectangular
    {
        get
        {
            double hypotenuse = Math.Max(SideA, Math.Max(SideB, SideC));

            bool IsPythagoreanTheoremPerformed;

            if (hypotenuse == SideA)
            {
                IsPythagoreanTheoremPerformed = Math.Pow(SideA, 2) == Math.Pow(SideB, 2) + Math.Pow(SideC, 2);
            }
            else if (hypotenuse == SideB)
            {
                IsPythagoreanTheoremPerformed = Math.Pow(SideB, 2) == Math.Pow(SideA, 2) + Math.Pow(SideC, 2);
            }
            else
            {
                IsPythagoreanTheoremPerformed = Math.Pow(SideC, 2) == Math.Pow(SideA, 2) + Math.Pow(SideB, 2);
            }

            return IsPythagoreanTheoremPerformed;
        }
    }

    protected override double CalculateSquare()
    {
        double semiPerimeter = (SideA + SideB + SideC) / 2;

        return Math.Sqrt(semiPerimeter
            * (semiPerimeter - SideA)
            * (semiPerimeter - SideB)
            * (semiPerimeter - SideC));
    }

    protected override void Validate()
    {
        if (SideA <= 0)
            throw new ArgumentOutOfRangeException("Side A of the triangle must be greater than 0");

        if (SideB <= 0)
            throw new ArgumentOutOfRangeException("Side B of the triangle must be greater than 0");

        if (SideC <= 0)
            throw new ArgumentOutOfRangeException("Side C of the triangle must be greater than 0");
    }
}
