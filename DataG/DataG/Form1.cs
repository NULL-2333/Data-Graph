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
            //sensorChart.ChartAreas[0].AxisX
        }
        string fName = "";
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
        /// 给定文件的路径，读取文件的二进制数据，判断文件的编码类型
        /// <param name="FILE_NAME">文件路径</param>
        /// <returns>文件的编码类型</returns>

        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }

        /// 通过给定的文件流，判断文件的编码类型
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
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

        /// 判断是否是不带 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
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

        static DataTable dtSave = new DataTable();
        static int dtrNum = dtSave.Rows.Count;
        static int dtcNum = dtSave.Columns.Count;
        static int[] datX = new int[dtrNum];
        static int[] datYA = new int[dtrNum];
        static int[] datYB = new int[dtrNum];
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
            //Refresh();
            dt = OpenCSV(fileName);
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
            
            //Series sensorASeries = new Series("SensorA");
            sensorChart.Series["SensorA"].Points.DataBindXY(datX,datYA);
            sensorChart.Series["SensorB"].Points.DataBindXY(datX, datYB);
            sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
            sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
            //Series series = sensorChart.Series["SensorB"];
            //series.Points.Clear();
            //sensorChart.Series["SensorB"].Points.DataBindXY(datX, datYB);
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
        private delegate void drawGraph();
        private static int offset = 0;
        private List<int> valueListX;
        private List<int> valueListYA;
        private List<int> valueListYB;
        private drawGraph doIt;
        private Thread thread;
        private void AddData()
        {
            //Re-read all datas from datSave
                dtrNum = dtSave.Rows.Count;
                dtcNum = dtSave.Columns.Count;
                datX = new int[dtrNum];
                if (checkBoxSensorA.Checked)
                    datYA = new int[dtrNum];
                if (checkBoxSensorB.Checked)
                    datYB = new int[dtrNum];
                if (offset < dtrNum)
                {
                    datX[offset] = int.Parse(dtSave.Rows[offset][0].ToString());
                    if (checkBoxSensorA.Checked)
                        datYA[offset] = int.Parse(dtSave.Rows[offset][1].ToString());
                    if (checkBoxSensorB.Checked)
                        datYB[offset] = int.Parse(dtSave.Rows[offset][2].ToString());
                    offset += 1;

                    //automatically move forward
                    if (sensorChart.Series[0].Points.Count > 0)
                    {
                        if (sensorChart.Series[0].Points[0].XValue < datX[offset - 1] - 5)
                        {
                            if (checkBoxSensorA.Checked)
                            {
                                sensorChart.Series[0].Points.RemoveAt(0);
                                sensorChart.ChartAreas[0].AxisX.Minimum = sensorChart.Series[0].Points[0].XValue;
                                sensorChart.ChartAreas[0].AxisX.Maximum = sensorChart.ChartAreas[0].AxisX.Minimum + 10;
                            }
                        }
                    }
                if (sensorChart.Series[1].Points.Count > 0)
                {
                    if (sensorChart.Series[1].Points[0].XValue < datX[offset - 1] - 5)
                    {
                        if (checkBoxSensorB.Checked)
                        {
                            sensorChart.Series[1].Points.RemoveAt(0);
                            sensorChart.ChartAreas[0].AxisX.Minimum = sensorChart.Series[1].Points[0].XValue;
                            sensorChart.ChartAreas[0].AxisX.Maximum = sensorChart.ChartAreas[0].AxisX.Minimum + 10;
                        }
                    }
                }
                //add data to chart
                sensorChart.ResetAutoValues();
                    valueListX.Add(datX[offset - 1]);
                    if (checkBoxSensorA.Checked)
                    {
                        valueListYA.Add(datYA[offset - 1]);
                        sensorChart.Series[0].Points.AddXY(datX[offset - 1], datYA[offset - 1]);
                    }

                    if (checkBoxSensorB.Checked)
                    {
                        valueListYB.Add(datYB[offset - 1]);
                        sensorChart.Series[1].Points.AddXY(datX[offset - 1], datYB[offset - 1]);
                    }

                    sensorChart.Invalidate();
                }
            
           
            
        }
        private void runThread()
        {
            while (true)
            {
                try
                {
                    dtrNum = dtSave.Rows.Count;
                    dtcNum = dtSave.Columns.Count;
                    datX = new int[dtrNum];
                    datYA = new int[dtrNum];
                    datYB = new int[dtrNum];
                    for (int i = 0; i < dtrNum; i++)
                    {

                        datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                        if (checkBoxSensorA.Checked)
                            datYA[i] = int.Parse(dtSave.Rows[i][1].ToString());
                        if (checkBoxSensorB.Checked)
                            datYB[i] = int.Parse(dtSave.Rows[i][2].ToString());
                    }
                    sensorChart.Invoke(doIt);
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception : " + e.ToString());
                }
            }
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (checkBoxSensorA.Checked)
                sensorChart.Series["SensorA"].Points.Clear();
            if (checkBoxSensorB.Checked)
                sensorChart.Series["SensorB"].Points.Clear();

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
                }
                if (checkBoxSensorB.Checked)
                {
                    datX[i] = int.Parse(dtSave.Rows[i][0].ToString());
                    datYB[i] = int.Parse(dtSave.Rows[i][2].ToString());
                }
            }
            valueListX = new List<int>();
            valueListYA = new List<int>();            
            valueListYB = new List<int>();                
            doIt += new drawGraph(AddData);

            thread = new Thread(new ThreadStart(runThread));
            thread.Start();
            //MessageBox.Show("HHH");
            //thread.Suspend();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sensorChart.Series["SensorA"].Points.Clear();
             sensorChart.Series["SensorB"].Points.Clear();

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

             sensorChart.Series["SensorA"].Points.DataBindXY(datX, datYA);
             sensorChart.Series["SensorB"].Points.DataBindXY(datX, datYB);
             sensorChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
             sensorChart.ChartAreas[0].AxisX.ScaleView.Size = 10;
             sensorChart.ChartAreas[0].AxisX.Minimum = 0;
             sensorChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
             sensorChart.ChartAreas[0].AxisY.ScaleView.Size = 100;
        }

        private void sensorChart_MouseClick(object sender, MouseEventArgs e)
        {
             
            int mouseX = e.X;
            int mouseY = e.Y;
            DataTable dt = new DataTable();
            if (fName == "")
            {
                return;
            }
            dt = OpenCSV(fName);
            int dtrNum = dt.Rows.Count;
            int dtcNum = dt.Columns.Count;
            int[,] dat = new int[dtrNum, dtcNum];
            for (int i = 0; i < dtrNum; i++)
            {
                for (int j = 0; j < dtcNum; j++)
                {
                    string s = dt.Rows[i][j].ToString();
                    dat[i, j] = int.Parse(s);
                }
            }

            textBoxSensorA.Clear();
            textBoxSensorB.Clear();
            textBoxTime.Clear();
            HitTestResult result = sensorChart.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                this.Refresh();
                Cursor = Cursors.Hand;
                if (checkBoxSensorA.Checked)
                {

                    textBoxTime.Text = sensorChart.Series[0].Points[result.PointIndex].XValue.ToString();
                    textBoxSensorA.Text = sensorChart.Series[0].Points[result.PointIndex].YValues[0].ToString();
                }
                if (checkBoxSensorB.Checked)
                {
                    textBoxTime.Text = sensorChart.Series[1].Points[result.PointIndex].XValue.ToString();
                    textBoxSensorB.Text = sensorChart.Series[1].Points[result.PointIndex].YValues[0].ToString();
                }
                
                Graphics g = sensorChart.CreateGraphics();
                Point p1 = new Point(e.X, 0);
                Point p2 = new Point(e.X, sensorChart.Height);
                Pen np = new Pen(Brushes.Blue, 1);
                g.DrawLine(np, p1, p2);
            }
            else if (result.ChartElementType != ChartElementType.Nothing)
            {
                Cursor = Cursors.Default;
            }       

        }
        
    }
}

