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
        /// Creates a display adapter based on the entered values
        /// </summary>
        /// <exception cref="ConfigurationException"/>
        IDisplayAdapter CreateDisplayAdapter();

        /// <summary>
        /// Returns the implementing object as a ConfigurationPanel (can't use an interface as an object)
        /// </summary>
        /// <returns></returns>
        ConfigurationPanel ToControl();

        string GetDisplayAdapterType();

        bool PopulateFromDisplayAdapter(IDisplayAdapter displayAdapter);
    }
}
