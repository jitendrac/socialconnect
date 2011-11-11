using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialConnectBE
{
    public class EventParticipantBE
    {

        #region Declaration of the private member's of the class
        int _EventParticipantId;
        int _EventId;
        int _SubmissionStatusId;
        string _Description;
        int _ParticipantParentId;
        DateTime _AddedDateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int EventParticipantId
        {
            get { return _EventParticipantId; }
            set { _EventParticipantId = value; }
        }
        
        public int EventId
        {
            get { return _EventId; }
            set { _EventId = value; }
        }
        
        public int SubmissionStatusId
        {
            get { return _SubmissionStatusId; }
            set { _SubmissionStatusId = value; }
        }
        
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        
        public int ParticipantParentId
        {
            get { return _ParticipantParentId; }
            set { _ParticipantParentId = value; }
        }
        

        public DateTime AddedDateTime
        {
            get { return _AddedDateTime; }
            set { _AddedDateTime = value; }
        }
         #endregion

    }
}
