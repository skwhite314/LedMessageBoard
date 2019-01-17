using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HidLibrary;

namespace LedMessageBoard.DisplayAdapters
{
    /// <summary>
    /// Interface for all display adapters (classes that determine what view port to use and what data to display)
    /// </summary>
    public interface IDisplayAdapter
    {
        /// <summary>
        /// The title of the display
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Whether or not this display adapter is active
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        /// Whether or not the display is done being displayed
        /// </summary>
        bool DisplayComplete { get; }

        ViewPort ViewPort { get; }

        /// <summary>
        /// Resets the display to be displayed again
        /// </summary>
        void Reset();

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="device">The device to draw to</param>
        /// <param name="brightness">The brightness to use</param>
        void Draw(HidDevice device, byte brightness);

        string Serialize();

        void PopulateFromString(string s);
    }
}
