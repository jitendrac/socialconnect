using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class EventBE
    {
        #region Declaration of the private member's of the class
        int _EventId;
        string _EventTitle;
        string _EventDescription;
        int _ownerId;
        int _ownerTypeId;
        int _EventTypeId;
        DateTime _EventStartDateTime;
        DateTime _EventEndDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int EventId
        {
            get { return _EventId; }
            set { _EventId = value; }
        }
        
        public string EventTitle
        {
            get { return _EventTitle; }
            set { _EventTitle = value; }
        }
        
        public string EventDescription
        {
            get { return _EventDescription; }
            set { _EventDescription = value; }
        }
        
        public int OwnerId
        {
            get { return _ownerId; }
            set { _ownerId = value; }
        }
        
        public int OwnerTypeId
        {
            get { return _ownerTypeId; }
            set { _ownerTypeId = value; }
        }
        
        public int EventTypeId
        {
            get { return _EventTypeId; }
            set { _EventTypeId = value; }
        }
        
        public DateTime EventStartDateTime
        {
            get { return _EventStartDateTime; }
            set { _EventStartDateTime = value; }
        }
        

        public DateTime EventEndDateTime
        {
            get { return _EventEndDateTime; }
            set { _EventEndDateTime = value; }
        }
         #endregion

    }
}
