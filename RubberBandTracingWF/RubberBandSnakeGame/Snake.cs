using RubberBandTracingWF.RubberBandTracing;
using RubberBandTracingWF.Vector2DLibrary;
using System.Collections.Generic;
using System.Drawing;

namespace RubberBandTracingWF.RubberBandSnakeGame
{
    /// <summary>
    /// A class who presents a snake with one head and a list of tails.
    /// </summary>
    public class Snake
    {
        //declarations
        #region declarations
        private HeadCircle head;
        private List<TailCircle> tails;

        //properties
        #region properties

        #endregion properties

        #endregion declarations

        //constructors
        #region constructors
        public Snake()
        {
            head = new HeadCircle(new SolidBrush(Color.Green), new Pen(Color.Red, 5), new Vector2D(50, 50), new Vector2D(0, 30));
            tails = new List<TailCircle>
            {
                new TailCircle(null, new SolidBrush(Color.Green), new Pen(Color.Red, 5), new Vector2D(--head.CenterVec2D), head.Radius)
            };

            for (int i = 0; i < 5; i++)
            {
                tails.Add(new TailCircle(this.tails[i]));
            }
        }

        public Snake(int numOfTails)
        {
            head = new HeadCircle(new SolidBrush(Color.Green), new Pen(Color.Red, 5), new Vector2D(50, 50), new Vector2D(0, 30));
            tails = new List<TailCircle>
            {
                new TailCircle(null, new SolidBrush(Color.Green), new Pen(Color.Red, 5), new Vector2D(--head.CenterVec2D), head.Radius)
            };

            for (int i = 0; i < numOfTails; i++)
            {
                tails.Add(new TailCircle(this.tails[i]));
            }
        }
        #endregion constructors

        //methods
        #region methods
        public void Update(int x, int y)
        {
            this.head.UpdateMyPosition(x, y);
            this.tails[0].UpdateMyPositionHead(head.CenterVec2D.XCoordinate, head.CenterVec2D.YCoordinate);
            foreach (TailCircle tail in this.tails)
            {
                tail.UpdateMyPosition();
            }
        }

        /// <summary>
        /// Draws the current snake.
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            for (int i = tails.Count-1; i >= 0; i--)
            {
                this.tails[i].DrawMe(g);
            }

            this.head.DrawMe(g);
        }
        #endregion methods
    }
}
