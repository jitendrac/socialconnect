using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class PermissionBE
    {
        #region Declaration of the private member's of the class
        int _PermissionId;
        string _PermissionName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int PermissionId
        {
            get { return _PermissionId; }
            set { _PermissionId = value; }
        }
       
        public string PermissionName
        {
            get { return _PermissionName; }
            set { _PermissionName = value; }
        }
        #endregion
    }
}
