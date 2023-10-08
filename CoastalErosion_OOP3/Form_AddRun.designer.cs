namespace CoastalErosion
{
    partial class Form_Add
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
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.lbl_main = new System.Windows.Forms.Label();
            this.tb_tr = new System.Windows.Forms.TextBox();
            this.tb_initSlope = new System.Windows.Forms.TextBox();
            this.tb_sfmin = new System.Windows.Forms.TextBox();
            this.tb_k = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tb_s = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Q = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_runID = new System.Windows.Forms.Label();
            this.nud_WaveSet = new System.Windows.Forms.NumericUpDown();
            this.nud_Sea = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_tectMovement = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_M = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.nud_ErMode = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_accuracy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_tideID = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.combo_save = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaveSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tideID)).BeginInit();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "Min surf force  Sfmin";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(32, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Bottom roughness  k";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Initial slope (deg)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tidal range (m)";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(35, 307);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(153, 35);
            this.bt_add.TabIndex = 40;
            this.bt_add.Text = "Add";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(360, 307);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(153, 35);
            this.bt_cancel.TabIndex = 41;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // lbl_main
            // 
            this.lbl_main.AutoSize = true;
            this.lbl_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_main.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_main.Location = new System.Drawing.Point(96, 19);
            this.lbl_main.Name = "lbl_main";
            this.lbl_main.Size = new System.Drawing.Size(319, 20);
            this.lbl_main.TabIndex = 42;
            this.lbl_main.Text = "Please specify the parameters:    Run  ";
            // 
            // tb_tr
            // 
            this.tb_tr.Location = new System.Drawing.Point(124, 59);
            this.tb_tr.Name = "tb_tr";
            this.tb_tr.Size = new System.Drawing.Size(100, 20);
            this.tb_tr.TabIndex = 43;
            // 
            // tb_initSlope
            // 
            this.tb_initSlope.Location = new System.Drawing.Point(124, 84);
            this.tb_initSlope.Name = "tb_initSlope";
            this.tb_initSlope.Size = new System.Drawing.Size(100, 20);
            this.tb_initSlope.TabIndex = 44;
            // 
            // tb_sfmin
            // 
            this.tb_sfmin.Location = new System.Drawing.Point(151, 145);
            this.tb_sfmin.Name = "tb_sfmin";
            this.tb_sfmin.Size = new System.Drawing.Size(100, 20);
            this.tb_sfmin.TabIndex = 46;
            // 
            // tb_k
            // 
            this.tb_k.Location = new System.Drawing.Point(151, 120);
            this.tb_k.Name = "tb_k";
            this.tb_k.Size = new System.Drawing.Size(100, 20);
            this.tb_k.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(32, 210);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 48;
            this.label25.Text = "Depth decay const  s";
            // 
            // tb_s
            // 
            this.tb_s.Location = new System.Drawing.Point(173, 207);
            this.tb_s.Name = "tb_s";
            this.tb_s.Size = new System.Drawing.Size(78, 20);
            this.tb_s.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Accumulation of debris Q";
            // 
            // tb_Q
            // 
            this.tb_Q.Location = new System.Drawing.Point(173, 179);
            this.tb_Q.Name = "tb_Q";
            this.tb_Q.Size = new System.Drawing.Size(78, 20);
            this.tb_Q.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Wave Set: ";
            // 
            // lbl_runID
            // 
            this.lbl_runID.AutoSize = true;
            this.lbl_runID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runID.Location = new System.Drawing.Point(422, 19);
            this.lbl_runID.Name = "lbl_runID";
            this.lbl_runID.Size = new System.Drawing.Size(19, 20);
            this.lbl_runID.TabIndex = 56;
            this.lbl_runID.Text = "0";
            // 
            // nud_WaveSet
            // 
            this.nud_WaveSet.Location = new System.Drawing.Point(433, 56);
            this.nud_WaveSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_WaveSet.Name = "nud_WaveSet";
            this.nud_WaveSet.Size = new System.Drawing.Size(73, 20);
            this.nud_WaveSet.TabIndex = 57;
            this.nud_WaveSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_Sea
            // 
            this.nud_Sea.Location = new System.Drawing.Point(433, 79);
            this.nud_Sea.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Sea.Name = "nud_Sea";
            this.nud_Sea.Size = new System.Drawing.Size(73, 20);
            this.nud_Sea.TabIndex = 59;
            this.nud_Sea.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Sea";
            // 
            // tb_tectMovement
            // 
            this.tb_tectMovement.Location = new System.Drawing.Point(433, 105);
            this.tb_tectMovement.Name = "tb_tectMovement";
            this.tb_tectMovement.Size = new System.Drawing.Size(73, 20);
            this.tb_tectMovement.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Tectonic Movement";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(374, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Options:";
            // 
            // tb_M
            // 
            this.tb_M.Location = new System.Drawing.Point(173, 236);
            this.tb_M.Name = "tb_M";
            this.tb_M.Size = new System.Drawing.Size(78, 20);
            this.tb_M.TabIndex = 64;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(32, 241);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 63;
            this.label23.Text = "Force-to-meters coef  M";
            // 
            // nud_ErMode
            // 
            this.nud_ErMode.Location = new System.Drawing.Point(433, 168);
            this.nud_ErMode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ErMode.Name = "nud_ErMode";
            this.nud_ErMode.Size = new System.Drawing.Size(73, 20);
            this.nud_ErMode.TabIndex = 66;
            this.nud_ErMode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Erosion Mode";
            // 
            // tb_accuracy
            // 
            this.tb_accuracy.Location = new System.Drawing.Point(433, 218);
            this.tb_accuracy.Name = "tb_accuracy";
            this.tb_accuracy.Size = new System.Drawing.Size(73, 20);
            this.tb_accuracy.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Accuracy";
            // 
            // nud_tideID
            // 
            this.nud_tideID.Location = new System.Drawing.Point(433, 193);
            this.nud_tideID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_tideID.Name = "nud_tideID";
            this.nud_tideID.Size = new System.Drawing.Size(73, 20);
            this.nud_tideID.TabIndex = 70;
            this.nud_tideID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "Tide ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(326, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Save:";
            // 
            // combo_save
            // 
            this.combo_save.Items.AddRange(new object[] {
            "ALL",
            "BEFORE_TOP",
            "AFTER_TOP",
            "BEFORE_BOTTOM",
            "AFTER_BOTTOM",
            "EVERY500YRS",
            "EVERY1000YRS"});
            this.combo_save.Location = new System.Drawing.Point(388, 245);
            this.combo_save.Name = "combo_save";
            this.combo_save.Size = new System.Drawing.Size(118, 21);
            this.combo_save.TabIndex = 72;
            // 
            // Form_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 367);
            this.Controls.Add(this.combo_save);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nud_tideID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_accuracy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nud_ErMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_M);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_tectMovement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_Sea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_WaveSet);
            this.Controls.Add(this.lbl_runID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Q);
            this.Controls.Add(this.tb_s);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tb_sfmin);
            this.Controls.Add(this.tb_k);
            this.Controls.Add(this.tb_initSlope);
            this.Controls.Add(this.tb_tr);
            this.Controls.Add(this.lbl_main);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Name = "Form_Add";
            this.Text = "Child1";
            this.Load += new System.EventHandler(this.Child1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaveSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tideID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label lbl_main;
        private System.Windows.Forms.TextBox tb_tr;
        private System.Windows.Forms.TextBox tb_initSlope;
        private System.Windows.Forms.TextBox tb_sfmin;
        private System.Windows.Forms.TextBox tb_k;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tb_s;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Q;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_runID;
        private System.Windows.Forms.NumericUpDown nud_WaveSet;
        private System.Windows.Forms.NumericUpDown nud_Sea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_tectMovement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_M;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown nud_ErMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_accuracy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_tideID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combo_save;
    }
}