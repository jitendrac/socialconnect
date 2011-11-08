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
    public class PostDA
    {
        private const string spPostSave = "spPost_Save";
        private const string spPostDelete = "spPost_Delete";
        private const string spPostGetAll = "spPost_GetAll";
        private const string spPostGetElementById = "spPost_SelectByPostId";


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
        /// <param name="objPostBE"></param>
        /// <returns></returns>
        public static int Save(PostBE objPostBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PostId", objPostBE.PostId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("CreatorId", objPostBE.CreatorId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("PostTypeId", objPostBE.PostTypeId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("Title", objPostBE.Title, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("Contents", objPostBE.Contents, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("AddedEndDateTime", objPostBE.AddedDateTime, DbType.DateTime));
            objPostBE.PostId = GenralizeStoredProcedure.GetInt(spPostSave, ObjListUserParam);
            return objPostBE.PostId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPostId"></param>
        /// <returns></returns>
        public static bool Delete(int intPostId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PostId", intPostId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spPostDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spPostGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPostId"></param>
        /// <returns></returns>
        public static PostBE GetElementById(int intPostId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PostId", intPostId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spPostGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static PostBE FillDataRecord(IDataRecord dr)
        {
            PostBE objPostBE = new PostBE();
            if (!dr.IsDBNull(dr.GetOrdinal("PostId")))
            {
                objPostBE.PostId = dr.GetInt32(dr.GetOrdinal("PostId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("CreatorID")))
            {
                objPostBE.CreatorId = dr.GetInt32(dr.GetOrdinal("CreatorId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("PostTyprId")))
            {
                objPostBE.PostTypeId = dr.GetInt32(dr.GetOrdinal("PostTypeId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Title")))
            {
                objPostBE.Title = dr.GetString(dr.GetOrdinal("Title"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Contents")))
            {
                objPostBE.Contents = dr.GetString(dr.GetOrdinal("Contents"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AddedEndDateTime")))
            {
                objPostBE.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }

            return objPostBE;
        }

        #endregion
    }
}
