using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Data.Common;
using SocialConnectBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Collections;

namespace SocialConnectDA
{
    public class GroupXFilesDA
    {
        private const string spGroupXFilesSave = "spGroupXFiles_Save";
        private const string spGroupXFilesDelete = "spGroupXFiles_Delete";
        private const string spGroupXFilesGetAll = "spGroupXFiles_GetAll";
        private const string spGroupXFilesGetElementById = "spGroupXFiles_GetElementById";

        public static int save(GroupXFilesBE objGroupXFilesBE)
        { 
            List<GenralizeParametre> objListGroupXFileParam=new List<GenralizeParametre>();
            objListGroupXFileParam.Add(new GenralizeParametre("GroupXFileId", objGroupXFilesBE.GroupXFileId, DbType.Int32));
            objListGroupXFileParam.Add(new GenralizeParametre("GroupId", objGroupXFilesBE.GroupId, DbType.Int32));
            objListGroupXFileParam.Add(new GenralizeParametre("FileId", objGroupXFilesBE.FileId, DbType.Int32));
            objListGroupXFileParam.Add(new GenralizeParametre("Category", objGroupXFilesBE.Category, DbType.String));
            objGroupXFilesBE.GroupXFileId=GenralizeStoredProcedure.GetInt (spGroupXFilesSave,objListGroupXFileParam);

            return objGroupXFilesBE.GroupXFileId;
        }

        public static Boolean Delete(int intGroupXFileId)
        {
            List<GenralizeParametre> objListGroupXFileParam = new List<GenralizeParametre>();
            objListGroupXFileParam.Add(new GenralizeParametre("GroupXFileId", intGroupXFileId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spGroupXFilesDelete, objListGroupXFileParam);
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
            List<GenralizeParametre> objListGroupXFileParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spGroupXFilesGetAll,objListGroupXFileParam);
            return objDataSet;
        }

        public static GroupXFilesBE getElementById(int intGroupXFileId)
        {
            List<GenralizeParametre> objListGroupXFile = new List<GenralizeParametre>();
            objListGroupXFile.Add(new GenralizeParametre("GroupXFileId", intGroupXFileId,DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spGroupXFilesGetElementById, objListGroupXFile);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static GroupXFilesBE FillDataRecord(IDataRecord dr)
        {
            GroupXFilesBE  objGroupXFilesBE = new GroupXFilesBE();
            if (!dr.IsDBNull(dr.GetOrdinal("GroupXFileId")))
            {
                objGroupXFilesBE.GroupXFileId = dr.GetInt32(dr.GetOrdinal("GroupXFileId"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("GroupId")))
            {
                objGroupXFilesBE.GroupId = dr.GetInt32(dr.GetOrdinal("GroupId"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("FileId")))
            {
                objGroupXFilesBE.FileId = dr.GetInt32(dr.GetOrdinal("FileId"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("Category")))
            {
                objGroupXFilesBE.Category = dr.GetString(dr.GetOrdinal("Category"));
            }

            return objGroupXFilesBE;
        }

        #endregion
    }
}
