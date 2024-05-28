// WFCControls: Refactoring PageControl.cs (11/06/2022) from 05/28/2024

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFCControls.PageController
{
    /// <summary>
    /// TabControl content area offset due to its controls
    /// </summary>
    public class TabControlCapOffests
    {
        public const int LocationOffsetX = -10;

        public const int LocationOffsetY = -21;

        public const int SizeOffsetX = 15;

        public const int SizeOffsetY = 25;
    }

    public class PageController
    {
        public PageController(TabControl tabControl) => 
            (PageControl, PageControlParent) = (tabControl, tabControl.Parent);

        TabControl PageControl;

        Control PageControlParent;

        /// <summary>
        /// When hiding controls, the TabControl will extend beyond its parent control according to offset.
        /// </summary>
        public void Bind()
        {
            PageControl.Dock = DockStyle.None;
            PageControl.Anchor = AnchorStyles.None;

            HideFrames();

            PageControlParent.Resize += ParentPageControlResize;
        }

        private void ParentPageControlResize(object sender, EventArgs e) => HideFrames();

        private void HideFrames()
        {
            int width = PageControl.Size.Width + TabControlCapOffests.SizeOffsetX;
            int height = PageControl.Size.Height + TabControlCapOffests.SizeOffsetY;

            PageControl.Size = new Size(width, height);
            PageControl.Location = new Point(TabControlCapOffests.LocationOffsetX, TabControlCapOffests.LocationOffsetY);
        }
    }
}
