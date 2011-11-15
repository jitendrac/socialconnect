using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SocialConnectBE;
using SocialConnectDA;

namespace SocialConnectBL
{
   public class WallStoryBL
    {
       public static DataSet GetWallStoryByUserId(int intUserId)
       {
           return WallStoryDA.GetWallStoryByUserId(1);
       }
    }
}
