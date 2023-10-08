using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Diagnostics;

namespace CoastalErosion
{
    public partial class Form2 : Form
    {                         
        //---------My Variables-----------
        TerraceFinder tf = new TerraceFinder();

        //--Reversible frame
        private bool allowSelect = false;
        private bool newScreen = true;
        private Point prevpoint, startpoint, tmp;
        private Rectangle r;

        //--Navigation through runs and options
        private dispMode dMode = dispMode.Current;
        private DatabaseInterface dbi;
        CurrencyManager cmRuns;
        CurrencyManager cmOptions;
        CurrencyManager cmWaves;
        CurrencyManager cmSea;
        private int nRuns = 0;
        private int nOptions = 0;
        private int cRunID = 1;
        private int cOption = 1;

        //--Show results
        private double[, ,] displayProfile;      
        private double[, ,] cdProfile;

        //--profile
        private Profile p;
        private Sea s;
        private int time = 0;
        private int startTime = 0 , endTime = 10;
            
        //--saved results
        private Graph gr = new Graph();
        private int nProfiles = 0;
        
        public Form2(DatabaseInterface dbi)
        {
            this.dbi = dbi;

            InitializeComponent();

            //no flicker
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            pb_picture.Capture = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = MdiParent.Width;
            this.Height = MdiParent.Height;

            //Allow to choose the run
            
            Form_PickOption fp = new Form_PickOption(dbi, false);
            DialogResult dr = fp.ShowDialog();
            OptionInfo oi;
            int selectedOption = 0;
            if (dr == DialogResult.OK)
            {
                selectedOption = fp.returnFirstSelectedItem();

                //say this corresponds to our options table
                oi = dbi.returnOptionByIndex(selectedOption);
                cRunID = oi.RunID;
                cOption = oi.OptionID;
            }
            else
            {
                //if no run was chosen load the first run
                oi = dbi.returnOptionByIndex(0);
                cRunID = 1;
                cOption = 1;
            }
            fp.Dispose();
                        
            //picture box
            pb_picture.Width = this.Width - 10;
            pb_picture.Location = new Point(0, (int)(2.5 * this.Height / 10));
            pb_picture.Height = (int)(7 * this.Height / 10);

            lbl_100m.Text = "100 m";
            lbl_10m.Text = "10 m ";
            lbl_100m.Location = new Point((int)(8.7 * this.Width / 10), (int)(9 * this.Height / 10));
            lbl_10m.Location = new Point((int)(9.3 * this.Width / 10), (int)(8.6 * this.Height / 10));

            //Menus
            mnu_Pause.Enabled = false;
            mnu_Stop.Enabled = false;
            nud_profileN.Enabled = false;
            mnu_NoGraph.Enabled = false;
                               
            cmRuns = (CurrencyManager)BindingContext[dbi.ds, "Runs"];
            cmWaves = (CurrencyManager)BindingContext[dbi.ds, "Waves"];
            cmSea = (CurrencyManager)BindingContext[dbi.ds, "Sea"];
            cmOptions = (CurrencyManager)BindingContext[dbi.ds, "Options"];
            
            lbl_initSlope.DataBindings.Add("Text", dbi.ds, "Runs.InitialSlope");
            lbl_tr.DataBindings.Add("Text", dbi.ds, "Runs.TidalRange");
            lbl_sfmin.DataBindings.Add("Text", dbi.ds, "Runs.Sfmin");
            lbl_s.DataBindings.Add("Text", dbi.ds, "Runs.s");
            lbl_Q.DataBindings.Add("Text", dbi.ds, "Runs.Q");
            lbl_k.DataBindings.Add("Text", dbi.ds, "Runs.k");
            lbl_M.DataBindings.Add("Text", dbi.ds, "Runs.M");
            lbl_runNo.DataBindings.Add("Text", dbi.ds, "Runs.RunID");
            lbl_waveSetID.DataBindings.Add("Text", dbi.ds, "Runs.WaveSetID");
            lbl_tectMove.DataBindings.Add("Text", dbi.ds, "Runs.TectMovement");

            lbl_seaID.DataBindings.Add("Text", dbi.ds, "Sea.SeaID");
            lbl_seaName.DataBindings.Add("Text", dbi.ds, "Sea.Name");
            lbl_fluctRange.DataBindings.Add("Text", dbi.ds, "Sea.Range0");
            lbl_fluctPeriod.DataBindings.Add("Text", dbi.ds, "Sea.Period0");

            lbl_H0.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight0");
            lbl_H1.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight1");
            lbl_H2.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight2");
            lbl_H3.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight3");
            lbl_H4.DataBindings.Add("Text", dbi.ds, "Waves.WaveHeight4");
            lbl_freq0.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency0");
            lbl_freq1.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency1");
            lbl_freq2.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency2");
            lbl_freq3.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency3");
            lbl_freq4.DataBindings.Add("Text", dbi.ds, "Waves.WaveFrequency4");
            lbl_period0.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod0");
            lbl_period1.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod1");
            lbl_period2.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod2");
            lbl_period3.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod3");
            lbl_period4.DataBindings.Add("Text", dbi.ds, "Waves.WavePeriod4");

            lbl_cOption.DataBindings.Add("Text", dbi.ds, "Options.OptionID"); 
            lbl_erMode.DataBindings.Add("Text", dbi.ds, "Options.ErosionMode");
            lbl_tide.DataBindings.Add("Text", dbi.ds, "Options.TideID");
            lbl_accuracy.DataBindings.Add("Text", dbi.ds, "Options.Accuracy");
            lbl_saveOption.DataBindings.Add("Text", dbi.ds, "Options.SaveProfiles");
                        
            //Set labels using currencyManagers:
            cmRuns.Position = cRunID;
            nRuns = dbi.returnNRuns();
            nOptions = dbi.returnNOptions(cRunID);  //need to be set everytime RunID is changed
            lbl_nRuns.Text = nRuns.ToString();
            lbl_nOptions.Text = nOptions.ToString();
            int wsi = (int) dbi.returnItem("Runs", cRunID, "WaveSetID");
            int seaID = (int)dbi.returnItem("Runs", cRunID, "SeaID"); ;
            cmWaves.Position = wsi;
            cmSea.Position = seaID;
            cmOptions.Position = selectedOption;
            
            //Initialise sea and profile
            s = new Sea(0);
            p = new Profile();
            p.setDeviceCoords(10, pb_picture.Width - 10, pb_picture.Height - 10, 10);
            
            //Graph
            gr.setDeviceCoords(10, pb_picture.Width - 10, pb_picture.Height - 10, 10);

            //Load result for this run and option
            reloadRun();
            setErosionMode(Convert.ToInt32(lbl_erMode.Text));
            setAccuracy(Convert.ToDouble(lbl_accuracy.Text));


        }

