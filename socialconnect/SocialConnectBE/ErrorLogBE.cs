using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class ErrorLogBE
    {
        #region Declaration of the private member's of the class
        int _ErrorLogId;
        string _ErrorCustomMessage;
        string _ErrorStackTrace;
        string _ErrorMessage;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int ErrorLogId
        {   
            get { return _ErrorLogId; }
            set { _ErrorLogId = value; }
        }
        
        public string ErrorCustomMessage
        {
            get { return _ErrorCustomMessage; }
            set { _ErrorCustomMessage = value; }
        }
        
        public string ErrorStackTrace
        {
            get { return _ErrorStackTrace; }
            set { _ErrorStackTrace = value; }
        }
        

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        #endregion

    }
}
