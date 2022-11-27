using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Screen_Saver
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool tmp = int.TryParse(textBox1.Text, out int numOfSavers);
            for(int i = 0; i < Math.Abs(numOfSavers); i++)
            {
                new ScreenSaver().Show();
            }  
            WindowState = FormWindowState.Minimized;
        }
    }
}
