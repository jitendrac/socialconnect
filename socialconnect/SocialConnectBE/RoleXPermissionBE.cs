using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class RoleXPermissionBE
    {
        #region Declaration of the private member's of the class
        int _RoleXPermissionId;
        int _RoleId;
        int _PermissionId;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int RoleXPermissionId
        {
            get { return _RoleXPermissionId; }
            set { _RoleXPermissionId = value; }
        }
        
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        
        public int PermissionId
        {
            get { return _PermissionId; }
            set { _PermissionId = value; }
        }
        #endregion
    
    }
}
