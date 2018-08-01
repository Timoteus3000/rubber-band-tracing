using RubberBandTracingWF.Vector2DLibrary;
using System.Drawing;

namespace RubberBandTracingWF.RubberBandTracing
{
    /// <summary>
    /// A class who presents a tail from a snake.
    /// </summary>
    public class TailCircle
    {
        //declarations
        #region declarations
        private TailCircle parentTail;
        private SolidBrush fillBrush;
        private Pen edgePen;
        private Vector2D centerVec2D;
        private double radius;

        //properties
        #region properties
        public SolidBrush FillBrush { get => fillBrush; set => fillBrush = value; }
        public Pen EdgePen { get => edgePen; set => edgePen = value; }
        public Vector2D CenterVec2D { get => centerVec2D; set => centerVec2D = value; }
        public double Radius { get => radius; set => radius = value; }
        #endregion properties

        #endregion declarations

        //constructors
        #region constructors
        public TailCircle(TailCircle parentTail)
        {
            this.parentTail = parentTail;
            this.fillBrush = parentTail.fillBrush;
            this.edgePen = parentTail.edgePen;
            this.centerVec2D = (--parentTail.centerVec2D);
            this.radius = parentTail.radius;
        }
        public TailCircle(TailCircle parentTail, SolidBrush fillBrush, Pen edgePen, Vector2D centerVec2D, double radius)
        {
            this.parentTail = parentTail;
            this.fillBrush = fillBrush;
            this.edgePen = edgePen;
            this.centerVec2D = centerVec2D;
            this.radius = radius;
        }

        #endregion constructors

        //methods
        #region methods

        public void UpdateMyPositionHead(double xHead, double yHead)
        {
            this.centerVec2D.XCoordinate += (xHead - this.centerVec2D.XCoordinate) * 0.15;
            this.centerVec2D.YCoordinate += (yHead - this.centerVec2D.YCoordinate) * 0.15;
        }
        public void UpdateMyPosition()
        {
            if(this.parentTail != null)
            {
                this.centerVec2D.XCoordinate += (this.parentTail.centerVec2D.XCoordinate - this.centerVec2D.XCoordinate) * 0.15;
                this.centerVec2D.YCoordinate += (this.parentTail.centerVec2D.YCoordinate - this.centerVec2D.YCoordinate) * 0.15;
            }
        }

        /// <summary>
        /// Draws the current tail.
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            float xPosRec = (float)(this.centerVec2D.XCoordinate - this.radius);
            float yPosRec = (float)(this.centerVec2D.YCoordinate - this.radius);
            float diameter = (float)(this.radius * 2);

            g.FillEllipse(this.fillBrush, xPosRec, yPosRec, diameter, diameter);
            g.DrawEllipse(this.edgePen, xPosRec, yPosRec, diameter, diameter);
        }
        #endregion methods
    }
}
