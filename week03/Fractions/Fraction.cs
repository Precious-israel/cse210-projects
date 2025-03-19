using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        // Default to 1/1
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        _top = top;
        _bottom = bottom;
        Simplify();
    }

    public string GetFractionString()
    {
        // Returns the fraction as a string in "numerator/denominator" format
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        // Returns the decimal value of the fraction
        return (double)_top / _bottom;
    }

    // Method to simplify the fraction
    private void Simplify()
    {
        int gcd = GCD(_top, _bottom);
        _top /= gcd;
        _bottom /= gcd;
    }

    // Helper method to calculate the Greatest Common Divisor (GCD)
    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}
