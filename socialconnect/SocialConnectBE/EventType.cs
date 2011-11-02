using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class EventType
    {
        #region Declaration of the private member's of the class
        int _EventTypeId;
        string EventTypeName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int EventTypeId
        {
            get { return _EventTypeId; }
            set { _EventTypeId = value; }
        }
        

        public string EventTypeName1
        {
            get { return EventTypeName; }
            set { EventTypeName = value; }
        }
         #endregion
    }
}
