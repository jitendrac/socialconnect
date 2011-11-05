using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class FileBE
    {

        #region Declaration of the private member's of the class
        int _FileId;
        string _FileName;
        string _FilePath;
        DateTime _AddedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int FileId
        {
            get { return _FileId; }
            set { _FileId = value; }
        }


        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }


        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }


        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
        #endregion
    }
}
