using ShapesTask.Compares;
using ShapesTask.Shapes;

namespace ShapesTask;

internal class ShapeMain
{
    static void Main(string[] args)
    {
        IShape[] shapes =
        {
            new Square(5),
            new Square(10),
            new Rectangle(5.3, 12.5),
            new Rectangle(3, 5),
            new Circle(2),
            new Circle(5.5),
            new Triangle(1, 3, 4.5, 2, 5, 2.5),
            new Triangle(-2, 0, 3, -1, 3, -1)
        };

        Array.Sort(shapes, new ShapesAreaComparer());
        Console.WriteLine("Фигура с максимальной площадью = {0}", shapes[^1]);

        Array.Sort(shapes, new ShapesPerimeterComparer());
        Console.WriteLine("Фигура со второй по величине периметром = {0}", shapes[^2]);
    }
}