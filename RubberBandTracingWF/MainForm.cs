using RubberBandTracingWF.RubberBandSnakeGame;
using System.Reflection;
using System.Windows.Forms;

namespace RubberBandTracingWF
{
    public partial class MainForm : Form
    {
        //declarations
        #region declarations
        private Snake snake;

        #endregion declarations

        //constructors
        #region constructors
        public MainForm()
        {
            InitializeComponent();

            //Activate double-buffering..
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this.drawPanel, new object[] { true });
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.snake = new Snake(20);
        }
        #endregion constructors

        //methods
        #region methods

        #region eventMethods
        private void DrawPanel_OnPaint(object sender, PaintEventArgs e)
        {
            this.snake.DrawMe(e.Graphics);
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.snake.Update(e.X, e.Y);
            this.drawPanel.Refresh();
        }
        #endregion eventMethods

        #endregion methods
    }
}
