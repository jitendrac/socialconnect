using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using SocialConnectBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Collections;

namespace SocialConnectDA
{
    public class WallStoryDA
    {
        private const string spGetPost = "spGetPost";
      

        public static DataSet getAllElements()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            String DbCommandStr = "Select * from sys.tables";
            using (DbCommand dbCommand = db.GetSqlStringCommand(DbCommandStr))
            {
                ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// The Function is used for Inserting or Updating the data of the User
        /// </summary>
        /// <param name="objUserBE">Object of Userbe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>

        public static DataSet GetWallStoryByUserId(int intUserId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("UserId", intUserId, DbType.Int32));
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spGetPost, ObjListUserParam);
            
            return objDataSet;
        }


    }
}
