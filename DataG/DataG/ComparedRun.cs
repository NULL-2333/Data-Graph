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
        string fName1 = "";                                     //the name of first opening file
        string fName2 = "";                                     //the name of second opening file
        double[] dataTime = new double[dtrNum];                 //the first file's data of time
        double[] dataTime2 = new double[dtrNum2];               //the second file's data of time
        double[,] data = new double[dtrNum, dtcNum - 1];        //the data of first file
        double[,] data2 = new double[dtrNum2, dtcNum2 - 1];     //the data of second file
        static DataTable dtSave = new DataTable();              //the datatable version of first .csv file
        static DataTable dtSave2 = new DataTable();             //the datatable version of second .csv file
        static int dtrNum = dtSave.Rows.Count;                  //the number of rows in dtSave
        static int dtrNum2 = dtSave2.Rows.Count;                //the number of rows in dtSave2
        static int dtcNum = dtSave.Columns.Count + 1;           //the number of columns in dtSave
        static int dtcNum2 = dtSave2.Columns.Count + 1;         //the number of columns in dtSave2

        string[] seriesName = new string[dtcNum - 1];           //the first names of different sensors
        string[] seriesName2 = new string[dtcNum - 1];          //the second names of different sensors
        double[] glpx = new double[dtrNum];                     //the x coordinate of first 2D coordinate system
        double[] glpy = new double[dtrNum];                     //the y coordinate of first 2D coordinate system
        double[] glpx2 = new double[dtrNum];                    //the x coordinate of second 2D coordinate system
        double[] glpy2 = new double[dtrNum];                    //the y coordinate of second 2D coordinate system
        double maxAbsX;                                         //the max abstract value of x coordinate
        double maxAbsY;                                         //the max abstract value of x coordinate
        double[] x = new double[dtrNum];                        //the first x coordinate in GPSPannel
        double[] y = new double[dtrNum];                        //the first y coordinate in GPSPannel
        double[] x2 = new double[dtrNum2];                      //the second x coordinate in GPSPannel
        double[] y2 = new double[dtrNum2];                      //the second y coordinate in GPSPannel

        static int xRangeMax = 70;                              //the max value of x coordinate
        static int xRangeMin = 0;                               //the min value of x coordinate
        static int yRangeMax = 100;                             //the max value of y coordinate
        static int yRangeMin = 0;                               //the min value of y coordinate
        static int xScale = 40;                                 //the size of x view
        static double xInterval = 2.0;                          //the interval of x axis
        static string yType = "R1";                             //the type of y axis

        double nowScrollValue = -xScale / 2;                    //the position of scrollbar
        double newPlace = 0;                                    //the position of moving dot
        double nowSteeringPlace = 0;                            //the place of playing
        bool fileOpen = false;                                  //determine whether the file has been opened
        bool flag = false;                                      //drag line
        bool flagPlace = true;                                  //determine if reset and stop button clicked
        double moveSpeed = .1;                                  //the speed of play
        bool firstPlayFlag = true;                              //the flag of first play
        bool haveReset = true;
        Bitmap bitNormal;
        bool isBitNormalCre = false;
        Bitmap bitSpeed;
        bool isBitSpeedCre = false;
        Bitmap bitAccele;
        bool isBitAcceleCre = false;
        bool scaleFlag = true;
        bool flag_gps = false;
        bool flag_line1 = false;
        bool flag_line2 = false;

        double[] speed = new double[dtrNum];                    //the speed in the csv file
        int speedRow = 0;
        double[] speed2 = new double[dtrNum2];                  //the speed in the csv file
        int speedRow2 = 0;
        double[] accelerate = new double[dtrNum];               //the speed in the csv file
        int accelerateRow = 0;
        double[] accelerate2 = new double[dtrNum2];             //the speed in the csv file
        int accelerateRow2 = 0;
        
        //double maxacc = 0;
        //double minacc = 0;
        double maxspeed = 0;
        double minspeed = 0;
        double maxspeed2 = 0;
        double minspeed2 = 0;

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public ChartArea caR2;
        public ChartArea caR3;
        public ChartArea caR4;

        bool isAccel = false;
        bool isAccel2 = false;
        double distance1 = 0;
        double distance2 = 0;
        double[] driver1 = new double[4];
        double[] driver2 = new double[4];
        int[] driver1_x = new int[4];
        int[] driver1_y = new int[4];
        int[] driver2_x = new int[4];
        int[] driver2_y = new int[4];
        double[] disA = new double[dtrNum];
        double[] disB = new double[dtrNum2];

        double[] gpsTime = new double[dtrNum];
        double barpos1 = 0;
        double barpos2 = 0;
        double barpos3 = 0;

        double sectionPoint1 = 0.25;//user can choose the start & end
        double sectionPoint2 = 0.5;
        double sectionPoint3 = 0.75;

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

        void change(string noStr, ChartArea caR)
        {
            double[] point = new double[dtrNum];
            double[] after = new double[dtrNum];
            int no = findStrSub(noStr, seriesName, seriesName.Length);
            for (int j = 0; j < dtrNum; j++)
            {
                point[j] = double.Parse(dt.Rows[j][no + 1].ToString());
            }
            for (int j = 0; j < dtrNum; j++)
            {
                after[j] = (point[j] - caR.AxisY.Minimum) / (caR.AxisY.Maximum - caR.AxisY.Minimum) * (sensorChart.ChartAreas[0].AxisY.Maximum - sensorChart.ChartAreas[0].AxisY.Minimum);
            }
            sensorChart.Series[noStr].Points.Clear();
            sensorChart.Series[noStr].Points.DataBindXY(dataTime, after); //sensorChart.Series[0].Points.DataBindXY(dataTime, dataSensors);
            sensorChart.Series[noStr].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();

        }

        void change2(string noStr, ChartArea caR)
        {
            double[] point = new double[dtrNum2];
            double[] after = new double[dtrNum2];
            int no = findStrSub(noStr, seriesName2, seriesName2.Length);
            for (int j = 0; j < dtrNum2; j++)
            {
                point[j] = double.Parse(dt2.Rows[j][no + 1].ToString());
            }
            for (int j = 0; j < dtrNum2; j++)
            {
                after[j] = (point[j] - caR.AxisY.Minimum) / (caR.AxisY.Maximum - caR.AxisY.Minimum) * (sensorChart.ChartAreas[0].AxisY.Maximum - sensorChart.ChartAreas[0].AxisY.Minimum);
            }
            sensorChart.Series[noStr].Points.Clear();
            sensorChart.Series[noStr].Points.DataBindXY(dataTime2, after); //sensorChart.Series[0].Points.DataBindXY(dataTime, dataSensors);
            sensorChart.Series[noStr].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();

        }

        void rb1_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));

            sensorChart.Series[seriesName[no]].Points.Clear();
            double[] dataSensor = new double[dtrNum];
            for (int j = 0; j < dtrNum; j++)
            {
                dataSensor[j] = data[j, no];
            }
            sensorChart.Series[seriesName[no]].Points.DataBindXY(dataTime, dataSensor);
            sensorChart.Series[seriesName[no]].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();

            sensorChart.Series[seriesName2[no]].Points.Clear();
            double[] dataSensor2 = new double[dtrNum2];
            for (int j = 0; j < dtrNum2; j++)
            {
                dataSensor2[j] = data2[j, no];
            }
            sensorChart.Series[seriesName2[no]].Points.DataBindXY(dataTime2, dataSensor2);
            sensorChart.Series[seriesName2[no]].ChartType = SeriesChartType.Line;
            sensorChart.Invalidate();

        }

        void rb2_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            // MessageBox.Show(no.ToString());
            change(seriesName[no], caR2);
            change2(seriesName2[no], caR2);
        }

        void rb3_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            change(seriesName[no], caR3);
            change2(seriesName2[no], caR3);
        }

        void rb4_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            change(seriesName[no], caR4);
            change2(seriesName2[no], caR4);
        }

        static void ExtendLine(PointF p1, PointF p2, float length, Graphics g, Pen np)
        {
            float lenAB = (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

            PointF p3 = new PointF();
            p3.X = p2.X + (p2.X - p1.X) / lenAB * length;
            p3.Y = p2.Y + (p2.Y - p1.Y) / lenAB * length;
            PointF p4 = new PointF();
            p4.X = p1.X - (p2.X - p1.X) / lenAB * length;
            p4.Y = p1.Y - (p2.Y - p1.Y) / lenAB * length;
            g.DrawLine(np, p3, p4);
        }       

        private void fileLoadingButton_Click(object sender, EventArgs e)
        {
            fileOpen = false;
            isBitNormalCre = false;
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
            sensorCheckedListBox2.Items.Clear();
            displayPanel.Controls.Add(sensorCheckedListBox);
            displayPanel.Controls.Add(sensorCheckedListBox2);
            YPanel.Controls.Clear();
            GPSPanel.Controls.Clear();
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
                fileOpen = false;
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
            disA = new double[dtrNum];
            disB = new double[dtrNum2];

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
                

            if ((dataTime[2] - (int)dataTime[2]) == 0)
            {
                if (dataTime[2] % 10 == 0)
                {
                    for (int i = 0; i < dtrNum; i++)
                    {
                        dataTime[i] /= 1000;
                    }
                }

            }
            if ((dataTime2[2] - (int)dataTime2[2]) == 0)
            {
                if (dataTime[2] % 10 == 0)
                {
                    for (int i = 0; i < dtrNum2; i++)
                    {
                        dataTime2[i] /= 1000;
                    }
                }

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
                disA[i] = distanceA(i);
            }
            for (int i = 0; i < dtrNum2; i++)
            {
                x2[i] = (maxAbsX + glpx2[i]) * 0.5 * (GPSPanel.Width) / maxAbsX;
                y2[i] = (maxAbsY - glpy2[i]) * 0.5 * (GPSPanel.Height) / maxAbsY;
                disB[i] = distanceB(i);
            }
            distance1 = distanceA(dtrNum);
            distance2 = distanceB(dtrNum2);
           
            driver1[0] = distance1 / 4;
            driver2[0] = distance2 / 4;
            driver1[1] = distance1 / 2;
            driver2[1] = distance2 / 2;
            driver1[2] = distance1 / 4 * 3;
            driver2[2] = distance2 / 4 * 3;
            driver1[3] = distance1 ;
            driver2[3] = distance2 ;
            
            driver1_y[0] = driver1_x[0] = findLeftNear(driver1[0],disA,dtrNum);
            driver1_y[1] = driver1_x[1] = findLeftNear(driver1[1], disA, dtrNum);
            driver1_y[2] = driver1_x[2] = findLeftNear(driver1[2], disA, dtrNum);
            driver1_y[3] = driver1_x[3] = findLeftNear(driver1[3], disA, dtrNum);

            driver2_y[0] = driver2_x[0] = findLeftNear(driver2[0], disB, dtrNum2);
            driver2_y[1] = driver2_x[1] = findLeftNear(driver2[1], disB, dtrNum2);
            driver2_y[2] = driver2_x[2] = findLeftNear(driver2[2], disB, dtrNum2);
            driver2_y[3] = driver2_x[3] = findLeftNear(driver2[3], disB, dtrNum2);

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
        double distanceA(int i)
        {
            double dis = 0;
            for (int j = 1; j < i; j++)
            {
                 dis += Math.Sqrt((x[j] - x[j - 1]) * (x[j] - x[j - 1]) + (y[j] - y[j - 1]) * (y[j] - y[j - 1]));

            }
            return dis;
        }
        double distanceB(int i)
        {
            double dis = 0;
            for (int j = 1; j < i; j++)
            {
                dis += Math.Sqrt((x2[j] - x2[j - 1]) * (x2[j] - x2[j - 1]) + (y2[j] - y2[j - 1]) * (y2[j] - y2[j - 1]));

            }
            return dis;
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

        private void sensorCheckedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            if (index < seriesName2.Length)
            {
                Series sz = sensorChart.Series[seriesName2[index]];
                sz.Enabled = !sensorCheckedListBox2.GetItemChecked(index);
            }
        }

        private void allSelectedCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtcNum - 1; i++)
            {
                sensorCheckedListBox2.SetItemChecked(i, allSelectedCheckBox2.Checked);
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

                    if (xx <= dataTime[dtrNum - 1])
                    {
                        PointF pp2 = new PointF();
                        pp2 = new PointF((float)m, (float)n);
                        Pen np2 = new Pen(Brushes.Red, 2);
                        if (xLeftSub + 10 < dtrNum)
                        {
                            PointF pp3 = new PointF((float)x[xLeftSub + 10], (float)y[xLeftSub + 10]);
                            AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
                            np2.CustomEndCap = lineCap;
                            g2.DrawLine(np2, pp2, pp3);
                        }

                    }
                }
                if(xx <= dataTime2[dtrNum2 - 1])
                {
                    double m2, n2;
                    m2 = (xx - xLeft) / (xRight - xLeft) * (x2[xRightSub] - x2[xLeftSub]) + x2[xLeftSub];
                    n2 = (xx - xLeft) / (xRight - xLeft) * (y2[xRightSub] - y2[xLeftSub]) + y2[xLeftSub];
                    if (xx <= dataTime2[dtrNum2 - 1])
                    {
                        PointF pp2 = new PointF();
                        pp2 = new PointF((float)m2, (float)n2);
                        Pen np2 = new Pen(Brushes.Green, 2);
                        if (xLeftSub + 10 < dtrNum2)
                        {
                            PointF pp3 = new PointF((float)x2[xLeftSub + 10], (float)y2[xLeftSub + 10]);
                            AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
                            np2.CustomEndCap = lineCap;
                            g2.DrawLine(np2, pp2, pp3);
                        }

                    }
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
                    }
                }
            }
            DateTime afterDT2 = System.DateTime.Now;
            TimeSpan ts2 = afterDT2.Subtract(beforDT);
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
                
                Graphics g3 = GPSPanel.CreateGraphics();
                if (xx2 <= dataTime[dtrNum - 1])
                {
                    m = x[xLeftSub];
                    n = y[xLeftSub];
                    PointF pp = new PointF();
                    pp = new PointF((float)m, (float)n);
                    Pen np2 = new Pen(Brushes.Red, 2);
                    if (xLeftSub + 10 < dtrNum)
                    {
                        PointF pp2 = new PointF((float)x[xLeftSub + 10], (float)y[xLeftSub + 10]);
                        AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
                        np2.CustomEndCap = lineCap;
                        g2.DrawLine(np2, pp, pp2);
                    }
                }
                if(xx2 <= dataTime2[dtrNum2 - 1])
                {
                    m2 = x2[xLeftSub];
                    n2 = y2[xLeftSub];
                    PointF pp2 = new PointF();
                    pp2 = new PointF((float)m2, (float)n2);
                    Pen np2 = new Pen(Brushes.Green, 2);
                    if (xLeftSub + 10 < dtrNum2)
                    {
                        PointF pp3 = new PointF((float)x2[xLeftSub + 10], (float)y2[xLeftSub + 10]);
                        AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
                        np2.CustomEndCap = lineCap;
                        g2.DrawLine(np2, pp2, pp3);
                    }

                }
                GPSPanel.Refresh();
                //this.Update();
                if(maxValue(dataTime, dataTime.Length) > maxValue(dataTime2, dataTime2.Length))
                {
                if ((newPlace + moveSpeed) <= maxValue(dataTime, dataTime.Length))
                    newPlace += moveSpeed;
                else
                    flagPlace = false;
                }
                else
                {
                    if ((newPlace + moveSpeed) <= maxValue(dataTime2, dataTime2.Length))
                        newPlace += moveSpeed;
                    else
                        flagPlace = false;
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
            }
            if (nowSteeringPlace <= maxValue(dataTime, dataTime.Length))
                nowSteeringPlace += moveSpeed;

            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
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

                        //PointF pp = new PointF();
                        //pp = new PointF((float)m, (float)n);
                        ////MessageBox.Show(pp.X.ToString() + " " + pp.Y.ToString());
                        //g2.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                        if (xx <= dataTime[dtrNum - 1])
                        {
                            PointF pp2 = new PointF();
                            pp2 = new PointF((float)m, (float)n);
                            //g3.FillEllipse(Brushes.Gray, pp2.X, pp2.Y, 5, 5);
                            Pen np2 = new Pen(Brushes.Red, 2);
                            if (xLeftSub + 10 < dtrNum)
                            {
                                PointF pp3 = new PointF((float)x[xLeftSub + 10], (float)y[xLeftSub + 10]);
                                AdjustableArrowCap lineCap =new AdjustableArrowCap(6, 6, false);
                                np2.CustomEndCap = lineCap;
                                g2.DrawLine(np2, pp2, pp3);
                            }
                        }
                    }
                    if (xx <= dataTime2[dtrNum2 - 1])
                    {
                        double m2, n2;
                        m2 = (xx - xLeft) / (xRight - xLeft) * (x2[xRightSub] - x2[xLeftSub]) + x2[xLeftSub];
                        n2 = (xx - xLeft) / (xRight - xLeft) * (y2[xRightSub] - y2[xLeftSub]) + y2[xLeftSub];

                        //PointF pp2 = new PointF();
                        //pp2 = new PointF((float)m2, (float)n2);

                        //g2.FillEllipse(Brushes.Gray, pp2.X, pp2.Y, 5, 5);
                        if (xx <= dataTime2[dtrNum2 - 1])
                        {
                            if (xx <= dataTime2[dtrNum2 - 1])
                            {
                                PointF pp2 = new PointF();
                                pp2 = new PointF((float)m2, (float)n2);
                                Pen np2 = new Pen(Brushes.Green, 2);
                                if (xLeftSub + 10 < dtrNum2)
                                {
                                    PointF pp3 = new PointF((float)x2[xLeftSub + 10], (float)y2[xLeftSub + 10]);
                                    AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
                                    np2.CustomEndCap = lineCap;
                                    g2.DrawLine(np2, pp2, pp3);
                                }
                            }
                        }
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
            isExist = false;
            Refresh();
            //Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
            //Graphics g2 = Graphics.FromImage(bitmap);
            //PointF p11 = new PointF();
            //PointF p22 = new PointF();
            //Pen nPen = new Pen(Brushes.Red, 2);
            //for (int i = 0; i < dtrNum - 1; i++)
            //{
            //    p11 = new PointF((float)x[i], (float)y[i]);
            //    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
            //    g2.DrawLine(nPen, p11, p22);
            //}
            //Graphics gg = GPSPanel.CreateGraphics();
            //gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
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
            if (fileOpen == false) return;
            if (isExist == true)
            {
                //isExist = false;
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
                return;
            }
            int kk = 0;
            if (isBitNormalCre == false)
            {
                bitNormal = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g = Graphics.FromImage(bitNormal);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen nPen = new Pen(Brushes.Red, 2);
                Pen nPen3 = new Pen(Brushes.Green, 2);
                p11 = new PointF((float)x[0], (float)y[0]);
                g.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);

                Label la = new Label();
                la.Text = "Start";
                la.Location = new Point((int)p11.X, (int)p11.Y);
                la.BackColor = Color.Transparent;
                la.AutoSize = true;
                GPSPanel.Controls.Add(la);

                p11 = new PointF((float)x[dtrNum - 1], (float)y[dtrNum - 1]);
                g.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);

                Label la2 = new Label();
                la2.Text = "End";
                la2.Location = new Point((int)p11.X, (int)p11.Y);
                la2.BackColor = Color.Transparent;
                la2.AutoSize = true;
                GPSPanel.Controls.Add(la2);

                p11 = new PointF((float)x2[0], (float)y2[0]);
                g.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x2[dtrNum2 - 1], (float)y2[dtrNum2 - 1]);
                g.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);

                for (int i = 0; i < dtrNum - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g.DrawLine(nPen, p11, p22);
                }
                for (int i = 0; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g.DrawLine(nPen3, p11, p22);
                }
                isBitNormalCre = true;
                if (radioButton_Normal.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitNormal, new PointF(0.0f, 0.0f));
                }
            }
            else
            {
                if (radioButton_Normal.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitNormal, new PointF(0.0f, 0.0f));
                }
            }

            if (isBitSpeedCre == false)
            {
                bitSpeed = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g3 = Graphics.FromImage(bitSpeed);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen p6;
                Pen p2;
                maxspeed = maxValue(speed, dtrNum);
                minspeed = minValue(speed, dtrNum);
                maxspeed2 = maxValue(speed2, dtrNum2);
                minspeed2 = minValue(speed2, dtrNum2);

                p11 = new PointF((float)x[0], (float)y[0]);
                g3.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x[dtrNum - 1], (float)y[dtrNum - 1]);
                g3.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x2[0], (float)y2[0]);
                g3.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x2[dtrNum2 - 1], (float)y2[dtrNum2 - 1]);
                g3.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);

                for (int i = 0; i < dtrNum - 1; i++)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    p6 = new Pen(Color.FromArgb(colorRed(speed[i], maxspeed, minspeed), colorGreen(speed[i], maxspeed, minspeed), 0), 2);
                    g3.DrawLine(p6, p11, p22);
                }
                for (int i = 0; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    p2 = new Pen(Color.FromArgb(colorRed(speed2[i], maxspeed2, minspeed2), colorGreen(speed2[i], maxspeed2, minspeed2), 255), 2);
                    g3.DrawLine(p2, p11, p22);
                }
                isBitSpeedCre = true;
                if (radioButton_Speed.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitSpeed, new PointF(0.0f, 0.0f));
                }
            }
            else
            {
                if (radioButton_Speed.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitSpeed, new PointF(0.0f, 0.0f));
                }
            }

            if (isBitAcceleCre == false)
            {
                if (isAccel == false) return;
                bitAccele = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g3 = Graphics.FromImage(bitAccele);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                Pen p6;
                Pen p2;
                maxspeed = maxValue(accelerate, dtrNum);
                minspeed = minValue(accelerate, dtrNum);
                maxspeed2 = maxValue(accelerate2, dtrNum2);
                minspeed2 = minValue(accelerate2, dtrNum2);

                p11 = new PointF((float)x[0], (float)y[0]);
                g3.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x[dtrNum - 1], (float)y[dtrNum - 1]);
                g3.FillEllipse(Brushes.Red, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x2[0], (float)y2[0]);
                g3.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);
                p11 = new PointF((float)x2[dtrNum2 - 1], (float)y2[dtrNum2 - 1]);
                g3.FillEllipse(Brushes.Green, p11.X, p11.Y, 5, 5);

                for (int i = 0; i < dtrNum - 1; i++)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    p6 = new Pen(Color.FromArgb(colorRed(accelerate[i], maxspeed, minspeed), colorGreen(accelerate[i], maxspeed, minspeed), 0), 2);
                    g3.DrawLine(p6, p11, p22);
                }
                for (int i = 0; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    p2 = new Pen(Color.FromArgb(colorRed(accelerate2[i], maxspeed2, minspeed2), colorGreen(accelerate2[i], maxspeed2, minspeed2), 255), 2);
                    g3.DrawLine(p2, p11, p22);
                }
                isBitAcceleCre = true;
                if (radioButton_Accelerate.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitAccele, new PointF(0.0f, 0.0f));
                }
            }
            else
            {
                if (radioButton_Accelerate.Checked)
                {
                    Graphics gg = GPSPanel.CreateGraphics();
                    gg.DrawImage(bitAccele, new PointF(0.0f, 0.0f));
                }
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
            if (radioButtonLine1.Checked)
            {
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
                if (key < dtrNum2)
                {
                    pp = new PointF((float)x2[key], (float)y2[key]);
                    g3.FillEllipse(Brushes.Gray, pp.X, pp.Y, 5, 5);
                }
                
            }
            if (radioButtonLine2.Checked)
            {
                for (int i = 0; i < dtrNum2; i++)
                {
                    temp = (x2[i] - mouseX) * (x2[i] - mouseX) + (y2[i] - mouseY) * (y2[i] - mouseY);
                    if (temp < min)
                    {
                        min = temp;
                        key = i;
                    }

                }
                this.Refresh();
                Graphics g3 = GPSPanel.CreateGraphics();
                PointF pp = new PointF();
                if (key < dtrNum)
                {
                    pp = new PointF((float)x[key], (float)y[key]);
                    g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                }
                pp = new PointF((float)x2[key], (float)y2[key]);
                g3.FillEllipse(Brushes.Gray, pp.X, pp.Y, 5, 5);
            }
            
            Graphics g4 = sensorChart.CreateGraphics();
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

        private void radioButtonLine1_Click(object sender, EventArgs e)
        {
            flag_line1 = true;
        }

        private void radioButtonLine2_Click(object sender, EventArgs e)
        {
            flag_line2 = true;
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
                if (flag_gps)
                {
                    if (radioButtonLine1.Checked)
                    {
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
                        g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                        if (key < dtrNum2)
                        {
                            pp = new PointF((float)x2[key], (float)y2[key]);
                            g3.FillEllipse(Brushes.Gray, pp.X, pp.Y, 5, 5);
                        }
                        
                    }
                    if (radioButtonLine2.Checked)
                    {
                        for (int i = 0; i < dtrNum2; i++)
                        {
                            temp = (x2[i] - mouseX) * (x2[i] - mouseX) + (y2[i] - mouseY) * (y2[i] - mouseY);
                            if (temp < min)
                            {
                                min = temp;
                                key = i;
                            }
                        }
                        Graphics g3 = GPSPanel.CreateGraphics();
                        PointF pp = new PointF();
                        if (key < dtrNum2)
                        {
                            pp = new PointF((float)x[key], (float)y[key]);
                            g3.FillEllipse(Brushes.Black, pp.X, pp.Y, 5, 5);
                        }
                        pp = new PointF((float)x2[key], (float)y2[key]);
                        g3.FillEllipse(Brushes.Gray, pp.X, pp.Y, 5, 5);
                    }
                    
                    Graphics g4 = sensorChart.CreateGraphics();
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
                }
            }
        }

        private void segmentationButton_Click(object sender, EventArgs e)
        {
            barpos1 = firstTrackBar.Value;
            barpos2 = secondTrackBar.Value;
            barpos3 = thirdTrackBar.Value;
            tableLayoutPanel1.Visible = true;
            firstDriverGroupBox.Visible = true;
            secondDriverGroupBox.Visible = true;
            Bitmap bitm;
            bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
            Graphics g2 = Graphics.FromImage(bitm);
            Pen pen1 = new Pen(Brushes.LightBlue, 2); //Blue for color1; Green for color2
            Pen pen2 = new Pen(Brushes.DarkBlue, 2);
            Pen pen3 = new Pen(Brushes.LightGreen, 2);
            Pen pen4 = new Pen(Brushes.DarkGreen, 2);
            PointF p11 = new PointF();
            PointF p22 = new PointF();
            if (fileOpen == false) return;

            barpos1 = 25;
            barpos2 = 50;
            barpos3 = 75;
            //standerd
            for (int i = 0; i < driver1_x[0] - 1; i += 1)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(pen1, p11, p22);
            }
            for (int i = 0; i < driver2_x[0] - 1; i += 1)
            {
                p11 = new PointF((float)x2[i], (float)y2[i]);
                p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                g2.DrawLine(pen2, p11, p22);
            }
            for (int i = driver1_x[0]; i < driver1_x[1] - 1; i += 1)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(pen3, p11, p22);
            }
            for (int i = driver2_x[0]; i < driver2_x[1] - 1; i += 1)
            {
                p11 = new PointF((float)x2[i], (float)y2[i]);
                p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                g2.DrawLine(pen4, p11, p22);
            }
            for (int i = driver1_x[1]; i < driver1_x[2] - 1; i += 1)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(pen1, p11, p22);
            }
            for (int i = driver2_x[1]; i < driver2_x[2] - 1; i += 1)
            {
                p11 = new PointF((float)x2[i], (float)y2[i]);
                p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                g2.DrawLine(pen2, p11, p22);
            }
            for (int i = driver1_x[2]; i < dtrNum - 1; i += 1)
            {
                p11 = new PointF((float)x[i], (float)y[i]);
                p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                g2.DrawLine(pen3, p11, p22);
            }
            for (int i = driver2_x[2]; i < dtrNum2 - 1; i += 1)
            {
                p11 = new PointF((float)x2[i], (float)y2[i]);
                p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                g2.DrawLine(pen4, p11, p22);
            }
            Graphics gg = GPSPanel.CreateGraphics();
            gg.DrawImage(bitm, new PointF(0.0f, 0.0f));
            /*
             * this is another version -- draw line to segment.
             */
            //Pen pen = new Pen(Brushes.Blue, 2);
            //Point p1 = new Point(Convert.ToInt32(x[driver1_x[0]]), Convert.ToInt32(y[driver1_y[0]]));
            //Point p2 = new Point(Convert.ToInt32(x2[driver2_x[0]]), Convert.ToInt32(y2[driver2_y[0]]));
            //ExtendLine(p1, p2, 20, g, pen);
            ////AdjustableArrowCap lineCap = new AdjustableArrowCap(6, 6, false);
            ////pen.CustomEndCap = lineCap;
            ////g.DrawLine(pen, p1, p2);
            //Point p3 = new Point(Convert.ToInt32(x[driver1_x[1]]), Convert.ToInt32(y[driver1_y[1]]));
            //Point p4 = new Point(Convert.ToInt32(x2[driver2_x[1]]), Convert.ToInt32(y2[driver2_y[1]]));
            //ExtendLine(p3, p4, 20, g, pen);
            ////g.DrawLine(pen, p3, p4);
            //Point p5 = new Point(Convert.ToInt32(x[driver1_x[2]]), Convert.ToInt32(y[driver1_y[2]]));
            //Point p6 = new Point(Convert.ToInt32(x2[driver2_x[2]]), Convert.ToInt32(y2[driver2_y[2]]));
            //ExtendLine(p5, p6, 20, g, pen);
            ////g.DrawLine(pen, p5, p6);
            //StandardSegmentation ss = new StandardSegmentation();
            label11.Text = dataTime[driver1_x[0]].ToString();
            label12.Text = (dataTime[driver1_x[1]] - dataTime[driver1_x[0]]).ToString();
            label13.Text = (dataTime[driver1_x[2]] - dataTime[driver1_x[1]]).ToString();
            label14.Text = (dataTime[dtrNum - 1] - dataTime[driver1_x[2]]).ToString();

            label21.Text = dataTime2[driver2_x[0]].ToString();
            label22.Text = (dataTime2[driver2_x[1]] - dataTime2[driver2_x[0]]).ToString();
            label23.Text = (dataTime2[driver2_x[2]] - dataTime2[driver2_x[1]]).ToString();
            label24.Text = (dataTime2[dtrNum2 - 1] - dataTime[driver2_x[2]]).ToString();
            //ss.Show();
            firstDriverGroupBox.Refresh();
            secondDriverGroupBox.Refresh();
        }


        private void firstTrackBar_ValueChanged(object sender, EventArgs e)
        {
            barpos1 = firstTrackBar.Value;
            if(barpos1 < barpos2)
            {
                sectionPoint1 = (double)barpos1 / 100;
                sectionPoint2 = (double)barpos2 / 100;
                sectionPoint3 = (double)barpos3 / 100;
                Bitmap bitm;
                bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitm);
                Pen pen1 = new Pen(Brushes.LightBlue, 2); //Blue for color1; Green for color2
                Pen pen2 = new Pen(Brushes.Blue, 2);
                Pen pen3 = new Pen(Brushes.LightGreen, 2);
                Pen pen4 = new Pen(Brushes.Green, 2);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                if (fileOpen == false) return;

                int line1Point1 = findLeftNear(sectionPoint1 * distance1, disA, dtrNum);
                int line1Point2 = findLeftNear(sectionPoint2 * distance1, disA, dtrNum);
                int line1Point3 = findLeftNear(sectionPoint3 * distance1, disA, dtrNum);

                int line2Point1 = findLeftNear(sectionPoint1 * distance2, disB, dtrNum2);
                int line2Point2 = findLeftNear(sectionPoint2 * distance2, disB, dtrNum2);
                int line2Point3 = findLeftNear(sectionPoint3 * distance2, disB, dtrNum2);

                if (line1Point1 == 0 && sectionPoint1 != 0)
                {
                    line1Point1 = dtrNum - 1;
                }
                if (line1Point2 == 0 && sectionPoint2 != 0)
                {
                    line1Point2 = dtrNum - 1;
                }
                if (line1Point3 == 0 && sectionPoint3 != 0)
                {
                    line1Point3 = dtrNum - 1;
                }
                if (line2Point1 == 0 && sectionPoint1 != 0)
                {
                    line2Point1 = dtrNum2 - 1;
                }
                if (line2Point2 == 0 && sectionPoint2 != 0)
                {
                    line2Point2 = dtrNum2 - 1;
                }
                if (line2Point3 == 0 && sectionPoint3 != 0)
                {
                    line2Point3 = dtrNum2 - 1;
                }

                for (int i = 0; i < line1Point1 - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                }
                for (int i = 0; i < line2Point1 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                }
                for (int i = line1Point1; i < line1Point2 - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point1; i < line2Point2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                }
                for (int i = line1Point2; i < dtrNum - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                }
                for (int i = line2Point2; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                }
                for (int i = line1Point3; i < dtrNum - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point3; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitm, new PointF(0.0f, 0.0f));

                label11.Text = dataTime[line1Point1].ToString("0.00");
                label12.Text = (dataTime[line1Point2] - dataTime[line1Point1]).ToString("0.00");
                label13.Text = (dataTime[line1Point3] - dataTime[line1Point2]).ToString("0.00");
                label14.Text = (dataTime[dtrNum - 1] - dataTime[line1Point3]).ToString("0.00");

                label21.Text = dataTime2[line2Point1].ToString("0.00");
                label22.Text = (dataTime2[line2Point2] - dataTime2[line2Point1]).ToString("0.00");
                label23.Text = (dataTime2[line2Point3] - dataTime2[line2Point2]).ToString("0.00");
                label24.Text = (dataTime2[dtrNum2 - 1] - dataTime2[line2Point3]).ToString("0.00");
            }
            else
            {
                firstTrackBar.Value = secondTrackBar.Value;
            }
        }

        private void secondTrackBar_ValueChanged(object sender, EventArgs e)
        {
            barpos2 = secondTrackBar.Value;
            if (barpos1 < barpos2 && barpos2 < barpos3)
            {
                sectionPoint1 = (double)barpos1 / 100;
                sectionPoint2 = (double)barpos2 / 100;
                sectionPoint3 = (double)barpos3 / 100;
                Bitmap bitm;
                bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitm);
                Pen pen1 = new Pen(Brushes.LightBlue, 2); //Blue for color1; Green for color2
                Pen pen2 = new Pen(Brushes.Blue, 2);
                Pen pen3 = new Pen(Brushes.LightGreen, 2);
                Pen pen4 = new Pen(Brushes.Green, 2);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                if (fileOpen == false) return;

                int line1Point1 = findLeftNear(sectionPoint1 * distance1, disA, dtrNum);
                int line1Point2 = findLeftNear(sectionPoint2 * distance1, disA, dtrNum);
                int line1Point3 = findLeftNear(sectionPoint3 * distance1, disA, dtrNum);

                int line2Point1 = findLeftNear(sectionPoint1 * distance2, disB, dtrNum2);
                int line2Point2 = findLeftNear(sectionPoint2 * distance2, disB, dtrNum2);
                int line2Point3 = findLeftNear(sectionPoint3 * distance2, disB, dtrNum2);

                if (line1Point1 == 0 && sectionPoint1 != 0)
                {
                    line1Point1 = dtrNum - 1;
                }
                if (line1Point2 == 0 && sectionPoint2 != 0)
                {
                    line1Point2 = dtrNum - 1;
                }
                if (line1Point3 == 0 && sectionPoint3 != 0)
                {
                    line1Point3 = dtrNum - 1;
                }
                if (line2Point1 == 0 && sectionPoint1 != 0)
                {
                    line2Point1 = dtrNum2 - 1;
                }
                if (line2Point2 == 0 && sectionPoint2 != 0)
                {
                    line2Point2 = dtrNum2 - 1;
                }
                if (line2Point3 == 0 && sectionPoint3 != 0)
                {
                    line2Point3 = dtrNum2 - 1;
                }

                for (int i = 0; i < line1Point1 - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                }
                for (int i = 0; i < line2Point1 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                }
                for (int i = line1Point1; i < line1Point2 - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point1; i < line2Point2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                }
                for (int i = line1Point2; i < dtrNum - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                }
                for (int i = line2Point2; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                }
                for (int i = line1Point3; i < dtrNum - 1; i += 1)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point3; i < dtrNum2 - 1; i += 1)
                {
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                }
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitm, new PointF(0.0f, 0.0f));

                label11.Text = dataTime[line1Point1].ToString("0.00");
                label12.Text = (dataTime[line1Point2] - dataTime[line1Point1]).ToString("0.00");
                label13.Text = (dataTime[line1Point3] - dataTime[line1Point2]).ToString("0.00");
                label14.Text = (dataTime[dtrNum - 1] - dataTime[line1Point3]).ToString("0.00");

                label21.Text = dataTime2[line2Point1].ToString("0.00");
                label22.Text = (dataTime2[line2Point2] - dataTime2[line2Point1]).ToString("0.00");
                label23.Text = (dataTime2[line2Point3] - dataTime2[line2Point2]).ToString("0.00");
                label24.Text = (dataTime2[dtrNum2 - 1] - dataTime2[line2Point3]).ToString("0.00");
            }
            else
            {
                if (barpos2 <= barpos1)
                {
                    secondTrackBar.Value = firstTrackBar.Value;
                }
                if (barpos2 >= barpos3)
                {
                    secondTrackBar.Value = thirdTrackBar.Value;
                }
            }

        }
        bool isExist = false;
        Bitmap bitmap;

        private void thirdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            isExist = true;
            barpos3 = thirdTrackBar.Value;

            
            
            if (barpos2 < barpos3)
            {
                sectionPoint1 = (double)barpos1 / 100;
                sectionPoint2 = (double)barpos2 / 100;
                sectionPoint3 = (double)barpos3 / 100;
                Bitmap bitm;
                bitm = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                isExist = true;
                Graphics g2 = Graphics.FromImage(bitm);
                Graphics g3 = Graphics.FromImage(bitmap);
                isExist = true;
                Pen pen1 = new Pen(Brushes.LightBlue, 2); //Blue for color1; Green for color2
                Pen pen2 = new Pen(Brushes.Blue, 2);
                Pen pen3 = new Pen(Brushes.LightGreen, 2);
                Pen pen4 = new Pen(Brushes.Green, 2);
                PointF p11 = new PointF();
                PointF p22 = new PointF();
                if (fileOpen == false) return;

                int line1Point1 = findLeftNear(sectionPoint1 * distance1, disA, dtrNum);
                int line1Point2 = findLeftNear(sectionPoint2 * distance1, disA, dtrNum);
                int line1Point3 = findLeftNear(sectionPoint3 * distance1, disA, dtrNum);

                int line2Point1 = findLeftNear(sectionPoint1 * distance2, disB, dtrNum2);
                int line2Point2 = findLeftNear(sectionPoint2 * distance2, disB, dtrNum2);
                int line2Point3 = findLeftNear(sectionPoint3 * distance2, disB, dtrNum2);

                //if(isExist == false)
                //foreach (Control c in GPSPanel.Controls)
                //{
                //    if (c.Name == "L1")
                //    {
                //        isExist = true;
                //        break;
                //    }
                //}
                //if (isExist == false)
                //{
                //    Label la = new Label();
                //    la.Text = "1";
                //    la.Name = "L1";
                //    la.Location = new Point((int)x[line1Point3], (int)y[line1Point3]);
                //    la.BackColor = Color.Transparent;
                //    la.AutoSize = true;
                //    GPSPanel.Controls.Add(la);
                //}
                //else
                //{
                //    GPSPanel.Controls["L1"].Location = new Point((int)x[line1Point3], (int)y[line1Point3]);
                //    GPSPanel.Invalidate();
                //}

                //GPSPanel.Controls.Clear();
                //Label la = new Label();
                //la.Text = "1";
                //la.Name = "L1";
                //la.Location = new Point((int)x[line1Point3], (int)y[line1Point3]);
                ////la.BackColor = Color.Transparent;
                //la.AutoSize = true;
                ////GPSPanel.Controls.Add(la);
                //la.DrawToBitmap(bitm, la.Bounds);

                
                if (line1Point1 == 0  && sectionPoint1 != 0)
                {
                    line1Point1 = dtrNum - 1;
                }
                if (line1Point2 == 0 && sectionPoint2 != 0)
                {
                    line1Point2 = dtrNum - 1;
                } 
                if (line1Point3 == 0 && sectionPoint3 != 0)
                {
                    line1Point3 = dtrNum - 1;
                }
                if (line2Point1 == 0 && sectionPoint1 != 0)
                {
                    line2Point1 = dtrNum2 - 1;
                }
                if (line2Point2 == 0 && sectionPoint2 != 0)
                {
                    line2Point2 = dtrNum2 - 1;
                }
                if (line2Point3 == 0 && sectionPoint3 != 0)
                {
                    line2Point3 = dtrNum2 - 1;
                }
                
                for (int i = 0; i < line1Point1 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                    g3.DrawLine(pen1, p11, p22);
                }
                for (int i = 0; i < line2Point1 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                    g3.DrawLine(pen2, p11, p22);
                }
                for (int i = line1Point1; i < line1Point2 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point1; i < line2Point2 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }
                for (int i = line1Point2; i < dtrNum - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen1, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point2; i < dtrNum2 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen2, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }
                for (int i = line1Point3; i < dtrNum - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    g2.DrawLine(pen3, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }
                for (int i = line2Point3; i < dtrNum2 - 1; i += 1)
                {
                    isExist = true;
                    p11 = new PointF((float)x2[i], (float)y2[i]);
                    p22 = new PointF((float)x2[i + 1], (float)y2[i + 1]);
                    g2.DrawLine(pen4, p11, p22);
                    g3.DrawLine(pen3, p11, p22);
                }

                isExist = true;
                GPSPanel.Refresh();
                isExist = true;
                //draw a point with the center of (x,y) and (x2,y2)
                PointF pf = new PointF((float)((x[line1Point3] + x2[line2Point3]) / 2), (float)((y[line1Point3] + y2[line2Point3]) / 2));
                //double r = Math.Sqrt((x[line1Point3] - x2[line2Point3]) * (x[line1Point3] - x2[line2Point3]) + (y[line1Point3] - y2[line2Point3]) * (y[line1Point3] - y2[line2Point3])) / 2;
                g2.FillEllipse(Brushes.Chocolate, pf.X - 3, pf.Y - 3, 6, 6);
                isExist = true;
                g2.DrawEllipse(new Pen(Brushes.Chocolate), pf.X - 10, pf.Y - 10, 20, 20);
                isExist = true;

                isExist = true;
                Graphics gg = GPSPanel.CreateGraphics();
                gg.DrawImage(bitm, new PointF(0.0f, 0.0f));

                label11.Text = dataTime[line1Point1].ToString("0.00");
                label12.Text = (dataTime[line1Point2] - dataTime[line1Point1]).ToString("0.00");
                label13.Text = (dataTime[line1Point3] - dataTime[line1Point2]).ToString("0.00");
                label14.Text = (dataTime[dtrNum - 1] - dataTime[line1Point3]).ToString("0.00");

                label21.Text = dataTime2[line2Point1].ToString("0.00");
                label22.Text = (dataTime2[line2Point2] - dataTime2[line2Point1]).ToString("0.00");
                label23.Text = (dataTime2[line2Point3] - dataTime2[line2Point2]).ToString("0.00");
                label24.Text = (dataTime2[dtrNum2 - 1] - dataTime2[line2Point3]).ToString("0.00");
            }
            else
            {
                thirdTrackBar.Value = secondTrackBar.Value;
            }
        }
    }
}