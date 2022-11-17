#if FNA || MONOGAME
using Microsoft.Xna.Framework;

using Velentr.Core.Shapes;

using Point = Velentr.Core.Shapes.Point;
using Rectangle = Velentr.Core.Shapes.Rectangle;

namespace Velentr.Core.Helpers.Extensions
{
    /// <summary>
    /// Various extensions for Velentr.Core Shapes
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        ///     A Vector2 extension method that converts a vector to a velentr point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Vector as a Point.
        /// </returns>
        public static Point ToVelentrPoint(this Microsoft.Xna.Framework.Point point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        ///     A PointI extension method that converts a point to an xna point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Point as a Microsoft.Xna.Framework.Point.
        /// </returns>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this Point point)
        {
            return new Microsoft.Xna.Framework.Point(point.IntX, point.IntY);
        }

        /// <summary>
        ///     A Vector2 extension method that converts a vector to a velentr point.
        /// </summary>
        /// <param name="vector">   The vector to act on. </param>
        /// <returns>
        ///     Vector as a Point.
        /// </returns>
        public static Point ToVelentrPoint(this Vector2 vector)
        {
            return new Point(vector.X, vector.Y);
        }

        /// <summary>
        ///     A PointI extension method that converts a point to a vector 2.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Point as a Vector2.
        /// </returns>
        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.IntX, point.IntY);
        }

        /// <summary>
        ///     A Vector2 extension method that converts a vector to a velentr point i.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Vector as a PointI.
        /// </returns>
        public static PointI ToVelentrPointI(this Microsoft.Xna.Framework.Point point)
        {
            return new PointI(point.X, point.Y);
        }

        /// <summary>
        ///     A PointI extension method that converts a point to an xna point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Point as a Microsoft.Xna.Framework.Point.
        /// </returns>
        public static Microsoft.Xna.Framework.Point ToXnaPoint(this PointI point)
        {
            return new Microsoft.Xna.Framework.Point(point.X, point.Y);
        }

        /// <summary>
        ///     A Vector2 extension method that converts a vector to a velentr point i.
        /// </summary>
        /// <param name="vector">   The vector to act on. </param>
        /// <returns>
        ///     Vector as a PointI.
        /// </returns>
        public static PointI ToVelentrPointI(this Vector2 vector)
        {
            return new PointI(vector.X, vector.Y);
        }

        /// <summary>
        ///     A PointI extension method that converts a point to a vector 2.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Point as a Vector2.
        /// </returns>
        public static Vector2 ToVector2(this PointI point)
        {
            return new Vector2(point.X, point.Y);
        }

        /// <summary>
        ///     A Microsoft.Xna.Framework.Rectangle extension method that converts a rectangle to a velentr
        ///     rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle to act on. </param>
        /// <returns>
        ///     Rectangle as a Rectangle.
        /// </returns>
        public static Rectangle ToVelentrRectangle(this Microsoft.Xna.Framework.Rectangle rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     A RectangleD extension method that converts a rectangle to an xna rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle to act on. </param>
        /// <returns>
        ///     Rectangle as a Microsoft.Xna.Framework.Rectangle.
        /// </returns>
        public static Microsoft.Xna.Framework.Rectangle ToXnaRectangle(this Rectangle rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     A Microsoft.Xna.Framework.Rectangle extension method that converts a rectangle to a velentr
        ///     rectangle d.
        /// </summary>
        /// <param name="rectangle">    The rectangle to act on. </param>
        /// <returns>
        ///     Rectangle as a RectangleD.
        /// </returns>
        public static RectangleD ToVelentrRectangleD(this Microsoft.Xna.Framework.Rectangle rectangle)
        {
            return new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     A RectangleD extension method that converts a rectangle to an xna rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle to act on. </param>
        /// <returns>
        ///     Rectangle as a Microsoft.Xna.Framework.Rectangle.
        /// </returns>
        public static Microsoft.Xna.Framework.Rectangle ToXnaRectangle(this RectangleD rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.IntX, rectangle.IntY, rectangle.IntWidth, rectangle.IntHeight);
        }

        /// <summary>
        ///     A Vector3 extension method that converts a vector to a circle.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     Vector as a Circle.
        /// </returns>
        public static Circle ToCircle(this Microsoft.Xna.Framework.Point point)
        {
            return new Circle(point.X, point.Y, 1);
        }

        /// <summary>
        ///     A Vector3 extension method that converts a vector to a circle.
        /// </summary>
        /// <param name="vector">   The vector to act on. </param>
        /// <returns>
        ///     Vector as a Circle.
        /// </returns>
        public static Circle ToCircle(this Vector2 vector)
        {
            return new Circle(vector.X, vector.Y, 1);
        }

        /// <summary>
        ///     A Vector3 extension method that converts a vector to a circle.
        /// </summary>
        /// <param name="vector">   The vector to act on. </param>
        /// <returns>
        ///     Vector as a Circle.
        /// </returns>
        public static Circle ToCircle(this Vector3 vector)
        {
            return new Circle(vector.X, vector.Y, vector.Z);
        }
    }
}
#endif
