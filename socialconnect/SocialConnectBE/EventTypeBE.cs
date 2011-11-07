using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class EventTypeBE
    {
        #region Declaration of the private member's of the class
        int _EventTypeId;
        string _EventTypeName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int EventTypeId
        {
            get { return _EventTypeId; }
            set { _EventTypeId = value; }
        }
        

        public string EventTypeName
        {
            get { return _EventTypeName; }
            set { _EventTypeName = value; }
        }
         #endregion
    }
}
