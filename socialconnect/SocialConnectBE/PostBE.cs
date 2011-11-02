using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class PostBE
    {
        #region Declaration of the private member's of the class
        int _PostId;
        int _CreatorId; 
        int _PostTypeId;
        string _Title;
        string _Contents;
        DateTime _AddedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int PostId
        {
            get { return _PostId; }
            set { _PostId = value; }
        }
        

        public int CreatorId
        {
            get { return _CreatorId; }
            set { _CreatorId = value; }
        }
        
        public int PostTypeId
        {
            get { return _PostTypeId; }
            set { _PostTypeId = value; }
        }
        
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }


        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
        #endregion    
    }
}
