using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedMessageBoard.Exceptions
{
    public class DisplayConfigurationException : Exception
    {
        public DisplayConfigurationException(string message) : base(message) { }

        public DisplayConfigurationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
