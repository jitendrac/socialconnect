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
    public class UserXRoleDA
    {
        private const string spUserXRoleSave = "spUserXRole_Save";
        private const string spUserXRoleDelete = "spUserXRole_Delete";
        private const string spUserXRoleGetAll = "spUserXRole_GetAll";
        private const string spUserXRoleGetElementById = "spUserXRole_SelectByUserXRoleId";
        /// <summary>
        /// The Function is used for Inserting or Updating the data of the UserXRole
        /// </summary>
        /// <param name="objUserXRoleBE">Object of UserXRolebe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(UserXRoleBE objUserXRoleBE)
        {
            List<GenralizeParametre> ObjListUserXRoleParam = new List<GenralizeParametre>();
            ObjListUserXRoleParam.Add(new GenralizeParametre("UserXRoleId", objUserXRoleBE.UserXRoleId, DbType.Int32));
            ObjListUserXRoleParam.Add(new GenralizeParametre("UserId", objUserXRoleBE.UserId, DbType.Int32));
            ObjListUserXRoleParam.Add(new GenralizeParametre("RoleId", objUserXRoleBE.RoleId, DbType.Int32));
            objUserXRoleBE.UserId = GenralizeStoredProcedure.GetInt(spUserXRoleSave, ObjListUserXRoleParam);
            return objUserXRoleBE.UserXRoleId;
            
        }

        public static bool Delete(int intUserXRoleId)
        {
            List<GenralizeParametre> ObjListUserXRoleParam = new List<GenralizeParametre>();
            ObjListUserXRoleParam.Add(new GenralizeParametre("UserXRoleId", intUserXRoleId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spUserXRoleDelete, ObjListUserXRoleParam);
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
            List<GenralizeParametre> ObjListUserXRoleParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spUserXRoleGetAll, ObjListUserXRoleParam);
            return objDataSet;
        }

        public static UserXRoleBE GetElementById(int intUserXRoleId)
        {
            List<GenralizeParametre> ObjListUserXRoleParam = new List<GenralizeParametre>();
            ObjListUserXRoleParam.Add(new GenralizeParametre("UserXRoleId", intUserXRoleId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spUserXRoleGetElementById, ObjListUserXRoleParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static UserXRoleBE FillDataRecord(IDataRecord dr)
        {
            UserXRoleBE objUserXRoleBE = new UserXRoleBE();
            if (!dr.IsDBNull(dr.GetOrdinal("UserId")))
            {
                objUserXRoleBE.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("UserXRoleId")))
            {
                objUserXRoleBE.UserXRoleId = dr.GetInt32(dr.GetOrdinal("UserXRoleId"));
            } if (!dr.IsDBNull(dr.GetOrdinal("RoleId")))
            {
                objUserXRoleBE.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
            }
            return objUserXRoleBE;
        }

        #endregion

    }
}