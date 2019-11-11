using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;

namespace LFSPreLift
{
    public partial class PreLift_6R : Form
    {
        public PreLift_6R()
        {
            InitializeComponent();
        }

        private void PreLift_6R_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Class1 C1 = new Class1();
            if (checkBox1.Checked)
            {
                string on = "-1";
                C1.StartHacking("LFS");
                C1.WriteFloat(0x5D5620, float.Parse(on), 4);

            }
            else
            {
                string off = "0,150000006";
                C1.StartHacking("LFS");
                C1.WriteFloat(0x5D5620, float.Parse(off), 4);
            }
        }
    }
}
