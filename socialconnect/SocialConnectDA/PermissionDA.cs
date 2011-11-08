using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Collections;

using SocialConnectBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace SocialConnectDA
{
    public class PermissionDA
    {
        private const string spPermissionSave = "spPermission_Save";
        private const string spPermissionDelete = "spPermission_Delete";
        private const string spPermissionGetAll = "spPermission_GetAll";
        private const string spPermissionGetElementById = "spPermission_SelectByPermissionId";


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
        /// <param name="objPermissionBE"></param>
        /// <returns></returns>
        public static int Save(PermissionBE objPermissionBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PermissionId", objPermissionBE.PermissionId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("PermissionName", objPermissionBE.PermissionName, DbType.String));
            
            objPermissionBE.PermissionId = GenralizeStoredProcedure.GetInt(spPermissionSave, ObjListUserParam);
            return objPermissionBE.PermissionId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPermissionId"></param>
        /// <returns></returns>
        public static bool Delete(int intPermissionId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PermissionId", intPermissionId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spPermissionDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spPermissionGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPermissionId"></param>
        /// <returns></returns>
        public static PermissionBE GetElementById(int intPermissionId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PermissionId", intPermissionId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spPermissionGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static PermissionBE FillDataRecord(IDataRecord dr)
        {
            PermissionBE objPermissionBE = new PermissionBE();
            if (!dr.IsDBNull(dr.GetOrdinal("PermissionId")))
            {
                objPermissionBE.PermissionId = dr.GetInt32(dr.GetOrdinal("PermissionId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("PermissionName")))
            {
                objPermissionBE.PermissionName = dr.GetString(dr.GetOrdinal("PermissionName"));
            }
            return objPermissionBE;
        }

        #endregion
    }
}
