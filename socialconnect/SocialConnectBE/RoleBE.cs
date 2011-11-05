using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class RoleBE
    {
        #region Declaration of the private member's of the class
        int _RoleId;
        string _RoleName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        #endregion
    }
}
