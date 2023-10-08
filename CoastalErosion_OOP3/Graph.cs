using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CoastalErosion
{  
    public class Graph
    {
        //world coordinates
        private float xmin = 0, xmax = 320, ymin = 0, ymax = 220;
        public float Xmin
        {
            get {return xmin;}
        }
        public float Xmax
        {
            get { return xmax; }
        }
        public float Ymin
        {
            get { return ymin; }
        }
        public float Ymax
        {
            get { return ymax; }
        }
        
        //device coordinates
        private float xdmin = 0, xdmax = 320, ydmin = 0, ydmax = 220;
       
        private float sx = 1, sy = 1, tx = 0, ty = 0;
        public float Sx
        {
            get { return sx; }
        }
        public float Sy
        {
            get { return sy; }
        }
        public float Tx
        {
            get { return tx; }
        }
        public float Ty
        {
            get { return ty; }
        }

        //Model specific
        private float[,,] data = null;
        
        public Graph()
        {

        }

        public Graph(double[,,] data)
        {
            setData(data);
        }

        public void Draw(Graphics g)
        {
            g.TranslateTransform(tx, ty);
            g.ScaleTransform(sx, sy);
            using (Pen p = new Pen(Color.Black, 1 / sx))
            {
                drawSeaAndAxis(g, p);

                //Draw profiles
                int length0 = data.GetLength(0);
                int length2 = data.GetLength(2);

                for (int k = 0; k < length2; k++)
                {
                    for (int i = 0; i < length0 - 1; i++)
                    {
                        g.DrawLine(p, data[i, 1, k], data[i, 0, k], data[i + 1, 1, k], data[i + 1, 0, k]);
                    }
                }
            }
        }

        public void drawWithTerraces(Graphics g, int[] bendPoints)
        {
            g.TranslateTransform(tx, ty);
            g.ScaleTransform(sx, sy);
            using (Pen p = new Pen(Color.Black, 1 / sx))
            {
                drawSeaAndAxis(g, p);

                //Draw profiles
                int length0 = data.GetLength(0);
                int length2 = data.GetLength(2);
                int nextChange = bendPoints[1];      
                int j = 1; 
      
                for (int k = 0; k < length2; k++)
                {
                    p.Color = Color.Red;
                    for (int i = 0; i < length0 - 1; i++)
                    {
                        if (i == nextChange)
                        {
                            if (p.Color == Color.Red)
                                p.Color = Color.Green;
                            else
                                p.Color = Color.Red;
                            j++;
                            nextChange = bendPoints[j];
                        }
                        g.DrawLine(p, data[i, 1, k], data[i, 0, k], data[i + 1, 1, k], data[i + 1, 0, k]);
                        
                    }
                }
            }
        }

        private void drawSeaAndAxis(Graphics g, Pen p)
        {
            //axis
            g.DrawLine(p, 0, ymin, 0, ymax);
            g.DrawLine(p, xmin, 0, xmax, 0);

            //scales
            float tickX = 5 / sx;
            float tickY = 5 / sy;
            g.DrawLine(p, xmin, ymin, xmax, ymin);    //top
            g.DrawLine(p, xmax, ymin, xmax, ymax);    //side
            for (float i = 0; i > xmin; i -= 100)
                g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
            for (float i = 0; i < xmax; i += 100)
                g.DrawLine(p, i, ymin - tickY, i, ymin + tickY);
            for (float i = 0; i < ymax; i += 10)
                g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);
            for (float i = 0; i > ymin; i -= 10)
                g.DrawLine(p, xmax - tickX, i, xmax + tickX, i);

            p.Color = Color.Blue;

            //Water - always at 0
            g.DrawLine(p, xmin, 0, xmax, 0);    //x axis

            p.Color = Color.Brown;
            //frame
            g.DrawLine(p, xmin, ymin, xmax, ymin);    //top
            g.DrawLine(p, xmax, ymin, xmax, ymax);    //side
        }

        public void drawCircles(Graphics g, float[,] data)
        {
            using (Pen p = new Pen(Color.Red, 1 / sx))
            {
                int length0 = data.GetLength(0);
                
                //Draw circles
                for (int i = 0; i < length0; i++)
                {
                    g.DrawEllipse(p, data[i, 0]- 3/sx, data[i, 1]-3/sy, 6/sx, 6/sy);
                } 
            }
        }

        public void setData(double[,,] data)
        {
            if (data != null)
            {
                if (data.GetLength(1) >= 2)
                {
                    this.data = new float[data.GetLength(0), data.GetLength(1), data.GetLength(2)];
                    for (int k = 0; k < data.GetLength(2); k++)  //for every table
                    {
                        for (int i = 0; i < data.GetLength(0); i++)
                        {
                            this.data[i, 0, k] = (float)data[i, 0, k];
                            this.data[i, 1, k] = (float)data[i, 1, k];
                        }
                    }
                    calcRanges();
                }
            }
        }

        public void setDataNoRescale(double[,,] data)
        {
            if (data != null)
            {
                if (data.GetLength(1) >= 2)
                {
                    this.data = new float[data.GetLength(0), data.GetLength(1), data.GetLength(2)];
                    for (int k = 0; k < data.GetLength(2); k++)  //for every table
                    {
                        for (int i = 0; i < data.GetLength(0); i++)
                        {
                            this.data[i, 0, k] = (float)data[i, 0, k];
                            this.data[i, 1, k] = (float)data[i, 1, k];
                        }
                    }
                }
            }
        }

        private void calcTransforms()
        {
            tx = (xdmin * xmax - xdmax * xmin) / (xmax - xmin);
            ty = (ydmin * ymax - ydmax * ymin) / (ymax - ymin);
            sx = (xdmax - xdmin) / (xmax - xmin);
            sy = (ydmax - ydmin) / (ymax - ymin);
        }

        private void calcRanges()
        {
            float xmn = 0, xmx = 0, ymn = 0, ymx = 0;
            if (data != null)
            {
                xmn = xmx = data[0, 1, 0];
                ymn = ymx = data[0, 0, 0];

                for (int k = 0; k < data.GetLength(2); k++)
                {
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        //ymin and ymax
                        if (data[i, 0, k] < ymn)
                            ymn = data[i, 0, k];
                        if (data[i, 0, k] > ymx)
                            ymx = data[i, 0, k];

                        //xmin and xmax
                        if (data[i, 1, k] < xmn)
                            xmn = data[i, 1, k];
                        if (data[i, 1, k] > xmx)
                            xmx = data[i, 1, k];
                    }
                }
            }
            this.xmin = xmn;
            this.xmax = xmx;
            this.ymin = ymn;
            this.ymax = ymx;

            calcTransforms();
        }
        
        public void setDeviceCoords(float xdmin, float xdmax, float ydmin, float ydmax)
        {
            //if(xdmin < xdmax && ydmin > ydmax)
            //{
            this.xdmin = xdmin;
            this.xdmax = xdmax;
            this.ydmin = ydmin;
            this.ydmax = ydmax;
            //}
            calcTransforms();
        }

        protected void setWorldCoords(float xmin, float xmax, float ymin, float ymax)
        {
            //if(xdmin < xdmax && ydmin > ydmax)
            //{
            this.xmin = xmin;
            this.xmax = xmax;
            this.ymin = ymin;
            this.ymax = ymax;
            //}
            calcTransforms();
        }

        public void rescale(double perLeft, double perRight, double perTop, double perBottom)
        {
            xmin += (float) perLeft * (xmax - xmin);
            xmax = xmin + (float)perRight * (xmax - xmin);
            ymin += (float)(1 - perBottom) * (ymax - ymin);
            ymax = ymin + (float)(1 - perTop) * (ymax - ymin);
            calcTransforms();
        }

        public void restore()
        {
            int n = data.GetLength(2);
            xmin = data[data.GetLength(0) - 1, 1, 0];
            xmax = data[0, 1, n -1];
            ymin = data[data.GetLength(0) - 1, 0, 0];
            ymax = data[0, 0, n -1];
            calcTransforms();
        }

    }
}
