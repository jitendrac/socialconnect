using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class PostTypeBE
    {
        #region Declaration of the private member's of the class
        int _PostTypeId;
        int _PostTypeName;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int PostTypeId
        {
            get { return _PostTypeId; }
            set { _PostTypeId = value; }
        }
        
        public int PostTypeName
        {
            get { return _PostTypeName; }
            set { _PostTypeName = value; }
        }
        #endregion
    }
}
