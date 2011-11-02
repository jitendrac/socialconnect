using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    class MessagemasterBE
    {
        #region Declaration of the private member's of the class
        int _MessageId;
        string _MessageContent;
        int _SenderId;
        int _ReceiverId;
        DateTime _DateTime;
        #endregion

        #region Declaration of the encaptulating  properties of  private member's of the class
        public int MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }
        
        public string MessageContent
        {
            get { return _MessageContent; }
            set { _MessageContent = value; }
        }
        
        public int SenderId
        {
            get { return _SenderId; }
            set { _SenderId = value; }
        }
        
        public int ReceiverId
        {
            get { return _ReceiverId; }
            set { _ReceiverId = value; }
        }
        
        public DateTime DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }
        #endregion

    }
}
