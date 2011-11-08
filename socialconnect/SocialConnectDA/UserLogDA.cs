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
    public class UserLogDA
    {
        private const string spUserLogSave = "spUserLog_Save";
        private const string spUserLogDelete = "spUserLog_Delete";
        private const string spUserLogGetAll = "spUserLog_GetAll";
        private const string spUserLogGetElementById = "spUserLog_SelectByUserLogId";
        /// <summary>
        /// The Function is used for Inserting or Updating the data of the UserLog
        /// </summary>
        /// <param name="objUserLogBE">Object of UserLogbe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(UserLogBE objUserLogBE)
        {
            List<GenralizeParametre> ObjListUserLogParam = new List<GenralizeParametre>();
            ObjListUserLogParam.Add(new GenralizeParametre("UserLogId", objUserLogBE.UserLogId, DbType.Int32));
            ObjListUserLogParam.Add(new GenralizeParametre("UserId", objUserLogBE.UserId, DbType.Int32));
            ObjListUserLogParam.Add(new GenralizeParametre("LogInfo", objUserLogBE.LogInfo, DbType.String));
            ObjListUserLogParam.Add(new GenralizeParametre("AddedDateTime", objUserLogBE.AddedDateTime, DbType.DateTime));
           
            objUserLogBE.UserLogId = GenralizeStoredProcedure.GetInt(spUserLogSave, ObjListUserLogParam);
            return objUserLogBE.UserLogId;
        }

        /// <summary>
        /// The Delete function accepts the UserLogId and deletes the User data
        /// </summary>
        /// <param name="intUserLogId">The Id of UserLog to Delete</param>
        /// <returns>returns true or false</returns>
        public static bool Delete(int intUserLogId)
        {
            List<GenralizeParametre> ObjListUserLogParam = new List<GenralizeParametre>();
            ObjListUserLogParam.Add(new GenralizeParametre("UserLogId", intUserLogId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spUserLogDelete, ObjListUserLogParam);
            if (tempInt == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// The function returns all data of the table UserLog
        /// </summary>
        /// <returns>Returns the Dataset containing all data of UserLog </returns>
        public static DataSet GetAll()
        {
            List<GenralizeParametre> ObjListUserLogParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spUserLogGetAll, ObjListUserLogParam);
            return objDataSet;
        }

        /// <summary>
        /// The function accepts the UserLogId and Returns the Specific UserLogBe object
        /// </summary>
        /// <param name="intUserLogId">Id of UserLog to Get</param>
        /// <returns>Returns UserLogBE</returns>
        public static UserLogBE GetElementById(int intUserLogId)
        {
            List<GenralizeParametre> ObjListUserLogParam = new List<GenralizeParametre>();
            ObjListUserLogParam.Add(new GenralizeParametre("UserLogId", intUserLogId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spUserLogGetElementById, ObjListUserLogParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static UserLogBE FillDataRecord(IDataRecord dr)
        {
            UserLogBE objUserLogBE = new UserLogBE();
            if (!dr.IsDBNull(dr.GetOrdinal("UserLogId")))
            {
                objUserLogBE.UserLogId = dr.GetInt32(dr.GetOrdinal("UserLogId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("UserId")))
            {
                objUserLogBE.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("LogInfo")))
            {
                objUserLogBE.LogInfo = dr.GetString(dr.GetOrdinal("LogInfo"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AddedDateTime")))
            {
                objUserLogBE.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }
          
            return objUserLogBE;
        }

        #endregion
    }
}
