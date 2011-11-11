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
        string _CustomMessage;
        string _StackTrace ;
        string _Message;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int ErrorLogId
        {   
            get { return _ErrorLogId; }
            set { _ErrorLogId = value; }
        }
        
        public string CustomMessage
        {
            get { return _CustomMessage; }
            set { _CustomMessage = value; }
        }
        
        public string StackTrace
        {
            get { return _StackTrace; }
            set { _StackTrace = value; }
        }
        

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion

    }
}
