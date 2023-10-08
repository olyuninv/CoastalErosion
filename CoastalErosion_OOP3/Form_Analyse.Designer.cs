namespace CoastalErosion
{
    partial class Form_Analyse
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_OK = new System.Windows.Forms.Button();
            this.tb_runID = new System.Windows.Forms.TextBox();
            this.tb_option = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_profileN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RunID: ";
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(99, 143);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(90, 22);
            this.bt_OK.TabIndex = 1;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // tb_runID
            // 
            this.tb_runID.Location = new System.Drawing.Point(124, 45);
            this.tb_runID.Name = "tb_runID";
            this.tb_runID.Size = new System.Drawing.Size(121, 20);
            this.tb_runID.TabIndex = 2;
            // 
            // tb_option
            // 
            this.tb_option.Location = new System.Drawing.Point(124, 77);
            this.tb_option.Name = "tb_option";
            this.tb_option.Size = new System.Drawing.Size(121, 20);
            this.tb_option.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Option:";
            // 
            // tb_profileN
            // 
            this.tb_profileN.Location = new System.Drawing.Point(124, 108);
            this.tb_profileN.Name = "tb_profileN";
            this.tb_profileN.Size = new System.Drawing.Size(121, 20);
            this.tb_profileN.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Profile number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Which profile would you like to analyse? :";
            // 
            // Form_Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 178);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_profileN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_option);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_runID);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.label1);
            this.Name = "Form_Analyse";
            this.Text = "Form_Analyse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.TextBox tb_runID;
        private System.Windows.Forms.TextBox tb_option;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_profileN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}