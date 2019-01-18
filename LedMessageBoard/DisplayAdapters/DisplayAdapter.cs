using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using HidLibrary;
using Newtonsoft.Json;

namespace LedMessageBoard.DisplayAdapters
{
    public abstract class DisplayAdapter : IDisplayAdapter
    {
        public static readonly string Delimiter = Environment.NewLine;

        public static TimeSpan StaticDisplayDuration
        {
            get
            {
                var timespan = new TimeSpan(0, 0, LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration);
                return timespan;
            }
        }

        public string Title { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public ViewPort ViewPort { get; set; }

        [JsonIgnore]
        public abstract bool DisplayComplete { get; }

        public abstract void Draw(HidDevice device, byte brightness);

        public abstract void Reset();

        public override string ToString()
        {
            return this.Title;
        }
    }
}
