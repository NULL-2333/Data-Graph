﻿using System;
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
    public partial class MainForm : Form
    {
        //constant variable
        const double EARTH_RAD_M = 6378100.00;                  //the radius of the earth (in meter)
        //global variables
        string fName = "";                                      //the name of opening file
        static DataTable dtSave = new DataTable();              //the datatable version of .csv file
        static int dtrNum = dtSave.Rows.Count;                  //the number of rows in dtSave
        static int dtcNum = dtSave.Columns.Count + 1;           //the number of columns in dtSave
        double[] dataTime = new double[dtrNum];                 //the data of time
        double[,] data = new double[dtrNum, dtcNum - 1];        //the sensors' data of dtSave
        string[] seriesName = new string[dtcNum - 1];           //the names of different sensors
        double[] glpx = new double[dtrNum];                     //the x coordinate of 2D coordinate system
        double[] glpy = new double[dtrNum];                     //the y coordinate of 2D coordinate system
        double maxAbsX;                                         //the max abstract value of x coordinate
        double maxAbsY;                                         //the max abstract value of x coordinate
        double[] x = new double[dtrNum];                        //the x coordinate in GPSPannel
        double[] y = new double[dtrNum];                        //the x coordinate in GPSPannel

        int nowScrollValue = 0;                                 //the position of scrollbar
        int newPlace = 1;                                       //the position of moving dot
        bool fileOpen = false;                                  //determine whether the file has been opened
        bool flag = false;                                      //drag line
        bool flagPlace = true;

        int xRangeMax = 70;                                  //the max value of x coordinate
        int xRangeMin = 0;                                      //the min value of x coordinate
        int yRangeMax = 200;                                    //the max value of y coordinate
        int yRangeMin = 0;                                      //the min value of y coordinate
        int xScale = 1;                                        //the size of x view
        int yScale = 100;                                       //the size of y view
        double[] speed = new double[dtrNum];                    //the speed in the csv file
        int speedRow = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10000;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
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
        int findSub(double value, double[] array, int length)
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

        //find the subscript with given value and array - string version
        int findStrSub(string value, string[] array, int length)
        {
            int res = 0;
            for (res = 0; res < length; res++)
            {
                if (array[res].Equals(value))
                {
                    break;
                }
            }
            return res;
        }

        //find nearest left neighbour
        int findLeftNear(double value, double[] array, int length)
        {
            int res = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] <= value && array[i + 1] >= value) {
                    res = i;
                    break;
                }
            }
            return res;
        }

        //calculate the min value of (num[])
        double minValue(double[] num, int length)
        {
            double re = num[0];
            for (int i = 0; i < length; i++)
            {
                if (num[i] < re)
                    re = num[i];
            }
            return re;
        }

        //calculate the max value of (num[])
        double maxValue(double[] num, int length)
        {
            double re = num[0];
            for (int i = 0; i < length; i++)
            {
                if (num[i] > re)
                    re = num[i];
            }
            return re;
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
            data = new double[dtrNum, dtcNum - 1];
            speed = new double[dtrNum];
            dataTime = new double[dtrNum];
            seriesName = new string[dtcNum - 1];
            for (int i = 0; i < dtrNum; i++)
            {
                dataTime[i] = double.Parse(dt.Rows[i][0].ToString());
                for (int j = 0; j < dtcNum - 1; j++)
                {
                    data[i, j] = double.Parse(dt.Rows[i][j + 1].ToString());
                }
            }
            double k = dataTime[0];
            for (int i = 0; i < dtrNum; i++)
            {
                dataTime[i] = dataTime[i] - k;
                dataTime[i] /= 1000;
            }
            for (int i = 0; i < dtcNum - 1; i++)
            {
                seriesName[i] = dt.Columns[i + 1].ColumnName;
                if (seriesName[i].Contains("SPEED"))
                {
                    speedRow = i;
                }
            }
            for (int i = 0; i < dtrNum; i++)
            {
                speed[i] = double.Parse(dt.Rows[i][speedRow + 1].ToString());
            }

            InputForm a = new InputForm();
            a.Names = new string[dtcNum - 1];
            for (int i = 0; i < dtcNum - 1; i++)
            {
                a.Names[i] = seriesName[i];
            }
            a.ShowDialog();
            string latName = a.latName;
            string lonName = a.lonName;

            if (latName.Equals("") || lonName.Equals(""))
            {
                MessageBox.Show("No column selected for latitude and lontitude!");
                return;
            }

            for (int i = 0; i < dtcNum - 1; i++)
            {
                Series s = new Series(seriesName[i]);
                double[] dataSensor = new double[dtrNum];
                for (int j = 0; j < dtrNum; j++)
                {
                    dataSensor[j] = data[j, i];
                }
                s.Points.DataBindXY(dataTime, dataSensor);
                s.ChartType = SeriesChartType.Line;
                sensorChart.Series.Add(s);
            }
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = 0.1;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            double[] datA = new double[dtrNum];     //the latitude
            double[] datO = new double[dtrNum];     //the longtitude
            
            for (int i = 0; i < dtrNum; i++)
            {
                datA[i] = data[i, findStrSub(latName, seriesName, dtcNum - 1)];
                datA[i] *= 0.017453293;
                datO[i] = data[i, findStrSub(lonName, seriesName, dtcNum - 1)];
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
            //add new labels and checkbox
            int locY = timeLabel.Location.Y + timeLabel.Height + 5;

            for (int i = 0; i < dtcNum - 1; i++)
            {
                Label label = new Label();
                label.Text = seriesName[i];
                label.Location = new Point(timeLabel.Location.X, locY);
                label.Height = timeLabel.Height;
                label.Width = timeLabel.Width;
                label.Font = timeLabel.Font;
                dataPanel.Controls.Add(label);

                TextBox textbox = new TextBox();
                textbox.Location = new Point(textBoxTime.Location.X, locY);
                textbox.Height = textBoxTime.Height;
                textbox.Width = textBoxTime.Width;
                textbox.Name = "textBox" + i.ToString();
                dataPanel.Controls.Add(textbox);

                locY += label.Height + 5;

                //add checkbox to checklist box
                sensorCheckedListBox.Items.Add(seriesName[i], true);
            }
            nowScrollValue = (int)minValue(dataTime, dataTime.Length);
            newPlace = (int)minValue(dataTime, dataTime.Length);
        }

        private void sensorCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            Series sz = sensorChart.Series[seriesName[index]];
            sz.Enabled = !sensorCheckedListBox.GetItemChecked(index);
        }

        private void allSelectedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtcNum - 1; i++)
            {
                sensorCheckedListBox.SetItemChecked(i, allSelectedCheckBox.Checked);
            }
        }

        private void sensorChart_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            double xx = sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(mouseX);
            if (fileOpen == true)
            {
                if (xx >= dataTime[0] && xx <= dataTime[dtrNum - 1])
                {
                    this.Refresh();
                    
                    //draw the line with mouse click
                    Graphics g = sensorChart.CreateGraphics();
                    Point p1 = new Point(mouseX, 0);
                    Point p2 = new Point(mouseX, sensorChart.Height);
                    Pen np = new Pen(Brushes.Blue, 1);
                    g.DrawLine(np, p1, p2);

                    textBoxTime.Clear();
                    TextBox txtBox = new TextBox();
                    for (int i = 0; i < dtcNum - 1; i++)
                    {
                        txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(),true)[0];
                        if (txtBox != null && sensorCheckedListBox.GetItemChecked(i))
                        {
                            txtBox.Text = "";
                        }
                    }
                    //calculate the place of mouse
                    textBoxTime.Text = Math.Round(xx, 2).ToString();
                    //find the Subscript with the xLeft
                    int xLeftSub = findLeftNear(xx, dataTime, dataTime.Length);
                    int xRightSub = xLeftSub + 1;
                    double xLeft = dataTime[xLeftSub], xRight = dataTime[xLeftSub];
                    //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                    xRight = dataTime[xRightSub];
                    for (int i = 0; i < dtcNum - 1; i++)
                    {
                        double k = (data[xLeftSub, i] - data[xRightSub, i]) / (xLeft - xRight);
                        double b = data[xLeftSub, i] - k * xLeft;
                        txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(), true)[0];
                        if (txtBox != null && sensorCheckedListBox.GetItemChecked(i))
                        {
                            txtBox.Text = Math.Round(k * xx + b, 8).ToString();
                        }
                    }

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

                    double m, n;
                    m = (xx - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                    n = (xx - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];
                    
                    PointF pp = new PointF();
                    pp = new PointF((float)m, (float)n);
                    g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                    
                }
            }
        }
        
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            
            if (fileOpen == true)
                chartTimer.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = 0.1;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            sensorChart.Invalidate();
            chartTimer.Enabled = false;
            /*
            Graphics g2 = GPSPanel.CreateGraphics();
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int j = 0; j < dtrNum - 1; j++)
            {
                p11 = new PointF((float)x[j], (float)y[j]);
                p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                g2.DrawLine(nPen, p11, p22);
            }*/

            flagPlace = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = 0.1;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            nowScrollValue = (int)minValue(dataTime, dataTime.Length);
            newPlace = (int)minValue(dataTime, dataTime.Length);
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            sensorChart.Invalidate();
            chartTimer.Enabled = false;

            GPSPanel.Refresh();
            /*Graphics g2 = GPSPanel.CreateGraphics();
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int j = 0; j < dtrNum - 1; j++)
            {
                p11 = new PointF((float)x[j], (float)y[j]);
                p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                g2.DrawLine(nPen, p11, p22);
            }*/
            flagPlace = true;
        }

        private void chartTimer_Tick(object sender, EventArgs e)
        {
            //Bitmap bitmap1 = new Bitmap(sensorChart.Width, sensorChart.Height);
            //Graphics g1 = Graphics.FromImage(bitmap1);
            //PointF p1 = new PointF((float)sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(nowScrollValue), 50);
            //PointF p2 = new PointF(0, 0);
            //Pen np = new Pen(Brushes.Beige, 2);
            //g1.DrawLine(np, p1, p2);
            //Graphics gg1 = sensorChart.CreateGraphics();
            //gg1.DrawImage(bitmap1, new PointF(0.0f, 0.0f));

            if (nowScrollValue >= minValue(dataTime, dataTime.Length) && nowScrollValue <= maxValue(dataTime, dataTime.Length))
            {
                textBoxTime.Text = nowScrollValue.ToString();
                TextBox txtBox = new TextBox();
                for (int i = 0; i < dtcNum - 1; i++)
                {
                    txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(), true)[0];
                    if (txtBox != null && sensorCheckedListBox.GetItemChecked(i))
                    {
                        txtBox.Text = data[findSub(nowScrollValue,dataTime,dataTime.Length), i].ToString();
                    }
                }
            }

            //sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            //sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            //sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            //sensorChart.ChartAreas[0].AxisX.Interval = 0.1;
            //sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            //sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            //sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            //sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            if (nowScrollValue <= maxValue(dataTime, dataTime.Length))
                nowScrollValue += 1;
            sensorChart.Invalidate();

            if (flagPlace == true)
            {
                Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitmap);
                /*
                //Graphics g2 = GPSPanel.CreateGraphics();
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen nPen = new Pen(Brushes.Red, 1);
                for (int j = 0; j < dtrNum - 1; j++)
                {
                    p11 = new PointF((float)x[j], (float)y[j]);
                    p22 = new PointF((float)x[j + 1], (float)y[j + 1]);
                    g2.DrawLine(nPen, p11, p22);
                }*/
                //find the Subscript with the xLeft
                int xLeftSub = findLeftNear(newPlace, dataTime, dataTime.Length);
                int xRightSub = xLeftSub + 1;
                double xLeft = dataTime[xLeftSub], xRight = dataTime[xLeftSub];
                //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                xRight = dataTime[xRightSub];

                double m, n;
                GPSPanel.Refresh();
                m = (newPlace - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                n = (newPlace - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];

                PointF pp = new PointF();
                pp = new PointF((float)m, (float)n);
                g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                this.Update();
                if (newPlace <= maxValue(dataTime, dataTime.Length))
                    newPlace += 1;
                if (newPlace > maxValue(dataTime, dataTime.Length))
                {
                    flagPlace = false;
                    //this.GPSPanel.Refresh();
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
            }
        }

        private void sensorChart_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            if(flag)
            {
                double xx = sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(mouseX);
                if (fileOpen == true)
                {
                    if (xx >= dataTime[0] && xx <= dataTime[dtrNum - 1])
                    {
                        this.Refresh();
                        //draw the line with mouse click
                        Graphics g = sensorChart.CreateGraphics();
                        Point p1 = new Point(mouseX, 0);
                        Point p2 = new Point(mouseX, sensorChart.Height);
                        Pen np = new Pen(Brushes.Blue, 1);
                        g.DrawLine(np, p1, p2);

                        textBoxTime.Clear();
                        TextBox txtBox = new TextBox();
                        for (int i = 0; i < dtcNum - 1; i++)
                        {
                            txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(), true)[0];
                            if (txtBox != null)
                            {
                                txtBox.Text = "";
                            }
                        }
                        //calculate the place of mouse
                        textBoxTime.Text = Math.Round(xx, 2).ToString();
                        //find the Subscript with the xLeft
                        int xLeftSub = findLeftNear(xx, dataTime, dataTime.Length);
                        int xRightSub = xLeftSub + 1;
                        double xLeft = dataTime[xLeftSub], xRight = dataTime[xLeftSub];
                        //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                        xRight = dataTime[xRightSub];
                        for (int i = 0; i < dtcNum - 1; i++)
                        {
                            double k = (data[xLeftSub, i] - data[xRightSub, i]) / (xLeft - xRight);
                            double b = data[xLeftSub, i] - k * xLeft;
                            txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(), true)[0];
                            if (txtBox != null && sensorCheckedListBox.GetItemChecked(i))
                            {
                                txtBox.Text = Math.Round(k * xx + b, 8).ToString();
                            }
                        }
                        Graphics g2 = GPSPanel.CreateGraphics();

                        /*
                        PointF p11 = new PointF();
                        PointF p22 = new PointF();
                        Pen nPen = new Pen(Brushes.Red, 1);
                        for (int i = 0; i < dtrNum - 1; i++)
                        {
                            p11 = new PointF((float)x[i], (float)y[i]);
                            p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                            g2.DrawLine(nPen, p11, p22);
                        }*/

                        double m, n;
                        m = (xx - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                        n = (xx - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];

                        PointF pp = new PointF();
                        pp = new PointF((float)m, (float)n);
                        g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                    }
                }
            }
        }

        private void sensorChart_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void sensorChart_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void XRangeButton_Click(object sender, EventArgs e)
        {

            XRangeForm a = new XRangeForm();
            a.ShowDialog();
            xRangeMax = a.xRangeMax;
            xRangeMin = a.xRangeMin;
            xScale = a.xScale;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;

            sensorChart.Invalidate();
        }

        private void YRangeButton_Click(object sender, EventArgs e)
        {
            YRangeForm a = new YRangeForm();
            a.ShowDialog();
            yRangeMax = a.yRangeMax;
            yRangeMin = a.yRangeMin;
            yScale = a.yScale;

            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.Invalidate();
        }

        private void radioButton_Normal_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
            Graphics g2 = Graphics.FromImage(bitmap);
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 1);
            for (int i = 0; i < dtrNum - 1; i++)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(nPen, p11, p22);
            }
        }

        private void radioButton_Speed_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void radioButton_Accelerate_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void GPSPanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
            Graphics g2 = Graphics.FromImage(bitmap);
            if (radioButton_Normal.Checked) //normal
            {
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen nPen = new Pen(Brushes.Red, 1);
                for (int i = 0; i < dtrNum -1 ; i++)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(nPen, p11, p22);
                }
            }
            else if (radioButton_Speed.Checked) //speed
            {
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen p1 = new Pen(Brushes.Red, 1); //1
                Pen p2 = new Pen(Brushes.Green, 1);//5
                Pen p3 = new Pen(Brushes.Yellow, 1);//4
                Pen p4 = new Pen(Brushes.OrangeRed, 1);//2
                Pen p5 = new Pen(Brushes.Orange, 1);//3


                for (int i = 0; i < dtrNum - 1; i++)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    if (speed[i] < 2)
                        g2.DrawLine(p2, p11, p22);
                    else if (speed[i] > 2 && speed[i] < 10)
                        g2.DrawLine(p3, p11, p22);
                    else if (speed[i] > 10 && speed[i] < 15)
                        g2.DrawLine(p5, p11, p22);
                    else if (speed[i] > 15 && speed[i] < 20)
                        g2.DrawLine(p4, p11, p22);
                    else
                        g2.DrawLine(p1, p11, p22);
                }

            }
            else
            {

            }
            Graphics gg = GPSPanel.CreateGraphics();
            gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
        }
    }
}
