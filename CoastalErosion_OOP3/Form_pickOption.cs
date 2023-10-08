using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_PickOption : Form
    {
        private DatabaseInterface dbi;
        private bool multiSelect = true;

        public Form_PickOption(DatabaseInterface dbi)
        {
            InitializeComponent();
        }

        public Form_PickOption(DatabaseInterface dbi, bool multiSelect)
        {
            this.dbi = dbi;

            this.multiSelect = multiSelect;
            InitializeComponent();
        }

        private void Form_pickRun_Load(object sender, EventArgs e)
        {
            lv_main.MultiSelect = multiSelect;

            //set label and button text
            if (multiSelect)
            {
                lbl_top.Text = "Please select runs to compare. ";
                bt_pick.Text = "Compare selected runs";
            }
            else
            {
                lbl_top.Text = "Please select a run. ";
                bt_pick.Text = "Show run";
            }

            RunOptionInfoList riList = dbi.returnRunOptionsInfoTable();

            foreach (RunOptionInfo ri in riList)
                lv_main.Items.Add(new ListViewItem(ri.ToStringArray()));

            lv_main.Items[0].Selected = true;
        }

        private void bt_pick_Click(object sender, EventArgs e)
        {
            if (lv_main.SelectedIndices.Count == 0)
                MessageBox.Show("Please select a run!");
            else
                DialogResult = DialogResult.OK;
        }

        public int returnFirstSelectedItem()
        {            
            return Convert.ToInt32(lv_main.SelectedIndices[0]);
        }

        public int[] returnSelectedItems()
        {
            int count = lv_main.SelectedIndices.Count;
            int[] tmp = new int[count];
            for (int i = 0; i < count; i++)
                tmp[i] = Convert.ToInt32(lv_main.SelectedIndices[i]);
            return tmp;
        }
    }
}