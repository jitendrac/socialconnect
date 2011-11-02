using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class NotificationBE
    {
        #region Declaration of the private member's of the class
        int _NotificationId;
        int _UserId;
        DateTime _DateTime;
        String _NotificationDescription;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int NotificationId
        {
            get { return _NotificationId; }
            set { _NotificationId = value; }
        }
        
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        
        public DateTime DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }
        
        public String NotificationDescription
        {
            get { return _NotificationDescription; }
            set { _NotificationDescription = value; }
        }
        #endregion

    }
}
