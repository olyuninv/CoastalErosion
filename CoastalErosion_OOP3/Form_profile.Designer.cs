namespace CoastalErosion
{
    partial class Form_Profile
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
            this.mnu_Main = new System.Windows.Forms.MenuStrip();
            this.mnu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_descr = new System.Windows.Forms.Label();
            this.mnu_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu_Main
            // 
            this.mnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Options});
            this.mnu_Main.Location = new System.Drawing.Point(0, 0);
            this.mnu_Main.Name = "mnu_Main";
            this.mnu_Main.Size = new System.Drawing.Size(514, 24);
            this.mnu_Main.TabIndex = 0;
            this.mnu_Main.Text = "menuStrip1";
            // 
            // mnu_Options
            // 
            this.mnu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_ZoomIn,
            this.mnu_ZoomOut});
            this.mnu_Options.Name = "mnu_Options";
            this.mnu_Options.Size = new System.Drawing.Size(66, 20);
            this.mnu_Options.Text = "Options";
            // 
            // mnu_ZoomIn
            // 
            this.mnu_ZoomIn.Name = "mnu_ZoomIn";
            this.mnu_ZoomIn.Size = new System.Drawing.Size(134, 22);
            this.mnu_ZoomIn.Text = "Zoom In";
            this.mnu_ZoomIn.Click += new System.EventHandler(this.mnu_ZoomIn_Click);
            // 
            // mnu_ZoomOut
            // 
            this.mnu_ZoomOut.Name = "mnu_ZoomOut";
            this.mnu_ZoomOut.Size = new System.Drawing.Size(134, 22);
            this.mnu_ZoomOut.Text = "Zoom Out";
            this.mnu_ZoomOut.Click += new System.EventHandler(this.mnu_ZoomOut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_descr);
            this.panel1.Location = new System.Drawing.Point(302, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 100);
            this.panel1.TabIndex = 1;
            // 
            // lbl_descr
            // 
            this.lbl_descr.AutoSize = true;
            this.lbl_descr.Location = new System.Drawing.Point(4, 4);
            this.lbl_descr.Name = "lbl_descr";
            this.lbl_descr.Size = new System.Drawing.Size(35, 13);
            this.lbl_descr.TabIndex = 0;
            this.lbl_descr.Text = "label1";
            // 
            // Form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(514, 310);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnu_Main);
            this.MainMenuStrip = this.mnu_Main;
            this.Name = "Form_Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Profile_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_picture_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_picture_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_picture_MouseDown);
            this.Load += new System.EventHandler(this.Form_Profile_Load);
            this.mnu_Main.ResumeLayout(false);
            this.mnu_Main.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu_Main;
        private System.Windows.Forms.ToolStripMenuItem mnu_Options;
        private System.Windows.Forms.ToolStripMenuItem mnu_ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mnu_ZoomOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_descr;
    }
}