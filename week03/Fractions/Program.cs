using System;

class Program
{
    static void Main(string[] args)
    {
        // Create and display various fractions.

        // Default fraction (1/1)
        Fraction f1 = new Fraction();
        DisplayFraction(f1);

        // Fraction with whole number (e.g., 5/1)
        Fraction f2 = new Fraction(5);
        DisplayFraction(f2);

        // Fraction with numerator and denominator (e.g., 3/4)
        Fraction f3 = new Fraction(3, 4);
        DisplayFraction(f3);

        // Fraction with numerator and denominator (e.g., 1/3)
        Fraction f4 = new Fraction(1, 3);
        DisplayFraction(f4);
    }

    // Helper method to display fraction details
    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine($"Fraction: {fraction.GetFractionString()}");
        Console.WriteLine($"Decimal Value: {fraction.GetDecimalValue():F2}");
    }
}