        private void reloadRun()
        {
            displayProfile = dbi.returnSavedProfiles(cRunID, cOption);
            
            if (displayProfile == null)
            {
                nud_profileN.Maximum = 0;
                cb_nProfile.Checked = false;
                cb_nProfile.Enabled = false;
                MessageBox.Show("No results availiable for this option.\n Select \'Re-evaluate\' to get results");
                dMode = dispMode.Current;
                initialiseData(dbi.returnRunInfo(cRunID), dbi.returnOptionInfo(cRunID, cOption));
            }
            else
            {
                
                //Graph
                dMode = dispMode.Results;
                nud_profileN.Maximum = dbi.returnNProfiles() - 1;
                cb_nProfile.Enabled = true;
                cb_nProfile.Checked = false;
                gr.setData(displayProfile);
                pb_picture.Refresh();
            }            
        }

        private void initialiseData(RunInfo ri, OptionInfo oi)
        {            
            //sea
            int seaID = ri.SeaID;
            s.setVariables(dbi.returnSeaInfo(seaID));
            s.SeaLevel = 0;
            s.SaveOpt = oi.returnSaveOption();
            time = startTime = s.StartTime;
            endTime = s.EndTime;
            lbl_iterations.Text = time.ToString();
                
            //profile
            p.setVariables (ri);
            int wsi = ri.WaveSetID;
            p.setWaves(dbi.returnWaveInfo(wsi));
            
            //profile options -> need Accuracy before initalising profile!!!
            p.ErosionMode = oi.ErMode;
            p.setTide(dbi.returnTideInfo(oi.TideID));
            p.Accuracy = oi.Accuracy;

            if (s.ConstSea)
            {                
                p.initialiseProfile(0, endTime - startTime);
            }
            else
                p.initialiseProfile(s.MaxRange, endTime - startTime);

            pb_picture.Refresh();
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
                case dispMode.Results:
                    try
                    {
                        setErosionMode(Convert.ToInt32(lbl_erMode.Text));
                        setAccuracy(Convert.ToDouble(lbl_accuracy.Text));
                        setTide(Convert.ToInt32(lbl_tide.Text));
                    }
                    catch (Exception ee)
                    {
                    }
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
            if (time == endTime)
            {
                mnu_Stop_Click(this, e);
                nProfiles++;
                dbi.addProfileToDB(cRunID, cOption, p.data, nProfiles + 2);
            }

            p.tectMove();
            p.erodeProfile(s.changeLevel(time));
            pb_picture.Refresh();

            //save Profile
            if (s.SaveResult)
            {
                s.SaveResult = false;
                nProfiles++;
                dbi.addProfileToDB(cRunID, cOption, p.data, nProfiles + 2);
            }    
        }
        
        
        private void mnu_Start_Click(object sender, EventArgs e)
        {
            bt_nextRun.Enabled = false;
            bt_prevRun.Enabled = false;
            bt_nextOption.Enabled = false;
            bt_prevOption.Enabled = false;
            mnu_Edit.Enabled = false;
            mnu_Play.Enabled = false;
            mnu_Pause.Enabled = true;
            mnu_Stop.Enabled = true;

            dMode = dispMode.Current;

            //Set data from existing run and from screen options
            RunInfo ri = dbi.returnRunInfo(cRunID);
            OptionInfo oi = dbi.returnOptionInfo(cRunID, cOption);
            
            //Initialise sea and profile
            initialiseData(ri, oi);

            s.SaveOpt = SaveOption.NONE;
           
            timer1.Start();
        }

