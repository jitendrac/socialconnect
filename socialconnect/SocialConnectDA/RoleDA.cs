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
    public class RoleDA
    {
        private const string spRoleSave = "spRole_Save";
        private const string spRoleDelete = "spRole_Delete";
        private const string spRoleGetAll = "spRole_GetAll";
        private const string spRoleGetElementById = "spRole_SelectByRoleId";

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
        /// The Function is used for Inserting or Updating the data of the Role
        /// </summary>
        /// <param name="objRoleBE">Object of Rolebe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(RoleBE objRoleBE)
        {
            List<GenralizeParametre> ObjListRoleParam = new List<GenralizeParametre>();
            ObjListRoleParam.Add(new GenralizeParametre("RoleId", objRoleBE.RoleId, DbType.Int32));
            ObjListRoleParam.Add(new GenralizeParametre("RoleName", objRoleBE.RoleName, DbType.String));
            
            objRoleBE.RoleId = GenralizeStoredProcedure.GetInt(spRoleSave, ObjListRoleParam);
            return objRoleBE.RoleId;
        }

        public static bool Delete(int intRoleId)
        {
            List<GenralizeParametre> ObjListRoleParam = new List<GenralizeParametre>();
            ObjListRoleParam.Add(new GenralizeParametre("RoleId", intRoleId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spRoleDelete, ObjListRoleParam);
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
            List<GenralizeParametre> ObjListRoleParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spRoleGetAll, ObjListRoleParam);
            return objDataSet;
        }

        public static RoleBE GetElementById(int intRoleId)
        {
            List<GenralizeParametre> ObjListRoleParam = new List<GenralizeParametre>();
            ObjListRoleParam.Add(new GenralizeParametre("RoleId", intRoleId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spRoleGetElementById, ObjListRoleParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static RoleBE FillDataRecord(IDataRecord dr)
        {
            RoleBE objRoleBE = new RoleBE();
            if (!dr.IsDBNull(dr.GetOrdinal("RoleId")))
            {
                objRoleBE.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("RoleName")))
            {
                objRoleBE.RoleName = dr.GetString(dr.GetOrdinal("RoleName"));
            }
            

            return objRoleBE;
        }

        #endregion
    }
}
