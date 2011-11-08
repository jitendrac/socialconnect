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
   public class PhotoDA
    {
        private const string spPhotoSave = "spPhoto_Save";
        private const string spPhotoDelete = "spPhoto_Delete";
        private const string spPhotoGetAll = "spPhoto_GetAll";
        private const string spPhotoGetElementById = "spPhoto_SelectByPhotoId";


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
        /// <param name="objPhotoBE"></param>
        /// <returns></returns>
        public static int Save(PhotoBE objPhotoBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PhotoId", objPhotoBE.PhotoId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("AlbumId", objPhotoBE.AlbumId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("OwnerId", objPhotoBE.OwnerId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("Description", objPhotoBE.Description, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("SmallSource", objPhotoBE.SmanllSource, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("MediumSource", objPhotoBE.MediumSource, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("LargeSource", objPhotoBE.LargeSource, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("AddedDateTime", objPhotoBE.AddedDateTime, DbType.DateTime));
            objPhotoBE.PhotoId = GenralizeStoredProcedure.GetInt(spPhotoSave, ObjListUserParam);
            return objPhotoBE.PhotoId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPhotoId"></param>
        /// <returns></returns>
        public static bool Delete(int intPhotoId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PhotoId", intPhotoId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spPhotoDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spPhotoGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPhotoId"></param>
        /// <returns></returns>
        public static PhotoBE GetElementById(int intPhotoId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("PhotoId", intPhotoId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spPhotoGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static PhotoBE FillDataRecord(IDataRecord dr)
        {
            PhotoBE objPhotoBE = new PhotoBE();
            if (!dr.IsDBNull(dr.GetOrdinal("PhotoId")))
            {
                objPhotoBE.PhotoId = dr.GetInt32(dr.GetOrdinal("PhotoId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AlbumId")))
            {
                objPhotoBE.AlbumId = dr.GetInt32(dr.GetOrdinal("AlbumId"));
            }
            
            if (!dr.IsDBNull(dr.GetOrdinal("OwnerId")))
            {
                objPhotoBE.OwnerId = dr.GetInt32(dr.GetOrdinal("OwnerId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Description")))
            {
                objPhotoBE.Description = dr.GetString(dr.GetOrdinal("Description"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("SmallSource")))
            {
                objPhotoBE.SmanllSource = dr.GetString(dr.GetOrdinal("SmallSource"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("MediumSource")))
            {
                objPhotoBE.MediumSource = dr.GetString(dr.GetOrdinal("MediumSource"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("LargeSource")))
            {
                objPhotoBE.LargeSource = dr.GetString(dr.GetOrdinal("LargeSource"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("DateTime")))
            {
                objPhotoBE.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }

            return objPhotoBE;
        }

        #endregion
    }
}
