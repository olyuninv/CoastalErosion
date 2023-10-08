namespace CoastalErosion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_picture = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_iterations = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_100m = new System.Windows.Forms.Label();
            this.lbl_10m = new System.Windows.Forms.Label();
            this.bt_show = new System.Windows.Forms.Button();
            this.tb_tr = new System.Windows.Forms.TextBox();
            this.tb_initSlope = new System.Windows.Forms.TextBox();
            this.tb_sfmin = new System.Windows.Forms.TextBox();
            this.tb_k = new System.Windows.Forms.TextBox();
            this.tb_M = new System.Windows.Forms.TextBox();
            this.tb_s = new System.Windows.Forms.TextBox();
            this.tb_Q = new System.Windows.Forms.TextBox();
            this.tb_H0 = new System.Windows.Forms.TextBox();
            this.tb_H1 = new System.Windows.Forms.TextBox();
            this.tb_H2 = new System.Windows.Forms.TextBox();
            this.tb_H3 = new System.Windows.Forms.TextBox();
            this.tb_H4 = new System.Windows.Forms.TextBox();
            this.tb_period4 = new System.Windows.Forms.TextBox();
            this.tb_period3 = new System.Windows.Forms.TextBox();
            this.tb_period2 = new System.Windows.Forms.TextBox();
            this.tb_period1 = new System.Windows.Forms.TextBox();
            this.tb_period0 = new System.Windows.Forms.TextBox();
            this.tb_freq4 = new System.Windows.Forms.TextBox();
            this.tb_freq3 = new System.Windows.Forms.TextBox();
            this.tb_freq2 = new System.Windows.Forms.TextBox();
            this.tb_freq1 = new System.Windows.Forms.TextBox();
            this.tb_freq0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_anyWave = new System.Windows.Forms.CheckBox();
            this.nud_waveSetID = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_anySea = new System.Windows.Forms.CheckBox();
            this.tb_tectMove = new System.Windows.Forms.TextBox();
            this.nud_SeaID = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_fluctPeriod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_fluctRange = new System.Windows.Forms.TextBox();
            this.lbl_seaName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_play = new System.Windows.Forms.Button();
            this.cb_Save = new System.Windows.Forms.CheckBox();
            this.mnu_Main = new System.Windows.Forms.MenuStrip();
            this.mnu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ErMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ModeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ModeSPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ModePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ModeLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Accuracy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc1TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc2TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc5TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc10TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc20TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc50TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Acc100TideInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_TidalRange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_tideName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_chooseTide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveBTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveATop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveBBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveABottom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveEvery500 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SaveEvery1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DrawColor = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_pause = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.cb_noGraph = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_flDuration = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_picture)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_waveSetID)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeaID)).BeginInit();
            this.mnu_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_picture
            // 
            this.pb_picture.BackColor = System.Drawing.SystemColors.Window;
            this.pb_picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_picture.Location = new System.Drawing.Point(15, 186);
            this.pb_picture.Name = "pb_picture";
            this.pb_picture.Size = new System.Drawing.Size(1003, 396);
            this.pb_picture.TabIndex = 0;
            this.pb_picture.TabStop = false;
            this.pb_picture.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_picture_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_iterations
            // 
            this.lbl_iterations.AutoSize = true;
            this.lbl_iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iterations.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_iterations.Location = new System.Drawing.Point(122, 223);
            this.lbl_iterations.Name = "lbl_iterations";
            this.lbl_iterations.Size = new System.Drawing.Size(16, 16);
            this.lbl_iterations.TabIndex = 2;
            this.lbl_iterations.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tidal range (m)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wave set:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Height  (m)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Period (sec)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Frequency";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Initial slope (degrees)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Bottom roughness  k";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "Min surf force  Sfmin";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 130);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 32;
            this.label23.Text = "Force-to-meters coef  M";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 84);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 34;
            this.label25.Text = "Depth decay const  s";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(75, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 36;
            this.label17.Text = "Platform/ Cliff";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Accumulation of debris Q";
            // 
            // lbl_100m
            // 
            this.lbl_100m.AutoSize = true;
            this.lbl_100m.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_100m.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_100m.Location = new System.Drawing.Point(721, 542);
            this.lbl_100m.Name = "lbl_100m";
            this.lbl_100m.Size = new System.Drawing.Size(16, 16);
            this.lbl_100m.TabIndex = 45;
            this.lbl_100m.Text = "0";
            // 
            // lbl_10m
            // 
            this.lbl_10m.AutoSize = true;
            this.lbl_10m.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_10m.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_10m.Location = new System.Drawing.Point(748, 516);
            this.lbl_10m.Name = "lbl_10m";
            this.lbl_10m.Size = new System.Drawing.Size(16, 16);
            this.lbl_10m.TabIndex = 46;
            this.lbl_10m.Text = "0";
            // 
            // bt_show
            // 
            this.bt_show.Location = new System.Drawing.Point(22, 143);
            this.bt_show.Name = "bt_show";
            this.bt_show.Size = new System.Drawing.Size(158, 36);
            this.bt_show.TabIndex = 47;
            this.bt_show.Text = "Show   result";
            this.bt_show.UseVisualStyleBackColor = true;
            this.bt_show.Click += new System.EventHandler(this.bt_show_Click);
            // 
            // tb_tr
            // 
            this.tb_tr.Location = new System.Drawing.Point(119, 24);
            this.tb_tr.Name = "tb_tr";
            this.tb_tr.Size = new System.Drawing.Size(51, 20);
            this.tb_tr.TabIndex = 49;
            this.tb_tr.Validating += new System.ComponentModel.CancelEventHandler(this.tb_tr_Validating);
            // 
            // tb_initSlope
            // 
            this.tb_initSlope.Location = new System.Drawing.Point(119, 3);
            this.tb_initSlope.Name = "tb_initSlope";
            this.tb_initSlope.Size = new System.Drawing.Size(51, 20);
            this.tb_initSlope.TabIndex = 50;
            this.tb_initSlope.Validating += new System.ComponentModel.CancelEventHandler(this.tb_initSlope_Validating);
            // 
            // tb_sfmin
            // 
            this.tb_sfmin.Location = new System.Drawing.Point(152, 59);
            this.tb_sfmin.Name = "tb_sfmin";
            this.tb_sfmin.Size = new System.Drawing.Size(51, 20);
            this.tb_sfmin.TabIndex = 52;
            // 
            // tb_k
            // 
            this.tb_k.Location = new System.Drawing.Point(152, 37);
            this.tb_k.Name = "tb_k";
            this.tb_k.Size = new System.Drawing.Size(51, 20);
            this.tb_k.TabIndex = 51;
            // 
            // tb_M
            // 
            this.tb_M.Location = new System.Drawing.Point(152, 127);
            this.tb_M.Name = "tb_M";
            this.tb_M.Size = new System.Drawing.Size(76, 20);
            this.tb_M.TabIndex = 53;
            // 
            // tb_s
            // 
            this.tb_s.Location = new System.Drawing.Point(152, 81);
            this.tb_s.Name = "tb_s";
            this.tb_s.Size = new System.Drawing.Size(51, 20);
            this.tb_s.TabIndex = 54;
            // 
            // tb_Q
            // 
            this.tb_Q.Location = new System.Drawing.Point(152, 104);
            this.tb_Q.Name = "tb_Q";
            this.tb_Q.Size = new System.Drawing.Size(51, 20);
            this.tb_Q.TabIndex = 55;
            // 
            // tb_H0
            // 
            this.tb_H0.Location = new System.Drawing.Point(83, 64);
            this.tb_H0.Name = "tb_H0";
            this.tb_H0.Size = new System.Drawing.Size(40, 20);
            this.tb_H0.TabIndex = 57;
            // 
            // tb_H1
            // 
            this.tb_H1.Location = new System.Drawing.Point(129, 64);
            this.tb_H1.Name = "tb_H1";
            this.tb_H1.Size = new System.Drawing.Size(40, 20);
            this.tb_H1.TabIndex = 58;
            // 
            // tb_H2
            // 
            this.tb_H2.Location = new System.Drawing.Point(175, 64);
            this.tb_H2.Name = "tb_H2";
            this.tb_H2.Size = new System.Drawing.Size(40, 20);
            this.tb_H2.TabIndex = 59;
            // 
            // tb_H3
            // 
            this.tb_H3.Location = new System.Drawing.Point(221, 64);
            this.tb_H3.Name = "tb_H3";
            this.tb_H3.Size = new System.Drawing.Size(40, 20);
            this.tb_H3.TabIndex = 60;
            // 
            // tb_H4
            // 
            this.tb_H4.Location = new System.Drawing.Point(267, 64);
            this.tb_H4.Name = "tb_H4";
            this.tb_H4.Size = new System.Drawing.Size(40, 20);
            this.tb_H4.TabIndex = 61;
            // 
            // tb_period4
            // 
            this.tb_period4.Location = new System.Drawing.Point(267, 91);
            this.tb_period4.Name = "tb_period4";
            this.tb_period4.Size = new System.Drawing.Size(40, 20);
            this.tb_period4.TabIndex = 66;
            // 
            // tb_period3
            // 
            this.tb_period3.Location = new System.Drawing.Point(221, 91);
            this.tb_period3.Name = "tb_period3";
            this.tb_period3.Size = new System.Drawing.Size(40, 20);
            this.tb_period3.TabIndex = 65;
            // 
            // tb_period2
            // 
            this.tb_period2.Location = new System.Drawing.Point(175, 91);
            this.tb_period2.Name = "tb_period2";
            this.tb_period2.Size = new System.Drawing.Size(40, 20);
            this.tb_period2.TabIndex = 64;
            // 
            // tb_period1
            // 
            this.tb_period1.Location = new System.Drawing.Point(129, 91);
            this.tb_period1.Name = "tb_period1";
            this.tb_period1.Size = new System.Drawing.Size(40, 20);
            this.tb_period1.TabIndex = 63;
            // 
            // tb_period0
            // 
            this.tb_period0.Location = new System.Drawing.Point(83, 91);
            this.tb_period0.Name = "tb_period0";
            this.tb_period0.Size = new System.Drawing.Size(40, 20);
            this.tb_period0.TabIndex = 62;
            // 
            // tb_freq4
            // 
            this.tb_freq4.Location = new System.Drawing.Point(267, 117);
            this.tb_freq4.Name = "tb_freq4";
            this.tb_freq4.Size = new System.Drawing.Size(40, 20);
            this.tb_freq4.TabIndex = 71;
            // 
            // tb_freq3
            // 
            this.tb_freq3.Location = new System.Drawing.Point(221, 117);
            this.tb_freq3.Name = "tb_freq3";
            this.tb_freq3.Size = new System.Drawing.Size(40, 20);
            this.tb_freq3.TabIndex = 70;
            // 
            // tb_freq2
            // 
            this.tb_freq2.Location = new System.Drawing.Point(175, 117);
            this.tb_freq2.Name = "tb_freq2";
            this.tb_freq2.Size = new System.Drawing.Size(40, 20);
            this.tb_freq2.TabIndex = 69;
            // 
            // tb_freq1
            // 
            this.tb_freq1.Location = new System.Drawing.Point(129, 117);
            this.tb_freq1.Name = "tb_freq1";
            this.tb_freq1.Size = new System.Drawing.Size(40, 20);
            this.tb_freq1.TabIndex = 68;
            // 
            // tb_freq0
            // 
            this.tb_freq0.Location = new System.Drawing.Point(83, 117);
            this.tb_freq0.Name = "tb_freq0";
            this.tb_freq0.Size = new System.Drawing.Size(40, 20);
            this.tb_freq0.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(17, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 72;
            this.label6.Text = "Play mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(148, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 73;
            this.label8.Text = "Sea";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_anyWave);
            this.panel1.Controls.Add(this.nud_waveSetID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tb_period4);
            this.panel1.Controls.Add(this.tb_freq4);
            this.panel1.Controls.Add(this.tb_period3);
            this.panel1.Controls.Add(this.tb_freq3);
            this.panel1.Controls.Add(this.tb_period2);
            this.panel1.Controls.Add(this.tb_freq2);
            this.panel1.Controls.Add(this.tb_period1);
            this.panel1.Controls.Add(this.tb_freq1);
            this.panel1.Controls.Add(this.tb_period0);
            this.panel1.Controls.Add(this.tb_freq0);
            this.panel1.Controls.Add(this.tb_H4);
            this.panel1.Controls.Add(this.tb_H3);
            this.panel1.Controls.Add(this.tb_H2);
            this.panel1.Controls.Add(this.tb_H1);
            this.panel1.Controls.Add(this.tb_H0);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(694, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 154);
            this.panel1.TabIndex = 74;
            // 
            // cb_anyWave
            // 
            this.cb_anyWave.AutoSize = true;
            this.cb_anyWave.Location = new System.Drawing.Point(235, 39);
            this.cb_anyWave.Name = "cb_anyWave";
            this.cb_anyWave.Size = new System.Drawing.Size(43, 17);
            this.cb_anyWave.TabIndex = 75;
            this.cb_anyWave.Text = "any";
            this.cb_anyWave.UseVisualStyleBackColor = true;
            this.cb_anyWave.CheckedChanged += new System.EventHandler(this.cb_anyWave_CheckedChanged);
            // 
            // nud_waveSetID
            // 
            this.nud_waveSetID.Location = new System.Drawing.Point(181, 37);
            this.nud_waveSetID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_waveSetID.Name = "nud_waveSetID";
            this.nud_waveSetID.Size = new System.Drawing.Size(42, 20);
            this.nud_waveSetID.TabIndex = 74;
            this.nud_waveSetID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_waveSetID.ValueChanged += new System.EventHandler(this.nud_waveSetID_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Olive;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tb_Q);
            this.panel2.Controls.Add(this.tb_s);
            this.panel2.Controls.Add(this.tb_M);
            this.panel2.Controls.Add(this.tb_sfmin);
            this.panel2.Controls.Add(this.tb_k);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Location = new System.Drawing.Point(197, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 153);
            this.panel2.TabIndex = 75;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.tb_flDuration);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cb_anySea);
            this.panel3.Controls.Add(this.tb_tectMove);
            this.panel3.Controls.Add(this.nud_SeaID);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.tb_fluctPeriod);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tb_fluctRange);
            this.panel3.Controls.Add(this.lbl_seaName);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.tb_tr);
            this.panel3.Controls.Add(this.tb_initSlope);
            this.panel3.Location = new System.Drawing.Point(489, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 154);
            this.panel3.TabIndex = 76;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 77;
            this.label13.Text = "Tectonic movement";
            // 
            // cb_anySea
            // 
            this.cb_anySea.AutoSize = true;
            this.cb_anySea.Location = new System.Drawing.Point(135, 112);
            this.cb_anySea.Name = "cb_anySea";
            this.cb_anySea.Size = new System.Drawing.Size(43, 17);
            this.cb_anySea.TabIndex = 76;
            this.cb_anySea.Text = "any";
            this.cb_anySea.UseVisualStyleBackColor = true;
            this.cb_anySea.CheckedChanged += new System.EventHandler(this.cb_anySea_CheckedChanged);
            // 
            // tb_tectMove
            // 
            this.tb_tectMove.Location = new System.Drawing.Point(119, 45);
            this.tb_tectMove.Name = "tb_tectMove";
            this.tb_tectMove.Size = new System.Drawing.Size(51, 20);
            this.tb_tectMove.TabIndex = 78;
            this.tb_tectMove.Validating += new System.ComponentModel.CancelEventHandler(this.tb_tectMove_Validating);
            // 
            // nud_SeaID
            // 
            this.nud_SeaID.Location = new System.Drawing.Point(44, 66);
            this.nud_SeaID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SeaID.Name = "nud_SeaID";
            this.nud_SeaID.Size = new System.Drawing.Size(44, 20);
            this.nud_SeaID.TabIndex = 59;
            this.nud_SeaID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SeaID.ValueChanged += new System.EventHandler(this.nud_SeaID_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Fluct period";
            // 
            // tb_fluctPeriod
            // 
            this.tb_fluctPeriod.Location = new System.Drawing.Point(76, 110);
            this.tb_fluctPeriod.Name = "tb_fluctPeriod";
            this.tb_fluctPeriod.Size = new System.Drawing.Size(53, 20);
            this.tb_fluctPeriod.TabIndex = 57;
            this.tb_fluctPeriod.Validating += new System.ComponentModel.CancelEventHandler(this.tb_fluctPeriod_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Fluct range";
            // 
            // tb_fluctRange
            // 
            this.tb_fluctRange.Location = new System.Drawing.Point(76, 89);
            this.tb_fluctRange.Name = "tb_fluctRange";
            this.tb_fluctRange.Size = new System.Drawing.Size(53, 20);
            this.tb_fluctRange.TabIndex = 55;
            this.tb_fluctRange.Validating += new System.ComponentModel.CancelEventHandler(this.tb_fluctRange_Validating);
            // 
            // lbl_seaName
            // 
            this.lbl_seaName.AutoSize = true;
            this.lbl_seaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seaName.Location = new System.Drawing.Point(94, 69);
            this.lbl_seaName.Name = "lbl_seaName";
            this.lbl_seaName.Size = new System.Drawing.Size(61, 13);
            this.lbl_seaName.TabIndex = 53;
            this.lbl_seaName.Text = "sea name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Sea:";
            // 
            // bt_play
            // 
            this.bt_play.Location = new System.Drawing.Point(22, 65);
            this.bt_play.Name = "bt_play";
            this.bt_play.Size = new System.Drawing.Size(63, 36);
            this.bt_play.TabIndex = 77;
            this.bt_play.Text = "Play";
            this.bt_play.UseVisualStyleBackColor = true;
            this.bt_play.Click += new System.EventHandler(this.bt_play_Click);
            // 
            // cb_Save
            // 
            this.cb_Save.AutoSize = true;
            this.cb_Save.Location = new System.Drawing.Point(26, 114);
            this.cb_Save.Name = "cb_Save";
            this.cb_Save.Size = new System.Drawing.Size(79, 17);
            this.cb_Save.TabIndex = 78;
            this.cb_Save.Text = "Save result";
            this.cb_Save.UseVisualStyleBackColor = true;
            // 
            // mnu_Main
            // 
            this.mnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_File,
            this.mnu_Options});
            this.mnu_Main.Location = new System.Drawing.Point(0, 0);
            this.mnu_Main.Name = "mnu_Main";
            this.mnu_Main.Size = new System.Drawing.Size(1030, 24);
            this.mnu_Main.TabIndex = 80;
            this.mnu_Main.Text = "menuStrip1";
            // 
            // mnu_File
            // 
            this.mnu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Play,
            this.mnu_Pause,
            this.mnu_Stop});
            this.mnu_File.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.mnu_File.Name = "mnu_File";
            this.mnu_File.Size = new System.Drawing.Size(42, 20);
            this.mnu_File.Text = "File";
            // 
            // mnu_Play
            // 
            this.mnu_Play.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnu_Play.MergeIndex = 0;
            this.mnu_Play.Name = "mnu_Play";
            this.mnu_Play.Size = new System.Drawing.Size(165, 22);
            this.mnu_Play.Text = "Play";
            this.mnu_Play.Click += new System.EventHandler(this.mnu_Play_Click);
            // 
            // mnu_Pause
            // 
            this.mnu_Pause.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnu_Pause.MergeIndex = 1;
            this.mnu_Pause.Name = "mnu_Pause";
            this.mnu_Pause.Size = new System.Drawing.Size(165, 22);
            this.mnu_Pause.Text = "Pause";
            this.mnu_Pause.Click += new System.EventHandler(this.mnu_Pause_Click);
            // 
            // mnu_Stop
            // 
            this.mnu_Stop.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnu_Stop.MergeIndex = 2;
            this.mnu_Stop.Name = "mnu_Stop";
            this.mnu_Stop.Size = new System.Drawing.Size(165, 22);
            this.mnu_Stop.Text = "Stop animation";
            this.mnu_Stop.Click += new System.EventHandler(this.mnu_Stop_Click);
            // 
            // mnu_Options
            // 
            this.mnu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_ErMode,
            this.mnu_Accuracy,
            this.mnu_TidalRange,
            this.mnu_Save,
            this.mnu_DrawColor});
            this.mnu_Options.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnu_Options.MergeIndex = 2;
            this.mnu_Options.Name = "mnu_Options";
            this.mnu_Options.Size = new System.Drawing.Size(66, 20);
            this.mnu_Options.Text = "Options";
            // 
            // mnu_ErMode
            // 
            this.mnu_ErMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_ModeStrip,
            this.mnu_ModeSPoint,
            this.mnu_ModePoint,
            this.mnu_ModeLine});
            this.mnu_ErMode.Name = "mnu_ErMode";
            this.mnu_ErMode.Size = new System.Drawing.Size(157, 22);
            this.mnu_ErMode.Text = "ErosionMode";
            // 
            // mnu_ModeStrip
            // 
            this.mnu_ModeStrip.Name = "mnu_ModeStrip";
            this.mnu_ModeStrip.Size = new System.Drawing.Size(170, 22);
            this.mnu_ModeStrip.Text = "In strips";
            this.mnu_ModeStrip.Click += new System.EventHandler(this.mnu_ModeInStrips_Click);
            // 
            // mnu_ModeSPoint
            // 
            this.mnu_ModeSPoint.Name = "mnu_ModeSPoint";
            this.mnu_ModeSPoint.Size = new System.Drawing.Size(170, 22);
            this.mnu_ModeSPoint.Text = "Strip-and-points";
            this.mnu_ModeSPoint.Click += new System.EventHandler(this.mnu_ModeSPoint_Click);
            // 
            // mnu_ModePoint
            // 
            this.mnu_ModePoint.Name = "mnu_ModePoint";
            this.mnu_ModePoint.Size = new System.Drawing.Size(170, 22);
            this.mnu_ModePoint.Text = "Point-by-point";
            this.mnu_ModePoint.Click += new System.EventHandler(this.mnu_ModePoints_Click);
            // 
            // mnu_ModeLine
            // 
            this.mnu_ModeLine.Name = "mnu_ModeLine";
            this.mnu_ModeLine.Size = new System.Drawing.Size(170, 22);
            this.mnu_ModeLine.Text = "Lines";
            this.mnu_ModeLine.Click += new System.EventHandler(this.mnu_ModeLine_Click);
            // 
            // mnu_Accuracy
            // 
            this.mnu_Accuracy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Acc1TideInt,
            this.mnu_Acc2TideInt,
            this.mnu_Acc5TideInt,
            this.mnu_Acc10TideInt,
            this.mnu_Acc20TideInt,
            this.mnu_Acc50TideInt,
            this.mnu_Acc100TideInt});
            this.mnu_Accuracy.Name = "mnu_Accuracy";
            this.mnu_Accuracy.Size = new System.Drawing.Size(157, 22);
            this.mnu_Accuracy.Text = "Accuracy";
            // 
            // mnu_Acc1TideInt
            // 
            this.mnu_Acc1TideInt.Name = "mnu_Acc1TideInt";
            this.mnu_Acc1TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc1TideInt.Text = "1/ 100 Tide Interval";
            this.mnu_Acc1TideInt.Click += new System.EventHandler(this.mnu_Acc1TideInt_Click);
            // 
            // mnu_Acc2TideInt
            // 
            this.mnu_Acc2TideInt.Name = "mnu_Acc2TideInt";
            this.mnu_Acc2TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc2TideInt.Text = "1/ 50 Tide Interval";
            this.mnu_Acc2TideInt.Click += new System.EventHandler(this.mnu_Acc2TideInt_Click);
            // 
            // mnu_Acc5TideInt
            // 
            this.mnu_Acc5TideInt.Name = "mnu_Acc5TideInt";
            this.mnu_Acc5TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc5TideInt.Text = "1/ 20 Tide Interval";
            this.mnu_Acc5TideInt.Click += new System.EventHandler(this.mnu_Acc5TideInt_Click);
            // 
            // mnu_Acc10TideInt
            // 
            this.mnu_Acc10TideInt.Name = "mnu_Acc10TideInt";
            this.mnu_Acc10TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc10TideInt.Text = "1/ 10 Tide Interval";
            this.mnu_Acc10TideInt.Click += new System.EventHandler(this.mnu_Acc10TideInt_Click);
            // 
            // mnu_Acc20TideInt
            // 
            this.mnu_Acc20TideInt.Name = "mnu_Acc20TideInt";
            this.mnu_Acc20TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc20TideInt.Text = "1/ 5 Tide Interval";
            this.mnu_Acc20TideInt.Click += new System.EventHandler(this.mnu_Acc20TideInt_Click);
            // 
            // mnu_Acc50TideInt
            // 
            this.mnu_Acc50TideInt.Name = "mnu_Acc50TideInt";
            this.mnu_Acc50TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc50TideInt.Text = "1/ 2 Tide Interval";
            this.mnu_Acc50TideInt.Click += new System.EventHandler(this.mnu_Acc50TideInt_Click);
            // 
            // mnu_Acc100TideInt
            // 
            this.mnu_Acc100TideInt.Name = "mnu_Acc100TideInt";
            this.mnu_Acc100TideInt.Size = new System.Drawing.Size(188, 22);
            this.mnu_Acc100TideInt.Text = "Tide Interval";
            this.mnu_Acc100TideInt.Click += new System.EventHandler(this.mnu_Acc100TideInt_Click);
            // 
            // mnu_TidalRange
            // 
            this.mnu_TidalRange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_tideName,
            this.mnu_chooseTide});
            this.mnu_TidalRange.Name = "mnu_TidalRange";
            this.mnu_TidalRange.Size = new System.Drawing.Size(157, 22);
            this.mnu_TidalRange.Text = "TidalRange";
            // 
            // mnu_tideName
            // 
            this.mnu_tideName.Name = "mnu_tideName";
            this.mnu_tideName.Size = new System.Drawing.Size(123, 22);
            this.mnu_tideName.Text = "Tide";
            // 
            // mnu_chooseTide
            // 
            this.mnu_chooseTide.Name = "mnu_chooseTide";
            this.mnu_chooseTide.Size = new System.Drawing.Size(123, 22);
            this.mnu_chooseTide.Text = "Choose";
            this.mnu_chooseTide.Click += new System.EventHandler(this.mnu_chooseTide_Click);
            // 
            // mnu_Save
            // 
            this.mnu_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_SaveAll,
            this.mnu_SaveBTop,
            this.mnu_SaveATop,
            this.mnu_SaveBBottom,
            this.mnu_SaveABottom,
            this.mnu_SaveEvery500,
            this.mnu_SaveEvery1000});
            this.mnu_Save.Name = "mnu_Save";
            this.mnu_Save.Size = new System.Drawing.Size(157, 22);
            this.mnu_Save.Text = "Save";
            // 
            // mnu_SaveAll
            // 
            this.mnu_SaveAll.Name = "mnu_SaveAll";
            this.mnu_SaveAll.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveAll.Text = "All stages";
            this.mnu_SaveAll.Click += new System.EventHandler(this.mnu_SaveAll_Click);
            // 
            // mnu_SaveBTop
            // 
            this.mnu_SaveBTop.Name = "mnu_SaveBTop";
            this.mnu_SaveBTop.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveBTop.Text = "Before Top Stand";
            this.mnu_SaveBTop.Click += new System.EventHandler(this.mnu_SaveBTop_Click);
            // 
            // mnu_SaveATop
            // 
            this.mnu_SaveATop.Name = "mnu_SaveATop";
            this.mnu_SaveATop.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveATop.Text = "After Top Stand";
            this.mnu_SaveATop.Click += new System.EventHandler(this.mnu_SaveATop_Click);
            // 
            // mnu_SaveBBottom
            // 
            this.mnu_SaveBBottom.Name = "mnu_SaveBBottom";
            this.mnu_SaveBBottom.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveBBottom.Text = "Before Bottom Stand";
            this.mnu_SaveBBottom.Click += new System.EventHandler(this.mnu_SaveBBottom_Click);
            // 
            // mnu_SaveABottom
            // 
            this.mnu_SaveABottom.Name = "mnu_SaveABottom";
            this.mnu_SaveABottom.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveABottom.Text = "After Bottom Stand";
            this.mnu_SaveABottom.Click += new System.EventHandler(this.mnu_SaveABottom_Click);
            // 
            // mnu_SaveEvery500
            // 
            this.mnu_SaveEvery500.Name = "mnu_SaveEvery500";
            this.mnu_SaveEvery500.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveEvery500.Text = "Every 500 years";
            this.mnu_SaveEvery500.Click += new System.EventHandler(this.mnu_SaveEvery500_Click);
            // 
            // mnu_SaveEvery1000
            // 
            this.mnu_SaveEvery1000.Name = "mnu_SaveEvery1000";
            this.mnu_SaveEvery1000.Size = new System.Drawing.Size(199, 22);
            this.mnu_SaveEvery1000.Text = "Every 1000 years";
            this.mnu_SaveEvery1000.Click += new System.EventHandler(this.mnu_SaveEvery1000_Click);
            // 
            // mnu_DrawColor
            // 
            this.mnu_DrawColor.CheckOnClick = true;
            this.mnu_DrawColor.Name = "mnu_DrawColor";
            this.mnu_DrawColor.Size = new System.Drawing.Size(157, 22);
            this.mnu_DrawColor.Text = "Draw Color";
            this.mnu_DrawColor.CheckedChanged += new System.EventHandler(this.mnu_DrawInColor_CheckedChanged);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(119, 65);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(61, 36);
            this.bt_stop.TabIndex = 81;
            this.bt_stop.Text = "Stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_pause
            // 
            this.bt_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_pause.Location = new System.Drawing.Point(88, 65);
            this.bt_pause.Name = "bt_pause";
            this.bt_pause.Size = new System.Drawing.Size(28, 36);
            this.bt_pause.TabIndex = 82;
            this.bt_pause.Text = "||";
            this.bt_pause.UseVisualStyleBackColor = true;
            this.bt_pause.Click += new System.EventHandler(this.bt_pause_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // cb_noGraph
            // 
            this.cb_noGraph.AutoSize = true;
            this.cb_noGraph.Location = new System.Drawing.Point(110, 114);
            this.cb_noGraph.Name = "cb_noGraph";
            this.cb_noGraph.Size = new System.Drawing.Size(70, 17);
            this.cb_noGraph.TabIndex = 83;
            this.cb_noGraph.Text = "No graph";
            this.cb_noGraph.UseVisualStyleBackColor = true;
            this.cb_noGraph.CheckedChanged += new System.EventHandler(this.cb_noGraph_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 79;
            this.label14.Text = "Model time";
            // 
            // tb_flDuration
            // 
            this.tb_flDuration.Location = new System.Drawing.Point(76, 131);
            this.tb_flDuration.Name = "tb_flDuration";
            this.tb_flDuration.Size = new System.Drawing.Size(53, 20);
            this.tb_flDuration.TabIndex = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1030, 616);
            this.ControlBox = false;
            this.Controls.Add(this.cb_noGraph);
            this.Controls.Add(this.bt_pause);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.cb_Save);
            this.Controls.Add(this.bt_play);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bt_show);
            this.Controls.Add(this.lbl_10m);
            this.Controls.Add(this.lbl_100m);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_iterations);
            this.Controls.Add(this.pb_picture);
            this.Controls.Add(this.mnu_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mnu_Main;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coastal Erosion Model";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_picture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_waveSetID)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeaID)).EndInit();
            this.mnu_Main.ResumeLayout(false);
            this.mnu_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_picture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_iterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_100m;
        private System.Windows.Forms.Label lbl_10m;
        private System.Windows.Forms.Button bt_show;
        private System.Windows.Forms.TextBox tb_tr;
        private System.Windows.Forms.TextBox tb_initSlope;
        private System.Windows.Forms.TextBox tb_sfmin;
        private System.Windows.Forms.TextBox tb_k;
        private System.Windows.Forms.TextBox tb_M;
        private System.Windows.Forms.TextBox tb_s;
        private System.Windows.Forms.TextBox tb_Q;
        private System.Windows.Forms.TextBox tb_H0;
        private System.Windows.Forms.TextBox tb_H1;
        private System.Windows.Forms.TextBox tb_H2;
        private System.Windows.Forms.TextBox tb_H3;
        private System.Windows.Forms.TextBox tb_H4;
        private System.Windows.Forms.TextBox tb_period4;
        private System.Windows.Forms.TextBox tb_period3;
        private System.Windows.Forms.TextBox tb_period2;
        private System.Windows.Forms.TextBox tb_period1;
        private System.Windows.Forms.TextBox tb_period0;
        private System.Windows.Forms.TextBox tb_freq4;
        private System.Windows.Forms.TextBox tb_freq3;
        private System.Windows.Forms.TextBox tb_freq2;
        private System.Windows.Forms.TextBox tb_freq1;
        private System.Windows.Forms.TextBox tb_freq0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_fluctPeriod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_fluctRange;
        private System.Windows.Forms.Label lbl_seaName;
        private System.Windows.Forms.NumericUpDown nud_waveSetID;
        private System.Windows.Forms.NumericUpDown nud_SeaID;
        private System.Windows.Forms.Button bt_play;
        private System.Windows.Forms.CheckBox cb_Save;
        private System.Windows.Forms.MenuStrip mnu_Main;
        private System.Windows.Forms.ToolStripMenuItem mnu_File;
        private System.Windows.Forms.ToolStripMenuItem mnu_Play;
        private System.Windows.Forms.ToolStripMenuItem mnu_Pause;
        private System.Windows.Forms.ToolStripMenuItem mnu_Stop;
        private System.Windows.Forms.CheckBox cb_anyWave;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Button bt_pause;
        private System.Windows.Forms.ToolStripMenuItem mnu_Options;
        private System.Windows.Forms.ToolStripMenuItem mnu_ErMode;
        private System.Windows.Forms.ToolStripMenuItem mnu_ModeStrip;
        private System.Windows.Forms.ToolStripMenuItem mnu_ModePoint;
        private System.Windows.Forms.ToolStripMenuItem mnu_ModeLine;
        private System.Windows.Forms.ToolStripMenuItem mnu_ModeSPoint;
        private System.Windows.Forms.CheckBox cb_anySea;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_tectMove;
        private System.Windows.Forms.ToolStripMenuItem mnu_Accuracy;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc1TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc2TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc5TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc10TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc20TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc50TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_Acc100TideInt;
        private System.Windows.Forms.ToolStripMenuItem mnu_TidalRange;
        private System.Windows.Forms.ToolStripMenuItem mnu_tideName;
        private System.Windows.Forms.ToolStripMenuItem mnu_chooseTide;
        private System.Windows.Forms.ToolStripMenuItem mnu_Save;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveAll;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveBTop;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveATop;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveBBottom;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveABottom;
        private System.Windows.Forms.CheckBox cb_noGraph;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveEvery500;
        private System.Windows.Forms.ToolStripMenuItem mnu_SaveEvery1000;
        private System.Windows.Forms.ToolStripMenuItem mnu_DrawColor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_flDuration;
    }
}

