using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CoastalErosion
{
    public class DatabaseInterface
    {
        //--DB connection
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= db3.mdb");
        OleDbDataAdapter daRuns;
        OleDbDataAdapter daRelief;
        OleDbDataAdapter daWaves;
        OleDbDataAdapter daSea;
        OleDbDataAdapter daTide;
        OleDbDataAdapter daOptions;
        OleDbCommandBuilder cbRuns;
        OleDbCommandBuilder cbRelief;
        OleDbCommandBuilder cbWaves;
        OleDbCommandBuilder cbSea;
        OleDbCommandBuilder cbTide;
        OleDbCommandBuilder cbOptions;
        OleDbCommand cmdDelete;
        public DataSet ds = new DataSet();

        public void initialiseDatabase()
        {
            daRuns = new OleDbDataAdapter("SELECT * FROM Runs ORDER BY RunID", conn);
            daRelief = new OleDbDataAdapter("SELECT * FROM Relief WHERE RunID = ? AND OptionID = ? ORDER BY Height DESC", conn);
            daWaves = new OleDbDataAdapter("SELECT * FROM Waves ORDER BY WaveSetID", conn);
            daSea = new OleDbDataAdapter("SELECT * FROM Sea ORDER BY SeaID", conn);
            daTide = new OleDbDataAdapter("SELECT * FROM Tide ORDER BY TideID", conn);
            daOptions = new OleDbDataAdapter("SELECT * FROM Options ORDER BY RunID, OptionID", conn);

            //ensure primary keys are loaded
            daRuns.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daRelief.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daWaves.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daSea.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daTide.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daOptions.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //Runs table schema
            daRuns.FillSchema(ds, SchemaType.Mapped, "Runs");
            daRuns.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 

            //Relief table schema
            daRelief.FillSchema(ds, SchemaType.Mapped, "Relief");
            daRelief.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 
            daRelief.SelectCommand.Parameters.Add("@RunID", OleDbType.Integer);
            daRelief.SelectCommand.Parameters.Add("@OptionID", OleDbType.Integer);

            //Waves table schema
            daWaves.FillSchema(ds, SchemaType.Mapped, "Waves");
            daWaves.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 

            //Sea table schema
            daSea.FillSchema(ds, SchemaType.Mapped, "Sea");
            daSea.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 

            //Sea table schema
            daTide.FillSchema(ds, SchemaType.Mapped, "Tide");
            daTide.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 

            //Options table schema
            daOptions.FillSchema(ds, SchemaType.Mapped, "Options");
            daOptions.MissingSchemaAction = MissingSchemaAction.Error; //to make sure no columns were removed from dataset. 
            //daOptions.SelectCommand.Parameters.Add("@RunID", OleDbType.Integer);

            //add relationships
            ds.Relations.Add("Runs_Options", ds.Tables["Runs"].Columns["RunID"], ds.Tables["Options"].Columns["RunID"], true);
            DataColumn[] dtarray1 = { ds.Tables["Options"].Columns["RunID"], ds.Tables["Options"].Columns["OptionID"] };
            DataColumn[] dtarray2 = { ds.Tables["Relief"].Columns["RunID"], ds.Tables["Relief"].Columns["OptionID"] };
            ds.Relations.Add("Options_Relief", dtarray1, dtarray2, true);
            ds.Relations.Add("Waves_Runs", ds.Tables["Waves"].Columns["WaveSetID"], ds.Tables["Runs"].Columns["WaveSetID"], true);
            ds.Relations.Add("Sea_Runs", ds.Tables["Sea"].Columns["SeaID"], ds.Tables["Runs"].Columns["SeaID"], true);
            ds.Relations.Add("Tide_Options", ds.Tables["Tide"].Columns["TideID"], ds.Tables["Options"].Columns["TideID"], true);

            //Command builders
            cbRelief = new OleDbCommandBuilder(daRelief);
            cbRuns = new OleDbCommandBuilder(daRuns);
            cbWaves = new OleDbCommandBuilder(daWaves);
            cbSea = new OleDbCommandBuilder(daSea);
            cbTide = new OleDbCommandBuilder(daTide);
            cbOptions = new OleDbCommandBuilder(daOptions);

            //Delete commmand
            cmdDelete = new OleDbCommand("DELETE * FROM Relief", conn);

            //Fill data
            daWaves.Fill(ds, "Waves");
            daSea.Fill(ds, "Sea");
            daTide.Fill(ds, "Tide");
            daRuns.Fill(ds, "Runs");
            daOptions.Fill(ds, "Options");
        }

        private void buildCommandsForRelief()
        {
            string insQuery = @"INSERT INTO Relief (RunID, OptionID, Height, InitProfile, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30, r31, r32, r33, r34, r35, r36) VALUES (@RunID, @OptionID, @Height, @InitProfile, @r1, @r2, @r3, @r4, @r5, @r6, @r7, @r8, @r9, @r10, @r11, @r12, @r13, @r14, @r15, @r16, @r17, @r18, @r19, @r20, @r21, @r22, @r23, @r24, @r25, @r26, @r27, @r28, @r29, @r30, @r31, @r32, @r33, @r34, @r35, @r36)";
            OleDbCommand insCmd = conn.CreateCommand();
            insCmd.CommandText = insQuery;

            //build parameters
            OleDbParameterCollection insParams = insCmd.Parameters;

            insParams.Add("@RunID", OleDbType.Integer, 0, "RunID");
            insParams.Add("@OptionID", OleDbType.Integer, 0, "OptionID");
            insParams.Add("@Height", OleDbType.Double, 16, "Height");
            insParams.Add("@InitProfile", OleDbType.Double, 16, "InitProfile");
            insParams.Add("@r1", OleDbType.Double, 16, "r1");
            insParams.Add("@r2", OleDbType.Double, 16, "r2");
            insParams.Add("@r3", OleDbType.Double, 16, "r3");
            insParams.Add("@r4", OleDbType.Double, 16, "r4");
            insParams.Add("@r5", OleDbType.Double, 16, "r5");
            insParams.Add("@r6", OleDbType.Double, 16, "r6");
            insParams.Add("@r7", OleDbType.Double, 16, "r7");
            insParams.Add("@r8", OleDbType.Double, 16, "r8");
            insParams.Add("@r9", OleDbType.Double, 16, "r9");
            insParams.Add("@r10", OleDbType.Double, 16, "r10");
            insParams.Add("@r11", OleDbType.Double, 16, "r11");
            insParams.Add("@r12", OleDbType.Double, 16, "r12");
            insParams.Add("@r13", OleDbType.Double, 16, "r13");
            insParams.Add("@r14", OleDbType.Double, 16, "r14");
            insParams.Add("@r15", OleDbType.Double, 16, "r15");
            insParams.Add("@r16", OleDbType.Double, 16, "r16");
            insParams.Add("@r17", OleDbType.Double, 16, "r17");
            insParams.Add("@r18", OleDbType.Double, 16, "r18");
            insParams.Add("@r19", OleDbType.Double, 16, "r19");
            insParams.Add("@r20", OleDbType.Double, 16, "r20");
            insParams.Add("@r21", OleDbType.Double, 16, "r21");
            insParams.Add("@r22", OleDbType.Double, 16, "r22");
            insParams.Add("@r23", OleDbType.Double, 16, "r23");
            insParams.Add("@r24", OleDbType.Double, 16, "r24");
            insParams.Add("@r25", OleDbType.Double, 16, "r25");
            insParams.Add("@r26", OleDbType.Double, 16, "r26");
            insParams.Add("@r27", OleDbType.Double, 16, "r27");
            insParams.Add("@r28", OleDbType.Double, 16, "r28");
            insParams.Add("@r29", OleDbType.Double, 16, "r29");
            insParams.Add("@r30", OleDbType.Double, 16, "r30");
            insParams.Add("@r31", OleDbType.Double, 16, "r31");
            insParams.Add("@r32", OleDbType.Double, 16, "r32");
            insParams.Add("@r33", OleDbType.Double, 16, "r33");
            insParams.Add("@r34", OleDbType.Double, 16, "r34");
            insParams.Add("@r35", OleDbType.Double, 16, "r35");
            insParams.Add("@r36", OleDbType.Double, 16, "r36");

            daRelief.InsertCommand = insCmd;

            string updQuery = "UPDATE Relief SET ";
            updQuery += " RunID = @RunID, ";
            updQuery += " OptionID = @OptionID, ";
            updQuery += " Height = @Height, ";
            updQuery += " InitProfile = @InitProfile, ";
            updQuery += " r1 = @r1, r2 = @r2, r3 = @r3, r4 = @r4, r5 = @r5, ";
            updQuery += " r6 = @r6, r7 = @r7, r8 = @r8, r9 = @r9, r10= @r10, ";
            updQuery += " r11 = @r11, r12 = @r12, r13 = @r13, r14 = @r14, r15 = @r15, ";
            updQuery += " r16 = @r16, r17 = @r17, r18 = @r18, r19 = @r19, r20 = @r20, ";
            updQuery += " r21 = @r21, r22 = @r22, r23 = @r23, r24 = @r24, r25 = @r25, ";
            updQuery += " r26 = @r26, r27 = @r27, r28 = @r28, r29 = @r29, r30 = @r30, ";
            updQuery += " r31 = @r31, r32 = @r32, r33 = @r33, r34 = @r34, r35 = @r35, r36 = @r36 ";
            updQuery += " WHERE ..."; 

            OleDbCommand updCmd = conn.CreateCommand();
            updCmd.CommandText = insQuery;

            //build parameters
            OleDbParameterCollection updParams = updCmd.Parameters;

            updParams.Add("@RunID", OleDbType.Integer, 0, "RunID");
            updParams.Add("@OptionID", OleDbType.Integer, 0, "OptionID");
            updParams.Add("@Height", OleDbType.Double, 16, "Height");
            updParams.Add("@InitProfile", OleDbType.Double, 16, "InitProfile");
            updParams.Add("@r1", OleDbType.Double, 16, "r1");
            updParams.Add("@r2", OleDbType.Double, 16, "r2");
            updParams.Add("@r3", OleDbType.Double, 16, "r3");
            updParams.Add("@r4", OleDbType.Double, 16, "r4");
            updParams.Add("@r5", OleDbType.Double, 16, "r5");
            updParams.Add("@r6", OleDbType.Double, 16, "r6");
            updParams.Add("@r7", OleDbType.Double, 16, "r7");
            updParams.Add("@r8", OleDbType.Double, 16, "r8");
            updParams.Add("@r9", OleDbType.Double, 16, "r9");
            updParams.Add("@r10", OleDbType.Double, 16, "r10");
            updParams.Add("@r11", OleDbType.Double, 16, "r11");
            updParams.Add("@r12", OleDbType.Double, 16, "r12");
            updParams.Add("@r13", OleDbType.Double, 16, "r13");
            updParams.Add("@r14", OleDbType.Double, 16, "r14");
            updParams.Add("@r15", OleDbType.Double, 16, "r15");
            updParams.Add("@r16", OleDbType.Double, 16, "r16");
            updParams.Add("@r17", OleDbType.Double, 16, "r17");
            updParams.Add("@r18", OleDbType.Double, 16, "r18");
            updParams.Add("@r19", OleDbType.Double, 16, "r19");
            updParams.Add("@r20", OleDbType.Double, 16, "r20");
            updParams.Add("@r21", OleDbType.Double, 16, "r21");
            updParams.Add("@r22", OleDbType.Double, 16, "r22");
            updParams.Add("@r23", OleDbType.Double, 16, "r23");
            updParams.Add("@r24", OleDbType.Double, 16, "r24");
            updParams.Add("@r25", OleDbType.Double, 16, "r25");
            updParams.Add("@r26", OleDbType.Double, 16, "r26");
            updParams.Add("@r27", OleDbType.Double, 16, "r27");
            updParams.Add("@r28", OleDbType.Double, 16, "r28");
            updParams.Add("@r29", OleDbType.Double, 16, "r29");
            updParams.Add("@r30", OleDbType.Double, 16, "r30");
            updParams.Add("@r31", OleDbType.Double, 16, "r31");
            updParams.Add("@r32", OleDbType.Double, 16, "r32");
            updParams.Add("@r33", OleDbType.Double, 16, "r33");
            updParams.Add("@r34", OleDbType.Double, 16, "r34");
            updParams.Add("@r35", OleDbType.Double, 16, "r35");
            updParams.Add("@r36", OleDbType.Double, 16, "r36");

            daRelief.UpdateCommand = updCmd;

        }

        public int returnNRuns()
        {
            return ds.Tables["Runs"].Rows.Count - 1;
        }

        public int returnNSeas()
        {
            return ds.Tables["Sea"].Rows.Count - 1;
        }

        public int returnNWaves()
        {
            return ds.Tables["Waves"].Rows.Count - 1;
        }

        public int returnNTides()
        {
            return ds.Tables["Tide"].Rows.Count;
        }

        public int returnNOptions(int runID)
        {
            string s = "RunID = " + runID.ToString();
            DataRow[] drs = ds.Tables["Options"].Select(s);
            return drs.Length;
        }

        public int returnNProfiles()
        {
            //assumed dtRelief has correct data
            DataTable dtRelief = ds.Tables["Relief"];
            int numRows = dtRelief.Rows.Count;

            if (numRows > 0)
            {
                DataRow r = dtRelief.Rows[0];

                //find the number of non-empty columns
                int cols = 0;
                while (cols < dtRelief.Columns.Count && !r.IsNull(cols))
                    cols++;
                return cols - 3;
            }
            else
                return 0;
        }

        public int returnNProfiles(int runID, int optionID)
        {
            ds.Tables["Relief"].Clear();

            daRelief.SelectCommand.Parameters[0].Value = runID;
            daRelief.SelectCommand.Parameters[1].Value = optionID;

            daRelief.Fill(ds, "Relief");

            DataTable dtRelief = ds.Tables["Relief"];
            int numRows = dtRelief.Rows.Count;

            if (numRows > 0)
            {
                DataRow r = dtRelief.Rows[0];

                //find the number of non-empty columns
                int cols = 0;
                while (cols < dtRelief.Columns.Count && !r.IsNull(cols))
                    cols++;
                return cols - 2;
            }
            else
                return 0;
        }

        public RunInfo returnRunInfo(int runID)
        {
            RunInfo tmp = new RunInfo(ds.Tables["Runs"].Rows[runID]);

            return tmp;
        }

        public WaveInfo returnWaveInfo(int waveSetID)
        {
            WaveInfo tmp = new WaveInfo(ds.Tables["Waves"].Rows[waveSetID]);

            return tmp;
        }

        public SeaInfo returnSeaInfo(int seaID)
        {
            SeaInfo tmp = new SeaInfo(ds.Tables["Sea"].Rows[seaID]);
 
            return tmp;
        }

        public double[] returnTideDuration(int tideID)
        {
            DataRow r = ds.Tables["Tide"].Rows[tideID - 1];
            int nCols = ds.Tables["Tide"].Columns.Count;

            double[] tmp = new double[nCols - 1];
            
            for (int i = 1; i < nCols; i++)
                tmp[i - 1] = (double) r[i];
            return tmp;
        }

        public TideInfo returnTideInfo(int tideID)
        {
            TideInfo tmp = new TideInfo(ds.Tables["Tide"].Rows[tideID - 1]);
            return tmp;
        }

        public OptionInfo returnOptionByIndex(int index)
        {
            OptionInfo tmp = new OptionInfo(ds.Tables["Options"].Rows[index]);
            return tmp;
        }

        public OptionInfo returnOptionInfo(int runID, int optionID)
        {
            string s = "RunID = " + runID.ToString();
            DataRow[] drs = ds.Tables["Options"].Select(s);
            OptionInfo tmp = new OptionInfo(drs[optionID - 1]);
            return tmp;
        }

        public DataRow newRunsRow()
        {
            return ds.Tables["Runs"].NewRow();
        }

        public DataRow newWavesRow()
        {
            return ds.Tables["Waves"].NewRow();
        }

        public DataRow newSeaRow()
        {
            return ds.Tables["Sea"].NewRow();
        }

        public DataRow newOptionRow()
        {
            return ds.Tables["Option"].NewRow();
        }

        public DataRow newTideRow()
        {
            return ds.Tables["Tide"].NewRow();
        }

        public object returnItem(string tableName, int ID, string colName)
        {
            return ds.Tables[tableName].Rows[ID][colName];
        }

        public RunOptionInfoList returnRunOptionsInfoTable()
        {
            OleDbCommand cmd = conn.CreateCommand();
            string str = "SELECT Runs.RunID, Options.OptionID, Runs.InitialSlope, Runs.TidalRange, Runs.WaveSetID, Runs.k, Runs.Sfmin, Runs.s, Runs.M, Runs.Q, Runs.SeaID, Sea.Name, Runs.TectMovement, Options.ErosionMode, Options.TideID, Options.Accuracy, Options.SaveProfiles FROM Runs, Sea, Options WHERE Runs.RunID = Options.RunID AND Sea.SeaID = Runs.SeaID ORDER BY Runs.RunID, Options.OptionID;";
            cmd.CommandText = str;

            try
            {
                conn.Open();
                               
                OleDbDataReader rdr = cmd.ExecuteReader();

                RunOptionInfoList rList = new RunOptionInfoList(rdr);

                conn.Close();

                return rList;
            }
            catch (OleDbException ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                if (conn != null)
                    conn.Close();                
            }
            return null;
        }

        public int returnOptionIndex(int RunID, int OptionID)
        {
            int rows =ds.Tables["Options"].Rows.Count;
            DataRow dr;

            for (int i = 0; i < rows; i++)
            {
                dr = ds.Tables["Options"].Rows[i];
                if ((int)dr["RunID"] == RunID && (int)dr["OptionID"] == OptionID)
                    return i;
            }
            MessageBox.Show("Incorrect parameters");
            return 0; 
        }

        public SaveOption returnSaveOption(int runID, int option)
        {
            string s = "RunID = " + runID.ToString();
            DataRow[] drs = ds.Tables["Options"].Select(s);
            s = (string)drs[option - 1]["SaveProfiles"];
            if (s == "ALL")
                return SaveOption.ALL;
            if (s == "BEFORE_TOP")
                return SaveOption.BEFORE_TOP;
            if (s == "AFTER_TOP")
                return SaveOption.AFTER_TOP;
            if (s == "BEFORE_BOTTOM")
                return SaveOption.BEFORE_BOTTOM;
            if (s == "AFTER_BOTTOM")
                return SaveOption.AFTER_BOTTOM;
            if (s == "EVERY500YRS")
                return SaveOption.EVERY500YRS;
            if (s == "EVERY1000YRS")
                return SaveOption.EVERY1000YRS;
            return SaveOption.NONE;
        }


        public double[, ,] returnSavedProfile(int runID, int option, int profileN)
        {
            ds.Tables["Relief"].Clear();

            daRelief.SelectCommand.Parameters[0].Value = runID;
            daRelief.SelectCommand.Parameters[1].Value = option;

            daRelief.Fill(ds, "Relief");

            DataTable dtRelief = ds.Tables["Relief"];
            int numRows = dtRelief.Rows.Count;

            if (numRows > 0)
            {
                DataRow r;
                double[, ,] tmp = new double[numRows, 2, 1];
                string s;

                if (profileN == 0)
                    s = "InitProfile";
                else
                    s = "r" + profileN.ToString();

                //see if land moved tectonically
                double tectMovement = (double)ds.Tables["Runs"].Rows[runID]["TectMovement"];
                if (tectMovement == 0)
                {
                    for (int i = 0; i < numRows; i++)
                    {
                        r = dtRelief.Rows[i];
                        tmp[i, 0, 0] = (double)r["Height"];
                        tmp[i, 1, 0] = (double)r[s];
                    }
                }
                else
                {
                    SeaInfo si = returnSeaInfo((int)ds.Tables["Runs"].Rows[runID]["SeaID"]);
                    SaveOption so = returnSaveOption(runID, option);
                    int[] savetimes = si.returnSaveIntervals(so);

                    double addHeight = 0;
                    for (int i = 0; i < profileN; i++)
                        addHeight += tectMovement * savetimes[i];

                    for (int i = 0; i < numRows; i++)
                    {
                        r = dtRelief.Rows[i];
                        tmp[i, 0, 0] = (double)r["Height"] + addHeight;
                        tmp[i, 1, 0] = (double)r[s];
                    }
                }
                return tmp;
            }
            else
                return null;
        }

        public double[, ,] returnSavedProfiles(int runID, int Option)
        {
            //Load data into Relief table
            ds.Tables["Relief"].Clear();

            daRelief.SelectCommand.Parameters[0].Value = runID;
            daRelief.SelectCommand.Parameters[1].Value = Option;

            daRelief.Fill(ds, "Relief");

            DataTable dtRelief = ds.Tables["Relief"];
            int numRows = dtRelief.Rows.Count;

            if (numRows > 0)
            {
                DataRow r = dtRelief.Rows[0];

                //find the number of non-empty columns
                int cols = 0;
                while (cols < dtRelief.Columns.Count && !r.IsNull(cols))
                    cols++;
                //we want to output all data into one long array
                double[, ,] tmp = new double[numRows, 2, cols - 3];

                //see if land moved tectonically
                double tectMovement = (double)ds.Tables["Runs"].Rows[runID]["TectMovement"];
                if (tectMovement == 0)
                {
                    for (int i = 0; i < cols - 3; i++)
                    {
                        for (int j = 0; j < numRows; j++)
                        {
                            r = dtRelief.Rows[j];
                            tmp[j, 0, i] = (double)r["Height"];
                            tmp[j, 1, i] = (double)r[i + 3];
                        }
                    }
                }
                else
                {
                    SeaInfo si = returnSeaInfo((int)ds.Tables["Runs"].Rows[runID]["SeaID"]);
                    SaveOption so = returnSaveOption(runID, Option);
                    int[] savetimes = si.returnSaveIntervals(so);

                    double addHeight = 0;

                    for (int i = 0; i < cols - 3; i++)
                    {
                        for (int j = 0; j < numRows; j++)
                        {
                            r = dtRelief.Rows[j];
                            tmp[j, 0, i] = (double)r["Height"] + addHeight;
                            tmp[j, 1, i] = (double)r[i + 3];
                        }
                        addHeight += savetimes[i] * tectMovement;
                    }

                }
                return tmp;

            }
            else
                return null;
        }

        public int addNewOption(int runID, OptionInfo oi)
        {
            //check if duplicate
            int duplID;
            if ((duplID = checkOptionDuplicate(runID, oi)) != 0)  //this run already has this option
            {
                MessageBox.Show("The run is identical to an existing run.");
                return duplID;
            }

            int optionID = returnNOptions(runID) + 1;   //add option at the end

            //Add new option
            DataTable dt = ds.Tables["Options"];
            DataRow ro = dt.NewRow();
            ro["RunID"] = runID;
            ro["OptionID"] = optionID;
            ro["ErosionMode"] = oi.ErMode;
            ro["TideID"] = oi.TideID;
            ro["Accuracy"] = oi.Accuracy;
            ro["SaveProfiles"] = oi.SaveOptions;
            ds.Tables["Options"].Rows.Add(ro);
            //should really be insertAt - test:
            //ds.Tables["Options"].Rows.InsertAt(ro, returnOptionIndex(runID, optionID -1) + 1);

            try
            {
                int rowsModified = daOptions.Update(ds.Tables["Options"]);
                MessageBox.Show(rowsModified + " options added. Option "+optionID.ToString());
            
                if (rowsModified == 0)
                    return 0;
                else
                    return optionID;
            }
            catch (OleDbException ee)
            {
                MessageBox.Show(ee.Message);
            }

            return 0;
        }

        public int addNewRun(RunInfo ri)
        {
            if (ri.SeaID == 0 || ri.WaveSetID == 0)
            {
                MessageBox.Show("Please create new wave or sea as appropriate");
                return 0;
            }

            //check if duplicate
            int duplID;
            if ((duplID = checkRunDuplicate(ri)) != 0)  //run already exists
            {
                MessageBox.Show("A run with similar parameters already exists.");
                return duplID;
            }

            //add run
            DataTable dt = ds.Tables["Runs"];
            int runID = dt.Rows.Count;
            DataRow r = dt.NewRow();
            r["RunID"] = runID;  //add the run at the end!
            r["InitialSlope"] = ri.InitSlope;
            r["TidalRange"] = ri.TidalRange;
            r["WaveSetID"] = ri.WaveSetID;
            r["k"] = ri.K;
            r["s"] = ri.S;
            r["Sfmin"] = ri.Sfmin;
            r["M"] = ri.getM;
            r["Q"] = ri.getQ;
            r["SeaID"] = ri.SeaID;
            r["TectMovement"] = ri.TectMovement;
            
            dt.Rows.Add(r);

            try
            {
                int rowsModified = daRuns.Update(ds.Tables["Runs"]);
                MessageBox.Show(rowsModified + " runs added: Run "+runID.ToString());

                if (rowsModified == 0)
                    return 0;
                else
                    return runID;
            }
            catch (OleDbException ee)
            {
                MessageBox.Show(ee.Message);
            }

            return 0;
        }

        private int checkRunDuplicate(RunInfo ri)
        {
            DataTable dtRuns = ds.Tables["Runs"];
            DataRow dr;
            int nRuns = dtRuns.Rows.Count;
            int i;

            for (i = 1; i < nRuns; i++)
            {
                dr = dtRuns.Rows[i];
                if (ri.compareToDataRow(dr))
                    break;
            }

            if (i == nRuns)
                return 0;
            else
                return i;
        }

        private int checkOptionDuplicate(int runID, OptionInfo oi)
        {
            string s = "RunID = " + runID.ToString();
            DataRow[] drs = ds.Tables["Options"].Select(s);
            int nOptions = drs.Length;
            int i;

            for (i = 0; i < nOptions; i++)
            {
                if (oi.compareToDataRow(drs[i]))
                    break;
            }

            if (i == nOptions)
                return 0;
            else
                return i + 1;
        }


        //----------SAVING DATA-------------------
        public void initProfileToDB(int runID, int optionID, double[,] data)
        {
            //Delete all data that's their already
            cmdDelete.CommandText = "DELETE * FROM Relief WHERE RunID = " + runID.ToString() +" AND OptionID = "+optionID.ToString();
            conn.Open();
            int pointsDeleted = cmdDelete.ExecuteNonQuery();
            MessageBox.Show("Deleted " + pointsDeleted + " previous records for this run");
            conn.Close();

            //Insert new data
            daRelief.SelectCommand.Parameters[0].Value = runID;
            daRelief.SelectCommand.Parameters[1].Value = optionID;
            DataTable dtRelief = ds.Tables["Relief"];
            dtRelief.Clear();   //make sure our Relief table is empty

            DataRow r;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                r = dtRelief.NewRow();
                r[0] = runID;
                r[1] = optionID;
                r[2] = data[i, 0];
                r[3] = data[i, 1];
                dtRelief.Rows.Add(r);
            }

            try
            {
                int pointsModified = daRelief.Update(dtRelief);
                MessageBox.Show(pointsModified + " points modified");
            }
            catch (DBConcurrencyException ex)
            {
                if (dtRelief.HasErrors)
                    MessageBox.Show(ex.Message);
                foreach (DataRow row in dtRelief.GetErrors())
                    MessageBox.Show("Mistake in row number: " + row["RunID", DataRowVersion.Original]);
            }
        }

        public void addProfileToDB(int runID, int optionID, double [,] data, int col)
        {
            //the dtRelief table should already contain necessary data 
            //as dtRelief is not cleared at the end of initialiseProfileToDB
 
            DataTable dtRelief = ds.Tables["Relief"];
            if (runID != (int)dtRelief.Rows[0]["RunID"] || optionID != (int)dtRelief.Rows[0]["OptionID"] || data.GetLength(0) != dtRelief.Rows.Count)
            {
                MessageBox.Show("Unable to add profile as current Run was not initialised in DB");
                return;
            }

            if (col > dtRelief.Columns.Count)
            {
                MessageBox.Show("Unable to add profile as number of profiles exceeds DB maximum");
                return;
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                dtRelief.Rows[i][col] = data[i, 1];
            }

            try
            {
                int pointsModified = daRelief.Update(dtRelief);
                MessageBox.Show("Added " + pointsModified + " data");
            }
            catch (DBConcurrencyException ex)
            {
                if (dtRelief.HasErrors)
                    MessageBox.Show(ex.Message);
                foreach (DataRow row in dtRelief.GetErrors())
                    MessageBox.Show("Mistake in row number: " + row["RunID", DataRowVersion.Original]);
            }
        }
    }
}
