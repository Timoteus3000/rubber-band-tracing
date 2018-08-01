using System;

namespace RubberBandTracingWF.Vector2DLibrary
{
    /// <summary>
    /// A class who presents a two dimensional vector, with a X- and a Y-coordinate.
    /// </summary>
    public class Vector2D
    {
        //declarations
        #region declarations
        private double xCoordinate;
        private double yCoordinate;

        //properties
        #region properties
        /// <summary>X-Position of the <see cref="Vector2D"/>.</summary>
        public double XCoordinate { get => xCoordinate; set => xCoordinate = value; }

        /// <summary>Y-Position of the <see cref="Vector2D"/>.</summary>
        public double YCoordinate { get => yCoordinate; set => yCoordinate = value; }
        #endregion properties

        #endregion declarations

        //constructors
        #region constructors
        /// <summary>
        /// Initialized a new <see cref="Vector2D"/>-object with standard position (0|0).
        /// </summary>
        public Vector2D()
        {
            this.xCoordinate = 0.0;
            this.yCoordinate = 0.0;
        }

        /// <summary>
        /// Initialized a new <see cref="Vector2D"/>-object with the passed position.
        /// </summary>
        /// <param name="xCoordinate">X-coordinate</param>
        /// <param name="yCoordinate">Y-coordinate</param>
        public Vector2D(double xCoordinate, double yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        /// <summary>
        /// Initialized a new <see cref="Vector2D"/>-object with the X- and Y-coordinate from the passed <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="copyVec2D"><see cref="Vector2D"/>-reference to copy.</param>
        public Vector2D(Vector2D copyVec2D)
        {
            this.xCoordinate = copyVec2D.xCoordinate;
            this.yCoordinate = copyVec2D.yCoordinate;
        }
        #endregion constructors

        //methods
        #region methods

        #region operatorMethods
        public static Vector2D operator +(Vector2D leftVec2D, Vector2D rightVec2D) => 
            new Vector2D(leftVec2D.xCoordinate + rightVec2D.xCoordinate, leftVec2D.yCoordinate + rightVec2D.yCoordinate);
        public static Vector2D operator ++(Vector2D leftVec2D) => 
            new Vector2D(++leftVec2D.xCoordinate, ++leftVec2D.yCoordinate);
        public static Vector2D operator -(Vector2D leftVec2D, Vector2D rightVec2D) => 
            new Vector2D(leftVec2D.xCoordinate - rightVec2D.xCoordinate, leftVec2D.yCoordinate - rightVec2D.yCoordinate);
        public static Vector2D operator --(Vector2D leftVec2D) => 
            new Vector2D(--leftVec2D.xCoordinate, --leftVec2D.yCoordinate);
        public static Vector2D operator *(Vector2D leftVec2D, Vector2D rightVec2D) => 
            new Vector2D(leftVec2D.xCoordinate * rightVec2D.xCoordinate, leftVec2D.yCoordinate * rightVec2D.yCoordinate);
        public static Vector2D operator /(Vector2D leftVec2D, Vector2D rightVec2D) => 
            new Vector2D(leftVec2D.xCoordinate / rightVec2D.xCoordinate, leftVec2D.yCoordinate / rightVec2D.yCoordinate);
        public static Vector2D operator ^(Vector2D leftVec2D, Vector2D rightVec2D) => 
            new Vector2D(Math.Pow(leftVec2D.xCoordinate, rightVec2D.xCoordinate), Math.Pow(leftVec2D.yCoordinate, rightVec2D.yCoordinate));

        public static bool operator ==(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate == rightVec2D.xCoordinate && leftVec2D.yCoordinate == rightVec2D.yCoordinate);
        public static bool operator !=(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate != rightVec2D.xCoordinate || leftVec2D.yCoordinate != rightVec2D.yCoordinate);

        public static bool operator >(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate > rightVec2D.xCoordinate && leftVec2D.yCoordinate > rightVec2D.yCoordinate);
        public static bool operator >=(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate >= rightVec2D.xCoordinate && leftVec2D.yCoordinate >= rightVec2D.yCoordinate);
        public static bool operator <(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate < rightVec2D.xCoordinate && leftVec2D.yCoordinate < rightVec2D.yCoordinate);
        public static bool operator <=(Vector2D leftVec2D, Vector2D rightVec2D) => 
            (leftVec2D.xCoordinate <= rightVec2D.xCoordinate && leftVec2D.yCoordinate <= rightVec2D.yCoordinate);
        #endregion operatorMethods

        #region ownMethods
        /// <summary>
        /// Returns the length of this vector.
        /// </summary>
        /// <returns>Length of this vector.</returns>
        public double GetLength() => 
            Math.Sqrt(this.xCoordinate * this.xCoordinate + this.yCoordinate * this.yCoordinate);

        /// <summary>
        /// Normalized this vector.
        /// </summary>
        public void Normalize()
        {
            double currentLength = Math.Sqrt(this.xCoordinate * this.xCoordinate + this.yCoordinate * this.yCoordinate);

            if (currentLength != 0)
            {
                this.xCoordinate /= currentLength;
                this.yCoordinate /= currentLength;
            }
        }

        /// <summary>
        /// Return a copy of this vector.
        /// </summary>
        /// <returns>Copy of this vector.</returns>
        public Vector2D GetCopy() => 
            new Vector2D(this.xCoordinate, this.yCoordinate);

        /// <summary>
        /// Adds the coordinates from the passed vector to this vector.
        /// </summary>
        /// <param name="addVec2D"></param>
        public void Add(Vector2D addVec2D)
        {
            this.xCoordinate += addVec2D.xCoordinate;
            this.yCoordinate += addVec2D.yCoordinate;
        }

        /// <summary>
        /// Substracted the coordinates from the passed vector to this vector.
        /// </summary>
        /// <param name="addVec2D"></param>
        public void Sub(Vector2D addVec2D)
        {
            this.xCoordinate -= addVec2D.xCoordinate;
            this.yCoordinate -= addVec2D.yCoordinate;
        }

        /// <summary>
        /// Multiplied the coordinates from the passed vector to this vector.
        /// </summary>
        /// <param name="addVec2D"></param>
        public void Multiply(Vector2D addVec2D)
        {
            this.xCoordinate *= addVec2D.xCoordinate;
            this.yCoordinate *= addVec2D.yCoordinate;
        }

        /// <summary>
        /// Multiplied the passed scalar to the coordinates of this vector.
        /// </summary>
        /// <param name="scalar"></param>
        public void Multiply(double scalar)
        {
            this.xCoordinate *= scalar;
            this.yCoordinate *= scalar;
        }

        /// <summary>
        /// Divided the coordinates from the passed vector to this vector.
        /// </summary>
        /// <param name="addVec2D"></param>
        public void Divide(Vector2D addVec2D)
        {
            this.xCoordinate /= addVec2D.xCoordinate;
            this.yCoordinate /= addVec2D.yCoordinate;
        }

        /// <summary>
        /// Returns the scalar product from this vector with the passed vector.
        /// </summary>
        /// <param name="rightVec2D"></param>
        /// <returns></returns>
        public double ScalarProd(Vector2D rightVec2D) => 
            (this.xCoordinate * rightVec2D.xCoordinate + rightVec2D.yCoordinate * this.yCoordinate);

        /// <summary>
        /// Returns the crodd product from this vector with the passed vector.
        /// </summary>
        /// <param name="rightVec2D"></param>
        /// <returns></returns>
        public double CrossProd(Vector2D rightVec2D) => 
            (this.xCoordinate * rightVec2D.yCoordinate - rightVec2D.xCoordinate * this.yCoordinate);
        #endregion ownMethods

        #region overrideMethods
        /// <summary>
        /// Determines whether the specified object is identical to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => 
            base.Equals(obj);

        /// <summary>
        /// Acts as the default hash function.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => 
            base.GetHashCode();
        #endregion overrideMethods

        #endregion methods
    }
}
