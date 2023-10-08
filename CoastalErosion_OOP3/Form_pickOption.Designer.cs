namespace CoastalErosion
{
    partial class Form_PickOption
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
            this.lbl_top = new System.Windows.Forms.Label();
            this.lv_main = new System.Windows.Forms.ListView();
            this.col_RunID = new System.Windows.Forms.ColumnHeader();
            this.col_Option = new System.Windows.Forms.ColumnHeader();
            this.col_initSlope = new System.Windows.Forms.ColumnHeader();
            this.col_tr = new System.Windows.Forms.ColumnHeader();
            this.col_waveSet = new System.Windows.Forms.ColumnHeader();
            this.col_k = new System.Windows.Forms.ColumnHeader();
            this.col_sfmin = new System.Windows.Forms.ColumnHeader();
            this.col_s = new System.Windows.Forms.ColumnHeader();
            this.col_M = new System.Windows.Forms.ColumnHeader();
            this.col_Q = new System.Windows.Forms.ColumnHeader();
            this.bt_pick = new System.Windows.Forms.Button();
            this.col_seaName = new System.Windows.Forms.ColumnHeader();
            this.col_tm = new System.Windows.Forms.ColumnHeader();
            this.col_erMode = new System.Windows.Forms.ColumnHeader();
            this.col_tideID = new System.Windows.Forms.ColumnHeader();
            this.col_Accuracy = new System.Windows.Forms.ColumnHeader();
            this.col_savedProfiles = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lbl_top
            // 
            this.lbl_top.AutoSize = true;
            this.lbl_top.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_top.Location = new System.Drawing.Point(6, 21);
            this.lbl_top.Name = "lbl_top";
            this.lbl_top.Size = new System.Drawing.Size(115, 20);
            this.lbl_top.TabIndex = 0;
            this.lbl_top.Text = "Please pick...";
            // 
            // lv_main
            // 
            this.lv_main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_RunID,
            this.col_Option,
            this.col_initSlope,
            this.col_tr,
            this.col_waveSet,
            this.col_k,
            this.col_sfmin,
            this.col_s,
            this.col_M,
            this.col_Q,
            this.col_seaName,
            this.col_tm,
            this.col_erMode,
            this.col_tideID,
            this.col_Accuracy,
            this.col_savedProfiles});
            this.lv_main.FullRowSelect = true;
            this.lv_main.GridLines = true;
            this.lv_main.Location = new System.Drawing.Point(11, 54);
            this.lv_main.Name = "lv_main";
            this.lv_main.Size = new System.Drawing.Size(945, 255);
            this.lv_main.TabIndex = 1;
            this.lv_main.UseCompatibleStateImageBehavior = false;
            this.lv_main.View = System.Windows.Forms.View.Details;
            // 
            // col_RunID
            // 
            this.col_RunID.Text = "RunID";
            // 
            // col_Option
            // 
            this.col_Option.Text = "Option";
            this.col_Option.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_Option.Width = 48;
            // 
            // col_initSlope
            // 
            this.col_initSlope.Text = "Init slope";
            this.col_initSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_tr
            // 
            this.col_tr.Text = "Tidal range";
            this.col_tr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_tr.Width = 69;
            // 
            // col_waveSet
            // 
            this.col_waveSet.Text = "Wave Set";
            this.col_waveSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_waveSet.Width = 67;
            // 
            // col_k
            // 
            this.col_k.Text = "k";
            this.col_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_k.Width = 36;
            // 
            // col_sfmin
            // 
            this.col_sfmin.Text = "Min Surf force";
            this.col_sfmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_sfmin.Width = 82;
            // 
            // col_s
            // 
            this.col_s.Text = "s";
            this.col_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_s.Width = 28;
            // 
            // col_M
            // 
            this.col_M.Text = "M";
            this.col_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_M.Width = 66;
            // 
            // col_Q
            // 
            this.col_Q.Text = "Q";
            this.col_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_Q.Width = 30;
            // 
            // bt_pick
            // 
            this.bt_pick.Location = new System.Drawing.Point(418, 320);
            this.bt_pick.Name = "bt_pick";
            this.bt_pick.Size = new System.Drawing.Size(186, 31);
            this.bt_pick.TabIndex = 2;
            this.bt_pick.Text = "Pick selected runs";
            this.bt_pick.UseVisualStyleBackColor = true;
            this.bt_pick.Click += new System.EventHandler(this.bt_pick_Click);
            // 
            // col_seaName
            // 
            this.col_seaName.Text = "Sea Name";
            this.col_seaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_seaName.Width = 68;
            // 
            // col_tm
            // 
            this.col_tm.Text = "Tect Move";
            this.col_tm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_tm.Width = 68;
            // 
            // col_erMode
            // 
            this.col_erMode.Text = "Er Mode";
            this.col_erMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_erMode.Width = 59;
            // 
            // col_tideID
            // 
            this.col_tideID.Text = "Tide ID";
            this.col_tideID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // col_Accuracy
            // 
            this.col_Accuracy.Text = "Accuracy";
            this.col_Accuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_savedProfiles
            // 
            this.col_savedProfiles.Text = "Saved profiles";
            this.col_savedProfiles.Width = 83;
            // 
            // Form_PickRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 363);
            this.Controls.Add(this.bt_pick);
            this.Controls.Add(this.lv_main);
            this.Controls.Add(this.lbl_top);
            this.Name = "Form_PickRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select runs";
            this.Load += new System.EventHandler(this.Form_pickRun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_top;
        private System.Windows.Forms.ListView lv_main;
        private System.Windows.Forms.ColumnHeader col_RunID;
        private System.Windows.Forms.ColumnHeader col_Option;
        private System.Windows.Forms.ColumnHeader col_initSlope;
        private System.Windows.Forms.ColumnHeader col_tr;
        private System.Windows.Forms.ColumnHeader col_waveSet;
        private System.Windows.Forms.ColumnHeader col_k;
        private System.Windows.Forms.ColumnHeader col_sfmin;
        private System.Windows.Forms.Button bt_pick;
        private System.Windows.Forms.ColumnHeader col_s;
        private System.Windows.Forms.ColumnHeader col_M;
        private System.Windows.Forms.ColumnHeader col_Q;
        private System.Windows.Forms.ColumnHeader col_seaName;
        private System.Windows.Forms.ColumnHeader col_tm;
        private System.Windows.Forms.ColumnHeader col_erMode;
        private System.Windows.Forms.ColumnHeader col_tideID;
        private System.Windows.Forms.ColumnHeader col_Accuracy;
        private System.Windows.Forms.ColumnHeader col_savedProfiles;
    }
}