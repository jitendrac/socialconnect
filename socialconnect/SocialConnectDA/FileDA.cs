using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Collections;

using SocialConnectBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace SocialConnectDA
{
    public class FileDA
    {
        private const string spFileSave = "spFile_save";
        private const string spFileDelete = "spFile_Delee";
        private const string spFileGetAll = "spFile_GetAll";
        private const string spFileGetElementById = "spFile_SelectByFileId";

        public static int Save(FileBE objFile)
        {
            List<GenralizeParametre> objListFileParam = new List<GenralizeParametre>();
            objListFileParam.Add(new GenralizeParametre("FileId", objFile.FileId, DbType.Int32));
            objListFileParam.Add(new GenralizeParametre("FileName", objFile.FileName, DbType.String));
            objListFileParam.Add(new GenralizeParametre("FilePath", objFile.FilePath, DbType.String));
            objListFileParam.Add(new GenralizeParametre("AddedDateTime", objFile.AddedDateTime, DbType.DateTime));
            objFile.FileId = GenralizeStoredProcedure.GetInt(spFileSave, objListFileParam);
            return objFile.FileId;
        }

        public static bool Delete(int intFileId)
        {
            List<GenralizeParametre> objListFileParam = new List<GenralizeParametre>();
            objListFileParam.Add(new GenralizeParametre("FileId", intFileId, DbType.Int32));
            int intTemp = GenralizeStoredProcedure.GetInt(spFileDelete, objListFileParam);
            if (intTemp == 0)
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
            List<GenralizeParametre> objListFileParam = new List<GenralizeParametre>();
            DataSet objDs = GenralizeStoredProcedure.GetDataset(spFileGetAll, objListFileParam);
            return objDs;
        }

        public static FileBE GetElementById(int intFileId)
        {
            FileBE objFile = new FileBE();
            List<GenralizeParametre> objListFileParam = new List<GenralizeParametre>();
            objListFileParam.Add(new GenralizeParametre("FileId", intFileId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spFileGetElementById, objListFileParam);
            objFile = FillDataRecord(dr);
            return objFile;

        }
        #region Private Methods
        private static FileBE FillDataRecord(IDataRecord dr)
        {
            FileBE objFile = new FileBE();
            if (!dr.IsDBNull(dr.GetOrdinal("FileId")))
            {
                objFile.FileId = dr.GetInt32(dr.GetOrdinal("FileId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("FileName")))
            {
                objFile.FileName = dr.GetString(dr.GetOrdinal("FileName"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("FilePath")))
            {
                objFile.FilePath = dr.GetString(dr.GetOrdinal("FilePath"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AddedDateTime")))
            {
                objFile.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }
            return objFile;
        }

        #endregion

    }
}
