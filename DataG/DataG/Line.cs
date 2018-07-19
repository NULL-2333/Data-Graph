using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataG
{
    class Line
    {
        protected Point p1;
        protected Point p2;
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        //public ~Line();
    }
}
