﻿namespace ShapeTask;

internal class ShapeMain
{
    static void Main(string[] args)
    {
        Square square1 = new Square(5);
        Square square2 = new Square(10);

        Rectangle rectangle1 = new Rectangle(5.3, 12.5);
        Rectangle rectangle2 = new Rectangle(3, 5);

        Circle circle1 = new Circle(2);
        Circle circle2 = new Circle(5.5);

        Triangle triangle1 = new Triangle(1, 3, 4.5, 2, 5, 2.5);
        Triangle triangle2 = new Triangle(-2, 0, 3, -1, 3, -1);

        IShape[] shapes = { square1, square2, rectangle1, rectangle2, circle1, circle2, triangle1, triangle2 };

        ShapesAreaComparer areaComparer = new ShapesAreaComparer();
        Array.Sort(shapes, areaComparer);

        Console.WriteLine("Максимальная по величине площадь = {0}", shapes[0]);
        Console.WriteLine("Вторая по величине площадь = {0}", shapes[1]);
    }
}