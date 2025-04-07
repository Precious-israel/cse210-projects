using System;


class Program
{
    static void Main()
    {
        // Create instances of shapes
        Square square = new Square("Red", 4.0);
        Rectangle rectangle = new Rectangle("Blue", 5.0, 3.0);
        Circle circle = new Circle("Green", 2.5);

        // List to hold all shapes
        List<Shape> shapes = new List<Shape>
        {
            square,
            rectangle,
            circle
        };

        // Iterate through the shapes and display their color and area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine(); // Add a line break for better readability
        }
    }
}
