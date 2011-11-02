using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class AlbumBE
    {
        #region Declaration of the private member's of the class
        int _Album;
        int _CoverImageId;
        int _OwnerId;
        String _Name;
        String _Caption;
        DateTime _AddedDateTime;
        DateTime _ModifiedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int Album
        {
            get { return _Album; }
            set { _Album = value; }
        }

        public int CoverImageId
        {
            get { return _CoverImageId; }
            set { _CoverImageId = value; }
        }

        public int OwnerId
        {
            get { return _OwnerId; }
            set { _OwnerId = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public String Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }
        
        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
        

        public DateTime ModifiedDateTime
        {
            get { return _ModifiedDateTime; }
            set { _ModifiedDateTime = value; }
        }
         #endregion

    }
}
