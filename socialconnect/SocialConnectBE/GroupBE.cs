using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class GroupBE
    {
        #region Declaration of the private member's of the class
        int _GroupId;
        string _GroupName;
        int _OwnerId;
        DateTime _StartDate;
        DateTime _EndDate;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int GroupId
        {
            get { return _GroupId; }
            set { _GroupId = value; }
        }
        
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        
        public int OwnerId
        {
            get { return _OwnerId; }
            set { _OwnerId = value; }
        }
        
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        #endregion
    }
}
