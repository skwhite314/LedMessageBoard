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

        public ViewPort ViewPort { get; set; }

        public abstract bool DisplayComplete { get; }

        public abstract void Draw(HidDevice device, byte brightness);

        public abstract void Reset();

        public virtual string Serialize()
        {
            var sb = new StringBuilder();

            AppendForSerialize(sb, this.Title);
            AppendForSerialize(sb, this.Active);

            return sb.ToString();
        }

        public abstract void PopulateFromString(string s);

        public override string ToString()
        {
            return this.Title ?? "Nothing";
        }

        protected static void AppendForSerialize(StringBuilder sb, object entry)
        {
            if (sb.Length == 0)
            {
                sb.Append(entry);
            }
            else
            {
                sb.Append(Delimiter);
                sb.Append(entry);
            }
        }

        protected string[] PopulateBaseFromString(string s)
        {
            var entries = s.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();

            this.Title = entries[0];
            entries.RemoveAt(0);

            this.Active = bool.Parse(entries[0]);
            entries.RemoveAt(0);

            return entries.ToArray();
        }
    }
}
