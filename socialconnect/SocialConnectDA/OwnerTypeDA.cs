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
    public class OwnerTypeDA
    {
        private const string spOwnerTypeSave = "spOwnerType_Save";
        private const string spOwnerTypeDelete = "spOwnerType_Delete";
        private const string spOwnerTypeGetAll = "spOwnerType_GetAll";
        private const string spOwnerTypeGetElementById = "spOwnerType_SelectByOwnerTypeId";


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
        /// <param name="objOwnerTypeBE"></param>
        /// <returns></returns>
        public static int Save(OwnerTypeBE objOwnerTypeBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("OwnerTypeId", objOwnerTypeBE.OwnerTypeId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("OwnerTypeName", objOwnerTypeBE.TypeName, DbType.String));
            
            objOwnerTypeBE.OwnerTypeId = GenralizeStoredProcedure.GetInt(spOwnerTypeSave, ObjListUserParam);
            return objOwnerTypeBE.OwnerTypeId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intOwnerTypeId"></param>
        /// <returns></returns>
        public static bool Delete(int intOwnerTypeId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("OwnerTypeId", intOwnerTypeId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spOwnerTypeDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spOwnerTypeGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intOwnerTypeId"></param>
        /// <returns></returns>
        public static OwnerTypeBE GetElementById(int intOwnerTypeId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("OwnerTypeId", intOwnerTypeId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spOwnerTypeGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static OwnerTypeBE FillDataRecord(IDataRecord dr)
        {
            OwnerTypeBE objOwnerTypeBE = new OwnerTypeBE();
            if (!dr.IsDBNull(dr.GetOrdinal("OwnerTypeId")))
            {
                objOwnerTypeBE.OwnerTypeId = dr.GetInt32(dr.GetOrdinal("OwnerTypeId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("TypeName")))
            {
                objOwnerTypeBE.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
            }
            
            return objOwnerTypeBE;
        }

        #endregion
    }
}
