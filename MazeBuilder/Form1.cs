using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void goButton_Click(object sender, EventArgs e)
        {
            Graphics graphicsHelper = this.CreateGraphics();
            Pen BluePen = Pens.Blue;
            Pen YellowPen = Pens.GreenYellow;

            int gridWidth = 10;
            int gridHeight = 10;
            int squareSize = 50;
            int numberOfCorners = gridWidth * gridHeight;
            ////////////////////|
            //int leftY = 0;
            //int topX = 0;
            int rightY = squareSize;
            int bottomX = squareSize;

            List<Corner> corners = new List<Corner>(numberOfCorners);
            for (int i = 0; i < numberOfCorners; i++)
            {
                if (i == numberOfCorners - 1)
                {
                    corners.Add(new Corner(false, false));
                }
                else if ((i + 1) % gridWidth == 0)
                {
                    corners.Add(new Corner(true, false));
                }
                
                else if ((i + 1) > gridWidth * (gridHeight - 1))
                {
                    corners.Add(new Corner(false, true));
                }
                else
                {
                    corners.Add(new Corner(true, true));
                }
            }

            Point cornerPoint = new Point();
            Point aboveCornerPoint = new Point();
            Point leftOfCornerPoint = new Point();

            cornerPoint.X = squareSize;
            cornerPoint.Y = squareSize;

            

            for (int i = 0; i < numberOfCorners; i++)
            {
                Corner corner = corners[i];


                aboveCornerPoint.Y = cornerPoint.Y - squareSize;
                aboveCornerPoint.X = cornerPoint.X;
                leftOfCornerPoint.X = cornerPoint.X - squareSize;
                leftOfCornerPoint.Y = cornerPoint.Y;


                if (corner.BottomIsUp)
                {
                    graphicsHelper.DrawLine(BluePen, cornerPoint, leftOfCornerPoint);
                }
                if (corner.RightIsUp)
                {
                    graphicsHelper.DrawLine(YellowPen, cornerPoint, aboveCornerPoint);
                }
                if ((i + 1) % gridWidth == 0)
                {
                    cornerPoint.X = squareSize;
                    cornerPoint.Y += squareSize;
                }
                else
                {
                    cornerPoint.X += squareSize;
                }

                

            }
        }
    }
}