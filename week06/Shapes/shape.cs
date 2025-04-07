using System;

public abstract class Shape
{
    public string _color;

    // Constructor that accepts color
    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }
 public abstract double GetArea();
}
