using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace DataG
{
    public partial class Form1 : Form
    {
        //constant variable
        static double EARTH_RAD_M = 6378100.00;             //the radius of the earth (in meter)
        //global variables
        string fName = "";                                  //the name of opening file
        static DataTable dtSave = new DataTable();          //the datatable version of .csv file
        static int dtrNum = dtSave.Rows.Count;              //the number of rows in dtSave
        static int dtcNum = dtSave.Columns.Count;           //the number of columns in dtSave
        static int[] datTime = new int[dtrNum];             //the data of time
        static double[] datSensorA = new double[dtrNum];    //the data of snesorA
        static double[] datS = new double[dtrNum];          //the data of speed
        static double[] datA = new double[dtrNum];          //the data of latitude
        static double[] datO = new double[dtrNum];          //the data of longtitude
        static double[] glpx = new double[dtrNum];          //the x coordinate of 2D coordinate system
        static double[] glpy = new double[dtrNum];          //the y coordinate of 2D coordinate system
        static double maxAbsX;                              //the max abstract value of x coordinate
        static double maxAbsY;                              //the max abstract value of x coordinate
        static double[] x = new double[dtrNum];             //the x coordinate in GPSPannel
        static double[] y = new double[dtrNum];             //the x coordinate in GPSPannel

        static int nowScrollValue = 0;                      //the position of scrollbar
        static int newPlace = 1;                            //the position of moving dot
        bool fileOpen = false;                              //determine whether the file has been opened

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //default all selected
            if (checkBoxAllSelection.Checked)
            {
                checkBoxSensorA.Checked = true;
                checkBoxSensorB.Checked = true;
            }
            sensorChart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
        }

        //read data from .csv file and return to datatable
        public static DataTable OpenCSV(string filePath)
        {
            System.Text.Encoding encoding = GetType(filePath);
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);

            //record a row of records per read
            string strLine = "";
            //record the contents of each field in each row of records
            string[] aryLine = null;
            string[] tableHead = null;
            //number of columns
            int columnCount = 0;
            //indicate whether it is the first line of reading
            bool IsFirst = true;
            //read data in .csv file line by line
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //create the column
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }
        
        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }

        //determine the encoding type of a file by a given file stream
        public static System.Text.Encoding GetType(System.IO.FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = System.Text.Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = System.Text.Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = System.Text.Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }

        //determine if it is UTF8 format without BOM
        private static bool IsUTF8Bytes(byte[] data)
        {
            //calculate the number of bytes that the character currently being analyzed should have
            int charByteCounter = 1;
            byte curByte; //the byte currently being analyzed
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //if the first bit of the tag is non-zero, start with at least 2
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //if it is UTF-8, the first digit must be 1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("Unexpected byte format!");
            }
            return true;
        }

        //calculate the max value of abs(num[])
        double maxAbsValue(double[] num, int length)
        {
            double[] numNew = new double[length];
            for (int i = 0; i < length; i++)
            {
                numNew[i] = Math.Abs(num[i]);
            }
            double re = 0;
            for (int i = 0; i < length; i++)
            {
                if (numNew[i] > re)
                    re = numNew[i];
            }
            return re;
        }

        //find the subscript with given value and array
        int findSub(int value, int[] array, int length)
        {
            int res = 0;
            for (res = 0; res < length; res++)
            {
                if (array[res] == value)
                {
                    break;
                }
            }
            return res;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c://";
            openFileDialog.Filter = "Data Files|*.csv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            string fileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            DataTable dt = new DataTable();
            if (fileName == "")
            {
                MessageBox.Show("No file selected", "Warning");
                return;
            }
            dt = OpenCSV(fileName);
            fileOpen = true;
            dtSave = dt;
            fName = fileName;
            dtrNum = dt.Rows.Count;
            dtcNum = dt.Columns.Count;
            datTime = new int[dtrNum];
            datSensorA = new double[dtrNum];//sensor
            datS = new double[dtrNum];
            datA = new double[dtrNum];
            datO = new double[dtrNum];
            
            for (int i = 0; i < dtrNum; i++)
            {

                datTime[i] = int.Parse(dt.Rows[i][0].ToString());
                datSensorA[i] = int.Parse(dt.Rows[i][1].ToString());
                datS[i] = int.Parse(dt.Rows[i][2].ToString());
            }
            
            sensorChart.Series["SensorA"].Points.DataBindXY(datTime,datSensorA);
            sensorChart.Series["Speed"].Points.DataBindXY(datTime, datS);
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;

            for (int i = 0; i < dtrNum; i++)
            {
                
                datA[i] = double.Parse(dt.Rows[i][2].ToString());
                datA[i] *= 0.017453293;
                datO[i] = double.Parse(dt.Rows[i][3].ToString());
                datO[i] *= 0.017453293;
            }
            //convert from lat and lon to x,y
            glpx = new double[dtrNum];
            glpy = new double[dtrNum];

            for (int i = 0; i < dtrNum; i++)
            {
                glpx[i] = (datO[i] - datO[0]) * EARTH_RAD_M;
                glpy[i] = (datA[i] - datA[0]) * EARTH_RAD_M * Math.Sin(datO[i]);
            }
            //change the original (x,y) to the position of panel
            maxAbsX = maxAbsValue(glpx, dtrNum);
            maxAbsY = maxAbsValue(glpy, dtrNum);
            x = new double[dtrNum];
            y = new double[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {
                x[i] = (maxAbsX + glpx[i]) * 0.5 * (GPSPanel.Width) / maxAbsX;
                y[i] = (maxAbsY - glpy[i]) * 0.5 * (GPSPanel.Height) / maxAbsY;
            }
            Graphics g = GPSPanel.CreateGraphics();
            PointF p1 = new PointF();
            PointF p2 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int i = 0; i < dtrNum - 1; i++)
            {
                p1 = new PointF((float)x[i], (float)y[i]);
                p2 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g.DrawLine(nPen, p1, p2);
            }
        }

        private void checkBoxAllSelection_Click(object sender, EventArgs e)
        {
            if (checkBoxAllSelection.Checked)
            {
                checkBoxSensorA.Checked = true;
                checkBoxSensorA_Click(sender, e);
                checkBoxSensorB.Checked = true;
                checkBoxSensorB_Click(sender, e);
            }
            else
            {
                checkBoxSensorA.Checked = false;
                checkBoxSensorA_Click(sender, e);
                checkBoxSensorB.Checked = false;
                checkBoxSensorB_Click(sender, e);
            }
        }

        private void checkBoxSensorA_Click(object sender, EventArgs e)
        {
            if (!checkBoxSensorA.Checked)
            {
                Series series = sensorChart.Series["SensorA"];
                series.Points.Clear();
            }
            else
            {
                dtrNum = dtSave.Rows.Count;
                dtcNum = dtSave.Columns.Count;
                datTime = new int[dtrNum];
                datSensorA = new double[dtrNum];
                for (int i = 0; i < dtrNum; i++)
                {
                    datTime[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datSensorA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                }
                sensorChart.Series["SensorA"].Points.DataBindXY(datTime, datSensorA);
                sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
                sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
                
            }
        }

        private void checkBoxSensorB_Click(object sender, EventArgs e)
        {
            if (!checkBoxSensorB.Checked)
            {
                Series series = sensorChart.Series["Speed"];
                series.Points.Clear();
            }
            else
            {
                dtrNum = dtSave.Rows.Count;
                dtcNum = dtSave.Columns.Count;
                datTime = new int[dtrNum];
                datS = new double[dtrNum];
                for (int i = 0; i < dtrNum; i++)
                {
                    datTime[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datS[i] = int.Parse(dtSave.Rows[i][2].ToString());
                }
                sensorChart.Series["Speed"].Points.DataBindXY(datTime, datS);
                sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
                sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;

            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            dtrNum = dtSave.Rows.Count;
            dtcNum = dtSave.Columns.Count;
            datTime = new int[dtrNum];
            datSensorA = new double[dtrNum];
            datS = new double[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {
                if (checkBoxSensorA.Checked)
                {
                    datTime[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datSensorA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                    textBoxTime.Text = datTime[i].ToString();
                    textBoxSensorA.Text = datSensorA[i].ToString();
                }
                if (checkBoxSensorB.Checked)
                {
                    datTime[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datS[i] = int.Parse(dtSave.Rows[i][2].ToString());
                    textBoxTime.Text = datTime[i].ToString();
                    textBoxSensorB.Text = datSensorA[i].ToString();
                }
                
            }
            if(fileOpen == true)
                chartTimer.Enabled = true;

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            sensorChart.Invalidate();
            chartTimer.Enabled = false;

            Graphics g2 = GPSPanel.CreateGraphics();
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int j = 0; j < dtrNum - 1; j++)
            {
                p11 = new PointF((float)x[j], (float)y[j]);
                p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                g2.DrawLine(nPen, p11, p22);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = 0;
            sensorChart.Invalidate();
            chartTimer.Enabled = false;
            nowScrollValue = 0;

            GPSPanel.Refresh();
            Graphics g2 = GPSPanel.CreateGraphics();
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int j = 0; j < dtrNum - 1; j++)
            {
                p11 = new PointF((float)x[j], (float)y[j]);
                p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                g2.DrawLine(nPen, p11, p22);
            }
            newPlace = 1;
        }

        private void sensorChart_MouseClick(object sender, MouseEventArgs e)
        { 
            dtrNum = dtSave.Rows.Count;
            dtcNum = dtSave.Columns.Count;
            datTime = new int[dtrNum];
            datSensorA = new double[dtrNum];
            datS = new double[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {

                datTime[i] = int.Parse(dtSave.Rows[i][0].ToString());
                datSensorA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                datS[i] = int.Parse(dtSave.Rows[i][2].ToString());
            }

            int mouseX = e.X;
            int mouseY = e.Y;
            double xx = sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(mouseX);
            if (fileOpen == true)
            {
                if (xx >= datTime[0] && xx <= datTime[dtrNum - 1])
                {
                    this.Refresh();
                    //draw the line with mouse click
                    Graphics g = sensorChart.CreateGraphics();
                    Point p1 = new Point(mouseX, 0);
                    Point p2 = new Point(mouseX, sensorChart.Height);
                    Pen np = new Pen(Brushes.Blue, 1);
                    g.DrawLine(np, p1, p2);

                    textBoxTime.Clear();
                    textBoxSensorA.Clear();
                    textBoxSensorB.Clear();
                    //calculate the place of mouse

                    textBoxTime.Text = Math.Round(xx, 2).ToString();
                    int xLeft = (int)xx;
                    //find the Subscript with the xLeft
                    int xLeftSub = findSub(xLeft, datTime, datTime.Length);
                    int xRightSub = xLeftSub + 1;
                    int xRight = 0;
                    //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                    if (xRightSub < dtrNum && xLeftSub >= 0) // for the chart
                    {
                        xRight = datTime[xRightSub];
                        double kA = ((double)(datSensorA[xLeftSub] - datSensorA[xRightSub])) / ((double)(xLeft - xRight));
                        double bA = (double)datSensorA[xLeftSub] - (double)kA * (double)xLeft;
                        textBoxSensorA.Text = Math.Round(kA * xx + bA, 2).ToString();
                        double kB = ((double)(datS[xLeftSub] - datS[xRightSub])) / ((double)(xLeft - xRight));
                        double bB = (double)datS[xLeftSub] - (double)kB * (double)xLeft;
                        textBoxSensorB.Text = Math.Round(kB * xx + bB, 2).ToString();
                    }



                    if (xRightSub < dtrNum && xLeftSub >= 0) // for the panel
                    {
                        double k = ((y[xLeftSub] - y[xRightSub]) / ((double)(x[xLeftSub] - x[xRightSub])));
                        double b = y[xLeftSub] - (double)k * x[xLeftSub];

                        double m;
                        double n; //make a point

                        //m = (maxAbsX + xx) * 0.5 * (GPSPanel.Width - 50) / maxAbsX;
                        m = (xx - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                        n = k * m + b;

                        Graphics g2 = GPSPanel.CreateGraphics();
                        PointF p11 = new PointF();
                        PointF p22 = new PointF();
                        Pen nPen = new Pen(Brushes.Red, 1);
                        for (int i = 0; i < dtrNum - 1; i++)
                        {
                            p11 = new PointF((float)x[i], (float)y[i]);
                            p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                            g2.DrawLine(nPen, p11, p22);
                        }

                        PointF pp = new PointF();
                        pp = new PointF((float)m, (float)n);
                        g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                    }
                }
            }
        }
        
        private void chartTimer_Tick(object sender, EventArgs e)
        {
            if (nowScrollValue >= 1 && nowScrollValue <= dtrNum)
            {
                textBoxSensorB.Text = datS[nowScrollValue - 1].ToString();
                textBoxSensorA.Text = datSensorA[nowScrollValue - 1].ToString();
                textBoxTime.Text = nowScrollValue.ToString();
            }

            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            if (nowScrollValue <= dtrNum)
                nowScrollValue++;
            sensorChart.Invalidate();

            Graphics g2 = GPSPanel.CreateGraphics();
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int j = 0; j < dtrNum - 1; j++)
            {
                p11 = new PointF((float)x[j], (float)y[j]);
                p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                g2.DrawLine(nPen, p11, p22);
            }
            int xLeft = (int)newPlace;
            //find the Subscript with the xLeft
            int xLeftSub = findSub(xLeft, datTime, datTime.Length);
            int xRightSub = xLeftSub + 1;
            int xRight = 0;
            if (xRightSub < dtrNum && xLeftSub >= 0) // for the panel
            {
                this.Refresh();
            
                double k = ((y[xLeftSub] - y[xRightSub]) / ((double)(x[xLeftSub] - x[xRightSub])));
                double b = y[xLeftSub] - (double)k * x[xLeftSub];

                double m;
                double n; //make a point

                m = (newPlace - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                n = k * m + b;
                PointF pp = new PointF();
                pp = new PointF((float)m, (float)n);
                g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                newPlace++;
            }
            


        }
    }
}

