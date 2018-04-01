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

    public partial class Form1 : Form
    {
        double a0 = 55, b0 = 21, c0 = 22, p0 = 2;
        double at , bt , ct , pt ;
        double k1 = 0.001, k2 = 0.004, k3 = 0.004, k4 = 0.003;

        double t,m;
        double t1, t2, t3, t4, t5;

        private void definitionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void definitionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 ss = new Form4();
            ss.Show();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*-----------Group : 25-----------*\n" +
                "201601030 Tikam Alma\n" +
                "201601042 Jalansh Munshi\n" +
                "201601048 Nidhi Gupta\n" +
                "201601063 Chirag Poddar\n" +
                "201601074 Brijesh Panara\n" +
                "201601082 Purva Mhaskar\n" +
                "201601096 Milan Dungarani\n" +
                "201601136 Bhargav Ajudiya\n" +
                "201601454 Yatin Patel\n");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                k1 = double.Parse(comboBox1.Text);
                k2 = double.Parse(comboBox2.Text);
                k3 = double.Parse(comboBox3.Text);
                k4 = double.Parse(comboBox4.Text);

                t = double.Parse(textBox1.Text);
                
                m = double.Parse(textBox2.Text);
                m = m / 1000;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Numeric Value(s)");
                return;
            }

                Form3 ss = new Form3(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text,textBox1.Text,m.ToString());
            ss.Show();

            this.Hide();
        }

        double an;
        double tn;
        double sn;
        double year;
        public Form1()
        {
            InitializeComponent();

            MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.StartPosition = FormStartPosition.CenterScreen;
            
            at = a0; bt = b0;  ct = c0; pt = p0;

            an = at;
            tn = pt;
            sn = bt + ct;

            button12.Text = "Air Nitrogen: " + an.ToString() + "%";
            button2.Text =  "Organic Nitrogen: "+ tn.ToString() + "%";
            button3.Text =  "Soil Nitrogen: " + sn.ToString() + "%";
            year = 0;
            button1.Text = "Time Elapsed(Years): " + year.ToString();

           

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                k1 = double.Parse(comboBox1.Text);
                k2 = double.Parse(comboBox2.Text);
                k3 = double.Parse(comboBox3.Text);
                k4 = double.Parse(comboBox4.Text);

                k1 = k1 * 0.0001;
                k2 = k2 * 0.0001;
                k3 = k3 * 0.0001;
                k4 = k4 * 0.0001;


                t = double.Parse(textBox1.Text);
                m = double.Parse(textBox2.Text);
                m = m / 1000;
                year += 10;
                double time = 1;

                Random rm = new Random();
                double temp = rm.Next(-1, 2);

                a0 = at;
                b0 = bt;
                c0 = ct;
                p0 = pt;

                //MessageBox.Show(a0.ToString() + " " + b0.ToString() + " " + c0.ToString()+" " + p0.ToString()+" "+ t.ToString()+" "+m.ToString());

                at = a0 * (Math.Exp(-1 * (time * t * m * (k1 * a0 - k2 * bt))));
                pt = p0 * (Math.Exp(-1 * (time * t * m * (k4 * p0 - k2 * bt))));

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


                an = at + (temp/2.5);
                tn = pt - (temp/5.0);
                sn = bt + ct - (temp/5.0);

                


                an = Math.Round(an, 2);
                tn = Math.Round(tn, 2);
                sn = Math.Round(sn, 2);



                button12.Text = "Air Nitrogen: " + an.ToString() + "%";
                button2.Text = "Organic Nitrogen: " + tn.ToString() + "%";
                button3.Text = "Soil Nitrogen: " + sn.ToString() + "%";

                button1.Text = "Time Elapsed(Years): " + year.ToString();

                if(year >=990)
                {
                    button4.Enabled = false;
                    
                }


            }

            catch(Exception ex)
            {

                MessageBox.Show("Please Enter Numeric Value(s)");


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            year = 0;
            at = 55; pt = 2; bt = 21; ct = 22;

            an = at;
            tn = pt;
            sn = bt + ct;

            button12.Text = "Air Nitrogen: " + an.ToString() + "%";
            button2.Text = "Organic Nitrogen: " + tn.ToString() + "%";
            button3.Text = "Soil Nitrogen: " + sn.ToString() + "%";
            button1.Text = "Time Elapsed(Years): " + year.ToString();

            comboBox1.Text = "2";
            comboBox2.Text = "3";
            comboBox3.Text = "3";
            comboBox4.Text = "2";

            textBox1.Text = "300";
            textBox2.Text = "0.5";

            button4.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p1 = new Pen(Brushes.Yellow, 8);
            p1.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p1, 145, 425,145, 315);

            Pen p2 = new Pen(Brushes.Yellow, 8);
            g.DrawLine(p2, 60,135,60,495);
            p2.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p2, 175, 495 ,56,495);

            Pen p3 = new Pen(Brushes.Yellow, 8);
            p3.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p3, 560, 230 , 560, 370);

            Pen p4 = new Pen(Brushes.Yellow, 8);
            //g.DrawLine(p4, 625, 465, 625, 435);
            //g.DrawLine(p4, 621, 435, 725, 435);
            
            p4.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p4, 675, 275,675,465);
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

           

        }
    }
}
