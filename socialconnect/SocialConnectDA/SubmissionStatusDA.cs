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
   public class SubmissionStatusDA
    {
        private const string spSubmissionStatusSave = "spSubmissionStatus_Save";
        private const string spSubmissionStatusDelete = "spSubmissionStatus_Delete";
        private const string spSubmissionStatusGetAll = "spSubmissionStatus_GetAll";
        private const string spSubmissionStatusGetElementById = "spSubmissionStatus_SelectBySubmissionStatusId";

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
        /// The Function is used for Inserting or Updating the data of the SubmissionStatus
        /// </summary>
        /// <param name="objSubmissionStatusBE">Object of SubmissionStatusbe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(SubmissionStatusBE objSubmissionStatusBE)
        {
            List<GenralizeParametre> ObjListSubmissionStatusParam = new List<GenralizeParametre>();
            ObjListSubmissionStatusParam.Add(new GenralizeParametre("SubmissionStatusId", objSubmissionStatusBE.SubmissionStatusId, DbType.Int32));
            ObjListSubmissionStatusParam.Add(new GenralizeParametre("Status", objSubmissionStatusBE.Status, DbType.String));
            
            objSubmissionStatusBE.SubmissionStatusId = GenralizeStoredProcedure.GetInt(spSubmissionStatusSave, ObjListSubmissionStatusParam);
            return objSubmissionStatusBE.SubmissionStatusId;
        }

        public static bool Delete(int intSubmissionStatusId)
        {
            List<GenralizeParametre> ObjListSubmissionStatusParam = new List<GenralizeParametre>();
            ObjListSubmissionStatusParam.Add(new GenralizeParametre("SubmissionStatusId", intSubmissionStatusId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spSubmissionStatusDelete, ObjListSubmissionStatusParam);
            if (tempInt == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static DataSet GetAll()
        {
            List<GenralizeParametre> ObjListSubmissionStatusParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spSubmissionStatusGetAll, ObjListSubmissionStatusParam);
            return objDataSet;
        }

        public static SubmissionStatusBE GetElementById(int intSubmissionStatusId)
        {
            List<GenralizeParametre> ObjListSubmissionStatusParam = new List<GenralizeParametre>();
            ObjListSubmissionStatusParam.Add(new GenralizeParametre("SubmissionStatusId", intSubmissionStatusId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spSubmissionStatusGetElementById, ObjListSubmissionStatusParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static SubmissionStatusBE FillDataRecord(IDataRecord dr)
        {
            SubmissionStatusBE objSubmissionStatusBE = new SubmissionStatusBE();
            if (!dr.IsDBNull(dr.GetOrdinal("SubmissionStatusId")))
            {
                objSubmissionStatusBE.SubmissionStatusId = dr.GetInt32(dr.GetOrdinal("SubmissionStatusId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Status")))

            {
                objSubmissionStatusBE.Status = dr.GetString(dr.GetOrdinal("Status"));
            }
           
            return objSubmissionStatusBE;
        }

        #endregion

    }
}
