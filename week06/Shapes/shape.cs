using System;

public abstract class Shape
{
    // Color property
    public string Color { get; set; }

    // Constructor that accepts color
    public Shape(string color)
    {
        Color = color;
    }

    // Abstract method for calculating area
    public abstract double GetArea();
}
