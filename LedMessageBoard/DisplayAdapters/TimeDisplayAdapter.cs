using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    /// <summary>
    ///Sends the current time in the customized format to the appropriate view port
    /// </summary>
    internal class TimeDisplayAdapter : DisplayAdapter
    {
        public string TimeFormat { get; private set; }

        private DateTime? timeToDisplay;

        private DateTime displayStart;

        public TimeDisplayAdapter(string timeFormat, string title)
        {
            this.Title = title;

            this.TimeFormat = timeFormat;

            this.timeToDisplay = null;

            this.ViewPort = ViewPortFactory.GetViewPort(DateTime.Now.ToString(this.TimeFormat));

            this.displayStart = DateTime.Now;
        }

        public override bool DisplayComplete
        {
            get
            {
                if (this.timeToDisplay == null)
                {
                    return false;
                }

                if (this.ViewPort is StaticViewPort)
                {
                    return DateTime.Now - this.displayStart > StaticDisplayDuration;
                }
                else if (this.ViewPort is ScrollingViewPort)
                {
                    return ((ScrollingViewPort) this.ViewPort).AtEnd;
                }

                throw new NotImplementedException("TimeDisplayAdapter.DisplayComplete");
            }
        }

        public override void Draw(HidDevice device, byte brightness)
        {
            if (this.timeToDisplay == null || (DateTime.Now - this.timeToDisplay.Value).Seconds > 0)
            {
                this.timeToDisplay = DateTime.Now;

                var offset = this.ViewPort.Offset;

                this.ViewPort = ViewPortFactory.GetViewPort(this.timeToDisplay.Value.ToString(this.TimeFormat));

                this.ViewPort.Offset = offset;
            }

            this.ViewPort.DisplayString(device, brightness);
        }

        public override void Reset()
        {
            this.timeToDisplay = null;
            this.displayStart = DateTime.Now;
        }
    }
}
