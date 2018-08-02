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

        double nowScrollValue = -0.5;                                 //the position of scrollbar
        double newPlace = 1;                                       //the position of moving dot
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
            //delete existing chart
            sensorChart.Series.Clear();
            sensorChart.ChartAreas.Clear();
            sensorChart.ChartAreas.Add(new ChartArea("ChartArea1"));
            sensorChart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10000;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;

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
            }
            for (int i = 0; i < dtcNum - 1; i++)
            {
                if (seriesName[i].Contains("SPEED"))
                {
                    speedRow = i;
                    break;
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

            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;
            sensorChart.ChartAreas[0].AxisX.Interval = 0.1;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

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
                //add panels to YPanel
                Panel pan = new Panel();
                Point pl = new Point(0, 0);
                pan.Height = 30;
                pl.Y += i * pan.Height;
                pan.Location = pl;
                pan.Width = YPanel.Width - 20;
                //pan.BorderStyle = BorderStyle.FixedSingle;
                YPanel.Controls.Add(pan);
                //add label to pan
                Label la = new Label();
                la.Text = seriesName[i];
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

            sensorChart.ChartAreas[0].InnerPlotPosition.X = (float)35;
            sensorChart.ChartAreas[0].InnerPlotPosition.Height = (float)90;
            //sensorChart.Series[0].Points.Clear();
            //for (int i = 0; i < dtrNum; i++)
            //{
            //    data[i, 0] = 100;
            //}
            //double[] dataSensors = new double[dtrNum];
            //for (int j = 0; j < dtrNum; j++)
            //{
            //    dataSensors[j] = data[j, 0];
            //}
            //sensorChart.Series[0].Points.DataBindXY(dataTime, dataSensors);  
            //sensorChart.Invalidate();
            //create 3 other chartareas for R2, R3, R4 Axises
            sensorChart.ChartAreas[0].AxisY.Title = "R1";
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
            ChartArea caR2 = sensorChart.ChartAreas.Add("R2");
            caR2.BackColor = Color.Transparent;
            caR2.BorderColor = Color.Transparent;
            caR2.Position.FromRectangleF(sensorChart.ChartAreas[0].Position.ToRectangleF());
            caR2.InnerPlotPosition.FromRectangleF(sensorChart.ChartAreas[0].InnerPlotPosition.ToRectangleF());
            caR2.InnerPlotPosition.X -= (float)10;
            caR2.AxisX.MajorGrid.Enabled = false;
            caR2.AxisX.MajorTickMark.Enabled = false;
            caR2.AxisX.LabelStyle.Enabled = false;
            caR2.AxisY.MajorGrid.Enabled = false;
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

            ChartArea caR3 = sensorChart.ChartAreas.Add("R3");
            caR3.BackColor = Color.Transparent;
            caR3.BorderColor = Color.Transparent;
            caR3.Position.FromRectangleF(caR2.Position.ToRectangleF());
            caR3.InnerPlotPosition.FromRectangleF(caR2.InnerPlotPosition.ToRectangleF());
            caR3.InnerPlotPosition.X -= (float)10;
            caR3.AxisX.MajorGrid.Enabled = false;
            caR3.AxisX.MajorTickMark.Enabled = false;
            caR3.AxisX.LabelStyle.Enabled = false;
            caR3.AxisY.MajorGrid.Enabled = false;
            caR3.AxisY.Title = "R3";
            caR3.AxisY.Maximum = 30;
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

            ChartArea caR4 = sensorChart.ChartAreas.Add("R4");
            caR4.BackColor = Color.Transparent;
            caR4.BorderColor = Color.Transparent;
            caR4.Position.FromRectangleF(caR3.Position.ToRectangleF());
            caR4.InnerPlotPosition.FromRectangleF(caR3.InnerPlotPosition.ToRectangleF());
            caR4.InnerPlotPosition.X -= (float)10;
            caR4.AxisX.MajorGrid.Enabled = false;
            caR4.AxisX.MajorTickMark.Enabled = false;
            caR4.AxisX.LabelStyle.Enabled = false;
            caR4.AxisY.MajorGrid.Enabled = false;
            caR4.AxisY.Title = "R4";
            caR4.AxisY.Maximum = 8000;
            caR4.AxisY.Minimum = 0;
            caR4.AxisY.IsStartedFromZero = sensorChart.ChartAreas[0].AxisY.IsStartedFromZero;
            sCopy4.ChartArea = caR4.Name;
        }
        //change the value scale from (x1,y1) to (x2,y2)
        //void changeScale
        void rb1_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no= int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            MessageBox.Show(no.ToString());
        }

        void rb2_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            MessageBox.Show(no.ToString());
        }

        void rb3_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            MessageBox.Show(no.ToString());
        }

        void rb4_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int no = int.Parse(rb.Name.Substring(3, rb.Name.Length - 3));
            MessageBox.Show(no.ToString());
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
            flagPlace = true;
        }

        private void sensorChart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            //double x0 = sensorChart.ChartAreas[0].AxisX.ValueToPixelPosition(nowScrollValue);
            //double y0 = sensorChart.ChartAreas[0].AxisY.ValueToPixelPosition(sensorCfbvhart.ChartAreas[0].AxisY.Minimum);
            //double y1 = sensorChart.ChartAreas[0].AxisY.ValueToPixelPosition(sensorChart.ChartAreas[0].AxisY.Maximum);
            double x = sensorChart.ChartAreas[0].AxisX.ScaleView.Position + 0.4;
            double x0 = sensorChart.ChartAreas[0].AxisX.ValueToPixelPosition(x);
            double y0 = sensorChart.ChartAreas[0].AxisY.ValueToPixelPosition(sensorChart.ChartAreas[0].AxisY.Minimum);
            double y1 = sensorChart.ChartAreas[0].AxisY.ValueToPixelPosition(sensorChart.ChartAreas[0].AxisY.Maximum);
            //if (x < sensorChart.ChartAreas[0].AxisX.ScaleView.Position + sensorChart.ChartAreas[0].AxisX.ScaleView.Size)
            e.ChartGraphics.Graphics.DrawLine(new Pen(Color.Red, 1), (float)x0, (float)y0, (float)x0, (float)y1);
        }

        private void chartTimer_Tick(object sender, EventArgs e)
        {
            
            sensorChart.PostPaint += new EventHandler<ChartPaintEventArgs>(sensorChart_PostPaint);

            if (nowScrollValue >= minValue(dataTime, dataTime.Length) && nowScrollValue <= maxValue(dataTime, dataTime.Length))
            {
                textBoxTime.Text = Math.Round(nowScrollValue + 0.5, 2).ToString();
                TextBox txtBox = new TextBox();
                for (int i = 0; i < dtcNum - 1; i++)
                {
                    txtBox = (TextBox)this.Controls.Find("textBox" + i.ToString(), true)[0];
                    if (txtBox != null && sensorCheckedListBox.GetItemChecked(i))
                    {
                        txtBox.Text = data[findSub(Math.Round(nowScrollValue + 0.5, 2), dataTime, dataTime.Length), i].ToString();
                    }
                }
            }

            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = nowScrollValue;

            //sensorChart.PostPaint += new EventHandler<ChartPaintEventArgs>(sensorChart_PostPaint);

            if ((nowScrollValue + 0.5) <= maxValue(dataTime, dataTime.Length))
                nowScrollValue += .1;
            sensorChart.Invalidate();

            if (flagPlace == true)
            {
                Bitmap bitmap = new Bitmap(GPSPanel.Width, GPSPanel.Height);
                Graphics g2 = Graphics.FromImage(bitmap);
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
                    newPlace += .1;
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

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            RangeForm a = new RangeForm();
            a.yRangeMax = yRangeMax;
            a.yRangeMin = yRangeMin;
            a.yScale = yScale;
            a.xRangeMax = xRangeMax;
            a.xRangeMin = xRangeMin;
            a.xScale = xScale;
            a.ShowDialog();
            yRangeMax = a.yRangeMax;
            yRangeMin = a.yRangeMin;
            yScale = a.yScale;
            xRangeMax = a.xRangeMax;
            xRangeMin = a.xRangeMin;
            xScale = a.xScale;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;

            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.Invalidate();
            //save settings to log file
            string s1 = "x: " + xRangeMin.ToString() + " - " + xRangeMax.ToString() + "\r\n";
            string s2 = "x scale: " + xScale.ToString() + "\r\n";
            string s3 = "y: " + yRangeMin.ToString() + " - " + yRangeMax.ToString() + "\r\n";
            string s4 = "y scale: " + yScale.ToString() + "\r\n";
            File.WriteAllText(@"..//..//Log/setting.log", s1 + s2 + s3 + s4);
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
                Pen p6;
                
                for (int i = 0; i < dtrNum - 1; i++)
                {
                    p11 = new PointF((float)x[i], (float)y[i]);
                    p22 = new PointF((float)x[i + 1], (float)y[i + 1]);
                    p6 = new Pen(Color.FromArgb(colorRed(speed[i]), colorGreen(speed[i]), 0), 2);
                    g2.DrawLine(p6, p11, p22);
                    /*if (speed[i] < 2)
                        g2.DrawLine(p2, p11, p22);
                    else if (speed[i] > 2 && speed[i] < 10)
                        g2.DrawLine(p3, p11, p22);
                    else if (speed[i] > 10 && speed[i] < 15)
                        g2.DrawLine(p5, p11, p22);
                    else if (speed[i] > 15 && speed[i] < 20)
                        g2.DrawLine(p4, p11, p22);
                    else
                        g2.DrawLine(p1, p11, p22);*/
                }
            }
            else
            {

            }
            Graphics gg = GPSPanel.CreateGraphics();
            gg.DrawImage(bitmap, new PointF(0.0f, 0.0f));
        }

        public int colorRed(double x)//xx,,
        {
            if (x > 15)
            {
                double y = 255 - 10 * (x-15);
                if (y > 0)
                return Convert.ToInt32(Math.Floor(y));
            else
                return 255;
            }
            else
            {
                return 255;
            }
        }

        public int colorGreen(double x)//,xx,
        {
            if (x < 15)
            {
                double y = 255 - 10 * x;
            if (y > 0)
                return Convert.ToInt32(Math.Floor(y));
            else
                return 0;
            }
            else
            {
                return 0;
            }
                
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            //read setting.log file
            string setting = File.ReadAllText(@"..//..//Log/setting.log");
            //MessageBox.Show(str);
            string[] sArray = Regex.Split(setting, "\r\n", RegexOptions.IgnoreCase);
            //foreach (string i in sArray) MessageBox.Show(i.ToString());
            int len = sArray.Length - 1;
            //handle the x range
            string xR = sArray[0];
            xRangeMin = int.Parse(Regex.Split(xR, " ", RegexOptions.IgnoreCase)[1]);
            xRangeMax = int.Parse(Regex.Split(xR, " ", RegexOptions.IgnoreCase)[3]);
            //handle the y range
            string yR = sArray[2];
            yRangeMin = int.Parse(Regex.Split(yR, " ", RegexOptions.IgnoreCase)[1]);
            yRangeMax = int.Parse(Regex.Split(yR, " ", RegexOptions.IgnoreCase)[3]);
            //handle the x scale
            string xS = sArray[1];
            xScale = int.Parse(Regex.Split(xS, " ", RegexOptions.IgnoreCase)[2]);
            //handle the y scale
            string yS = sArray[3];
            yScale = int.Parse(Regex.Split(yS, " ", RegexOptions.IgnoreCase)[2]);

            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = xScale;
            sensorChart.ChartAreas[0].AxisX.Maximum = xRangeMax;
            sensorChart.ChartAreas[0].AxisX.Minimum = xRangeMin;

            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = yScale;
            sensorChart.ChartAreas[0].AxisY.Maximum = yRangeMax;
            sensorChart.ChartAreas[0].AxisY.Minimum = yRangeMin;

            sensorChart.Invalidate();
        }


        

    }
}

