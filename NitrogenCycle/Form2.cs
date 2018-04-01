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

namespace NitrogenCycle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            int n = 5;
            for(int i=0;i<n;i++)
            {
                //flowLayoutPanel1.Controls.Add((sender as Pa));
            }
            
        }

        private Panel Fun(int i)
        {

            Panel p = new Panel();
            
            Rectangle bounds = p.ClientRectangle;
            using (var ellipsePath = new GraphicsPath())
            {
                ellipsePath.AddEllipse(bounds);
                using (var brush = new PathGradientBrush(ellipsePath))
                {
                    brush.CenterPoint = new PointF(bounds.Width / 2f, bounds.Height / 2f);
                    brush.CenterColor = Color.White;
                    brush.SurroundColors = new[] { Color.Blue };
                    brush.FocusScales = new PointF(0, 0);


                  //  e.Graphics.FillRectangle(brush, bounds);
                }

            }


            MessageBox.Show(i.ToString());
            return p;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle bounds = panel1.ClientRectangle;
            using (var ellipsePath = new GraphicsPath())
            {
                ellipsePath.AddEllipse(bounds);
                using (var brush = new PathGradientBrush(ellipsePath))
                {
                    brush.CenterPoint = new PointF(bounds.Width / 2f, bounds.Height / 2f);
                    brush.CenterColor = Color.White;
                    brush.SurroundColors = new[] { Color.Blue};
                    brush.FocusScales = new PointF(0, 0);

                    e.Graphics.FillRectangle(brush, bounds);
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1 = null;
            GC.Collect();

            Panel panel2 = new Panel();
            panel2.Height = Int32.Parse(textBox1.Text);
            panel2.Width = Int32.Parse(textBox1.Text);

            
        }
    }
}
