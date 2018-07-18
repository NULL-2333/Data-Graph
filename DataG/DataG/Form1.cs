using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
        int minx, miny;
        string fName;
        private void button1_Click(object sender, EventArgs e)
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
            if (fileName=="")
            {
                MessageBox.Show("No file selected","Warning");
                return;
            }
            Refresh();
            dt = OpenCSV(fileName);
            fName = fileName;
            int dtrNum = dt.Rows.Count;
            int dtcNum = dt.Columns.Count;
            int[,] dat = new int[dtrNum, dtcNum];
            for (int i = 0; i < dtrNum; i++)
            {
                for (int j = 0; j < dtcNum; j++)
                {
                    //Console.WriteLine(dt.Rows[i].ToString());
                    //DialogResult dia;
                    //dia = MessageBox.Show(dt.Rows[i][j].ToString());
                    string s = dt.Rows[i][j].ToString();
                    dat[i, j] = int.Parse(s);
                }
            }
            //MessageBox.Show(dat[0, 0].ToString()+" "+dat[0,1].ToString());
            //painting on the board
            Graphics g = graphPanel.CreateGraphics();
            float move = 50f;
            float newX = graphPanel.Width - move;
            float newY = graphPanel.Height - move;
            float LenX = graphPanel.Width - 2 * move;
            float LenY = graphPanel.Height - 2 * move;
            int lenX = 5;
            int lenY = 10;
            int minX = minx;
            int minY = miny;
            int maxX = minx + lenX * 1;
            int maxY = miny + lenY * 10;
            
            //MessageBox.Show(panel.Width.ToString());
            //MessageBox.Show(panel.Height.ToString());
            Pen nPen = new Pen(Brushes.Black, 1);
            //draw x-axis
            PointF px1 = new PointF(move, newY);
            PointF px2 = new PointF(newX, newY);
            g.DrawLine(nPen, px1, px2);
            //complete x-axis
            for (int i = 1; i <= lenX; i++)
            {
                PointF px3 = new PointF(LenX * i / lenX + move, newY - 4);
                PointF px4 = new PointF(LenX * i / lenX + move, newY);
                string sy = (((maxX - minX) * i / lenX) + minX).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), px3, px4);
                g.DrawString(sy, new Font("YaHei", 8f), Brushes.Black, new PointF(LenX * i / lenX + move, newY / 1.1f));
            }
            Pen pen = new Pen(Color.Black, 1);
            g.DrawString("X", new Font("YaHei", 10f), Brushes.Black, new PointF(newX, newY / 1.2f));

            //draw y-axis
            PointF py1 = new PointF(move, move);
            PointF py2 = new PointF(move, newY);

            g.DrawLine(nPen, py1, py2);
            //complete y-axis
            
            for (int i = 0; i <= lenY; i++)
            {
                PointF py3 = new PointF(move, LenY * i / lenY + move);
                PointF py4 = new PointF(move + 4, LenY * i / lenY + move);
                g.DrawLine(nPen, py3, py4);
                string sx = (((maxY - minY) - (maxY - minY) * i / lenY) + minY).ToString();
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("YaHei", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / lenY + move * 1.1f), drawFormat);
            }
            g.DrawString("Y", new Font("YaHei", 10f), Brushes.Black, new PointF(move / 3, move / 2f));
            
            //draw the dataTable
            //MessageBox.Show((move + (float)dat[0, 0] / (float)maxX * LenX).ToString());
            PointF pf1 = new PointF(move + (float)(dat[0, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[0, 1] - minY) / (float)(maxY - minY) * LenY);
            PointF pf2 = new PointF(move + (float)(dat[1, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[1, 1] - minY) / (float)(maxY - minY) * LenY);
            Pen p = new Pen(Brushes.Red,1);
            g.DrawLine(p, pf1, pf2);
            //g.FillEllipse(Brushes.Red, pf1.X, pf1.Y, 10, 10);
            for (int i = 2; i < dtrNum; i++)
            {
                pf1 = pf2;
                pf2 = new PointF(move + (float)(dat[i, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[i, 1] - minY) / (float)(maxY - minY) * LenY);
                g.DrawLine(p, pf1, pf2);
            }
            
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

        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            minx = trackBarX.Value;
            DataTable dt = new DataTable();
            Refresh();
            dt = OpenCSV(fName);
            int dtrNum = dt.Rows.Count;
            int dtcNum = dt.Columns.Count;
            int[,] dat = new int[dtrNum, dtcNum];
            for (int i = 0; i < dtrNum; i++)
            {
                for (int j = 0; j < dtcNum; j++)
                {
                    //Console.WriteLine(dt.Rows[i].ToString());
                    //DialogResult dia;
                    //dia = MessageBox.Show(dt.Rows[i][j].ToString());
                    string s = dt.Rows[i][j].ToString();
                    dat[i, j] = int.Parse(s);
                }
            }
            //MessageBox.Show(dat[0, 0].ToString()+" "+dat[0,1].ToString());
            //painting on the board
            Graphics g = graphPanel.CreateGraphics();
            float move = 50f;
            float newX = graphPanel.Width - move;
            float newY = graphPanel.Height - move;
            float LenX = graphPanel.Width - 2 * move;
            float LenY = graphPanel.Height - 2 * move;
            int lenX = 5;
            int lenY = 10;
            int minX = minx;
            int minY = miny;
            int maxX = minx + lenX * 1;
            int maxY = miny + lenY * 10;

            //MessageBox.Show(panel.Width.ToString());
            //MessageBox.Show(panel.Height.ToString());
            Pen nPen = new Pen(Brushes.Black, 1);
            //draw x-axis
            PointF px1 = new PointF(move, newY);
            PointF px2 = new PointF(newX, newY);
            g.DrawLine(nPen, px1, px2);
            //complete x-axis
            for (int i = 1; i <= lenX; i++)
            {
                PointF px3 = new PointF(LenX * i / lenX + move, newY - 4);
                PointF px4 = new PointF(LenX * i / lenX + move, newY);
                string sy = (((maxX - minX) * i / lenX) + minX).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), px3, px4);
                g.DrawString(sy, new Font("YaHei", 8f), Brushes.Black, new PointF(LenX * i / lenX + move, newY / 1.1f));
            }
            Pen pen = new Pen(Color.Black, 1);
            g.DrawString("X", new Font("YaHei", 10f), Brushes.Black, new PointF(newX, newY / 1.2f));

            //draw y-axis
            PointF py1 = new PointF(move, move);
            PointF py2 = new PointF(move, newY);

            g.DrawLine(nPen, py1, py2);
            //complete y-axis

            for (int i = 0; i <= lenY; i++)
            {
                PointF py3 = new PointF(move, LenY * i / lenY + move);
                PointF py4 = new PointF(move + 4, LenY * i / lenY + move);
                g.DrawLine(nPen, py3, py4);
                string sx = (((maxY - minY) - (maxY - minY) * i / lenY) + minY).ToString();
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("YaHei", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / lenY + move * 1.1f), drawFormat);
            }
            g.DrawString("Y", new Font("YaHei", 10f), Brushes.Black, new PointF(move / 3, move / 2f));

            //draw the dataTable
            //MessageBox.Show((move + (float)dat[0, 0] / (float)maxX * LenX).ToString());
            PointF pf1 = new PointF(move + (float)(dat[0, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[0, 1] - minY) / (float)(maxY - minY) * LenY);
            PointF pf2 = new PointF(move + (float)(dat[1, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[1, 1] - minY) / (float)(maxY - minY) * LenY);
            Pen p = new Pen(Brushes.Red, 1);
            g.DrawLine(p, pf1, pf2);
            //g.FillEllipse(Brushes.Red, pf1.X, pf1.Y, 10, 10);
            for (int i = 2; i < dtrNum; i++)
            {
                pf1 = pf2;
                pf2 = new PointF(move + (float)(dat[i, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[i, 1] - minY) / (float)(maxY - minY) * LenY);
                g.DrawLine(p, pf1, pf2);
            }
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            miny = trackBarY.Value * 10;
            DataTable dt = new DataTable();
            Refresh();
            dt = OpenCSV(fName);
            int dtrNum = dt.Rows.Count;
            int dtcNum = dt.Columns.Count;
            int[,] dat = new int[dtrNum, dtcNum];
            for (int i = 0; i < dtrNum; i++)
            {
                for (int j = 0; j < dtcNum; j++)
                {
                    //Console.WriteLine(dt.Rows[i].ToString());
                    //DialogResult dia;
                    //dia = MessageBox.Show(dt.Rows[i][j].ToString());
                    string s = dt.Rows[i][j].ToString();
                    dat[i, j] = int.Parse(s);
                }
            }
            //MessageBox.Show(dat[0, 0].ToString()+" "+dat[0,1].ToString());
            //painting on the board
            Graphics g = graphPanel.CreateGraphics();
            float move = 50f;
            float newX = graphPanel.Width - move;
            float newY = graphPanel.Height - move;
            float LenX = graphPanel.Width - 2 * move;
            float LenY = graphPanel.Height - 2 * move;
            int lenX = 5;
            int lenY = 10;
            int minX = minx;
            int minY = miny;
            int maxX = minx + lenX * 1;
            int maxY = miny + lenY * 10;

            //MessageBox.Show(panel.Width.ToString());
            //MessageBox.Show(panel.Height.ToString());
            Pen nPen = new Pen(Brushes.Black, 1);
            //draw x-axis
            PointF px1 = new PointF(move, newY);
            PointF px2 = new PointF(newX, newY);
            g.DrawLine(nPen, px1, px2);
            //complete x-axis
            for (int i = 1; i <= lenX; i++)
            {
                PointF px3 = new PointF(LenX * i / lenX + move, newY - 4);
                PointF px4 = new PointF(LenX * i / lenX + move, newY);
                string sy = (((maxX - minX) * i / lenX) + minX).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), px3, px4);
                g.DrawString(sy, new Font("YaHei", 8f), Brushes.Black, new PointF(LenX * i / lenX + move, newY / 1.1f));
            }
            Pen pen = new Pen(Color.Black, 1);
            g.DrawString("X", new Font("YaHei", 10f), Brushes.Black, new PointF(newX, newY / 1.2f));

            //draw y-axis
            PointF py1 = new PointF(move, move);
            PointF py2 = new PointF(move, newY);

            g.DrawLine(nPen, py1, py2);
            //complete y-axis

            for (int i = 0; i <= lenY; i++)
            {
                PointF py3 = new PointF(move, LenY * i / lenY + move);
                PointF py4 = new PointF(move + 4, LenY * i / lenY + move);
                g.DrawLine(nPen, py3, py4);
                string sx = (((maxY - minY) - (maxY - minY) * i / lenY) + minY).ToString();
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("YaHei", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / lenY + move * 1.1f), drawFormat);
            }
            g.DrawString("Y", new Font("YaHei", 10f), Brushes.Black, new PointF(move / 3, move / 2f));

            //draw the dataTable
            //MessageBox.Show((move + (float)dat[0, 0] / (float)maxX * LenX).ToString());
            PointF pf1 = new PointF(move + (float)(dat[0, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[0, 1] - minY) / (float)(maxY - minY) * LenY);
            PointF pf2 = new PointF(move + (float)(dat[1, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[1, 1] - minY) / (float)(maxY - minY) * LenY);
            Pen p = new Pen(Brushes.Red, 1);
            g.DrawLine(p, pf1, pf2);
            //g.FillEllipse(Brushes.Red, pf1.X, pf1.Y, 10, 10);
            for (int i = 2; i < dtrNum; i++)
            {
                pf1 = pf2;
                pf2 = new PointF(move + (float)(dat[i, 0] - minX) / (float)(maxX - minX) * LenX, newY - (float)(dat[i, 1] - minY) / (float)(maxY - minY) * LenY);
                g.DrawLine(p, pf1, pf2);
            }
        }


    }
}
