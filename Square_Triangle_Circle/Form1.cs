using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Square_Triangle_Circle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rdm = new Random();

        Thread t1;
        Thread t2;
        Thread t3;

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new Thread(ThreadM);
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = new Thread(ThreadMB);
            t2.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            t3 = new Thread(ThreadMC);
            t3.Start();
        }

        public void ThreadM()
        {
            for (int i = 0; i < 100; i++)
            {
                Color cl = Color.FromArgb(rdm.Next(256), rdm.Next(256), rdm.Next(256));

                this.CreateGraphics().DrawRectangle(new Pen(cl, 4), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), rdm.Next(0, 20), rdm.Next(0, 20)));
                Thread.Sleep(100);
            }

            MessageBox.Show("completed");
        }

        public void ThreadMB()
        {

            for (int i = 0; i < 100; i++)
            {
                Graphics g = this.CreateGraphics();

                Color cl = Color.FromArgb(rdm.Next(256), rdm.Next(256), rdm.Next(256));

                Pen pen = new Pen(cl, 4);

                int x = rdm.Next(0, this.Width);

                int y = rdm.Next(0, this.Height);

                int size = rdm.Next(10, 100);

                Point[] points = {

                new Point(x, y),

                new Point(x + size / 2, y - (int)(Math.Sqrt(3) / 2 * size)),

                new Point(x + size, y)
                };
                g.DrawPolygon(pen, points);

                Thread.Sleep(100);
            }

            MessageBox.Show("completed");
        }

        public void ThreadMC()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Blue, 4), rdm.Next(0, this.Width), rdm.Next(0, this.Height), rdm.Next(0, 20), rdm.Next(0, 20));
                Thread.Sleep(100);
            }

            MessageBox.Show("completed");
        }
    }
}
