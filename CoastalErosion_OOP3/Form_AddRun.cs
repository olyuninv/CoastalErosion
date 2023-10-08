using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_Add : Form
    {
        DatabaseInterface dbi;
        int runID = 0, optionID = 0;
        bool newRun = false;

        public Form_Add()
        {
            InitializeComponent();
        }

        public Form_Add(DatabaseInterface dbi)
        {
            InitializeComponent();

            newRun = true;
            this.dbi = dbi;
            lbl_runID.Text = "New Run";
        }

        public Form_Add(DatabaseInterface dbi, int runID, int cOption)
        {
            InitializeComponent();

            newRun = false;
            this.dbi = dbi;
            this.runID = runID;
            this.optionID = cOption;
            lbl_runID.Text = runID.ToString();
            //bt_add.Text = "Modify this run";
        }    

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Child1_Load(object sender, EventArgs e)
        {
            //Q is not used in the model
            tb_Q.Text = "1";
            tb_Q.Enabled = false;

            //Set maximums for nud's
            nud_WaveSet.Maximum = dbi.returnNWaves();
            nud_Sea.Maximum = dbi.returnNSeas();
            nud_tideID.Maximum = dbi.returnNTides();
            nud_ErMode.Maximum = 4;

            if (!newRun)
            {
                //Load data from the existing run into labels
                RunInfo ri = dbi.returnRunInfo(runID);
                
                tb_initSlope.Text = ri.InitSlope.ToString();
                tb_tr.Text = ri.TidalRange.ToString();
                nud_WaveSet.Value = ri.WaveSetID;
                tb_k.Text = ri.K.ToString();
                tb_s.Text = ri.S.ToString();
                tb_Q.Text = ri.getQ.ToString();
                tb_sfmin.Text = ri.Sfmin.ToString();
                tb_M.Text = ri.getM.ToString();
                nud_Sea.Value = ri.SeaID;
                tb_tectMovement.Text = ri.TectMovement.ToString();

                tb_initSlope.Enabled = false;
                tb_tr.Enabled = false;
                nud_WaveSet.Enabled = false;
                tb_k.Enabled = false;
                tb_s.Enabled = false;
                tb_Q.Enabled = false;
                tb_sfmin.Enabled = false;
                tb_M.Enabled = false;
                nud_Sea.Enabled = false;
                tb_tectMovement.Enabled = false;

            }
            
        }

        private RunInfo getRunInfoFromScreen()
        {
            RunInfo ri = new RunInfo();
            ri.InitSlope = Convert.ToDouble(tb_initSlope.Text);
            ri.TidalRange = Convert.ToDouble(tb_tr.Text);
            ri.WaveSetID = (int) nud_WaveSet.Value;
            ri.K = Convert.ToDouble(tb_k.Text);
            ri.S = Convert.ToDouble(tb_s.Text);
            ri.Sfmin = Convert.ToDouble(tb_sfmin.Text);
            ri.getM = Convert.ToDouble(tb_M.Text);
            ri.getQ = Convert.ToDouble(tb_Q.Text);
            ri.SeaID = (int) nud_Sea.Value;
            ri.TectMovement = Convert.ToDouble(tb_tectMovement.Text);
            
            return ri;
        }

        private OptionInfo getOptionInfoFromScreen()
        {
            OptionInfo oi = new OptionInfo();
            oi.ErMode = Convert.ToInt32((int)nud_ErMode.Value);
            oi.TideID = Convert.ToInt32((int)nud_tideID.Value);
            oi.Accuracy = Convert.ToDouble(tb_accuracy.Text);
            oi.SaveOptions = combo_save.SelectedItem.ToString();

            return oi;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            RunInfo runInfo = getRunInfoFromScreen();
            OptionInfo oi = getOptionInfoFromScreen();

            if (newRun)
            {
                //Add new run if no double
                int nRuns = dbi.returnNRuns();
                runID = dbi.addNewRun(runInfo);
                if (runID == 0)
                {
                    MessageBox.Show("Unable to add a new run");
                    DialogResult = DialogResult.Cancel;
                }
            }
          
            //Add new option to the run
            SeaInfo si = dbi.returnSeaInfo(runInfo.SeaID);
            if (si.ConstantSea && oi.SaveOptions != "EVERY500YRS" && oi.SaveOptions != "EVERY1000YRS")
            {
                oi.SaveOptions = "EVERY500YRS";
                MessageBox.Show("Save option defaulted to \"Every 500 years\"");
            }
 
            optionID = dbi.addNewOption(runID, oi);
            if (optionID == 0)
            {
                MessageBox.Show("Unable to add a new option");
                DialogResult = DialogResult.Cancel;
            }

            DialogResult = DialogResult.OK;
        }

        public int[] returnAddedValues()
        {
            int[] ii = {runID, optionID};
            return ii;
        }
    }
}