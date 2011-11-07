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
    public class ErrorLogDA
    {
        private const string spErrorLogSave = "spErrorLog_Save";
        private const string spErrorLogDelete = "spErrorLog_Delete";
        private const string spErrorLogGetAll = "spErrorLog_GetAll";
        private const string spErrorLogGetElementById = "spAlbum_SelectByErrorLogId";

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
        /// 
        /// </summary>
        /// <param name="objErrorLogBE"></param>
        /// <returns></returns>
        public static int Save(ErrorLogBE objErrorLogBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("ErrorLogId", objErrorLogBE.ErrorLogId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("ErrorCustomMessage", objErrorLogBE.ErrorCustomMessage, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("ErrorStackTrace", objErrorLogBE.ErrorStackTrace, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("ErrorMessage", objErrorLogBE.ErrorMessage, DbType.String));
            objErrorLogBE.ErrorLogId = GenralizeStoredProcedure.GetInt(spErrorLogSave, ObjListUserParam);
            return objErrorLogBE.ErrorLogId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intErrorLogId"></param>
        /// <returns></returns>
        public static bool Delete(int intErrorLogId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("ErrorLogId", intErrorLogId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spErrorLogDelete, ObjListUserParam);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAll()
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spErrorLogGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intErrorLogId"></param>
        /// <returns></returns>
        public static ErrorLogBE GetElementById(int intErrorLogId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("ErrorLogId", intErrorLogId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spErrorLogGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static ErrorLogBE FillDataRecord(IDataRecord dr)
        {
            ErrorLogBE objErrorLogBE = new ErrorLogBE();
            if (!dr.IsDBNull(dr.GetOrdinal("ErrorLogId")))
            {
                objErrorLogBE.ErrorLogId = dr.GetInt32(dr.GetOrdinal("ErrorLogId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ErrorCustomMessage")))
            {
                objErrorLogBE.ErrorCustomMessage = dr.GetString(dr.GetOrdinal("ErrorCustomMessage"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ErrorStackTrace")))
            {
                objErrorLogBE.ErrorStackTrace = dr.GetString(dr.GetOrdinal("ErrorStackTrace"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ErrorMessage")))
            {
                objErrorLogBE.ErrorMessage = dr.GetString(dr.GetOrdinal("ErrorMessage"));
            }
            return objErrorLogBE;
        }

        #endregion

    }
}
