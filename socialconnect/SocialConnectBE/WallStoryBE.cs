using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    public class WallStoryBE
    {
        int _PostId = 0;
        int _CreatirId = 0;
        string _CreatorName = "";
        string _PostTypeName = "";
        string _Title = "";
        string _Contents = "";
        public int PostId
        {
            get { return _PostId; }
            set { _PostId = value; }
        }

        public int CreatirId
        {
            get { return _CreatirId; }
            set { _CreatirId = value; }
        }

        public string CreatorName
        {
            get { return _CreatorName; }
            set { _CreatorName = value; }
        }

        public string PostTypeName
        {
            get { return _PostTypeName; }
            set { _PostTypeName = value; }
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
    }
}
