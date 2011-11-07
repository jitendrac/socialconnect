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
    public class AlbumDA
    {
        private const string spAlbumSave = "spAlbum_Save";
        private const string spAlbumDelete = "spAlbum_Delete";
        private const string spAlbumGetAll = "spAlbum_GetAll";
        private const string spAlbumGetElementById = "spAlbum_SelectByAlbumId";

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
        /// This function is used for saving or updating Album Data
        /// </summary>
        /// <param name="objAlbumBE">Object </param>
        /// <returns></returns>
        public static int Save(AlbumBE objAlbumBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("AlbumId", objAlbumBE.AlbumId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("CoverImageId", objAlbumBE.CoverImageId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("OwnerId", objAlbumBE.OwnerId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("Name", objAlbumBE.Name, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("Caption", objAlbumBE.Caption, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("AddedDateTime", objAlbumBE.AddedDateTime, DbType.DateTime));
            ObjListUserParam.Add(new GenralizeParametre("ModifiedDateTime", objAlbumBE.ModifiedDateTime, DbType.DateTime));
            objAlbumBE.AlbumId = GenralizeStoredProcedure.GetInt(spAlbumSave, ObjListUserParam);
            return objAlbumBE.AlbumId;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="intAlbumId"></param>
      /// <returns></returns>
        public static bool Delete(int intAlbumId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("AlbumId", intAlbumId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spAlbumDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spAlbumGetAll, ObjListUserParam);
            return objDataSet;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="intAlbumId"></param>
       /// <returns></returns>
        public static AlbumBE GetElementById(int intAlbumId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("AlbumId", intAlbumId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spAlbumGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static AlbumBE FillDataRecord(IDataRecord dr)
        {
            AlbumBE objAlbumBE = new AlbumBE();
            if (!dr.IsDBNull(dr.GetOrdinal("AlbumId")))
            {
                objAlbumBE.AlbumId = dr.GetInt32(dr.GetOrdinal("AlbumId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("CoverImageId")))
            {
                objAlbumBE.CoverImageId = dr.GetInt32(dr.GetOrdinal("CoverImageId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("OwnerId")))
            {
                objAlbumBE.OwnerId = dr.GetInt32(dr.GetOrdinal("OwnerId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Name")))
            {
                objAlbumBE.Name = dr.GetString(dr.GetOrdinal("Name"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Caption")))
            {
                objAlbumBE.Caption = dr.GetString(dr.GetOrdinal("Caption"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AddedDateTime")))
            {
                objAlbumBE.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ModifiedDateTime")))
            {
                objAlbumBE.ModifiedDateTime = dr.GetDateTime(dr.GetOrdinal("ModifiedDateTime"));
            }

            return objAlbumBE;
        }

        #endregion
    }
}
