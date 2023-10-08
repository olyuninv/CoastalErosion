namespace CoastalErosion
{
    partial class Form_Main
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
            this.mnu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_PlayMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ExistingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CompareRuns = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Detect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu_Main
            // 
            this.mnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_File,
            this.mnu_View});
            this.mnu_Main.Location = new System.Drawing.Point(0, 0);
            this.mnu_Main.Name = "mnu_Main";
            this.mnu_Main.Size = new System.Drawing.Size(632, 24);
            this.mnu_Main.TabIndex = 1;
            this.mnu_Main.Text = "menuStrip1";
            // 
            // mnu_File
            // 
            this.mnu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Exit});
            this.mnu_File.Name = "mnu_File";
            this.mnu_File.Size = new System.Drawing.Size(42, 20);
            this.mnu_File.Text = "File";
            // 
            // mnu_Exit
            // 
            this.mnu_Exit.MergeIndex = 4;
            this.mnu_Exit.Name = "mnu_Exit";
            this.mnu_Exit.Size = new System.Drawing.Size(152, 22);
            this.mnu_Exit.Text = "Exit";
            this.mnu_Exit.Click += new System.EventHandler(this.mnu_Exit_Click);
            // 
            // mnu_View
            // 
            this.mnu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_PlayMode,
            this.mnu_ExistingMode,
            this.mnu_CompareRuns,
            this.mnu_Detect});
            this.mnu_View.Name = "mnu_View";
            this.mnu_View.Size = new System.Drawing.Size(49, 20);
            this.mnu_View.Text = "View";
            // 
            // mnu_PlayMode
            // 
            this.mnu_PlayMode.Name = "mnu_PlayMode";
            this.mnu_PlayMode.Size = new System.Drawing.Size(173, 22);
            this.mnu_PlayMode.Text = "Play Mode";
            this.mnu_PlayMode.Click += new System.EventHandler(this.mnu_PlayMode_Click);
            // 
            // mnu_ExistingMode
            // 
            this.mnu_ExistingMode.Name = "mnu_ExistingMode";
            this.mnu_ExistingMode.Size = new System.Drawing.Size(173, 22);
            this.mnu_ExistingMode.Text = "Existing Runs";
            this.mnu_ExistingMode.Click += new System.EventHandler(this.mnu_ExistingMode_Click);
            // 
            // mnu_CompareRuns
            // 
            this.mnu_CompareRuns.Name = "mnu_CompareRuns";
            this.mnu_CompareRuns.Size = new System.Drawing.Size(173, 22);
            this.mnu_CompareRuns.Text = "Compare Runs";
            this.mnu_CompareRuns.Click += new System.EventHandler(this.mnu_CompareRuns_Click);
            // 
            // mnu_Detect
            // 
            this.mnu_Detect.Name = "mnu_Detect";
            this.mnu_Detect.Size = new System.Drawing.Size(173, 22);
            this.mnu_Detect.Text = "Detect Terraces";
            this.mnu_Detect.Click += new System.EventHandler(this.mnu_Detect_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 427);
            this.Controls.Add(this.mnu_Main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnu_Main;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coastal Erosion model";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.mnu_Main.ResumeLayout(false);
            this.mnu_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu_Main;
        private System.Windows.Forms.ToolStripMenuItem mnu_File;
        private System.Windows.Forms.ToolStripMenuItem mnu_View;
        private System.Windows.Forms.ToolStripMenuItem mnu_Exit;
        private System.Windows.Forms.ToolStripMenuItem mnu_PlayMode;
        private System.Windows.Forms.ToolStripMenuItem mnu_ExistingMode;
        private System.Windows.Forms.ToolStripMenuItem mnu_CompareRuns;
        private System.Windows.Forms.ToolStripMenuItem mnu_Detect;
    }
}

