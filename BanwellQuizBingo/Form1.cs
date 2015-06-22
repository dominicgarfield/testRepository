using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanwellQuizBingo
{
    public partial class Form1 : Form
    {
        PrintDocument printDocument = new PrintDocument();

        public Form1()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = new PrintDocument();

            var iBingoNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            var iRandomizedBingoNumbers = Program.RandomizeIntArray(iBingoNumbers);
            Bitmap pbImge = new Bitmap(50, 50, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(pbImge);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.Tomato), 40, 40, 10, 10);
            graphics.FillRectangle(new SolidBrush(Color.Tomato), 10, 10, 10, 10);
            //this.pictureBox1.Image = this.Draw(50, 50, 40, 40);
            //this.pictureBox1.Image = this.Draw(50, 50, 10, 10);
            //this.pictureBox1.Image = this.Draw(50, 50, 10, 10);
            //this.pictureBox1.Image = this.Draw(50, 50, 10, 10);
            //this.pictureBox1.Image = this.Draw(50, 50, 10, 10);
            var ddd = new String[]{"dd", "ff"};

            for (int i = 1; i < 4; i++)
            {
                QuizBingoSheet bingoSheet = new QuizBingoSheet();
                bingoSheet.Show();
                //bingoSheet.PrintScreen();
                //bingoSheet.Close();
            }
            
            
        }

        public Bitmap Draw(int width, int height, int x, int y)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.Tomato), x, y, 10, 10);

            return bitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        void button2_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument.Print();
        }


        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
