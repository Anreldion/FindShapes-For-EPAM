using System.Collections.Generic;
using ShapeLib.Shapes;

namespace ShapeLib.Calculators
{
    /// <summary>
    /// Defines geometric operations that can be performed on collections of shapes.
    /// </summary>
    public interface IShapeCalculator
    {
        /// <summary>
        /// Returns the shape with the largest area from the provided collection.
        /// </summary>
        /// <param name="list">A collection of shapes.</param>
        /// <returns>The shape that has the largest area.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
        Shape GetLargestAreaShape(IEnumerable<Shape> list);

        /// <summary>
        /// Calculates the average perimeter of all shapes in the provided collection.
        /// </summary>
        /// <param name="list">A collection of shapes.</param>
        /// <returns>The average perimeter of all shapes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
        double GetAveragePerimeter(IEnumerable<Shape> list);

        /// <summary>
        /// Calculates the total area of all shapes in the provided collection.
        /// </summary>
        /// <param name="list">A collection of shapes.</param>
        /// <returns>The sum of the areas of all shapes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null.</exception>
        double GetAreaSum(IEnumerable<Shape> list);

        /// <summary>
        /// Returns the shape type (by name) that has the highest average perimeter across all instances in the collection.
        /// </summary>
        /// <param name="list">A collection of shapes.</param>
        /// <returns>
        /// A key-value pair where the key is the shape name and the value is the average perimeter of that shape type.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
        KeyValuePair<string, double> GetShapeWithMaxAveragePerimeter(IEnumerable<Shape> list);
    }
}
