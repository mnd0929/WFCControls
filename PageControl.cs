using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFC_Controls
{
    public class PageControl
    {
        public TabControl TabControl { get; set; }
        public int LocationOffsetX = -10;
        public int LocationOffsetY = -21;
        public int SizeOffsetX = 15;
        public int SizeOffsetY = 25;
        public void PageControlResize(object sender, EventArgs e)
        {
            TabControl cnt = TabControl;
            Control pnt = cnt.Parent;

            cnt.Dock = cnt.Dock != DockStyle.None ? DockStyle.None : cnt.Dock;

            cnt.Size = new Size(pnt.Size.Width + SizeOffsetX, pnt.Size.Height + SizeOffsetY);
            cnt.Location = new Point(LocationOffsetX, LocationOffsetY);
        }
    }
}