        private void mnu_reEvaluate_Click(object sender, EventArgs e)
        {
            //if results are displayed ask if need to overwrite
            if (dMode == dispMode.Results)
            {
                DialogResult dres = MessageBox.Show("Overwrite existing results?", "Overwrite results?", MessageBoxButtons.YesNo);

                if (dres == DialogResult.Cancel)
                    return;
            }

            bt_nextRun.Enabled = false;
            bt_prevRun.Enabled = false;
            bt_nextOption.Enabled = false;
            bt_prevOption.Enabled = false;
            mnu_Edit.Enabled = false;
            mnu_Play.Enabled = false;
            mnu_Pause.Enabled = true;
            mnu_Stop.Enabled = true;

            dMode = dispMode.Current;

            RunInfo ri = dbi.returnRunInfo(cRunID);
            OptionInfo oi = dbi.returnOptionInfo(cRunID, cOption);
            initialiseData(ri, oi);

            dbi.initProfileToDB(cRunID, cOption, p.data);
            nProfiles = 1; //added initial profile

            timer1.Start();

            mnu_NoGraph.Enabled = true;

        }


        private void mnu_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            bt_nextRun.Enabled = true;
            bt_prevRun.Enabled = true;
            bt_nextOption.Enabled = true;
            bt_prevOption.Enabled = true;
            mnu_Edit.Enabled = true;
            mnu_Play.Enabled = true;
            mnu_Pause.Enabled = false;
            mnu_Stop.Enabled = false;
            mnu_NoGraph.Enabled = true;

        }

        private void mnu_Pause_Click(object sender, EventArgs e)
        {
            if (mnu_Pause.Text == "Continue")
            {
                mnu_Pause.Text = "Pause";
                timer1.Start();
            }
            else if (mnu_Pause.Text == "Pause")
            {
                mnu_Pause.Text = "Continue";
                timer1.Stop();
            }
            else
                MessageBox.Show("Something is incorrect");
        }       

        //-------------NAVIGATION BETWEEN RUNS-------------

        private void bt_prevRun_Click(object sender, EventArgs e)
        {
            if (cRunID > 1)
            {
                cRunID--;
                cOption = 1;
                nOptions = dbi.returnNOptions(cRunID);
                lbl_nOptions.Text = nOptions.ToString();
                cmRuns.Position--;
                cmWaves.Position = (int)dbi.returnItem("Runs", cmRuns.Position, "WaveSetID");
                cmSea.Position = (int)dbi.returnItem("Runs", cmRuns.Position, "SeaID");
                cmOptions.Position = dbi.returnOptionIndex(cRunID, cOption);
                reloadRun();
            }
             
        }

