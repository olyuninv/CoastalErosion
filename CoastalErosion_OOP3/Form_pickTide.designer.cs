namespace CoastalErosion
{
    partial class Form_pickTide
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
            this.col_tideID = new System.Windows.Forms.ColumnHeader();
            this.col_MHWS = new System.Windows.Forms.ColumnHeader();
            this.col_MHWN = new System.Windows.Forms.ColumnHeader();
            this.col_MT = new System.Windows.Forms.ColumnHeader();
            this.col_MLWN = new System.Windows.Forms.ColumnHeader();
            this.col_MLWS = new System.Windows.Forms.ColumnHeader();
            this.bt_choose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_top
            // 
            this.lbl_top.AutoSize = true;
            this.lbl_top.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_top.Location = new System.Drawing.Point(13, 9);
            this.lbl_top.Name = "lbl_top";
            this.lbl_top.Size = new System.Drawing.Size(155, 20);
            this.lbl_top.TabIndex = 0;
            this.lbl_top.Text = "Please pick a tide:";
            // 
            // lv_main
            // 
            this.lv_main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_tideID,
            this.col_MHWS,
            this.col_MHWN,
            this.col_MT,
            this.col_MLWN,
            this.col_MLWS});
            this.lv_main.FullRowSelect = true;
            this.lv_main.GridLines = true;
            this.lv_main.Location = new System.Drawing.Point(22, 46);
            this.lv_main.MultiSelect = false;
            this.lv_main.Name = "lv_main";
            this.lv_main.Size = new System.Drawing.Size(364, 235);
            this.lv_main.TabIndex = 1;
            this.lv_main.UseCompatibleStateImageBehavior = false;
            this.lv_main.View = System.Windows.Forms.View.Details;
            // 
            // col_tideID
            // 
            this.col_tideID.Text = "TideID";
            // 
            // col_MHWS
            // 
            this.col_MHWS.Text = "MHWS";
            // 
            // col_MHWN
            // 
            this.col_MHWN.Text = "MHWN";
            // 
            // col_MT
            // 
            this.col_MT.Text = "MT";
            // 
            // col_MLWN
            // 
            this.col_MLWN.Text = "MLWN";
            // 
            // col_MLWS
            // 
            this.col_MLWS.Text = "MLWS";
            // 
            // bt_choose
            // 
            this.bt_choose.Location = new System.Drawing.Point(165, 289);
            this.bt_choose.Name = "bt_choose";
            this.bt_choose.Size = new System.Drawing.Size(75, 23);
            this.bt_choose.TabIndex = 2;
            this.bt_choose.Text = "Choose";
            this.bt_choose.UseVisualStyleBackColor = true;
            this.bt_choose.Click += new System.EventHandler(this.bt_choose_Click);
            // 
            // Form_pickTide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 322);
            this.Controls.Add(this.bt_choose);
            this.Controls.Add(this.lv_main);
            this.Controls.Add(this.lbl_top);
            this.Name = "Form_pickTide";
            this.Text = "Select tide";
            this.Load += new System.EventHandler(this.Form_pickTide_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_top;
        private System.Windows.Forms.ListView lv_main;
        private System.Windows.Forms.ColumnHeader col_MHWS;
        private System.Windows.Forms.ColumnHeader col_MHWN;
        private System.Windows.Forms.ColumnHeader col_MT;
        private System.Windows.Forms.ColumnHeader col_MLWN;
        private System.Windows.Forms.ColumnHeader col_MLWS;
        private System.Windows.Forms.Button bt_choose;
        private System.Windows.Forms.ColumnHeader col_tideID;
    }
}