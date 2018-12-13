using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedMessageBoard
{
    /// <summary>
    /// A view port for displaying a non-scrolling message on the message board; centers the message
    /// </summary>
    internal class StaticViewPort : ViewPort
    {
        public StaticViewPort(string message) : base(LedFont.StringWidth(message), message)
        {
        }

        public override void ChangeMessage(string message, bool keepOffset = false)
        {
            base.ChangeMessage(message, keepOffset);

            var diff = MaxWidth - this.MessageWidth;

            if (diff < 0)
            {
                this.LeftMargin = 0;
                this.RightMargin = 0;
                this.Offset = (int)(diff / 2);
            }
            else
            {
                this.LeftMargin = (int)(diff / 2);
                this.RightMargin = MaxWidth - this.LeftMargin - this.MessageWidth;
                this.Offset = 0;
            }
        }
    }
}
