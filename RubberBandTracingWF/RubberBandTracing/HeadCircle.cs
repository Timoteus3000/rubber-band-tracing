using RubberBandTracingWF.Vector2DLibrary;
using System.Drawing;

namespace RubberBandTracingWF.RubberBandTracing
{
    /// <summary>
    /// A class who presents a head from a snake.
    /// </summary>
    public class HeadCircle
    {
        //declarations
        #region declarations
        private SolidBrush fillBrush;
        private Pen edgePen;
        private Vector2D centerVec2D;
        private Vector2D directionVec2D;
        private double radius;

        //properties
        #region properties
        public SolidBrush FillBrush { get => fillBrush; set => fillBrush = value; }
        public Pen EdgePen { get => edgePen; set => edgePen = value; }
        public Vector2D CenterVec2D { get => centerVec2D; set => centerVec2D = value; }
        public Vector2D DirectionVec2D { get => directionVec2D; set => directionVec2D = value; }
        public double Radius { get => radius; set => radius = value; }
        #endregion properties

        #endregion declarations

        //constructors
        #region constructors
        public HeadCircle()
        {
            this.fillBrush = new SolidBrush(Color.Black);
            this.edgePen = new Pen(Brushes.Black);
            this.centerVec2D = new Vector2D(0, 0);
            this.directionVec2D = new Vector2D(0, 0);
        }
        public HeadCircle(SolidBrush fillBrush, Pen edgePen, Vector2D centerVec2D, Vector2D directionVec2D)
        {
            this.fillBrush = fillBrush;
            this.edgePen = edgePen;
            this.centerVec2D = centerVec2D;
            this.directionVec2D = directionVec2D;
            this.radius = this.directionVec2D.GetLength();

            TailCircle tail1 = new TailCircle(null, new SolidBrush(Color.Green), new Pen(Color.Red, 5), new Vector2D(--this.centerVec2D), this.radius);
        }

        #endregion constructors

        //methods
        #region methods
        
        public void UpdateMyPosition(double xMouse, double yMouse)
        {
            this.directionVec2D.XCoordinate = (xMouse- this.centerVec2D.XCoordinate);
            this.directionVec2D.YCoordinate = (yMouse-this.centerVec2D.YCoordinate);

            this.directionVec2D.Normalize();
            this.directionVec2D.Multiply(this.radius);

            this.centerVec2D.XCoordinate += (xMouse - this.centerVec2D.XCoordinate) * 0.1;
            this.centerVec2D.YCoordinate += (yMouse - this.centerVec2D.YCoordinate) * 0.1;
        }
        
        /// <summary>
        /// Draws the current head.
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            float xPosRec = (float)(this.centerVec2D.XCoordinate - this.radius);
            float yPosRec = (float)(this.centerVec2D.YCoordinate - this.radius);
            float diameter = (float)(this.radius * 2);

            g.FillEllipse(this.fillBrush, xPosRec, yPosRec, diameter, diameter);
            g.DrawEllipse(this.edgePen, xPosRec, yPosRec, diameter, diameter);

            //Draw the direction-line ->
            g.DrawLine(this.edgePen, (float)(this.centerVec2D.XCoordinate), (float)(this.centerVec2D.YCoordinate), (float)(this.centerVec2D.XCoordinate+this.directionVec2D.XCoordinate), (float)(this.centerVec2D.YCoordinate+this.directionVec2D.YCoordinate));
            
            //Draw the center ->
            g.FillEllipse(Brushes.Black, (float)(this.centerVec2D.XCoordinate -5), (float)(this.centerVec2D.YCoordinate - 5), 10, 10);
        }
        #endregion methods
    }
}
