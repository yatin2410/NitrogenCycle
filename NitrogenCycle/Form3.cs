using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitrogenCycle
{
    public partial class Form3 : Form
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;

        double k1, k2, k3, k4;
        //cin>>k1>>k2>>k3>>k4;
        double an, tn, sn;
        double a0 = 55, b0 = 21, c0 = 22, p0 = 2;

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        double at , bt , ct , pt;


        double time = 1, t = 300, m = 0.5;
        double t1, t2, t3, t4, t5;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            InitializeComponent();
            MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.StartPosition = FormStartPosition.CenterScreen;


            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.text5 = text5;
            this.text6 = text6;


            at = a0;bt = b0;ct = c0;pt = p0;
            t = double.Parse(text5);
            m = double.Parse(text6);

            k1 = double.Parse(text1);
            k2 = double.Parse(text2);
            k3 = double.Parse(text3);
            k4 = double.Parse(text4);

            k1 = k1 * 0.0001;
            k2 = k2 * 0.0001;
            k3 = k3 * 0.0001;
            k4 = k4 * 0.0001;

            //MessageBox.Show(at.ToString());

            // chartGraphic.Series.Add("AIR Nitrogen");

            chartGraphic.Size = new Size(955, 495);

            
            chartGraphic.Series.Add("Air Nirogen");

            chartGraphic.Series.Add("Organic Nitrogen");

            chartGraphic.Series.Add("Soil Nitrogen");

            
            chartGraphic.ChartAreas[0].AxisY.ScaleView.Zoom(0,100); // -15<= y <=15
            chartGraphic.ChartAreas[0].AxisX.ScaleView.Zoom(0,500); // -15 <= x <= 2
            chartGraphic.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartGraphic.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartGraphic.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartGraphic.ChartAreas[0].AxisX.Minimum = 0;
            // chartGraphic.ChartAreas[0].AxisY.Interval = 0.5;
            chartGraphic.ChartAreas[0].AxisX.Title = "Years";
            chartGraphic.ChartAreas[0].AxisY.Title = "% of Nitrogen";


           // chartGraphic.Series[0].Label = "";

            chartGraphic.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartGraphic.Series[0].Color = Color.Blue;
            chartGraphic.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartGraphic.Series[1].Color = Color.Red;
            chartGraphic.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartGraphic.Series[2].Color = Color.Green;

            chartGraphic.Series[0].Points.AddXY(0, 55);
            chartGraphic.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartGraphic.Series[1].Points.AddXY(0, 2);
            chartGraphic.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartGraphic.Series[2].Points.AddXY(0, 43);
            chartGraphic.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


            //MessageBox.Show(chartGraphic.Series[0].Label + " " + chartGraphic.Series[1].Label + " " + chartGraphic.Series[2].Label + " " + chartGraphic.Series[3].Label);

            Random rm = new Random();

            for (int i = 1; i <= 50; i++)
            {
                double temp = rm.Next(-1, 2);
                
                a0 = at;
                b0 = bt;
                c0 = ct;
                p0 = pt;

                double time = 1;
                at = a0 * (Math.Exp(-1 * (time * t * m * (k1 * a0 - k2 * bt))));
                pt = p0 * (Math.Exp(-1 * (time * t * m * (k4 * p0 - k2 * bt))));
               // Console.WriteLine(at.ToString());
                bt = b0 + (a0 - at) + (p0 - pt);

                b0 = bt;
                bt = b0 * (Math.Exp(-1 * (time * t * m * (k2 * b0 - k4 * pt))));
                pt = pt + (b0 - bt);

                b0 = bt;
                bt = b0 * (Math.Exp(-1 * (time * t * m * (k2 * b0 - k3 * ct))));
                ct = ct + (b0 - bt);

                c0 = ct;
                ct = c0 * (Math.Exp(-1 * (time * t * m * (k3 * c0 - k1 * at))));
                at = at + (c0 - ct);


                an = at;
                tn = pt;
                sn = bt + ct;

                an = Math.Round(an, 2);
                tn = Math.Round(tn, 2);
                sn = Math.Round(sn, 2);

       //         MessageBox.Show(an.ToString());
                chartGraphic.Series[0].Points.AddXY(i*10,an+(temp/2.5));
                chartGraphic.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


                chartGraphic.Series[1].Points.AddXY(i * 10, tn-(temp/5.0));
                chartGraphic.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                chartGraphic.Series[2].Points.AddXY(i * 10, sn-(temp/5.0));
                chartGraphic.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
