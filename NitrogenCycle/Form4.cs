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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            try
            {
                string url = @"C:\Program Files (x86)\Y3\NitrogenCycleSetup\Nitrogen-Cycle.pdf";
                webBrowser1.Navigate(url);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry! File is not found");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
