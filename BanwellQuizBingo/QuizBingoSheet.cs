using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanwellQuizBingo
{
    public partial class QuizBingoSheet : Form
    {
        PrintDocument printDocument = new PrintDocument();
        public void PrintScreen(){    
            CaptureScreen();
            printDocument.Print();
        }

        public QuizBingoSheet()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;// this.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            Font drawFont = new Font("Arial", 16);
            List<Rectangle> rects = SpawnRectangleSegment(0, 0);
            rects.AddRange(SpawnRectangleSegment(400, 0));
            rects.AddRange(SpawnRectangleSegment(200, 200));
            rects.AddRange(SpawnRectangleSegment(0, 400));
            rects.AddRange(SpawnRectangleSegment(400, 400));

            var iBingoNumbers = Enumerable.Range(1, 25);
            var iRandomizedBingoNumbers = Program.RandomizeIntArray(iBingoNumbers.ToArray());

            SpawnRectangleSegmentLabel(ref g, iRandomizedBingoNumbers.ToList().GetRange(0,5), 0, 0);
            SpawnRectangleSegmentLabel(ref g, iRandomizedBingoNumbers.ToList().GetRange(5,5), 400, 0);
            SpawnRectangleSegmentLabel(ref g, iRandomizedBingoNumbers.ToList().GetRange(10,5), 200, 200);
            SpawnRectangleSegmentLabel(ref g, iRandomizedBingoNumbers.ToList().GetRange(15,5), 0, 400);
            SpawnRectangleSegmentLabel(ref g, iRandomizedBingoNumbers.ToList().GetRange(20,5), 400, 400);

            Rectangle[] rectArray = rects.ToArray();
            g.DrawRectangles(p, rectArray);
            PrintScreen();
        }

        private List<Rectangle> SpawnRectangleSegment(int xOffset, int yOffset) {
            Rectangle rect1 = new Rectangle(10+xOffset, 10+yOffset, 60, 60);
            Rectangle rect2 = new Rectangle(130+xOffset, 10+yOffset, 60, 60);
            Rectangle rect3 = new Rectangle(70+xOffset, 70+yOffset, 60, 60);
            Rectangle rect4 = new Rectangle(10+xOffset, 130+yOffset, 60, 60);
            Rectangle rect5 = new Rectangle(130+xOffset, 130+yOffset, 60, 60);
            List<Rectangle> rects = new List<Rectangle> { rect1, rect2, rect3, rect4, rect5 };
            return rects;
        }

        private void SpawnRectangleSegmentLabel(ref Graphics g, List<int> iRandomizedBingoNumbers, int xOffset, int yOffset)
        {
            Font drawFont = new Font("Arial", 12);
            g.DrawString(iRandomizedBingoNumbers[0].ToString(), drawFont, System.Drawing.Brushes.Black, 10 + xOffset, 10 + yOffset);
            g.DrawString(iRandomizedBingoNumbers[1].ToString(), drawFont, System.Drawing.Brushes.Black, 130 + xOffset, 10 + yOffset);
            g.DrawString(iRandomizedBingoNumbers[2].ToString(), drawFont, System.Drawing.Brushes.Black, 70 + xOffset, 70 + yOffset);
            g.DrawString(iRandomizedBingoNumbers[3].ToString(), drawFont, System.Drawing.Brushes.Black, 10 + xOffset, 130 + yOffset);
            g.DrawString(iRandomizedBingoNumbers[4].ToString(), drawFont, System.Drawing.Brushes.Black, 130 + xOffset, 130 + yOffset);
        }

        private void QuizBingoSheet_Load(object sender, EventArgs e)
        {
           //adding a test comment to quiz bingo sheet load for GIT test
            //adding a second test comment to quiz bingo sheet for GIT test
        }

        Bitmap memoryImage;

        public void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            //for each image in collection print - do array  
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
