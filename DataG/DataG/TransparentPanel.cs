using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DataG
{
    public class TransparentPanel : Panel
    {
        public TransparentPanel() { }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    //不进行背景的绘制
        //}

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //绘制panel的背景图像
            if (BackgroundImage != null) e.Graphics.DrawImage(this.BackgroundImage, new Point(0, 0));
        }
    }
}