        private void bt_nextRun_Click(object sender, EventArgs e)
        {
            if (cRunID < nRuns)
            {
                cRunID++;
                cOption = 1;
                nOptions = dbi.returnNOptions(cRunID);
                lbl_nOptions.Text = nOptions.ToString();
            
                cmRuns.Position++;
                cmWaves.Position = (int) dbi.returnItem("Runs", cmRuns.Position, "WaveSetID");
                cmSea.Position = (int) dbi.returnItem("Runs", cmRuns.Position, "SeaID");
                cmOptions.Position = dbi.returnOptionIndex(cRunID, cOption);
                reloadRun();
            }

        }

        private void bt_prevOption_Click(object sender, EventArgs e)
        {
            if (cOption > 1)
            {
                cOption--;
                cmOptions.Position--;
                reloadRun();
            }
        }

        private void bt_nextOption_Click(object sender, EventArgs e)
        {
            if (cOption < nOptions)
            {
                cOption++;
                cmOptions.Position++;
                reloadRun();
            }
        }

        //-----------ADDING AND MODIFYING RUNS--------
        private void mnu_NewRun_Click(object sender, EventArgs e)
        {
            Form_Add c = new Form_Add(dbi);
            c.Text = "New Run";
            DialogResult dres = c.ShowDialog();

            if (dres == DialogResult.OK)
            {
                nRuns = dbi.returnNRuns();
                
                int[] values = c.returnAddedValues();
                cRunID = values[0];
                cmRuns.Position = cRunID;
                
                nOptions = dbi.returnNOptions(cRunID);  //need to be set everytime RunID is changed
                cOption = values[1];
                cmOptions.Position = dbi.returnOptionIndex(cRunID, cOption);
                lbl_nRuns.Text = nRuns.ToString();
                lbl_nOptions.Text = nOptions.ToString();
                int wsi = (int)dbi.returnItem("Runs", cRunID, "WaveSetID");
                int seaID = (int)dbi.returnItem("Runs", cRunID, "SeaID"); ;
                cmWaves.Position = wsi;
                cmSea.Position = seaID;

                reloadRun();
            }

            c.Dispose();
        }

        private void mnu_ModifyRun_Click(object sender, EventArgs e)
        {
            Form_Add c = new Form_Add(dbi, cRunID, cOption);
            c.Text = "Modify Run";
            DialogResult dres = c.ShowDialog();

            if (dres == DialogResult.OK)
            {
                nRuns = dbi.returnNRuns();

                int[] values = c.returnAddedValues();
                cRunID = values[0];
                cmRuns.Position = cRunID;

                nOptions = dbi.returnNOptions(cRunID);  //need to be set everytime RunID is changed
                cOption = values[1];
                cmOptions.Position = dbi.returnOptionIndex(cRunID, cOption);
                lbl_nRuns.Text = nRuns.ToString();
                lbl_nOptions.Text = nOptions.ToString();
                int wsi = (int)dbi.returnItem("Runs", cRunID, "WaveSetID");
                int seaID = (int)dbi.returnItem("Runs", cRunID, "SeaID"); ;
                cmWaves.Position = wsi;
                cmSea.Position = seaID;

                reloadRun();
            }

            c.Dispose();
           
        }
        
