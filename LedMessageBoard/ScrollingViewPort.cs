using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace LedMessageBoard
{
    /// <summary>
    /// A view port for displaying a scrolling message on the message board; handles offset for scrolling
    /// </summary>
    internal class ScrollingViewPort : ViewPort
    {
        public int ScrollRate { get; private set; }

        private DateTime lastScroll;

        public ScrollingViewPort(string message) : this(ViewPort.MaxWidth, message) { }

        public ScrollingViewPort(int width, String message) : base(width, message)
        {
            var scrollRate = LedMessageBoard.Properties.Settings.Default.Global_ScrollRate;
            var refreshRate = LedMessageBoard.Properties.Settings.Default.Global_RefreshRate;

            if (scrollRate % refreshRate == 0)
            {
                this.ScrollRate = scrollRate;
            }
            else
            {
                var factor = (int)(scrollRate / refreshRate) + 1;
                this.ScrollRate = factor * refreshRate;
            }

            this.lastScroll = DateTime.Now;

            this.Offset = this.Width;
        }

        public bool AtEnd
        {
            get
            {
                return this.MessageWidth + this.Offset <= 0;
            }
        }

        public void ResetScroll(bool force = false)
        {
            if (force || this.MessageWidth + this.Offset <= 0)
            {
                this.Offset = this.Width;
                this.lastScroll = DateTime.Now;
            }
        }

        public override void DisplayString(HidDevice device, byte brightness)
        {
            this.ResetScroll();

            base.DisplayString(device, brightness);

            this.HandleScrolling();
        }

        private void HandleScrolling()
        {
            var now = DateTime.Now;

            if ((now - this.lastScroll).TotalMilliseconds > this.ScrollRate)
            {
                this.Offset--;
                this.lastScroll = now;
            }
        }
    }
}
