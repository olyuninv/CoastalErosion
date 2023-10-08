using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoastalErosion
{
    public partial class Form_Profile : Form
    {
        //--Reversible frame
        private bool allowSelect;
        private bool newScreen;
        private Point prevpoint, startpoint, tmp;
        private Rectangle r;

        private Graph gr = new Graph();

        double[, ,] data;
        float[,] circles;
        int[] bendPoints;

        public Form_Profile(double[,,] data)
        {
            InitializeComponent();

            this.data = new double[data.GetLength(0), 2, data.GetLength(2)];
            for (int j = 0; j < data.GetLength(2); j++)
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    this.data[i, 0, j] = data[i, 0, j];
                    this.data[i, 1, j] = data[i, 1, j];
                }
            }
            gr.setData(data);
        }

        private void Form_Profile_Load(object sender, EventArgs e)
        {            
            this.Capture = false;
            allowSelect = true;
            newScreen = true;
            mnu_ZoomIn.Enabled = true;
            mnu_ZoomOut.Enabled = false;
        }

        private void Form_Profile_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point((int)(0.8 * this.Width), (int)(0.55 * this.Height));
            gr.setDeviceCoords(10, this.Width - 20, this.Height - mnu_Main.Height - 20, mnu_Main.Height + 10);

            Graphics g = e.Graphics;
            if (bendPoints != null)
                gr.drawWithTerraces(g, bendPoints);
            else
                gr.Draw(g);
            if (circles != null)
                gr.drawCircles(g, circles);
            
        }

        public void assignCircles(double[,] circles)
        {
            int length = circles.GetLength(0);
            this.circles = new float[length, 2];
            for (int i = 0; i < length; i++)
            {
                this.circles[i, 0] = (float)circles[i, 0];
                this.circles[i, 1] = (float)circles[i, 1];
            }
            this.Invalidate();
        }

        public void assignBend(int[] bp)
        {
            bendPoints = new int[bp.Length];
            for (int i = 0; i < bp.Length; i++)
                bendPoints[i] = bp[i];
            this.Invalidate();
        }

        private void pb_picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (allowSelect)
            {
                if (r != null && !newScreen)
                    ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);

                this.Capture = true;
                startpoint.X = prevpoint.X = e.X;
                startpoint.Y = prevpoint.Y = e.Y;
                tmp = this.PointToScreen(startpoint);
                r.X = tmp.X;
                r.Y = tmp.Y;
                r.Width = e.X - startpoint.X;
                r.Height = e.Y - startpoint.Y;
                ControlPaint.DrawReversibleFrame(r, Color.Black, FrameStyle.Dashed);
                newScreen = false;
            }
            else
                this.Capture = false;
        }

        private void pb_picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Capture)
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
            if (this.Capture)
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

            topBoundry = (double)startpoint.Y / (double)(this.Height - mnu_Main.Height);
            lowBoundry = (double)prevpoint.Y / (double)(this.Height - mnu_Main.Height);
            leftBoundry = (double)startpoint.X / (double) (this.Width - 6 );
            rightBoundry = (double)prevpoint.X / (double) (this.Width - 6) ;

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
            this.Refresh();

            allowSelect = false;
            mnu_ZoomIn.Enabled = false;
            mnu_ZoomOut.Enabled = true;
        }

        private void mnu_ZoomOut_Click(object sender, EventArgs e)
        {
            gr.restore();
            this.Refresh();

            allowSelect = true;
            this.Capture = false;
            newScreen = true;
            mnu_ZoomIn.Enabled = true;
            mnu_ZoomOut.Enabled = false;
        }

        public void setLabelText(string s)
        {
            if (s == "")
            {
                lbl_descr.Text = s;
                panel1.Visible = false;
            }
            else
            {
                lbl_descr.Text = s;
                panel1.Visible = true;
            }
        }
    }
}