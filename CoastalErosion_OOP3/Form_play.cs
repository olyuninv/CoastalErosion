using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CoastalErosion
{
    public enum dispMode
    {
        Nothing, Current, Color, Results
    }

    public partial class Form1 : Form
    {                         
        //---------My Variables-----------
        private dispMode dMode = dispMode.Current;
        private DatabaseInterface dbi;
        private int nRuns = 0;
        private int cRunID = 0;
        private int cOptionID = 1;
        CurrencyManager cmWaves;
        CurrencyManager cmSea;

        //--Model
        private Profile p;
        private Sea s;
        private int time = -1966000;
        private int startTime;
        private int endTime;

        //--Display
        private Graph gr = new Graph();
        private int nProfiles = 0;
        private double[,,] displayProfile;      

        //--Database
        private RunInfo rri;
        private WaveInfo wwi;
        private SeaInfo ssi;

        //--Options
        int cErMode = 2;
        double cAccuracy = 0.05;
        TideInfo cTide;
        SaveOption cSaveOption = SaveOption.EVERY500YRS;

        public Form1(DatabaseInterface dbi)
        {
            this.dbi = dbi;

            InitializeComponent();

            //no flicker
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dMode = dispMode.Current;

            this.Width = MdiParent.Width;
            this.Height = MdiParent.Height;
 
            //picture box
            pb_picture.Width = this.Width - 10;
            pb_picture.Location = new Point(0, (int)(2.5 * this.Height / 10));
            pb_picture.Height = (int)(7 * this.Height / 10);

            lbl_100m.Text = "100 m";
            lbl_10m.Text = "10 m ";
            lbl_100m.Location = new Point((int)(8.7 * this.Width / 10), (int) (9 *this.Height/10));
            lbl_10m.Location = new Point((int)(9.3 * this.Width / 10), (int)(8.6 * this.Height / 10));

            //Menus
            cb_noGraph.Enabled = false;
            bt_show.Enabled = false;
            mnu_Pause.Enabled = false;
            mnu_Stop.Enabled = false;
            
            //Menu - options
            mnu_ModePoint.Checked = true;
            mnu_Acc5TideInt.Checked = true;
            cTide = dbi.returnTideInfo(1);
            mnu_tideName.Text = cTide.ConvertToLabel();
            mnu_SaveEvery500.Checked = true;

            //waves textboxes
            tb_H0.Enabled = false;
            tb_H1.Enabled = false;
            tb_H2.Enabled = false;
            tb_H3.Enabled = false;
            tb_H4.Enabled = false;
            tb_freq0.Enabled = false;
            tb_freq1.Enabled = false;
            tb_freq2.Enabled = false;
            tb_freq3.Enabled = false;
            tb_freq4.Enabled = false;
            tb_period0.Enabled = false;
            tb_period1.Enabled = false;
            tb_period2.Enabled = false;
            tb_period3.Enabled = false;
            tb_period4.Enabled = false;

            //sea textboxes
            tb_fluctRange.Enabled = false;
            tb_fluctPeriod.Enabled = false;
            tb_flDuration.Enabled = false;
                                    
            //Set min and max on Nuds
            nRuns = dbi.returnNRuns();
            nud_waveSetID.Maximum = dbi.returnNWaves();
            nud_SeaID.Maximum = dbi.returnNSeas();

            cmSea = (CurrencyManager)BindingContext[dbi.ds, "Sea"];
            cmWaves = (CurrencyManager)BindingContext[dbi.ds, "Waves"];
            cmSea.Position = 1;
            cmWaves.Position = 1;
                        
            tb_initSlope.DataBindings.Add("Text", dbi.ds, "Runs.InitialSlope");
            tb_tr.DataBindings.Add("Text", dbi.ds, "Runs.TidalRange");
            tb_sfmin.DataBindings.Add("Text", dbi.ds, "Runs.Sfmin");
            tb_s.DataBindings.Add("Text", dbi.ds, "Runs.s");
            tb_Q.DataBindings.Add("Text", dbi.ds, "Runs.Q");
            tb_k.DataBindings.Add("Text", dbi.ds, "Runs.k");
            tb_M.DataBindings.Add("Text", dbi.ds, "Runs.M");
            tb_tectMove.DataBindings.Add("Text", dbi.ds, "Runs.TectMovement");

            nud_SeaID.DataBindings.Add("Text", dbi.ds, "Sea.SeaID");
            lbl_seaName.DataBindings.Add("Text", dbi.ds, "Sea.Name");
            tb_fluctRange.DataBindings.Add("Text", dbi.ds, "Sea.Range0");
            tb_fluctPeriod.DataBindings.Add("Text", dbi.ds, "Sea.Period0");
            tb_flDuration.DataBindings.Add("Text", dbi.ds, "Sea.EndTime");

            nud_waveSetID.DataBindings.Add("Text", dbi.ds, "Waves.WaveSetID");
            tb_H0.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight0");
            tb_H1.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight1");
            tb_H2.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight2");
            tb_H3.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight3");
            tb_H4.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight4");
            tb_freq0.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency0");
            tb_freq1.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency1");
            tb_freq2.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency2");
            tb_freq3.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency3");
            tb_freq4.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency4");
            tb_period0.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod0");
            tb_period1.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod1");
            tb_period2.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod2");
            tb_period3.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod3");
            tb_period4.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod4");

            //Graph
            gr.setDeviceCoords(10, pb_picture.Width - 10, pb_picture.Height - 10, 10);

            //sea
            s = new Sea(0);
            
            //profile
            p = new Profile(cTide);
            p.setDeviceCoords(10, pb_picture.Width - 10, pb_picture.Height - 10, 10);
                      
            initialiseData();
            tb_Q.Enabled = false;
        }
                
        //Initialises sea and profile from screen
        private void initialiseData()
        {
            //Sea
            if (!cb_anySea.Checked)
                ssi = dbi.returnSeaInfo((int)nud_SeaID.Value);
            else
                ssi = getSeaInfoFromScreen();
             
            s.setVariables(ssi);
            s.SeaLevel = 0;
            s.SaveOpt = cSaveOption;
            time = startTime = s.StartTime;
            endTime = s.EndTime;
            lbl_iterations.Text = time.ToString();

            //Profile options
            p.ErosionMode = cErMode;
            p.setTide(cTide);
            p.Accuracy = cAccuracy;

            //Fill current RunInfo with data from screen
            rri = getRunInfoFromScreen();
            rri.SeaID = ssi.SeaID;
            p.setVariables (rri);
            
            //waves
            if (!cb_anyWave.Checked)
                wwi = dbi.returnWaveInfo((int)nud_waveSetID.Value);
            else
                wwi = getWaveInfoFromScreen();
            p.setWaves(wwi);
            rri.WaveSetID = wwi.WaveSetID;

            if (s.ConstSea)
                p.initialiseProfile(0, endTime - startTime);
            else
                p.initialiseProfile(s.MaxRange, endTime - startTime);
                     
            pb_picture.Refresh();
        }

        private RunInfo getRunInfoFromScreen()
        {
            RunInfo ri = new RunInfo();    //RunID = 0  
            ri.InitSlope = Convert.ToDouble(tb_initSlope.Text);
            ri.TidalRange = Convert.ToDouble(tb_tr.Text);
            ri.K = Convert.ToDouble(tb_k.Text);
            ri.S = Convert.ToDouble(tb_s.Text);
            ri.Sfmin = Convert.ToDouble(tb_sfmin.Text);
            ri.getM = Convert.ToDouble(tb_M.Text);
            ri.getQ = Convert.ToDouble(tb_Q.Text);
            ri.TectMovement = Convert.ToDouble(tb_tectMove.Text);

            return ri;
        }

        private WaveInfo getWaveInfoFromScreen()
        {
            double[] waveH = { Convert.ToDouble(tb_H0.Text), Convert.ToDouble(tb_H1.Text), Convert.ToDouble(tb_H2.Text), Convert.ToDouble(tb_H3.Text), Convert.ToDouble(tb_H4.Text) };
            double[] waveF = { Convert.ToDouble(tb_freq0.Text), Convert.ToDouble(tb_freq1.Text), Convert.ToDouble(tb_freq2.Text), Convert.ToDouble(tb_freq3.Text), Convert.ToDouble(tb_freq4.Text) };
            double[] waveP = { Convert.ToDouble(tb_period0.Text), Convert.ToDouble(tb_period1.Text), Convert.ToDouble(tb_period2.Text), Convert.ToDouble(tb_period3.Text), Convert.ToDouble(tb_period4.Text) };

            WaveInfo wi = new WaveInfo(waveH, waveF, waveP);   //WaveSetID = 0

            return wi;
        }

        private SeaInfo getSeaInfoFromScreen()
        {
            int[] times = { 0, Convert.ToInt32(tb_flDuration.Text) };
            int[] periods = { Convert.ToInt32(tb_fluctPeriod.Text) };
            double[] ranges = { Convert.ToDouble(tb_fluctRange.Text) };
            double[] durations = { 0.03, 0.82, 0.03, 0.12 };

            SeaInfo si = new SeaInfo(times, periods, ranges, durations);

            return si;
        }

        private OptionInfo getOptionInfoFromScreen()
        {
            OptionInfo oi = new OptionInfo();
            oi.ErMode = cErMode;
            oi.TideID = cTide.TideID;
            oi.Accuracy = cAccuracy;
            oi.SaveOptions = cSaveOption.ToString();

            return oi;
        }

        // -------PAINT EVENT----------------------
        private void pb_picture_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            switch (dMode)
            {
                case dispMode.Current:
                    p.Draw(g);
                    break;
                case dispMode.Color:
                    p.DrawColor(g);
                    break;
                case dispMode.Results:
                    gr.Draw(g);
                    break;
                case dispMode.Nothing:
                    break;
            }   
        }
        
        //--------ANIMATION-----------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            lbl_iterations.Text = time.ToString();
            if (time == endTime)   //! check for not saving...
            {
                mnu_Stop_Click(this, e);
                //nProfiles++;
                //dbi.addProfileToDB(cRunID, cOptionID, p.data, nProfiles + 2);
            }

            p.tectMove();
            p.erodeProfile(s.changeLevel(time));
            pb_picture.Refresh();

            //save Profile
            if (s.SaveResult)
            {
                s.SaveResult = false;
                nProfiles++;
                dbi.addProfileToDB(cRunID, cOptionID, p.data, nProfiles + 2);
                
            }         
        }

        private void bt_play_Click(object sender, EventArgs e)
        {
            mnu_Play_Click(sender, e);
        }

        private void mnu_Play_Click(object sender, EventArgs e)
        {
            bt_show.Enabled = false;
            mnu_Play.Enabled = false;
            bt_play.Enabled = false;
            mnu_Pause.Enabled = true;
            bt_pause.Enabled = true;
            mnu_Stop.Enabled = true;
            bt_stop.Enabled = true;
            if (cb_Save.Checked)
                cb_noGraph.Enabled = true;

            initialiseData();   //initialises profile and sea from textboxes and fills in rri, wwi, ssi
            
            if (!cb_Save.Checked)
            {
                s.SaveOpt = SaveOption.NONE;
            }
            else
            {
                //Add new run (if required.. )
                int tmp;
                if ((tmp = dbi.addNewRun(rri)) != 0)
                {
                    cRunID = tmp;
                    if (cRunID > nRuns)  //new row was added
                        nRuns = cRunID;
                }
                else
                {
                    MessageBox.Show("Unable to add a new run");
                    return;
                }

                //Add new option to the run
                OptionInfo oi = getOptionInfoFromScreen();   //both runID and optionID =0
                if (s.ConstSea && s.SaveOpt != SaveOption.EVERY500YRS && s.SaveOpt!=SaveOption.EVERY1000YRS)
                {
                    s.SaveOpt = SaveOption.EVERY500YRS;
                    oi.SaveOptions = SaveOption.EVERY500YRS.ToString();
                    MessageBox.Show("Save option defaulted to \"Every 500 years\"");
                }
                
                int nOptions = dbi.returnNOptions(cRunID);
                if ((tmp = dbi.addNewOption(cRunID, oi)) != 0)
                {
                    cOptionID = tmp;
                    if (cOptionID != nOptions + 1) //option already exists
                    {
                        DialogResult dres = MessageBox.Show("Overwrite results?", "Similar run already exists", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.No || dres == DialogResult.Cancel)
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("Unable to add a new option");
                    return;
                }

                dbi.initProfileToDB(cRunID, cOptionID, p.data);
                nProfiles = 1; //added initial profile only
            }
            
            timer1.Start();
        }

        private void mnu_Pause_Click(object sender, EventArgs e)
        {
            if (mnu_Pause.Text == "Continue")
            {
                mnu_Pause.Text = "Pause";
                bt_show.Enabled = false;
                timer1.Start();
            }
            else if (mnu_Pause.Text == "Pause")
            {
                mnu_Pause.Text = "Continue";
                bt_show.Enabled = true;
                timer1.Stop();
            }
            else
                MessageBox.Show("Something is incorrect");
        }

        private void mnu_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (cb_Save.Checked)
                bt_show.Enabled = true;
            cb_noGraph.Enabled = false;
            mnu_Play.Enabled = true;
            bt_play.Enabled = true;
            mnu_Pause.Enabled = false;
            bt_pause.Enabled = false;
            mnu_Stop.Enabled = false;
            bt_stop.Enabled = false;
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            mnu_Stop_Click(sender, e);
        }

        private void bt_pause_Click(object sender, EventArgs e)
        {
            mnu_Pause_Click(sender, e);

        }

        //-------------SHOW RESULTS------------
        private void bt_show_Click(object sender, EventArgs e)
        {
            if (bt_show.Text == "Show   result")
            {
                //Load result for this run and option
                displayProfile = dbi.returnSavedProfiles(cRunID, cOptionID);
                if (displayProfile == null)
                {
                    MessageBox.Show("No results availiable.");
                    dMode = dispMode.Current;
                }
                else
                {
                    bt_show.Text = "Back to animation";                   
             
                    //Graph
                    dMode = dispMode.Results;
                    gr.setData(displayProfile);
                    pb_picture.Refresh();
                }
            }
            else 
            {
                bt_show.Text = "Show   result";
                dMode = dispMode.Current;
                initialiseData();
            }
        }

        //---------INTERFACE AND OPTIONS-------

        private void nud_waveSetID_ValueChanged(object sender, EventArgs e)
        {
            cmWaves.Position = (int)nud_waveSetID.Value;
            initialiseData();
        }

        private void nud_SeaID_ValueChanged(object sender, EventArgs e)
        {
            cmSea.Position = (int)nud_SeaID.Value;
            initialiseData();
        }

        private void cb_anyWave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_anyWave.Checked)
            {
                nud_waveSetID.Enabled = false;
                cmWaves.Position = 0;

                //waves textboxes
                tb_H0.Enabled = true;
                tb_H1.Enabled = true;
                tb_H2.Enabled = true;
                tb_H3.Enabled = true;
                tb_H4.Enabled = true;
                tb_freq0.Enabled = true;
                tb_freq1.Enabled = true;
                tb_freq2.Enabled = true;
                tb_freq3.Enabled = true;
                tb_freq4.Enabled = true;
                tb_period0.Enabled = true;
                tb_period1.Enabled = true;
                tb_period2.Enabled = true;
                tb_period3.Enabled = true;
                tb_period4.Enabled = true;
            }
            else
            {
                nud_waveSetID.Enabled = true;
                cmWaves.Position = 1;

                //waves textboxes
                tb_H0.Enabled = false;
                tb_H1.Enabled = false;
                tb_H2.Enabled = false;
                tb_H3.Enabled = false;
                tb_H4.Enabled = false;
                tb_freq0.Enabled = false;
                tb_freq1.Enabled = false;
                tb_freq2.Enabled = false;
                tb_freq3.Enabled = false;
                tb_freq4.Enabled = false;
                tb_period0.Enabled = false;
                tb_period1.Enabled = false;
                tb_period2.Enabled = false;
                tb_period3.Enabled = false;
                tb_period4.Enabled = false;

                initialiseData();
            }
        }
                
        private void mnu_ModeInStrips_Click(object sender, EventArgs e)
        {
            cErMode = 1;
            mnu_ModeStrip.Checked = true;
            mnu_ModePoint.Checked = false;
            mnu_ModeLine.Checked = false;
            mnu_ModeSPoint.Checked = false;
            initialiseData();
        }

        private void mnu_ModePoints_Click(object sender, EventArgs e)
        {
            cErMode = 2;
            mnu_ModeStrip.Checked = false;
            mnu_ModePoint.Checked = true;
            mnu_ModeLine.Checked = false;
            mnu_ModeSPoint.Checked = false;
            initialiseData();
        }

        private void mnu_ModeLine_Click(object sender, EventArgs e)
        {
            cErMode = 3;
            mnu_ModeStrip.Checked = false;
            mnu_ModePoint.Checked = false;
            mnu_ModeLine.Checked = true;
            mnu_ModeSPoint.Checked = false;
            initialiseData();
        }

        private void mnu_ModeSPoint_Click(object sender, EventArgs e)
        {
            cErMode = 4;
            mnu_ModeStrip.Checked = false;
            mnu_ModePoint.Checked = false;
            mnu_ModeLine.Checked = false;
            mnu_ModeSPoint.Checked = true;
            initialiseData();
        }

        private void cb_anySea_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_anySea.Checked)
            {
                cmSea.Position = 0;
                nud_SeaID.Enabled = false;

                tb_flDuration.Enabled = true;
                tb_fluctRange.Enabled = true;
                tb_fluctPeriod.Enabled = true;
            }
            else
            {
                nud_SeaID.Enabled = true;
                cmSea.Position = 1;

                tb_flDuration.Enabled = false;
                tb_fluctRange.Enabled = false;
                tb_fluctPeriod.Enabled = false;

                initialiseData();
            }
        }

        private void tb_initSlope_Validating(object sender, CancelEventArgs e)
        {
            Match m = Regex.Match(tb_initSlope.Text, @"^[0-9]+\.?[0-9]*$");
            if (!m.Success)
            {
                e.Cancel = true;
                epError.SetError(tb_initSlope, "Please enter a positive floating point number");
            }
            else
            {
                epError.SetError(tb_initSlope, "");
            }
        }

        private void tb_tr_Validating(object sender, CancelEventArgs e)
        {
            Match m = Regex.Match(tb_tr.Text, @"^[0-9]+\.?[0-9]*$");
            if (!m.Success)
            {
                e.Cancel = true;
                epError.SetError(tb_tr, "Please enter a positive floating point number");
            }
            else
            {
                epError.SetError(tb_tr, "");
                initialiseData();
            }
        }

        private void tb_fluctRange_Validating(object sender, CancelEventArgs e)
        {
            Match m = Regex.Match(tb_fluctRange.Text, @"^[0-9]+\.?[0-9]*$");
            if (!m.Success)
            {
                e.Cancel = true;
                epError.SetError(tb_fluctRange, "Please enter a positive floating point number");
            }
            else
            {
                epError.SetError(tb_fluctRange, "");
                initialiseData();
            }
        }

        private void tb_fluctPeriod_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(tb_fluctPeriod.Text) == 0)
            {
                tb_fluctRange.Text = "0";
                initialiseData();
            }
        }

        private void tb_tectMove_Validating(object sender, CancelEventArgs e)
        {
            Match m = Regex.Match(tb_tectMove.Text, @"^[0-9]+\.?[0-9]*$");
            if (!m.Success)
            {
                e.Cancel = true;
                epError.SetError(tb_tectMove, "Please enter a positive floating point number");
            }
            else
            {
                epError.SetError(tb_tectMove, "");
                initialiseData();
            }
        }  

        //-----------ACCURACY MENUS------------
    
        private void mnu_Acc1TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.01;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc1TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
 
        }

        private void mnu_Acc2TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.02;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc2TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_Acc5TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.05;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc5TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_Acc10TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.1;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc10TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_Acc20TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.2;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc20TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_Acc50TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 0.5;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc50TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_Acc100TideInt_Click(object sender, EventArgs e)
        {
            cAccuracy = 1;
            foreach (ToolStripMenuItem mnu in mnu_Accuracy.DropDownItems)
            {
                if (mnu.Name == mnu_Acc100TideInt.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_chooseTide_Click(object sender, EventArgs e)
        {
            Form_pickTide fpt = new Form_pickTide(dbi);
            DialogResult dr = fpt.ShowDialog();

            if (dr == DialogResult.OK)
            {
                cTide =  fpt.returnChosenTide();
                mnu_tideName.Text = cTide.ConvertToLabel();
            }

            fpt.Dispose();
        }

        private void mnu_SaveAll_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.ALL;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveAll.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveBTop_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.BEFORE_TOP;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveBTop.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveATop_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.AFTER_TOP;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveATop.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveBBottom_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.BEFORE_BOTTOM;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveBBottom.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveABottom_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.AFTER_BOTTOM;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveABottom.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveEvery500_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.EVERY500YRS;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveEvery500.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void mnu_SaveEvery1000_Click(object sender, EventArgs e)
        {
            cSaveOption = SaveOption.EVERY1000YRS;
            foreach (ToolStripMenuItem mnu in mnu_Save.DropDownItems)
            {
                if (mnu.Name == mnu_SaveEvery1000.Name)
                    mnu.Checked = true;
                else
                    mnu.Checked = false;
            }
        }

        private void cb_noGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_noGraph.Checked)
                dMode = dispMode.Nothing;
            else
                dMode = dispMode.Current;
        }
        
        private void mnu_DrawInColor_CheckedChanged(object sender, EventArgs e)
        {
            if (mnu_DrawColor.Checked)
                dMode = dispMode.Color;
            else
                dMode = dispMode.Current;
        }
    }
}