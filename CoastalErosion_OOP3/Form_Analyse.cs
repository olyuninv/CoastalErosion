using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_Analyse : Form
    {
        //Would be good to check data....

        public Form_Analyse()
        {
            InitializeComponent();
        }
        
        private void bt_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public int[] returnChoice()
        {
            int[] tmp = new int[3];
            tmp[0] = Convert.ToInt32(tb_runID.Text);
            tmp[1] = Convert.ToInt32(tb_option.Text);
            tmp[2] = Convert.ToInt32(tb_profileN.Text);

            return tmp;
        }
    }
}