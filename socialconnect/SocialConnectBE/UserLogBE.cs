using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class UserLogBE
    {
        #region Declaration of the private member's of the class
        int _UserLogId;
        int _UserId;
        string _LogInfo;
        DateTime _AddedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int UserLogId
        {
            get { return _UserLogId; }
            set { _UserLogId = value; }
        }
        
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        
        public string LogInfo
        {
            get { return _LogInfo; }
            set { _LogInfo = value; }
        }
        
        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
        #endregion
    }
}
