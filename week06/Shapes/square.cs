using System;

public class Square : Shape
{
    // Private member variable for side
    private double _side;

    // Constructor that accepts color and side, and calls the base constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea method from Shape class
    public override double GetArea()
    {
        return _side * _side;
    }
}
