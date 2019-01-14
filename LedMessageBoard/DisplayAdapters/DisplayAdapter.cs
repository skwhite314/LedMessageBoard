using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    internal abstract class DisplayAdapter : IDisplayAdapter
    {
        public static TimeSpan StaticDisplayDuration
        {
            get
            {
                var timespan = new TimeSpan(0, 0, LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration);
                return timespan;
            }
        }

        public string Title { get; protected set; }

        public bool Active { get; set; }

        public ViewPort ViewPort { get; protected set; }

        public abstract bool DisplayComplete { get; }

        public abstract void Draw(HidDevice device, byte brightness);

        public abstract void Reset();

        public override string ToString()
        {
            return this.Title ?? "Nothing";
        }
    }
}
