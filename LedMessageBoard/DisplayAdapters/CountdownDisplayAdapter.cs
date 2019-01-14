﻿using System;
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
    internal class CountdownDisplayAdapter : DisplayAdapter
    {
        public DateTime Target { get; private set; }

        public string TimeSpanFormat { get; private set; }

        private DateTime displayStarted;

        public CountdownDisplayAdapter(DateTime targetDateTime, string timeSpanFormat, string title)
        {
            this.Target = targetDateTime;
            this.TimeSpanFormat = timeSpanFormat;
            this.Title = title;

            this.displayStarted = DateTime.Now;

            var message = this.GetMessage();

            this.ViewPort = ViewPortFactory.GetViewPort(message);
        }

        public override bool DisplayComplete
        {
            get
            {
                if (this.ViewPort is StaticViewPort)
                {
                    return DateTime.Now - this.displayStarted > StaticDisplayDuration;
                }
                else if (this.ViewPort is ScrollingViewPort)
                {
                    return ((ScrollingViewPort)this.ViewPort).AtEnd;
                }

                throw new NotImplementedException("CountdownDisplayAdapter.DisplayComplete");
            }
        }

        public override void Draw(HidDevice device, byte brightness)
        {
            this.ViewPort.DisplayString(device, brightness);
        }

        public override void Reset()
        {
            this.ViewPort = ViewPortFactory.GetViewPort(this.GetMessage());

            if (this.ViewPort is StaticViewPort)
            {
                this.displayStarted = DateTime.Now;
            }
        }

        private string GetMessage()
        {
            var timespan = DateTime.Now < this.Target ? this.Target - DateTime.Now : new TimeSpan(0);

            return timespan.ToString(this.TimeSpanFormat);
        }
    }
}
