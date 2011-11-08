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
    public class PostTypeDA
    {
        private const string spPostTypeSave = "spPostType_Save";
        private const string spPostTypeDelete = "spPostType_Delete";
        private const string spPostTypeGetAll = "spPostType_GetAll";
        private const string spPostTypeGetElementById = "spPostType_SelectByPostTypeId";

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
        /// The Function is used for Inserting or Updating the data of the PostType
        /// </summary>
        /// <param name="objPostTypeBE">Object of PostTypebe to be stored</param>
        /// <returns>Returns the ID of the changed Record</returns>
        public static int Save(PostTypeBE objPostTypeBE)
        {
            List<GenralizeParametre> ObjListPostTypeParam = new List<GenralizeParametre>();
            ObjListPostTypeParam.Add(new GenralizeParametre("PostTypeId", objPostTypeBE.PostTypeId, DbType.Int32));
            ObjListPostTypeParam.Add(new GenralizeParametre("PostTypeName", objPostTypeBE.PostTypeName, DbType.String));
          
            objPostTypeBE.PostTypeId = GenralizeStoredProcedure.GetInt(spPostTypeSave, ObjListPostTypeParam);
            return objPostTypeBE.PostTypeId;
        }

        public static bool Delete(int intPostTypeId)
        {
            List<GenralizeParametre> ObjListPostTypeParam = new List<GenralizeParametre>();
            ObjListPostTypeParam.Add(new GenralizeParametre("PostTypeId", intPostTypeId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spPostTypeDelete, ObjListPostTypeParam);
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
            List<GenralizeParametre> ObjListPostTypeParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spPostTypeGetAll, ObjListPostTypeParam);
            return objDataSet;
        }

        public static PostTypeBE GetElementById(int intPostTypeId)
        {
            List<GenralizeParametre> ObjListPostTypeParam = new List<GenralizeParametre>();
            ObjListPostTypeParam.Add(new GenralizeParametre("PostTypeId", intPostTypeId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spPostTypeGetElementById, ObjListPostTypeParam);
            return FillDataRecord(dr);
        }
        #region Private Methods
        private static PostTypeBE FillDataRecord(IDataRecord dr)
        {
            PostTypeBE objPostTypeBE = new PostTypeBE();
            if (!dr.IsDBNull(dr.GetOrdinal("PostTypeId")))
            {
                objPostTypeBE.PostTypeId = dr.GetInt32(dr.GetOrdinal("PostTypeId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("PostTypeName")))
            {
                objPostTypeBE.PostTypeName = dr.GetString(dr.GetOrdinal("PostTypeName"));
            }
           

            return objPostTypeBE;
        }

        #endregion
    }
}
