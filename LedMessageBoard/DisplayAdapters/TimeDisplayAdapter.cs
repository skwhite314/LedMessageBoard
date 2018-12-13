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
    internal class TimeDisplayAdapter : IDisplayAdapter
    {
        private DateTime? timeToDisplay;

        private string timeFormat;

        private TimeSpan displayStatic;

        private DateTime displayStart;

        public string Title { get { return LedMessageBoard.Properties.Resources.TimeTitle; } }

        public bool Active { get; set; }

        public ViewPort ViewPort { get; private set; }

        public bool DisplayComplete
        {
            get
            {
                if (this.timeToDisplay == null)
                {
                    return false;
                }

                if (this.ViewPort is StaticViewPort)
                {
                    return DateTime.Now - this.displayStart > this.displayStatic;
                }
                else if (this.ViewPort is ScrollingViewPort)
                {
                    return ((ScrollingViewPort) this.ViewPort).AtEnd;
                }

                throw new NotImplementedException("TimeDisplayAdapter.DisplayComplete");
            }
        }

        public TimeDisplayAdapter(string timeFormat, TimeSpan displayStatic)
        {
            this.timeFormat = timeFormat;

            this.timeToDisplay = null;

            this.ViewPort = ViewPortFactory.GetViewPort(DateTime.Now.ToString(this.timeFormat));

            this.displayStatic = displayStatic;
            this.displayStart = DateTime.Now;
        }

        public void Draw(HidDevice device, byte brightness)
        {
            if (this.timeToDisplay == null || (DateTime.Now - this.timeToDisplay.Value).Seconds > 0)
            {
                this.timeToDisplay = DateTime.Now;

                var offset = this.ViewPort.Offset;

                this.ViewPort = ViewPortFactory.GetViewPort(this.timeToDisplay.Value.ToString(this.timeFormat));

                this.ViewPort.Offset = offset;
            }

            this.ViewPort.DisplayString(device, brightness);
        }

        public void Reset()
        {
            this.timeToDisplay = null;
            this.displayStart = DateTime.Now;
        }
    }
}
