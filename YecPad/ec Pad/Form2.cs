using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ec_Pad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "※";
            Form1.ChaRu = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "【";
            Form1.ChaRu = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {       
            Form1.ziFuChuan = "】";
            Form1.ChaRu = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "◎";
            Form1.ChaRu = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "%";
            Form1.ChaRu = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "$";
            Form1.ChaRu = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "@";
            Form1.ChaRu = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "!";
            Form1.ChaRu = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "~";
            Form1.ChaRu = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1.ziFuChuan = "A";
            Form1.ChaRu = true;
        }
    }
}
