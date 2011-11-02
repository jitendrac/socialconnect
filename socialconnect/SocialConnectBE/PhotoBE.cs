using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class PhotoBE
    {
        #region Declaration of the private member's of the class
        int _PhotoId;
        int _AlbumId;
        int _OwnerId;
        string _Description;
        string _SmanllSource;
        string _MediumSource;
        string _LargeSource;
        DateTime _AddedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int PhotoId
        {
            get { return _PhotoId; }
            set { _PhotoId = value; }
        }
        
        public int AlbumId
        {
            get { return _AlbumId; }
            set { _AlbumId = value; }
        }
        
        public int OwnerId
        {
            get { return _OwnerId; }
            set { _OwnerId = value; }
        }
        
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        
        public string SmanllSource
        {
            get { return _SmanllSource; }
            set { _SmanllSource = value; }
        }
        
        public string MediumSource
        {
            get { return _MediumSource; }
            set { _MediumSource = value; }
        }
        
        public string LargeSource
        {
            get { return _LargeSource; }
            set { _LargeSource = value; }
        }
        

        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
        #endregion
    }
}
