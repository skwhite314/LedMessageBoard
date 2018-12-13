using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    /// <summary>
    /// Sends the custom text to the appropriate view port 
    /// </summary>
    internal class CustomTextDisplayAdapter : IDisplayAdapter
    {
        private TimeSpan displayStatic;

        private DateTime displayStarted;

        private string message;

        public CustomTextDisplayAdapter(string message, TimeSpan displayStatic)
        {
            this.message = message;
            this.displayStatic = displayStatic;

            this.ViewPort = ViewPortFactory.GetViewPort(this.message);
            this.displayStarted = DateTime.Now;
        }

        public string Title { get { return LedMessageBoard.Properties.Resources.CustomTextTitle; } }

        public bool Active { get; set; }

        public ViewPort ViewPort { get; private set; }

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
                    return this.ViewPort.Offset + this.ViewPort.MessageWidth <= 0;
                }

                throw new NotImplementedException("CustomTextDisplayAdapter.DisplayComplete");
            }
        }

        public void Reset()
        {
            this.ViewPort = ViewPortFactory.GetViewPort(this.message);

            if (this.ViewPort is StaticViewPort)
            {
                this.displayStarted = DateTime.Now;
            }
        }

        public void Draw(HidDevice device, byte brightness)
        {
            this.ViewPort.DisplayString(device, brightness);
        }
    }
}
