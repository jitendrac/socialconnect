using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class UserBE
    {
        #region Declaration of the private member's of the class
        int _UserId;
        string _Name;
        string _Password;
        string _Address;
        string _ContactNo;
        string _EmailId;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string Email_id
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        #endregion
    }
}
