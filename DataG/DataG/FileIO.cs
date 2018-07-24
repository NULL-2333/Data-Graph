using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace DataG
{
    class FileIO
    {
        public static bool is_rpg_fname(char[] str)
        {
            if(str == null){
                return false;
            }
            uint i = 0;
            while (str[(int)i]!= null)
            {
                if (str[(int)i] == '.' && str[(int)i + 1] == 'r' && str[(int)i + 2] == 'g' && str[(int)i + 3] == 'p')
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public void clear_buff(char[] buff, uint length)
        {
            if (buff == null)
            {
                return;
            }
            uint i;
            for (i = 0; i < length; i++)
            {
                buff[(int)i] = char.MinValue;
            }
        }
        public bool isNum(char c)
        {
            return c >= '0' && c <= '9';
        }
        public static GPSRectArr readFile(char[] fname)
        {
            if (fname == null)
            {
                return null;
            }
            GPSRectArr res = new GPSRectArr();
            res.length = 0;
            res.array = null;
            GPSRect[] curr = null;
            GPSRaw temp = new GPSRaw();
            char c = char.MinValue;
            char[] buff = new char[25];
            for (int i = 0; i < 25; i++)
            {
                buff[i] = char.MinValue;
            }
            uint counter = 0, counter2 = 0;
            char mode = char.MinValue;
            if (!is_rpg_fname(fname))
            {
                return res;
            }
            StreamReader sr = new StreamReader(new string(fname));
            string sTemp = sr.ReadLine();
            if (sTemp[0].Equals('G')) counter++;
            while (sTemp != null)
            {
                sTemp = sr.ReadLine();
                if (sTemp.Equals("") == false)
                {
                    if (sTemp[0].Equals('G'))
                    {
                        counter++;
                    }
                }
            }
            MessageBox.Show(counter.ToString());
            return null;
        }

    }
}
