using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedMessageBoard
{
    /// <summary>
    /// Parent class for all view ports. Handles encoding the message in such a way as to display on the message board
    /// </summary>
    public abstract class ViewPort
    {
        public const int MaxWidth = 21;
        public const int Height = 7;

        public int Width { get; private set; }

        public int LeftMargin { get; protected set; }

        public int RightMargin { get; protected set; }

        public string Message { get; private set; }

        public int MessageWidth { get; private set; }

        public int Offset { get; set; }

        protected ViewPort(int width, string message)
        {
            this.Width = width > 0 && width <= MaxWidth ? width : MaxWidth;

            var diff = MaxWidth - this.Width;

            this.LeftMargin = diff / 2;

            this.RightMargin = MaxWidth - this.Width - this.LeftMargin;

            this.ChangeMessage(message);
        }

        public virtual void ChangeMessage(string message, bool keepOffset = false)
        {
            this.Message = string.IsNullOrWhiteSpace(message)
                               ? LedMessageBoard.Properties.Settings.Default.Global_DefaultViewPortMessage
                               : message;

            this.MessageWidth = LedFont.StringWidth(message);

            if (!keepOffset)
            {
                this.Offset = this.Width;
            }
        }

        public virtual void DisplayString(HidDevice device, byte brightness)
        {
            var bools = this.RenderAsBools();

            var packet = new byte[9];

            packet[0] = 0; // Report ID must be 0

            packet[1] = brightness; // Brightness ranges from 0 to 3

            for (var row = 0; row < Height; row += 2)
            {
                // set our row
                packet[2] = (byte)row;

                // first row
                packet[3] = ToLedByte(bools, row, 16);
                packet[4] = ToLedByte(bools, row, 8);
                packet[5] = ToLedByte(bools, row, 0);

                // second row
                packet[6] = ToLedByte(bools, row + 1, 16);
                packet[7] = ToLedByte(bools, row + 1, 8);
                packet[8] = ToLedByte(bools, row + 1, 0);

                if (device != null)
                {
                    device.Write(packet);
                }
            }
        }

        private static byte ToLedByte(bool[,] buffer, int row, int x)
        {
            byte result = 0xff;

            if (x < 0 || x >= buffer.GetLength(0) || row < 0 || row >= buffer.GetLength(1))
            {
                return result;
            }

            for (var i = 0; i < 8 && x + i < buffer.GetLength(0); i++)
            {
                if (buffer[x + i, row])
                {
                    result &= (byte)(~(1 << i));
                }
            }

            return result;
        }

        private bool[,] RenderAsBools()
        {
            var result = new bool[MaxWidth, Height];

            int xloc = this.Offset + this.LeftMargin;

            foreach (var c in this.Message.ToCharArray())
            {
                this.RenderChar(c, xloc, ref result);
                xloc = xloc + LedFont.CharWidth(c) + 1;
            }

            return result;
        }

        private void RenderChar(char c, int offset, ref bool[,] buffer)
        {
            var charWidth = LedFont.CharWidth(c);
            var blankOffset = LedFont.LeftBlankColumns(c);

            for (var x = 0; x < charWidth; x++)
            {
                var xi = x + offset;

                if ( xi < this.LeftMargin || xi >= this.Width + this.LeftMargin)
                {
                    continue;
                }

                var xchar = x + blankOffset;

                for (var y = 0; y < Height; y++)
                {
                    var bit = LedFont.IsSet(c, xchar, y);

                    buffer[xi, y] = bit;
                }
            }
        }
    }
}
