using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Screen_Saver
{
    public partial class ScreenSaver : Form
    {
        static Random r = new Random();
        static int sTop, sBot, sLeft, sRight;
        double angle;
        static double radian;

        public ScreenSaver()
        {
            InitializeComponent();
            angle = r.NextDouble()*360;
            
            //Get screen boundaries
            sTop = Screen.PrimaryScreen.WorkingArea.Top;
            sBot = Screen.PrimaryScreen.WorkingArea.Bottom;
            sLeft = Screen.PrimaryScreen.WorkingArea.Left;
            sRight = Screen.PrimaryScreen.WorkingArea.Right;
        }

        private void Screensavers_Load(object sender, EventArgs e)
        {
            SaverMove.Start(); //Start the movement timer
            Size = new Size(50, 50);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, Width, Height);
            CenterToScreen();     
            Region = new Region(path);
        }

        private void SaverMove_Tick(object sender, EventArgs e)
        {
            radian = (angle * Math.PI) / 180;
            Top -= (int)(10 * Math.Sin(radian));
            Left += (int)(10 * Math.Cos(radian));
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (Top <= sTop || Bottom >= sBot)
            {
                angle = -angle;
                BackColor = Color.FromArgb(0, r.Next(0, 256), r.Next(0, 256));
            }
            else if (Left <= sLeft || Right >= sRight)
            {
                angle = 180 - angle;
                BackColor = Color.FromArgb(0, r.Next(0, 256), r.Next(0, 256));
            }
            
        }
    }
}
