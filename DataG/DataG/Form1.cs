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
        string fName = "";

        static DataTable dtSave = new DataTable();
        static int dtrNum = dtSave.Rows.Count;
        static int dtcNum = dtSave.Columns.Count;
        static int[] datX = new int[dtrNum];
        static int[] datYA = new int[dtrNum];
        static int[] datYB = new int[dtrNum];

        static int nowScrollValue = 0;
        bool fileOpen = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkBoxAllSelection.Checked)
            {
                checkBoxSensorA.Checked = true;
                checkBoxSensorB.Checked = true;
            }
            sensorChart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
        }

        public static DataTable OpenCSV(string filePath)//从csv读取数据返回table
        {
            System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
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

        //给定文件的路径，读取文件的二进制数据，判断文件的编码类型
        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }

        //通过给定的文件流，判断文件的编码类型
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

        //判断是否是不带 BOM 的 UTF8 格式
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
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
            datX = new int[dtrNum];
            datYA = new int[dtrNum];
            datYB = new int[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {

                datX[i] = int.Parse(dt.Rows[i][0].ToString());
                datYA[i] = int.Parse(dt.Rows[i][1].ToString());
                datYB[i] = int.Parse(dt.Rows[i][2].ToString());
            }
            
            sensorChart.Series["SensorA"].Points.DataBindXY(datX,datYA);
            sensorChart.Series["SensorB"].Points.DataBindXY(datX, datYB);
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
            //sensorChart.ChartAreas[0].AxisX.ScaleView.Position = dtrNum - sensorChart.ChartAreas[0].AxisX.ScaleView.Size;
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
                datX = new int[dtrNum];
                datYA = new int[dtrNum];
                for (int i = 0; i < dtrNum; i++)
                {
                    datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datYA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                }
                sensorChart.Series["SensorA"].Points.DataBindXY(datX, datYA);
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
                Series series = sensorChart.Series["SensorB"];
                series.Points.Clear();
            }
            else
            {
                dtrNum = dtSave.Rows.Count;
                dtcNum = dtSave.Columns.Count;
                datX = new int[dtrNum];
                datYB = new int[dtrNum];
                for (int i = 0; i < dtrNum; i++)
                {
                    datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datYB[i] = int.Parse(dtSave.Rows[i][2].ToString());
                }
                sensorChart.Series["SensorB"].Points.DataBindXY(datX, datYB);
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
            datX = new int[dtrNum];
            datYA = new int[dtrNum];
            datYB = new int[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {
                if (checkBoxSensorA.Checked)
                {
                    datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datYA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                    textBoxTime.Text = datX[i].ToString();
                    textBoxSensorA.Text = datYA[i].ToString();
                }
                if (checkBoxSensorB.Checked)
                {
                    datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datYB[i] = int.Parse(dtSave.Rows[i][2].ToString());
                    textBoxTime.Text = datX[i].ToString();
                    textBoxSensorB.Text = datYA[i].ToString();
                }
                
            }
            if(fileOpen == true)
                chartTimer.Enabled = true;
            nowScrollValue = 0;

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
        }
        
        private void sensorChart_MouseClick(object sender, MouseEventArgs e)
        { 
            dtrNum = dtSave.Rows.Count;
            dtcNum = dtSave.Columns.Count;
            datX = new int[dtrNum];
            datYA = new int[dtrNum];
            datYB = new int[dtrNum];
            for (int i = 0; i < dtrNum; i++)
            {

                datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                datYA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                datYB[i] = int.Parse(dtSave.Rows[i][2].ToString());
            }
            int mouseX = e.X;
            int mouseY = e.Y;
            this.Refresh();
            Graphics g = sensorChart.CreateGraphics();
            Point p1 = new Point(mouseX, 0);
            Point p2 = new Point(mouseX, sensorChart.Height);
            Pen np = new Pen(Brushes.Blue, 1);
            g.DrawLine(np, p1, p2);
            double x = sensorChart.ChartAreas[0].AxisX.PixelPositionToValue(mouseX);
            textBoxTime.Text = Math.Round(x, 2).ToString();
            //MessageBox.Show(x.ToString());
            int xLeft = (int)x;
            int xRight = xLeft + 1;
            //two points:A(xLeft,datY[xLeft-1]),B(xRight,datY[xRight-1])
            if (xRight < dtrNum && xLeft > 0)
            {
                double kA = ((double)(datYA[xLeft - 1] - datYA[xRight - 1])) / ((double)(xLeft - xRight));
                double bA = (double)datYA[xLeft - 1] - (double)kA * (double)xLeft;
                textBoxSensorA.Text = Math.Round(kA * x + bA, 2).ToString();
                double kB = ((double)(datYB[xLeft - 1] - datYB[xRight - 1])) / ((double)(xLeft - xRight));
                double bB = (double)datYB[xLeft - 1] - (double)kB * (double)xLeft;
                textBoxSensorB.Text = Math.Round(kB * x + bB, 2).ToString();                
            }
            
        }
        
        private void chartTimer_Tick(object sender, EventArgs e)
        {
            if (nowScrollValue >= 1 && nowScrollValue <= dtrNum)
            {
                textBoxSensorB.Text = datYB[nowScrollValue - 1].ToString();
                textBoxSensorA.Text = datYA[nowScrollValue - 1].ToString();
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
        }

        private void GPSFilesLoadingButton_Click(object sender, EventArgs e)
        {
            string filename = "C:\\Users\\user\\Desktop\\GPS_Code\\test.rgp";
            FileIO.readFile(filename.ToCharArray());
        }
    }
}

