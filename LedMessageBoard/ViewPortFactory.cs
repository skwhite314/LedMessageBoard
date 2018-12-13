using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedMessageBoard
{
    /// <summary>
    /// Factory for providing the appropriate view port based on the length of the message compared to the maximum width of the message board
    /// </summary>
    internal static class ViewPortFactory
    {
        public static ViewPort GetViewPort(string message, int width = ViewPort.MaxWidth)
        {
            width = Math.Min(width, ViewPort.MaxWidth);

            if (LedFont.StringWidth(message) > width)
            {
                return new ScrollingViewPort(width, message);
            }
            else
            {
                return new StaticViewPort(message);
            }
        }
    }
}
