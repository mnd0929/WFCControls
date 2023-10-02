using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFCControls
{
    public class PageControl
    {
        public TabControl TabControl { get; set; }
        public int LocationOffsetX = -10;
        public int LocationOffsetY = -21;
        public int SizeOffsetX = 15;
        public int SizeOffsetY = 25;

        //
        // Сводка:
        //     Событие Resize элемента управления TabControl для скрытия его рамок
        public void PageControlResize(object sender, EventArgs e)
        {
            TabControl cnt = TabControl;
            Control pnt = cnt.Parent;

            cnt.Dock = cnt.Dock != DockStyle.None ? DockStyle.None : cnt.Dock;

            cnt.Size = new Size(pnt.Size.Width + SizeOffsetX, pnt.Size.Height + SizeOffsetY);
            cnt.Location = new Point(LocationOffsetX, LocationOffsetY);
        }

        //
        // Сводка:
        //     Убирает рамки с TabControl.
        //     <!> После преобразования свойство элемента управления Dock визуально всегда будет иметь значение DockStyle.Fill
        public static void ConvertingTabControlToPageControl(TabControl tabControl)
        {
            PageControl pageControl = new PageControl { TabControl = tabControl };
            tabControl.Parent.Resize += new EventHandler(pageControl.PageControlResize);
            pageControl.PageControlResize(tabControl.Parent, null);
        }
    }
}
