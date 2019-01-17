using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    /// <summary>
    /// Sends the custom text to the appropriate view port 
    /// </summary>
    public class CustomTextDisplayAdapter : DisplayAdapter
    {
        public string Message { get; set; }

        private DateTime displayStarted;

        public CustomTextDisplayAdapter() { }

        public CustomTextDisplayAdapter(string message, string title)
        {
            this.Initialize(message, title);
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

        public override string Serialize()
        {
            var sb = new StringBuilder();

            AppendForSerialize(sb, base.Serialize());
            AppendForSerialize(sb, this.Message);

            return sb.ToString();
        }

        public override void PopulateFromString(string s)
        {
            var items = base.PopulateBaseFromString(s);

            this.Message = items[0];
        }

        #endregion

        private void Initialize(string message, string title)
        {
            this.Message = message;
            this.Title = title;

            this.ViewPort = ViewPortFactory.GetViewPort(this.Message);
            this.displayStarted = DateTime.Now;
        }
    }
}
