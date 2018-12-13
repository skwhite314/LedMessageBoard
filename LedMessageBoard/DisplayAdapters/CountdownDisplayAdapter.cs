using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    /// <summary>
    /// Determines what time is left in the countdown and sends it to the appropriate view port
    /// </summary>
    internal class CountdownDisplayAdapter : IDisplayAdapter
    {
        private DateTime targetDateTime;

        private string timeSpanFormat;

        private TimeSpan displayStatic;

        private DateTime displayStarted;

        public CountdownDisplayAdapter(DateTime targetDateTime, string timeSpanFormat, TimeSpan displayStatic)
        {
            this.targetDateTime = targetDateTime;
            this.timeSpanFormat = timeSpanFormat;

            var message = this.GetMessage();

            this.ViewPort = ViewPortFactory.GetViewPort(message);

            this.displayStatic = displayStatic;

            this.displayStarted = DateTime.Now;
        }

        public string Title { get { return LedMessageBoard.Properties.Resources.CountdownTitle; } }

        public bool Active { get; set; }

        public bool DisplayComplete
        {
            get
            {
                if (this.ViewPort is StaticViewPort)
                {
                    return DateTime.Now - this.displayStarted > this.displayStatic;
                }
                else if (this.ViewPort is ScrollingViewPort)
                {
                    return ((ScrollingViewPort)this.ViewPort).AtEnd;
                }

                throw new NotImplementedException("CountdownDisplayAdapter.DisplayComplete");
            }
        }

        public ViewPort ViewPort { get; private set; }

        public void Draw(HidDevice device, byte brightness)
        {
            this.ViewPort.DisplayString(device, brightness);
        }

        public void Reset()
        {
            this.ViewPort = ViewPortFactory.GetViewPort(this.GetMessage());

            if (this.ViewPort is StaticViewPort)
            {
                this.displayStarted = DateTime.Now;
            }
        }

        private string GetMessage()
        {
            var timespan = DateTime.Now < this.targetDateTime ? this.targetDateTime - DateTime.Now : new TimeSpan(0);

            return timespan.ToString(this.timeSpanFormat);
        }
    }
}
