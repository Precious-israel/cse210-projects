using System;

public class Circle : Shape
{
    // Private member variable for radius
    private double _radius;

    // Constructor that accepts color and radius, and calls the base constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea method from Shape class
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
