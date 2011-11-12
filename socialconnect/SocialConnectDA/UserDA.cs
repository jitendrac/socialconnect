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
    public class UserDA
    {
        private const string spUserSave = "spUser_Save";
        private const string spUserDelete = "spUser_Delete";
        private const string spUserGetAll = "spUser_GetAll";
        private const string spUserGetElementById = "spUser_SelectByUserId";

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
        public static int Save(UserBE objUserBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("UserId", objUserBE.UserId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("Name", objUserBE.Name, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("Password", objUserBE.Password, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("Address", objUserBE.Address, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("ContactNo", objUserBE.ContactNo, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("EmailId", objUserBE.EmailId, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("UserStatus", objUserBE.EmailId, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("UserIdentityImageName", objUserBE.UserIdentityImageName, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("UserIdentityImagePath", objUserBE.UserIdentityImagePath, DbType.String));
            objUserBE.UserId = GenralizeStoredProcedure.GetInt(spUserSave, ObjListUserParam);
            return objUserBE.UserId;
            

        }

        public static bool Delete(int intUserId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("UserId", intUserId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spUserDelete, ObjListUserParam);
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
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spUserGetAll, ObjListUserParam);
            return objDataSet;
        }

        public static UserBE GetElementById(int intUserId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("UserId", intUserId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spUserGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static UserBE FillDataRecord(IDataRecord dr)
        {
            UserBE objUserBE = new UserBE();
            if (!dr.IsDBNull(dr.GetOrdinal("UserId")))
            {
                objUserBE.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Name")))
            {
                objUserBE.Name = dr.GetString(dr.GetOrdinal("Name"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Password")))
            {
                objUserBE.Password = dr.GetString(dr.GetOrdinal("Password"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Address")))
            {
                objUserBE.Address = dr.GetString(dr.GetOrdinal("Address"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ContactNo")))
            {
                objUserBE.ContactNo = dr.GetString(dr.GetOrdinal("ContactNo"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("EmailId")))
            {
                objUserBE.EmailId = dr.GetString(dr.GetOrdinal("EmailId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("UserIdentityImageName")))
            {
                objUserBE.UserIdentityImageName = dr.GetString(dr.GetOrdinal("UserIdentityImageName"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("UserIdentityImagePath")))
            {
                objUserBE.UserIdentityImagePath = dr.GetString(dr.GetOrdinal("UserIdentityImagePath"));
            }

            return objUserBE;
        }
        
        #endregion
    }
}
