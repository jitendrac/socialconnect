using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class GroupXFilesBE
    {
    
        #region Declaration of the private member's of the class
        int _GroupXField;
        int _GroupId;
        int _FileId;
        string _Category;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int GroupXField
        {
          get { return _GroupXField; }
          set { _GroupXField = value; }
        }
                
        public int GroupId
        {
          get { return _GroupId; }
          set { _GroupId = value; }
        }
        

        public int FileId
        {
          get { return _FileId; }
          set { _FileId = value; }
        }
                

        public string Category
        {
          get { return _Category; }
          set { _Category = value; }
        }
        #endregion
    }
}
