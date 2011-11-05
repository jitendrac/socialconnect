using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SocialConnectDA;

namespace SocialConnectBL
{
    public class UserBL
    {
        public static DataSet getAllElements()
        {
            return UserDA.getAllElements();
        }
    }
}
