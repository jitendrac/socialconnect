using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class OwnerTypeBE
    {
        #region Declaration of the private member's of the class
        int _OwnerTypeId;
        string _TypeName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int OwnerTypeId
        {
            get { return _OwnerTypeId; }
            set { _OwnerTypeId = value; }
        }
        

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        #endregion
    }
}
