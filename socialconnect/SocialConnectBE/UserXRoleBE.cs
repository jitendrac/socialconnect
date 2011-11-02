using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class UserXRoleBE
    {
        #region Declaration of the private member's of the class
        int _UserXRoleId;
        int _UserId;
        int _RoleId;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int UserXRoleId
        {
            get { return _UserXRoleId; }
            set { _UserXRoleId = value; }
        }
        
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        #endregion
    }
}
