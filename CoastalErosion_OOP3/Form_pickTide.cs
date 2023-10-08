using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_pickTide : Form
    {
        private DatabaseInterface dbi;

        public Form_pickTide(DatabaseInterface dbi)
        {
            this.dbi = dbi;

            InitializeComponent();
        }

        private void Form_pickTide_Load(object sender, EventArgs e)
        {
            int nTides = dbi.returnNTides();
            TideInfo tide;

            for (int i = 1; i <= nTides; i++)
            {
                tide = dbi.returnTideInfo(i);
                                
                lv_main.Items.Add(new ListViewItem(tide.ToStringArray()));                
            }
        }

        private void bt_choose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public TideInfo returnChosenTide()
        {
            TideInfo tmp = new TideInfo(lv_main.SelectedItems[0]);
            return tmp;
        }
    }
}