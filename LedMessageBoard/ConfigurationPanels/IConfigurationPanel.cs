using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedMessageBoard.DisplayAdapters;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Interface for all configuration panels
    /// </summary>
    internal interface IConfigurationPanel
    {
        /// <summary>
        /// The adapter that coordinates the displaying of what the user configured
        /// </summary>
        IDisplayAdapter CreateDisplayAdapter();

        /// <summary>
        /// Returns the implementing object as a ConfigurationPanel (can't use an interface as an object)
        /// </summary>
        /// <returns></returns>
        ConfigurationPanel ToControl();

        string GetDisplayAdapterType();
    }
}
