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
            Pen BluePen = Pens.Black;
            Pen YellowPen = Pens.Black;

            int gridWidth = 4;
            int gridHeight = 4;
            int squareSize = 50;
            int numberOfCorners = gridWidth * gridHeight;
            ////////////////////|
            int rightY = squareSize;
            int bottomX = squareSize;

            List<Corner> corners = new List<Corner>(numberOfCorners);

            for (int i = 0; i < numberOfCorners; i++)
            {                
                if (IsLastSquareBorderSet(i, numberOfCorners))// (BottomIsUp, RightIsUp)
                    corners.Add(new Corner(false, false));
                else if (IsTheEndOfTheRow(i, gridWidth))
                    corners.Add(new Corner(true, false));
                else if (IsTheEndOfTheColumn(i, gridWidth, gridHeight))
                    corners.Add(new Corner(false, true));
                else
                    corners.Add(new Corner(true, true));
            }

            //corners.Add(new Corner(true, false));
            //corners.Add(new Corner(false, true));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, true));
            //corners.Add(new Corner(false, true));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, true));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(true, true));
            //corners.Add(new Corner(true, false));
            //corners.Add(new Corner(false, true));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, false));
            //corners.Add(new Corner(false, false));

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
                    graphicsHelper.DrawLine(BluePen, cornerPoint, leftOfCornerPoint);
                
                if (corner.RightIsUp)
                    graphicsHelper.DrawLine(YellowPen, cornerPoint, aboveCornerPoint);
                
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
        
        bool IsLastSquareBorderSet(int indexOfCell, int NumberOfCorners)
        {
            return indexOfCell == NumberOfCorners - 1;
        }

        bool IsTheEndOfTheRow(int indexOfCell, int GridWidth)
        {
            return (indexOfCell + 1) % GridWidth == 0;
        }

        bool IsTheEndOfTheColumn(int indexOfCell, int GridWidth, int GridHeight)
        {
            return (indexOfCell + 1) > GridWidth * (GridHeight - 1);
        }
    }
}