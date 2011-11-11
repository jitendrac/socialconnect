using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class EventBE
    {
        #region Declaration of the private member's of the class
        int _EventId;
        string _Title;
        string _Description;
        int _ownerId;
        int _ownerTypeId;
        int _EventTypeId;
        DateTime _StartDateTime;
        DateTime _EndDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int EventId
        {
            get { return _EventId; }
            set { _EventId = value; }
        }
        
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
        
        public DateTime StartDateTime
        {
            get { return _StartDateTime; }
            set { _StartDateTime = value; }
        }
        

        public DateTime EndDateTime
        {
            get { return _EndDateTime; }
            set { _EndDateTime = value; }
        }
         #endregion

    }
}
