using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_Main : Form
    {
        private DatabaseInterface dbi;
        private TerraceFinder tf;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            //Fill database and labels
            dbi = new DatabaseInterface();
            dbi.initialiseDatabase();

            tf = new TerraceFinder();
    
            Form1 form1 = new Form1(dbi);
            form1.MdiParent = this;
            form1.Show();
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_PlayMode_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                f.Close();
            Form1 form1 = new Form1(dbi);
            form1.MdiParent = this;
            form1.Show();
        }

        private void mnu_ExistingMode_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                f.Close();
            Form2 form2 = new Form2(dbi);
            form2.MdiParent = this;
            form2.Show();
        }

        private void mnu_CompareRuns_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                f.Close();
            Form_PickOption fpick = new Form_PickOption(dbi, true);
            DialogResult dr = fpick.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (int i in fpick.returnSelectedItems())
                {
                    OptionInfo oi = dbi.returnOptionByIndex(i);
                    RunInfo ri = dbi.returnRunInfo(oi.RunID);
                    double[,,] profiles = dbi.returnSavedProfiles(oi.RunID, oi.OptionID);
                    Form_Profile fp = new Form_Profile(profiles);
                    fp.MdiParent = this;
                    fp.Text = "Run " + oi.RunID + " Option "+oi.OptionID;
                    string s = "Tr = "+ri.TidalRange+"  WaveSet "+ri.WaveSetID;
                    s+= "\nIncline = "+ri.InitSlope+"  SeaID "+ri.SeaID;
                    s+= "\nk = "+ri.K + "  TectMovement "+ri.TectMovement; 
                    s+="\nSfmin = "+ri.Sfmin+"  ErMode "+oi.ErMode;
                    s+="\ns = "+ri.S+"  TideID"+oi.TideID;
                    s+="\nQ = "+ri.getQ+"  Accuracy"+oi.Accuracy;
                    s+="\nM = "+ri.getM+"  Saved "+oi.SaveOptions;

                    fp.setLabelText(s);
                }
            }
            fpick.Dispose();

            foreach (Form f in this.MdiChildren)
                f.Show();

            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnu_Detect_Click(object sender, EventArgs e)
        {
            //no error checking by the form!!!!
            Form_Analyse fa = new Form_Analyse();
            DialogResult dres = fa.ShowDialog();
            int[] choice = null;

            if (dres == DialogResult.OK)
            {
                choice = fa.returnChoice();
            }
            fa.Dispose();

            double[,,] profile;
            if (choice != null)
            {
                profile = dbi.returnSavedProfile(choice[0], choice[1], choice[2]);

                if (profile != null)
                {
                    //Find terraces  -> array of points
                    //double[,] res = tf.findTerraces(profile);
                    int[] res2 = tf.findTerraces2(profile);

                    Form_Profile fp = new Form_Profile(profile);
                    fp.MdiParent = this;
                    fp.Text = "Run " + choice[0].ToString() + " Option " + choice[1].ToString() + " Profile " + choice[2].ToString();
                    fp.setLabelText("");
                    fp.Show();
                    fp.assignBend(res2);
                    //fp.assignCircles(res);
                }
            }
        }

        
    }
}