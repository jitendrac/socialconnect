using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class SubmissionStatusBE
    {
        #region Declaration of the private member's of the class
        int _SubmissionStatusId;
        int _Status;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int SubmissionStatusId
        {
            get { return _SubmissionStatusId; }
            set { _SubmissionStatusId = value; }
        }
        

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

    }
}
