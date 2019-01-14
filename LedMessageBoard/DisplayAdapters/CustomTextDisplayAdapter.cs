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
    internal class CustomTextDisplayAdapter : DisplayAdapter
    {
        public string Message { get; private set; }

        private DateTime displayStarted;

        public CustomTextDisplayAdapter(string message, string title)
        {
            this.Message = message;
            this.Title = title;

            this.ViewPort = ViewPortFactory.GetViewPort(this.Message);
            this.displayStarted = DateTime.Now;
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
                    return this.ViewPort.Offset + this.ViewPort.MessageWidth <= 0;
                }

                throw new NotImplementedException("CustomTextDisplayAdapter.DisplayComplete");
            }
        }

        public override void Reset()
        {
            this.ViewPort = ViewPortFactory.GetViewPort(this.Message);

            if (this.ViewPort is StaticViewPort)
            {
                this.displayStarted = DateTime.Now;
            }
        }

        #region Overridden Methods

        public override void Draw(HidDevice device, byte brightness)
        {
            this.ViewPort.DisplayString(device, brightness);
        }

        #endregion
    }
}
