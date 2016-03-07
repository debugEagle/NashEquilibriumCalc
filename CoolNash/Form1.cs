using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CoolNash
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
        HandPool pool = new HandPool();
        HandCombos combos = new HandCombos();
        EquityPool eqpool = new EquityPool();

        private void button2_Click(object sender, EventArgs e)
        {
            HeadsupNash.form1 = this;
            int sbStack = Int32.Parse(SBstack.Text);
            int bbStack = Int32.Parse(BBstack.Text);
            int sb = Int32.Parse(SBbox.Text);
            int bb = Int32.Parse(BBbox.Text);
            int nIter = Int32.Parse(IterNumber.Text);
            List<int> stacks = new List<int>() {sbStack, bbStack};
            List<int> blinds = new List<int>() {sb, bb};
            HeadsupNash.BuildNash(stacks, blinds, nIter);
            //label1.Text = r1.ToString();
        }

        public void setMaxProgressBar(int max)
        {
            progressBar1.Maximum = max;
        }

        public void updateProgressBar(int value)
        {
            progressBar1.Value = value;
        }

        public void print(String text)
        {
            label1.Text = text;
        }

    }
}
