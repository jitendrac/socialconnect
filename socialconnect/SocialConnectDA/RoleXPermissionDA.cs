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
    public class RoleXPermissionDA
    {
        private const string spRoleXPermissionSave = "spRoleXPermission_Save";
        private const string spRoleXPermissionDelete = "spRoleXPermission_Delete";
        private const string spRoleXPermissionGetAll = "spRoleXPermission_GetAll";
        private const string spRoleXPermissionGetElementById = "spRoleXPermission_SelectByRoleXPermissionId";

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
        /// The Function is used for Inserting or Updating the data of the RoleXPermission
        /// </summary>
        /// <param name="objRoleXPermissionBE">Object of RoleXPermissionbe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(RoleXPermissionBE objRoleXPermissionBE)
        {
            List<GenralizeParametre> ObjListRoleXPermissionParam = new List<GenralizeParametre>();
            ObjListRoleXPermissionParam.Add(new GenralizeParametre("RoleXPermissionId", objRoleXPermissionBE.RoleXPermissionId, DbType.Int32));
            ObjListRoleXPermissionParam.Add(new GenralizeParametre("RoleId", objRoleXPermissionBE.RoleId, DbType.Int32));
            ObjListRoleXPermissionParam.Add(new GenralizeParametre("PermissionId", objRoleXPermissionBE.PermissionId, DbType.Int32));
            
            objRoleXPermissionBE.RoleXPermissionId = GenralizeStoredProcedure.GetInt(spRoleXPermissionSave, ObjListRoleXPermissionParam);
            return objRoleXPermissionBE.RoleXPermissionId;
        }

        public static bool Delete(int intRoleXPermissionId)
        {
            List<GenralizeParametre> ObjListRoleXPermissionParam = new List<GenralizeParametre>();
            ObjListRoleXPermissionParam.Add(new GenralizeParametre("RoleXPermissionId", intRoleXPermissionId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spRoleXPermissionDelete, ObjListRoleXPermissionParam);
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
            List<GenralizeParametre> ObjListRoleXPermissionParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spRoleXPermissionGetAll, ObjListRoleXPermissionParam);
            return objDataSet;
        }

        public static RoleXPermissionBE GetElementById(int intRoleXPermissionId)
        {
            List<GenralizeParametre> ObjListRoleXPermissionParam = new List<GenralizeParametre>();
            ObjListRoleXPermissionParam.Add(new GenralizeParametre("RoleXPermissionId", intRoleXPermissionId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spRoleXPermissionGetElementById, ObjListRoleXPermissionParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static RoleXPermissionBE FillDataRecord(IDataRecord dr)
        {
            RoleXPermissionBE objRoleXPermissionBE = new RoleXPermissionBE();
            if (!dr.IsDBNull(dr.GetOrdinal("RoleXPermissionId")))
            {
                objRoleXPermissionBE.RoleXPermissionId = dr.GetInt32(dr.GetOrdinal("RoleXPermissionId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("RoleId")))
            {
                objRoleXPermissionBE.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("PermissionId")))
            {
                objRoleXPermissionBE.PermissionId = dr.GetInt32(dr.GetOrdinal("PermissionId"));
            }
            
            return objRoleXPermissionBE;
        }

        #endregion
    
    }
}
