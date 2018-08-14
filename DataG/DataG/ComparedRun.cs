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
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Collections;

namespace DataG
{
    public partial class ComparedRun : Form
    {
        //constant variable
        const double EARTH_RAD_M = 6378100.00;                  //the radius of the earth (in meter)
        //global variables
        string fName1 = "";                                      //the name of opening file
        string fName2 = "";
        double[] dataTime = new double[dtrNum];
        double[] dataTime2 = new double[dtrNum2];
        double[,] data = new double[dtrNum, dtcNum - 1];
        double[,] data2 = new double[dtrNum2, dtcNum2 - 1];
        static DataTable dtSave = new DataTable();              //the datatable version of .csv file
        static DataTable dtSave2 = new DataTable();
        static int dtrNum = dtSave.Rows.Count;                  //the number of rows in dtSave
        static int dtrNum2 = dtSave2.Rows.Count;
        static int dtcNum = dtSave.Columns.Count + 1;           //the number of columns in dtSave
        static int dtcNum2 = dtSave2.Columns.Count + 1;

        string[] seriesName = new string[dtcNum - 1];           //the names of different sensors
        string[] seriesName2 = new string[dtcNum - 1];           //the names of different sensors
        double[] glpx = new double[dtrNum];                     //the x coordinate of 2D coordinate system
        double[] glpy = new double[dtrNum];                     //the y coordinate of 2D coordinate system
        double[] glpx2 = new double[dtrNum];                     //the x coordinate of 2D coordinate system
        double[] glpy2 = new double[dtrNum];
        double maxAbsX,maxAbsX2;                                         //the max abstract value of x coordinate
        double maxAbsY, maxAbsY2;                                         //the max abstract value of x coordinate
        double[] x = new double[dtrNum];                        //the x coordinate in GPSPannel
        double[] y = new double[dtrNum];       //the y coordinate in GPSPannel
        double[] x2 = new double[dtrNum2];                        //the x coordinate in GPSPannel
        double[] y2 = new double[dtrNum2];

        static int xRangeMax = 70;                              //the max value of x coordinate
        static int xRangeMin = 0;                               //the min value of x coordinate
        static int yRangeMax = 100;                             //the max value of y coordinate
        static int yRangeMin = 0;                               //the min value of y coordinate
        static int xScale = 40;                                 //the size of x view
        static double xInterval = 2.0;                          //the interval of x axis
        static string yType = "R1";                             //the type of y axis

        double nowScrollValue = -xScale / 2;                    //the position of scrollbar
        double newPlace = 0;                                    //the position of moving dot
        double nowSteeringPlace = 0;
        bool fileOpen = false;                                  //determine whether the file has been opened
        bool flag = false;                                      //drag line
        bool flagPlace = true;
        double moveSpeed = .1;                                  //the speed of play
        bool firstPlayFlag = true;                              //the flag of first play
        bool haveReset = true;
        Bitmap bitm;
        bool isBitCre = false;
        bool scaleFlag = true;
        bool flag_gps = false;

        double[] speed = new double[dtrNum];                    //the speed in the csv file
        int speedRow = 0;
        double[] speed2 = new double[dtrNum2];                    //the speed in the csv file
        int speedRow2 = 0;
        double[] accelerate = new double[dtrNum];               //the speed in the csv file
        int accelerateRow = 0;
        double[] accelerate2 = new double[dtrNum2];               //the speed in the csv file
        int accelerateRow2 = 0;

        

        double maxacc = 0;
        double minacc = 0;
        double maxspeed = 0;
        double minspeed = 0;

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public ChartArea caR2;
        public ChartArea caR3;
        public ChartArea caR4;

        bool isAccel = false;
        bool isAccel2 = false;

        double[] gpsTime = new double[dtrNum];

        public ComparedRun()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                if (array[i] <= value && array[i + 1] >= value)
                {
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

        void change(int no, ChartArea caR)
        {
            double[] point = new double[dtrNum];
            double[] after = new double[dtrNum];

            for (int j = 0; j < dtrNum; j++)
            {
                point[j] = double.Parse(dt.Rows[j][no + 1].ToString());
            }
            for (int j = 0; j < dtrNum; j++)
            {
                after[j] = (point[j] - caR.AxisY.Minimum) / (caR.AxisY.Maximum - caR.AxisY.Minimum) * (sensorChart.ChartAreas[0].AxisY.Maximum - sensorChart.ChartAreas[0].AxisY.Minimum);
            }
            sensorChart.Series[no].Points.Clear();
            sensorChart.Series[no].Points.DataBindXY(dataTime, after); //sensorChart.Series[0].Points.DataBindXY(dataTime, dataSensors);
            sensorChart.Series[no].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();

        }

        void rb1_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            //MessageBox.Show(no.ToString());
            double[] point = new double[dtrNum];
            sensorChart.Series[no].Points.Clear();
            double[] dataSensor = new double[dtrNum];
            for (int j = 0; j < dtrNum; j++)
            {
                dataSensor[j] = data[j, no];
            }


            sensorChart.Series[no].Points.DataBindXY(dataTime, dataSensor);
            sensorChart.Series[no].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();


        }

        void rb2_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            // MessageBox.Show(no.ToString());
            change(no, caR2);
        }

