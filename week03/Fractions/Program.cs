using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a default fraction (0/1)
        Fraction f1 = new Fraction();
        DisplayFraction(f1);

        // Create a fraction with a whole number (5/1)
        Fraction f2 = new Fraction(5);
        DisplayFraction(f2);

        // Create a fraction with a numerator and denominator (3/4)
        Fraction f3 = new Fraction(3, 4);
        DisplayFraction(f3);

        // Create a fraction with a numerator and denominator (1/3)
        Fraction f4 = new Fraction(1, 3);
        DisplayFraction(f4);
    }

    // Method to display fraction details
    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine($"Fraction: {fraction.GetFractionString()}");
        Console.WriteLine($"Decimal Value: {fraction.GetDecimalValue():F2}");
    }
}

// Fraction class definition
class Fraction
{
    private int numerator;
    private int denominator;

    // Default constructor (0/1)
    public Fraction()
    {
        numerator = 0;
        denominator = 1;
    }

    // Constructor for whole number (n/1)
    public Fraction(int wholeNumber)
    {
        numerator = wholeNumber;
        denominator = 1;
    }

    // Constructor for numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        this.numerator = numerator;
        this.denominator = denominator;
        Simplify();
    }

    // Method to get the fraction as a string
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to get the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }

    // Simplify the fraction (e.g., 4/8 -> 1/2)
    private void Simplify()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Helper method to calculate the greatest common divisor (GCD)
    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}