        //--Single profiles
        private void cb_nProfile_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nProfile.Checked)
            {
                allowSelect = true;
                newScreen = true;
                nud_profileN.Enabled = true;
                mnu_ZoomIn.Enabled = true;
                mnu_ZoomOut.Enabled = false;
                reloadProfile((int)nud_profileN.Value);
            }
            else
            {
                allowSelect = false;
                nud_profileN.Enabled = false;
                mnu_ZoomIn.Enabled = false;
                nud_profileN.Value = 0;                
                reloadRun();
            }
        }

        private void reloadProfile(int profileN)
        {
            int rows = displayProfile.GetLength(0);
            cdProfile = new double[rows, 2, 1];

            for (int i = 0; i < rows; i++)
            {
                cdProfile[i, 0, 0] = displayProfile[i, 0, profileN];
                cdProfile[i, 1, 0] = displayProfile[i, 1, profileN];
            }

            gr.setDataNoRescale(cdProfile);
            pb_picture.Refresh();
        }

        private void nud_profileN_ValueChanged(object sender, EventArgs e)
        {
            reloadProfile((int)nud_profileN.Value);
        }

        private void mnu_NoGraph_Click(object sender, EventArgs e)
        {
            if (mnu_NoGraph.Checked)
            {
                mnu_NoGraph.Checked = false;
                dMode = dispMode.Current;
            }
            else
            {
                mnu_NoGraph.Checked = true;
                dMode = dispMode.Nothing;
            }
        }

        private void pb_picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (allowSelect)
            {
                if (r != null && !newScreen)
                    ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);

                pb_picture.Capture = true;
                startpoint.X = prevpoint.X = e.X;
                startpoint.Y = prevpoint.Y = e.Y;
                tmp = pb_picture.PointToScreen(startpoint);
                r.X = tmp.X;
                r.Y = tmp.Y;
                r.Width = e.X - startpoint.X;
                r.Height = e.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                newScreen = false;
            }
            else
                pb_picture.Capture = false;
        }

        private void pb_picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (pb_picture.Capture)
            {
                r.X = tmp.X;
                r.Y = tmp.Y;
                r.Width = prevpoint.X - startpoint.X;
                r.Height = prevpoint.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                r.Width = e.X - startpoint.X;
                r.Height = e.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                prevpoint.X = e.X;
                prevpoint.Y = e.Y;

            }
        }

        private void pb_picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (pb_picture.Capture)
            {
                r.X = tmp.X;
                r.Y = tmp.Y;
                r.Width = prevpoint.X - startpoint.X;
                r.Height = prevpoint.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                r.Width = e.X - startpoint.X;
                r.Height = e.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                prevpoint.X = e.X;
                prevpoint.Y = e.Y;
                this.Capture = false;
            }
        }

        private void mnu_ZoomIn_Click(object sender, EventArgs e)
        {
            if (startpoint == null || prevpoint == null)
                return;

            //ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
            
            double topBoundry, lowBoundry, leftBoundry, rightBoundry;
            
            topBoundry = (double)startpoint.Y / (double)pb_picture.Height;
            lowBoundry = (double)prevpoint.Y / (double)pb_picture.Height;
            leftBoundry = (double)startpoint.X / (double)pb_picture.Width;
            rightBoundry = (double)prevpoint.X / (double)pb_picture.Width;

            double tmp;
            if (startpoint.Y > prevpoint.Y)
            {
                tmp = lowBoundry;
                lowBoundry = topBoundry;
                topBoundry = tmp;
            }
            if (startpoint.X > prevpoint.X)
            {
                tmp = rightBoundry;
                rightBoundry = leftBoundry;
                leftBoundry = tmp;
            }

            gr.rescale(leftBoundry, rightBoundry, topBoundry, lowBoundry);
            pb_picture.Refresh();

            allowSelect = false;
            mnu_ZoomIn.Enabled = false;
            mnu_ZoomOut.Enabled = true;
        }

        private void mnu_ZoomOut_Click(object sender, EventArgs e)
        {
            gr.restore();
            pb_picture.Refresh();

            allowSelect = true;
            pb_picture.Capture = false;
            newScreen = true;
            mnu_ZoomIn.Enabled = true;
            mnu_ZoomOut.Enabled = false;
        }

        private void mnu_Detect_Click(object sender, EventArgs e)
        {
            if (cdProfile != null)
            {
                int[] res2 = tf.findTerraces2(cdProfile);

                Form_Profile fp = new Form_Profile(cdProfile);
                fp.Text = "Run " + cRunID.ToString() + " Option " + cOption.ToString() + " Profile" + nud_profileN.Value.ToString();
                fp.setLabelText("");
                fp.Show();
                fp.assignBend(res2);
            }
        }

        private void setErosionMode(int mode)
        {
            switch (mode)
            {
                case 1:
                    lbl_erMode.Text = "In Strips";
                    break;
                case 2:
                    lbl_erMode.Text = "Point-by-point";
                    break;
                case 3:
                    lbl_erMode.Text = "Lines";
                    break;
                case 4:
                    lbl_erMode.Text = "SPoints";
                    break;
                default:
                    MessageBox.Show("Mistake in error mode");
                    break;
            }
        }

        private void setAccuracy(double accuracy)
        {
            lbl_accuracy.Text = "1/"+Convert.ToInt32(1/accuracy) + " Tide Interval";
        }

        private void setTide(int tideID)
        {
            TideInfo ti = dbi.returnTideInfo(tideID);
            lbl_tide.Text = ti.ConvertToLabelShort();
        }
    }
}