        void rb3_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            change(no, caR3);
        }

        void rb4_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            change(no, caR4);
        }

        private void fileLoadingButton_Click(object sender, EventArgs e)
        {
            fileOpen = false;
            isBitCre = false;
            //delete existing chart
            sensorChart.Series.Clear();
            sensorChart.ChartAreas.Clear();
            sensorChart.ChartAreas.Add(new ChartArea("ChartArea1"));
            sensorChart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10000;
            sensorChart.ChartAreas[0].AxisX.LabelStyle.Format = "N2";
            //delete all textboxes, checkboxes and radiobuttons
            displayPanel.Controls.Clear();
            displayPanel.Controls.Add(label4);
            displayPanel.Controls.Add(allSelectedCheckBox);
            displayPanel.Controls.Add(allSelectedCheckBox2);
            sensorCheckedListBox.Items.Clear();
            displayPanel.Controls.Add(sensorCheckedListBox);
            displayPanel.Controls.Add(sensorCheckedListBox2);
            YPanel.Controls.Clear();
            GPSPanel.Refresh();

            ComparedRun_FileLoadingForm crFLF = new ComparedRun_FileLoadingForm();
            crFLF.ShowDialog();
            fName1 = crFLF.firstFileName;
            fName2 = crFLF.secondFileName;

            if (fName1 == "" || fName2 == "")
            {
                return;
            }
            dt = OpenCSV(fName1);
            dt2 = OpenCSV(fName2);
            fileOpen = true;
            dtSave = dt;
            dtSave2 = dt2;
            dtrNum = dt.Rows.Count;
            dtrNum2 = dt2.Rows.Count;
            
            dtcNum = dt.Columns.Count;
            dtcNum2 = dt2.Columns.Count;
            if (dtcNum != dtcNum2)
            {
                MessageBox.Show("Two files have different formate.");
                return;
            }

            data = new double[dtrNum, dtcNum - 1];
            data2 = new double[dtrNum2, dtcNum - 1];
            speed = new double[dtrNum];
            speed2 = new double[dtrNum2];
            dataTime = new double[dtrNum];
            dataTime2 = new double[dtrNum2];
            seriesName = new string[dtcNum - 1];
            seriesName2 = new string[dtcNum - 1];

            for (int i = 0; i < dtrNum; i++)
            {
                dataTime[i] = double.Parse(dt.Rows[i][0].ToString());
                dataTime[i] = Math.Round(dataTime[i], 2);
                for (int j = 0; j < dtcNum - 1; j++)
                {
                    data[i, j] = double.Parse(dt.Rows[i][j + 1].ToString());
                }
            }
            for (int i = 0; i < dtrNum2; i++)
            {
                dataTime2[i] = double.Parse(dt2.Rows[i][0].ToString());
                dataTime2[i] = Math.Round(dataTime2[i], 2);
                for (int j = 0; j < dtcNum2 - 1; j++)
                {
                    data2[i, j] = double.Parse(dt2.Rows[i][j + 1].ToString());
                }
            }

            double k = dataTime[0];
            for (int i = 0; i < dtrNum; i++)
            {
                dataTime[i] = dataTime[i] - k;
            }

            k = dataTime2[0];
            for (int i = 0; i < dtrNum2; i++)
            {
                dataTime2[i] = dataTime2[i] - k;
                
            }
            if (dataTime2[2] - dataTime2[1] == 1)
            {
                for (int i = 0; i < dtrNum2; i++)
                    dataTime2[i] = dataTime2[i] / 10;
            }
                

            for (int i = 0; i < dtcNum - 1; i++)
            {
                seriesName[i] = dt.Columns[i + 1].ColumnName;
                seriesName[i] = seriesName[i] + "_1";
                seriesName2[i] = dt2.Columns[i + 1].ColumnName;
                seriesName2[i] = seriesName2[i] + "_2";
                if (dt.Columns[i + 1].ColumnName != dt2.Columns[i + 1].ColumnName) return;
            }
            for (int i = 0; i < dtcNum - 1; i++)
            {
                if (seriesName[i].IndexOf("speed") >= 0 || seriesName[i].IndexOf("SPEED") >= 0 || seriesName[i].IndexOf("Speed") >= 0)
                {
                    speedRow = i;
                    break;
                }
            }

            for (int i = 0; i < dtcNum - 1; i++)
            {
                if (seriesName2[i].IndexOf("speed") >= 0 || seriesName2[i].IndexOf("SPEED") >= 0 || seriesName2[i].IndexOf("Speed") >= 0)
                {
                    speedRow2 = i;
                    break;
                }
            }

            for (int i = 0; i < dtcNum - 1; i++)
            {
                if (seriesName[i].Contains("ACCEL_Y(g)"))
                {
                    accelerateRow = i;
                    isAccel = true;
                    break;
                }
                else
                    isAccel = false;
            }

            for (int i = 0; i < dtcNum - 1; i++)
            {
                if (seriesName2[i].Contains("ACCEL_Y(g)"))
                {
                    accelerateRow2 = i;
                    isAccel2 = true;
                    break;
                }
                else
                    isAccel2 = false;
            }

            for (int i = 0; i < dtrNum; i++)
            {
                speed[i] = double.Parse(dt.Rows[i][speedRow + 1].ToString());
                if (isAccel)
                    accelerate[i] = double.Parse(dt.Rows[i][accelerateRow + 1].ToString());
            }

            for (int i = 0; i < dtrNum2; i++)
            {
                speed2[i] = double.Parse(dt2.Rows[i][speedRow2 + 1].ToString());
                if (isAccel2)
                    accelerate2[i] = double.Parse(dt2.Rows[i][accelerateRow2 + 1].ToString());
            }


            InputForm a = new InputForm();
            a.Names = new string[dtcNum - 1];
            for (int i = 0; i < dtcNum - 1; i++)
            {
                a.Names[i] = dt.Columns[i + 1].ColumnName;
            }
            a.ShowDialog();
            string latName = a.latName;
            string lonName = a.lonName;

            if (latName.Equals("") || lonName.Equals(""))
            {
                MessageBox.Show("No column selected for latitude and lontitude!");
                fileOpen = false;
                return;
            }

            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = xInterval;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yRangeMax - yRangeMin;

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

                Series s2 = new Series(seriesName2[i]);
                double[] dataSensor2 = new double[dtrNum2];
                for (int j = 0; j < dtrNum2; j++)
                {
                    dataSensor2[j] = data2[j, i];
                }
                s2.Points.DataBindXY(dataTime2, dataSensor2);
                s2.ChartType = SeriesChartType.Line;
                sensorChart.Series.Add(s2);
            }

            double[] datA = new double[dtrNum];     //the latitude1
            double[] datO = new double[dtrNum];     //the longtitude2

            double[] datA2 = new double[dtrNum2];     //the latitude1
            double[] datO2 = new double[dtrNum2];     //the longtitude2

            for (int i = 0; i < dtrNum; i++)
            {
                datA[i] = data[i, findStrSub(latName + "_1", seriesName, dtcNum - 1)];
                datA[i] *= 0.017453293;
                datO[i] = data[i, findStrSub(lonName + "_1", seriesName, dtcNum - 1)];
                datO[i] *= 0.017453293;
            }
            for (int i = 0; i < dtrNum2; i++)
            {
                datA2[i] = data2[i, findStrSub(latName + "_2", seriesName2, dtcNum2 - 1)];
                datA2[i] *= 0.017453293;
                datO2[i] = data2[i, findStrSub(lonName + "_2", seriesName2, dtcNum2 - 1)];
                datO2[i] *= 0.017453293;
            }
            //convert from lat and lon to x,y
            glpx = new double[dtrNum];
            glpy = new double[dtrNum];

            glpx2 = new double[dtrNum2];
            glpy2 = new double[dtrNum2];

            for (int i = 0; i < dtrNum; i++)
            {
                glpx[i] = (datO[i] - datO[0]) * EARTH_RAD_M;
                glpy[i] = (datA[i] - datA[0]) * EARTH_RAD_M * Math.Sin(datO[i]);
            }
            for (int i = 0; i < dtrNum2; i++)
            {
                glpx2[i] = (datO2[i] - datO2[0]) * EARTH_RAD_M;
                glpy2[i] = (datA2[i] - datA2[0]) * EARTH_RAD_M * Math.Sin(datO2[i]);
            }
            //change the original (x,y) to the position of panel
            maxAbsX = Math.Max(maxAbsValue(glpx, dtrNum), maxAbsValue(glpx2, dtrNum2));
            maxAbsY = Math.Max(maxAbsValue(glpy, dtrNum), maxAbsValue(glpy2, dtrNum2));


            x = new double[dtrNum];
            y = new double[dtrNum];
            x2 = new double[dtrNum2];
            y2 = new double[dtrNum2];
            for (int i = 0; i < dtrNum; i++)
            {
                x[i] = (maxAbsX + glpx[i]) * 0.5 * (GPSPanel.Width) / maxAbsX;
                y[i] = (maxAbsY - glpy[i]) * 0.5 * (GPSPanel.Height) / maxAbsY;
            }
            for (int i = 0; i < dtrNum2; i++)
            {
                x2[i] = (maxAbsX + glpx2[i]) * 0.5 * (GPSPanel.Width) / maxAbsX;
                y2[i] = (maxAbsY - glpy2[i]) * 0.5 * (GPSPanel.Height) / maxAbsY;
            }

            GPSPanel.Refresh();
            //add new labels and checkbox
            for (int i = 0; i < dtcNum - 1; i++)
            {
                //add checkbox to checklist box
                sensorCheckedListBox.Items.Add(seriesName[i], true);
                sensorCheckedListBox2.Items.Add(seriesName2[i], true);
                //add panels to YPanel
                Panel pan = new Panel();
                Point pl = new Point(0, 0);
                pan.Height = 30;
                pan.Name = seriesName[i] + "Panel";
                pl.Y += i * pan.Height;
                pan.Location = pl;
                pan.Width = YPanel.Width - 20;
                //pan.BorderStyle = BorderStyle.FixedSingle;
                YPanel.Controls.Add(pan);
                //add label to pan
                Label la = new Label();
                la.Text = dt.Columns[i + 1].ColumnName;
                la.Location = new Point(0, 8);
                la.Height = pan.Height;
                la.Width = pan.Width / 2;
                pan.Controls.Add(la);

                //add radiobutton to pan
                RadioButton rb1 = new RadioButton();
                rb1.Text = "R1";
                rb1.Location = new Point(pan.Width / 2, 0);
                rb1.Width = pan.Width / 8;
                rb1.Height = pan.Height;
                rb1.Checked = true;
                rb1.Name = "R1_" + i.ToString();
                pan.Controls.Add(rb1);
                RadioButton rb2 = new RadioButton();
                rb2.Text = "R2";
                rb2.Location = new Point(pan.Width * 5 / 8, 0);
                rb2.Width = pan.Width / 8;
                rb2.Height = pan.Height;
                rb2.Name = "R2_" + i.ToString();
                pan.Controls.Add(rb2);
                RadioButton rb3 = new RadioButton();
                rb3.Text = "R3";
                rb3.Location = new Point(pan.Width * 6 / 8, 0);
                rb3.Width = pan.Width / 8;
                rb3.Height = pan.Height;
                rb3.Name = "R3_" + i.ToString();
                pan.Controls.Add(rb3);
                RadioButton rb4 = new RadioButton();
                rb4.Text = "R4";
                rb4.Location = new Point(pan.Width * 7 / 8, 0);
                rb4.Width = pan.Width / 8;
                rb4.Height = pan.Height;
                rb4.Name = "R4_" + i.ToString();
                pan.Controls.Add(rb4);
                rb1.Click += rb1_Click;
                rb2.Click += rb2_Click;
                rb3.Click += rb3_Click;
                rb4.Click += rb4_Click;
            }
            nowScrollValue = (int)minValue(dataTime, dataTime.Length);
            newPlace = (int)minValue(dataTime, dataTime.Length);
            sensorChart.ChartAreas[0].InnerPlotPosition.X = (float)45;
            sensorChart.ChartAreas[0].InnerPlotPosition.Height = (float)90;
            //create 3 other chartareas for R2, R3, R4 Axises
            sensorChart.ChartAreas[0].AxisY.Title = "R1";
            sensorChart.ChartAreas[0].Name = "R1";
            Series sCopy2 = sensorChart.Series.Add("R2Copy");
            sCopy2.ChartType = sensorChart.Series[0].ChartType;
            foreach (DataPoint point in sensorChart.Series[0].Points)
            {
                sCopy2.Points.AddXY(point.XValue, point.YValues[0]);
            }
            sCopy2.IsVisibleInLegend = false;
            sCopy2.Color = Color.Transparent;
            sCopy2.BorderColor = Color.Transparent;

            this.Refresh();
            caR2 = sensorChart.ChartAreas.Add("R2");
            caR2.BackColor = Color.Transparent;
            caR2.BorderColor = Color.Transparent;
            caR2.Position.FromRectangleF(sensorChart.ChartAreas[0].Position.ToRectangleF());
            caR2.InnerPlotPosition.FromRectangleF(sensorChart.ChartAreas[0].InnerPlotPosition.ToRectangleF());
            caR2.InnerPlotPosition.X -= (float)12;
            caR2.AxisX.MajorGrid.Enabled = false;
            caR2.AxisX.MajorTickMark.Enabled = false;
            caR2.AxisX.LabelStyle.Enabled = false;
            caR2.AxisX.Enabled = AxisEnabled.False;
            caR2.AxisY.MajorGrid.Enabled = false;
            caR2.AxisY.LineColor = Color.Black;
            caR2.AxisY.Title = "R2";
            caR2.AxisY.Maximum = 2;
            caR2.AxisY.Minimum = -2;
            caR2.AxisY.IsStartedFromZero = sensorChart.ChartAreas[0].AxisY.IsStartedFromZero;
            sCopy2.ChartArea = caR2.Name;

            Series sCopy3 = sensorChart.Series.Add("R3Copy");
            sCopy3.ChartType = sensorChart.Series[0].ChartType;
            foreach (DataPoint point in sensorChart.Series[0].Points)
            {
                sCopy3.Points.AddXY(point.XValue, point.YValues[0]);
            }
            sCopy3.IsVisibleInLegend = false;
            sCopy3.Color = Color.Transparent;
            sCopy3.BorderColor = Color.Transparent;

            caR3 = sensorChart.ChartAreas.Add("R3");
            caR3.BackColor = Color.Transparent;
            caR3.BorderColor = Color.Transparent;
            caR3.Position.FromRectangleF(caR2.Position.ToRectangleF());
            caR3.InnerPlotPosition.FromRectangleF(caR2.InnerPlotPosition.ToRectangleF());
            caR3.InnerPlotPosition.X -= (float)12;
            caR3.AxisX.MajorGrid.Enabled = false;
            caR3.AxisX.MajorTickMark.Enabled = false;
            caR3.AxisX.LabelStyle.Enabled = false;
            caR3.AxisX.Enabled = AxisEnabled.False;
            caR3.AxisY.MajorGrid.Enabled = false;
            caR3.AxisY.Title = "R3";
            caR3.AxisY.Maximum = 80;
            caR3.AxisY.Minimum = 0;
            caR3.AxisY.IsStartedFromZero = sensorChart.ChartAreas[0].AxisY.IsStartedFromZero;
            sCopy3.ChartArea = caR3.Name;

            Series sCopy4 = sensorChart.Series.Add("R4Copy");
            sCopy4.ChartType = sensorChart.Series[0].ChartType;
            foreach (DataPoint point in sensorChart.Series[0].Points)
            {
                sCopy4.Points.AddXY(point.XValue, point.YValues[0]);
            }
            sCopy4.IsVisibleInLegend = false;
            sCopy4.Color = Color.Transparent;
            sCopy4.BorderColor = Color.Transparent;

            caR4 = sensorChart.ChartAreas.Add("R4");
            caR4.BackColor = Color.Transparent;
            caR4.BorderColor = Color.Transparent;
            caR4.Position.FromRectangleF(caR3.Position.ToRectangleF());
            caR4.InnerPlotPosition.FromRectangleF(caR3.InnerPlotPosition.ToRectangleF());
            caR4.InnerPlotPosition.X -= (float)12;
            caR4.AxisX.MajorGrid.Enabled = false;
            caR4.AxisX.MajorTickMark.Enabled = false;
            caR4.AxisX.LabelStyle.Enabled = false;
            caR4.AxisX.Enabled = AxisEnabled.False;
            caR4.AxisY.MajorGrid.Enabled = false;
            caR4.AxisY.Title = "R4";
            caR4.AxisY.Maximum = 8000;
            caR4.AxisY.Minimum = 0;
            caR4.AxisY.IsStartedFromZero = sensorChart.ChartAreas[0].AxisY.IsStartedFromZero;
            sCopy4.ChartArea = caR4.Name;
            
        }

        private void sensorCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            if (index < seriesName.Length)
            {
                Series sz = sensorChart.Series[seriesName[index]];
                sz.Enabled = !sensorCheckedListBox.GetItemChecked(index);
            }

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
                    this.Refresh();

                    //draw the line with mouse click
                    Graphics g = sensorChart.CreateGraphics();
                    Point p1 = new Point(mouseX, 0);
                    Point p2 = new Point(mouseX, sensorChart.Height);
                    Pen np = new Pen(Brushes.Blue, 1);
                    g.DrawLine(np, p1, p2);
                    //find the Subscript with the xLeft
                    int xLeftSub = findLeftNear(xx, dataTime, dataTime.Length);
                    int xRightSub = xLeftSub + 1;
                    double xLeft = dataTime[xLeftSub], xRight = dataTime[xLeftSub];
                    //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                    xRight = dataTime[xRightSub];
                    //MessageBox.Show(xLeftSub.ToString());
                    Graphics g2 = GPSPanel.CreateGraphics();
                if (xx >= dataTime[0] && xx <= dataTime[dtrNum - 1])
                {
                    double m, n;
                    m = (xx - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                    n = (xx - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];

                    PointF pp = new PointF();
                    pp = new PointF((float)m, (float)n);
                    //MessageBox.Show(pp.X.ToString() + " " + pp.Y.ToString());
                    g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                }
                if(xx <= dataTime2[dtrNum2 - 1])
                {
                    double m2, n2;
                    m2 = (xx - xLeft) / (xRight - xLeft) * (x2[xRightSub] - x2[xLeftSub]) + x2[xLeftSub];
                    n2 = (xx - xLeft) / (xRight - xLeft) * (y2[xRightSub] - y2[xLeftSub]) + y2[xLeftSub];
                    
                    PointF pp2 = new PointF();
                    pp2 = new PointF((float)m2, (float)n2);
                    
                    g2.FillEllipse(Brushes.Gray, pp2.X, pp2.Y, 5, 5);
                }

            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (fileOpen == true)
            {
                if (firstPlayFlag == true)
                {
                    resetButton_Click(sender, e);
                    firstPlayFlag = false;
                }
                if (haveReset == true)
                {
                    ChartArea ca = new ChartArea();
                    ca = sensorChart.ChartAreas.Add("Vertical");
                    ca.BackColor = Color.Transparent;
                    ca.BorderColor = Color.Transparent;
                    ca.Position.FromRectangleF(sensorChart.ChartAreas[0].Position.ToRectangleF());
                    ca.InnerPlotPosition.FromRectangleF(sensorChart.ChartAreas[0].InnerPlotPosition.ToRectangleF());
                    //ca.InnerPlotPosition.X = (sensorChart.ChartAreas[0].Position.X + sensorChart.ChartAreas[0].Position.Right) / 2;
                    ca.AxisY.MajorGrid.Enabled = false;
                    ca.AxisY.MajorTickMark.Enabled = false;
                    ca.AxisY.LabelStyle.Enabled = false;
                    ca.AxisY.Enabled = AxisEnabled.False;

                    ca.AxisX.MajorGrid.Enabled = false;
                    ca.AxisX.LineColor = Color.Black;
                    ca.AxisX.MajorGrid.Enabled = true;
                    ca.AxisX.Maximum = 2;
                    ca.AxisX.Minimum = 0;
                    ca.AxisX.Interval = 1;
                    ca.AxisX.MajorTickMark.Enabled = false;
                    ca.AxisX.LabelStyle.Enabled = false;
                    //ca.AxisY.IsStartedFromZero = sensorChart.ChartAreas[0].AxisY.IsStartedFromZero; 

                    Series sCopy2 = sensorChart.Series.Add("caS");
                    sCopy2.ChartType = sensorChart.Series[0].ChartType;
                    foreach (DataPoint point in sensorChart.Series[0].Points)
                    {
                        sCopy2.Points.AddXY(point.XValue, point.YValues[0]);
                    }
                    sCopy2.IsVisibleInLegend = false;
                    sCopy2.Color = Color.Transparent;
                    sCopy2.BorderColor = Color.Transparent;
                    sCopy2.ChartArea = ca.Name;
                    haveReset = false;
                }


                chartTimer.Interval = (int)(1000 * moveSpeed);
                chartTimer.Enabled = true;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = xInterval;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            sensorChart.Invalidate();
            chartTimer.Enabled = false;
            flagPlace = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (fileOpen == true)
            {
                sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
                sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
                sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
                sensorChart.ChartAreas[0].AxisX.Interval = xInterval;
                sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
                sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
                sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

                nowScrollValue = (int)minValue(dataTime, dataTime.Length) - xScale / 2;
                newPlace = (int)minValue(dataTime, dataTime.Length) - xScale / 2;
                nowSteeringPlace = 0;
                sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue + xScale / 2;
                if (firstPlayFlag == false)
                {
                    //sensorChart.ChartAreas["Vertical"].Dispose();
                    sensorChart.ChartAreas.Remove(sensorChart.ChartAreas["Vertical"]);
                    sensorChart.Series.Remove(sensorChart.Series["caS"]);
                }


                sensorChart.Invalidate();
                chartTimer.Enabled = false;

                GPSPanel.Refresh();
                flagPlace = true;
                scaleFlag = true;
                haveReset = true;

            }
        }

        private void chartTimer_Tick(object sender, EventArgs e)
        {
            //FileStream fs1 = File.OpenWrite(@"C:\Users\user\Desktop\1.txt");
            //FileStream fs2 = File.OpenWrite(@"C:\Users\user\Desktop\2.txt");
            //chartTimer.Interval = (int)(1000 * moveSpeed);
            DateTime beforDT = System.DateTime.Now;
            //sensorChart.PostPaint += new EventHandler<ChartPaintEventArgs>(sensorChart_PostPaint);
            int xLeftSub3 = findLeftNear(nowSteeringPlace, dataTime, dataTime.Length);
            //xxx += 10;
            if ((nowScrollValue + xScale / 2) >= minValue(dataTime, dataTime.Length) && (nowScrollValue + xScale / 2) <= maxValue(dataTime, dataTime.Length))
            {
                for (int i = 0; i < dtcNum - 1; i++)
                {
                    if (sensorCheckedListBox.GetItemChecked(i))
                    {
                        double xx = 0;
                        if ((nowScrollValue + xScale / 2) < xScale / 2)
                            xx = nowScrollValue + xScale / 2 + moveSpeed;
                        else
                            xx = nowScrollValue + xScale / 2 + moveSpeed - 0.1;
                        int xLeftSub2 = findLeftNear(xx, dataTime, dataTime.Length);
                        //int xRightSub2 = xLeftSub2 + 1;
                        //double xLeft2 = dataTime[xLeftSub2], xRight2 = dataTime[xRightSub2];
                        //double k = (data[xLeftSub2, i] - data[xRightSub2, i]) / (xLeft2 - xRight2);
                        //double b = data[xLeftSub2, i] - k * xLeft2;
                        //txtBox.Text = Math.Round(k * xx + b, 8).ToString();

                    }
                }
            }
            DateTime afterDT2 = System.DateTime.Now;
            TimeSpan ts2 = afterDT2.Subtract(beforDT);
            //fs1.Position = fs1.Length;
            //string s1 = ts2.TotalMilliseconds.ToString()+"\r\n";
            //Encoding encoder = Encoding.UTF8;
            //byte[] bytes = encoder.GetBytes(s1);  
            //fs1.Write(bytes,0,bytes.Length);
            //fs1.Close();
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;
            if ((nowScrollValue + xScale / 2) < xScale / 2)
            {
                nowScrollValue += moveSpeed;
            }
            else if ((nowScrollValue + xScale / 2) <= maxValue(dataTime, dataTime.Length))
            {
                if (scaleFlag == true)
                {
                    scaleFlag = false;
                    nowScrollValue += 0.1;
                }
                nowScrollValue += moveSpeed;
            }

            //sensorChart.Invalidate();

            if (flagPlace == true)
            {
                Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitmap);
                //find the Subscript with the xLeft
                double xx2 = newPlace + xScale / 2 + moveSpeed;
                int xLeftSub = xLeftSub3;// findLeftNear(xx2, dataTime, dataTime.Length);
                int xRightSub = xLeftSub + 1;
                double xLeft = dataTime[xLeftSub], xRight = dataTime[xRightSub];
                //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])

                double m, n, m2, n2;
                GPSPanel.Refresh();
                //m = (xx2 - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                //n = (xx2 - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];
                m = x[xLeftSub];
                n = y[xLeftSub];
                
                Graphics g3 = GPSPanel.CreateGraphics();
                PointF pp = new PointF();
                PointF pp2 = new PointF();
                pp = new PointF((float)m, (float)n);
                
                g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                if(xx2 <= dataTime2[dtrNum2 - 1])
                {
                    m2 = x2[xLeftSub];
                    n2 = y2[xLeftSub];
                    pp2 = new PointF((float)m2, (float)n2);
                    g3.FillEllipse(Brushes.Gray, pp2.X, pp2.Y, 5, 5);

                }
               
                this.Update();
                if ((newPlace + moveSpeed) <= maxValue(dataTime, dataTime.Length))
                {
                    newPlace += moveSpeed;
                }
                else
                {
                    flagPlace = false;
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
            }
            //int xLeftSub3 = findLeftNear(nowSteeringPlace, dataTime, dataTime.Length);
            if (nowSteeringPlace <= maxValue(dataTime, dataTime.Length))
                nowSteeringPlace += moveSpeed;

            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            //fs2.Position = fs2.Length;
            //string s2 = ts.TotalMilliseconds.ToString() + "\r\n";
            //Encoding encoder2 = Encoding.UTF8;
            //byte[] bytes2 = encoder.GetBytes(s2);
            //fs2.Write(bytes2, 0, bytes2.Length);
            //fs2.Close();
            if ((int)ts.TotalMilliseconds >= (int)(1000 * moveSpeed))
                chartTimer.Interval = 1;
            else
                chartTimer.Interval = (int)(1000 * moveSpeed) - (int)ts.TotalMilliseconds;
        }

        private void sensorChart_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            if (flag)
            {
                double xx = sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(mouseX);
                if (fileOpen == true)
                {
                    this.Refresh();
                        //draw the line with mouse click
                    Graphics g = sensorChart.CreateGraphics();
                    Point p1 = new Point(mouseX, 0);
                    Point p2 = new Point(mouseX, sensorChart.Height);
                    Pen np = new Pen(Brushes.Blue, 1);
                    g.DrawLine(np, p1, p2);
                    //find the Subscript with the xLeft
                    int xLeftSub = findLeftNear(xx, dataTime, dataTime.Length);
                    int xRightSub = xLeftSub + 1;
                    double xLeft = dataTime[xLeftSub], xRight = dataTime[xLeftSub];
                        //two points:A(xLeft,datY[xLeftSub]),B(xRight,datY[xRightSub])
                    xRight = dataTime[xRightSub];
                        
                    Graphics g2 = GPSPanel.CreateGraphics();
                    if (xx >= dataTime[0] && xx <= dataTime[dtrNum - 1])
                    {
                        double m, n;
                        m = (xx - xLeft) / (xRight - xLeft) * (x[xRightSub] - x[xLeftSub]) + x[xLeftSub];
                        n = (xx - xLeft) / (xRight - xLeft) * (y[xRightSub] - y[xLeftSub]) + y[xLeftSub];

                        PointF pp = new PointF();
                        pp = new PointF((float)m, (float)n);
                        //MessageBox.Show(pp.X.ToString() + " " + pp.Y.ToString());
                        g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                    }
                    if (xx <= dataTime2[dtrNum2 - 1])
                    {
                        double m2, n2;
                        m2 = (xx - xLeft) / (xRight - xLeft) * (x2[xRightSub] - x2[xLeftSub]) + x2[xLeftSub];
                        n2 = (xx - xLeft) / (xRight - xLeft) * (y2[xRightSub] - y2[xLeftSub]) + y2[xLeftSub];

                        PointF pp2 = new PointF();
                        pp2 = new PointF((float)m2, (float)n2);

                        g2.FillEllipse(Brushes.Gray, pp2.X, pp2.Y, 5, 5);
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

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            if (fileOpen == false)
            {
                return;
            }
            RangeForm a = new RangeForm();
            a.yMax1 = yRangeMax;
            a.yMin1 = yRangeMin;
            a.xRangeMax = xRangeMax;
            a.xRangeMin = xRangeMin;
            a.xScale = xScale;
            a.interval = xInterval;
            a.yType = yType;
            a.yMax2 = caR2.AxisY.Maximum;
            a.yMax3 = caR3.AxisY.Maximum;
            a.yMax4 = caR4.AxisY.Maximum;
            a.yMin2 = caR2.AxisY.Minimum;
            a.yMin3 = caR3.AxisY.Minimum;
            a.yMin4 = caR4.AxisY.Minimum;
            a.speed = moveSpeed;
            a.ShowDialog();
            yRangeMax = a.yMax1;
            yRangeMin = a.yMin1;
            xRangeMax = a.xRangeMax;
            xRangeMin = a.xRangeMin;
            xScale = a.xScale;
            xInterval = a.interval;
            yType = a.yType;
            moveSpeed = a.speed;
            int i = int.Parse(yType[1].ToString());
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = xInterval;

            sensorChart.ChartAreas["R" + i.ToString()].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas["R" + i.ToString()].AxisY.Minimum = yRangeMin;
            sensorChart.ChartAreas["R" + i.ToString()].AxisY.ScaleView.Size = yRangeMax - yRangeMin;
            for (int j = 0; j < dtcNum - 1; j++)
            {
                string s = "R" + i.ToString() + "_" + j.ToString();

                RadioButton rb = new RadioButton();
                rb = (RadioButton)this.Controls.Find(s, true)[0];
                if (rb.Checked == true)
                {
                    if (i == 1) rb1_Click(rb, e);
                    else if (i == 2) rb2_Click(rb, e);
                    else if (i == 3) rb3_Click(rb, e);
                    else if (i == 4) rb4_Click(rb, e);
                }


            }
            sensorChart.Invalidate();

        }

        private void radioButton_Normal_CheckedChanged(object sender, EventArgs e)
        {
            //Refresh();
            Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
            Graphics g2 = Graphics.FromImage(bitmap);
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            Pen nPen = new Pen(Brushes.Red, 2);
            for (int i = 0; i < dtrNum - 1; i++)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(nPen, p11, p22);
            }
            Graphics gg = GPSPanel.CreateGraphics();
            gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
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
            if (isBitCre == false && fileOpen == true)
            {
                bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitm);
                if (radioButton_Normal.Checked) //normal
                {
                    PointF p11 = new PointF();
                    PointF p22 = new PointF();
                    Pen nPen = new Pen(Brushes.Red, 2);
                    Pen nPen3 = new Pen(Brushes.Green, 2);
                    for (int i = 0; i < dtrNum - 1; i += 1)
                    {
                        p11 = new PointF((float)x[i], (float)y[i]);
                        p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                        g2.DrawLine(nPen, p11, p22);
                    }
                    for (int i = 0; i < dtrNum2 - 1; i += 1)
                    {
                        p11 = new PointF((float)x2[i], (float)y2[i]);
                        p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                        g2.DrawLine(nPen3, p11, p22);
                    }
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                }
                else if (radioButton_Speed.Checked) //speed
                {
                    bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                    Graphics g3 = Graphics.FromImage(bitm);
                    PointF p11 = new PointF();
                    PointF p22 = new PointF();
                    Pen p6;
                    maxspeed = maxValue(speed, dtrNum);
                    minspeed = minValue(speed, dtrNum);
                    for (int i = 0; i < dtrNum - 1; i++)
                    {
                        p11 = new PointF((float)x[i], (float)y[i]);
                        p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                        p6 = new Pen(Color.FromArgb(colorRed(speed[i], maxspeed, minspeed), colorGreen(speed[i], maxspeed, minspeed), 0), 2);
                        g3.DrawLine(p6, p11, p22);
                    }
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                }
                else
                {
                    bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                    Graphics g4 = Graphics.FromImage(bitm);
                    PointF p11 = new PointF();
                    PointF p22 = new PointF();
                    Pen p6;
                    maxacc = maxValue(accelerate, dtrNum);
                    minacc = minValue(accelerate, dtrNum);
                    for (int i = 0; i < dtrNum - 1; i++)
                    {
                        p11 = new PointF((float)x[i], (float)y[i]);
                        p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                        p6 = new Pen(Color.FromArgb(colorRed(accelerate[i], maxacc, minacc), colorGreen(accelerate[i], maxacc, minacc), 0), 2);
                        g4.DrawLine(p6, p11, p22);
                    }
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                }
                //Graphics gg = GPSPanel.CreateGraphics();
                //gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                isBitCre = true;
            }
            else if (fileOpen == true)
            {
                //if (radioButton_Normal.Checked) //speed
                //{
                //    Graphics gg2 = GPSPanel.CreateGraphics();
                //    gg2.DrawImage(bitm, new PointF(0.0f, 0.0f));
                //}

                if (radioButton_Speed.Checked) //speed
                {
                    bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                    Graphics g3 = Graphics.FromImage(bitm);
                    PointF p11 = new PointF();
                    PointF p22 = new PointF();
                    Pen p6;
                    maxspeed = maxValue(speed, dtrNum);
                    minspeed = minValue(speed, dtrNum);
                    for (int i = 0; i < dtrNum - 1; i++)
                    {
                        p11 = new PointF((float)x[i], (float)y[i]);
                        p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                        p6 = new Pen(Color.FromArgb(colorRed(speed[i], maxspeed, minspeed), colorGreen(speed[i], maxspeed, minspeed), 0), 2);
                        g3.DrawLine(p6, p11, p22);
                    }
                    //Graphics gg = GPSPanel.CreateGraphics();
                    //gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                }
                if (radioButton_Accelerate.Checked && isAccel)
                {
                    bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                    Graphics g4 = Graphics.FromImage(bitm);
                    PointF p11 = new PointF();
                    PointF p22 = new PointF();
                    Pen p6;
                    maxacc = maxValue(accelerate, dtrNum);
                    minacc = minValue(accelerate, dtrNum);
                    for (int i = 0; i < dtrNum - 1; i++)
                    {
                        p11 = new PointF((float)x[i], (float)y[i]);
                        p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                        p6 = new Pen(Color.FromArgb(colorRed(accelerate[i], maxacc, minacc), colorGreen(accelerate[i], maxacc, minacc), 0), 2);
                        g4.DrawLine(p6, p11, p22);
                    }
                    //Graphics gg = GPSPanel.CreateGraphics();
                    //gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
            }

        }

        public int colorRed(double x, double max, double min)//xx,,
        {
            double len = max - min;
            double tlen = max - x;

            if (tlen / len >= 0.5)
            {
                return 255;

            }
            else
            {
                int k = Convert.ToInt32(2 * ((tlen) / len) * 255);
                return k;

            }

        }

        public int colorGreen(double x, double max, double min)//,xx,
        {
            double len = max - min;
            double tlen = max - x;

            if (tlen / len >= 0.5)
            {
                int k = Convert.ToInt32(2 * ((len - tlen) / len) * 255);
                return k;

            }
            else
            {
                return 255;

            }

        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            if (fileOpen == false)
            {
                return;
            }
            //read setting.log file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c://";
            openFileDialog.Filter = "Log Files|*.log";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            string fileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            if (fileName.Equals(""))
            {
                MessageBox.Show("No file choosed!");
                return;
            }
            string[] sArray = File.ReadAllLines(fileName);
            //handle the x range
            string xR = sArray[0];
            xRangeMin = int.Parse(Regex.Split(xR, " ", RegexOptions.IgnoreCase)[2]);
            xRangeMax = int.Parse(Regex.Split(xR, " ", RegexOptions.IgnoreCase)[4]);
            //handle the x scale
            string xS = sArray[1];
            xScale = int.Parse(Regex.Split(xS, " ", RegexOptions.IgnoreCase)[2]);
            //handle the x interval
            string xi = sArray[2];
            xInterval = double.Parse(Regex.Split(xi, " ", RegexOptions.IgnoreCase)[2]);
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = xInterval;
            for (int i = 1; i <= 4; i++)
            {
                //determine y type
                string yT = sArray[i * 2 + 1];
                yType = Regex.Split(yT, ":", RegexOptions.IgnoreCase)[0];
                //handle the y range
                string yR = sArray[i * 2 + 2];
                yRangeMin = int.Parse(Regex.Split(yR, " ", RegexOptions.IgnoreCase)[2]);
                yRangeMax = int.Parse(Regex.Split(yR, " ", RegexOptions.IgnoreCase)[4]);


                sensorChart.ChartAreas["R" + i.ToString()].AxisY.Maximum = yRangeMax;
                sensorChart.ChartAreas["R" + i.ToString()].AxisY.Minimum = yRangeMin;

                sensorChart.Invalidate();
            }
            string speedString = sArray[11];
            moveSpeed = double.Parse(Regex.Split(speedString, " ", RegexOptions.IgnoreCase)[2]);
            sensorChart.Invalidate();
        }

        private void GPSPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (fileOpen == false)
            {
                return;
            }
            GPSPanel.Refresh();
            int mouseX = e.X;
            int mouseY = e.Y;
            double temp = 0;
            double min = 100;
            int key = 0;
            for (int i = 0; i < dtrNum; i++)
            {
                temp = (x[i] - mouseX) * (x[i] - mouseX) + (y[i] - mouseY) * (y[i] - mouseY);
                if (temp < min)
                {
                    min = temp;
                    key = i;
                }

            }
            this.Refresh();
            Graphics g3 = GPSPanel.CreateGraphics();
            PointF pp = new PointF();
            pp = new PointF((float)x[key], (float)y[key]);
            g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);

            Graphics g4 = sensorChart.CreateGraphics();
            //MessageBox.Show(sensorChart.Width.ToString());
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, sensorChart.Height);
            double dT = Convert.ToDouble(dataTime[key].ToString("0.0"));
            for (int i = 0; i < sensorChart.Width; i++)
            {
                double xValue = Math.Round(sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(i), 1);
                if (xValue == dT)
                {
                    p1 = new Point(i, 0);
                    p2 = new Point(i, sensorChart.Height);

                    if (xValue > sensorChart.ChartAreas[0].AxisX.ScaleView.Position + sensorChart.ChartAreas[0].AxisX.ScaleView.Size)
                    {
                        sensorChart.ChartAreas[0].AxisX.ScaleView.Position += sensorChart.ChartAreas[0].AxisX.ScaleView.Size / 2;
                        sensorChart.Invalidate();
                    }
                    if (xValue < sensorChart.ChartAreas[0].AxisX.ScaleView.Position)
                    {
                        sensorChart.ChartAreas[0].AxisX.ScaleView.Position -= sensorChart.ChartAreas[0].AxisX.ScaleView.Size / 2;
                        sensorChart.Invalidate();
                    }
                    g4.DrawLine(new Pen(Brushes.Blue), p1, p2);
                    break;
                }
            }
            g4.DrawLine(new Pen(Brushes.Blue), p1, p2);

        }

        private void GPSPanel_MouseDown(object sender, MouseEventArgs e)
        {
            flag_gps = true;
        }

        private void GPSPanel_MouseUp(object sender, MouseEventArgs e)
        {
            flag_gps = false;
        }

        private void GPSPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (fileOpen == true)
            {
                int mouseX = e.X;
                int mouseY = e.Y;
                double temp = 0;
                double min = 100;
                int key = 0;
                for (int i = 0; i < dtrNum; i++)
                {
                    temp = (x[i] - mouseX) * (x[i] - mouseX) + (y[i] - mouseY) * (y[i] - mouseY);
                    if (temp < min)
                    {
                        min = temp;
                        key = i;
                    }
                }
                Graphics g3 = GPSPanel.CreateGraphics();
                PointF pp = new PointF();
                pp = new PointF((float)x[key], (float)y[key]);
                if (flag_gps)
                {
                    //GPSPanel.Invalidate();
                    GPSPanel.Update();//if Refresh() there will be blinking problem!
                    g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                    Graphics g4 = sensorChart.CreateGraphics();
                    //MessageBox.Show(sensorChart.Width.ToString());
                    Point p1 = new Point(0, 0);
                    Point p2 = new Point(0, sensorChart.Height);
                    double dT = Convert.ToDouble(dataTime[key].ToString("0.0"));
                    sensorChart.Invalidate();
                    for (int i = 0; i < sensorChart.Width; i++)
                    {
                        double xValue = Math.Round(sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(i), 1);
                        if (xValue == dT)
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, sensorChart.Height);

                            if (xValue > sensorChart.ChartAreas[0].AxisX.ScaleView.Position + sensorChart.ChartAreas[0].AxisX.ScaleView.Size)
                            {
                                sensorChart.ChartAreas[0].AxisX.ScaleView.Position += sensorChart.ChartAreas[0].AxisX.ScaleView.Size / 2;
                                sensorChart.Invalidate();
                            }
                            if (xValue < sensorChart.ChartAreas[0].AxisX.ScaleView.Position)
                            {
                                sensorChart.ChartAreas[0].AxisX.ScaleView.Position -= sensorChart.ChartAreas[0].AxisX.ScaleView.Size / 2;
                                sensorChart.Invalidate();
                            }
                            g4.DrawLine(new Pen(Brushes.Blue), p1, p2);
                            break;
                        }
                    }
                    //g4.DrawLine(new Pen(Brushes.Blue), p1, p2);
                }
            }

        }

    }
}