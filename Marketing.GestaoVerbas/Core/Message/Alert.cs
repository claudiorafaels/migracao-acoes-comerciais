using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.Core.Message
{
    public class Alert
    {
        public AlertStyle AlertStyle { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        private bool? _EnableClose;
        public bool EnableClose
        {
            get
            {
                if (_EnableClose != null)
                    return _EnableClose.Value;
                else
                    return true;
            }
            set { _EnableClose = value; }
        }

        private bool? _AutoClose;
        public bool AutoClose
        {
            get
            {
                if (_AutoClose != null)
                    return _AutoClose.Value;
                else if (AlertStyle == AlertStyle.success)
                    return true;
                else
                    return false;
            }
            set { _AutoClose = value; }
        }
    }
}
