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
    class GroupDA
    {
        private const string spGroupSave = "spGroup_save";
        private const string spGroupDelete = "spGroup_Delee";
        private const string spGroupGetAll = "spGroup_GetAll";
        private const string spGroupGetElementById = "spGroup_SelectByGroupId";
        public static int Save(GroupBE objGroupBE)
        {
            List<GenralizeParametre> objListGroupParam = new List<GenralizeParametre>();
            objListGroupParam.Add(new GenralizeParametre("GroupId", objGroupBE.GroupId, DbType.Int32));
            objListGroupParam.Add(new GenralizeParametre("GroupName", objGroupBE.GroupName, DbType.String));
            objListGroupParam.Add(new GenralizeParametre("OwnerId", objGroupBE.OwnerId, DbType.Int32));
            objListGroupParam.Add(new GenralizeParametre("StartDate", objGroupBE.StartDate, DbType.DateTime));
            objListGroupParam.Add(new GenralizeParametre("EndDate", objGroupBE.EndDate, DbType.DateTime));
            
            objGroupBE.GroupId = GenralizeStoredProcedure.GetInt(spGroupSave, objListGroupParam);
            return objGroupBE.GroupId;
        }

        public static bool Delete(int intGroupId)
        {
            List<GenralizeParametre> objListGroupParam = new List<GenralizeParametre>();
            objListGroupParam.Add(new GenralizeParametre("GroupId", intGroupId, DbType.Int32));
            int intTemp = GenralizeStoredProcedure.GetInt(spGroupDelete, objListGroupParam);
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
            List<GenralizeParametre> objListGroupParam = new List<GenralizeParametre>();
            DataSet objDs = GenralizeStoredProcedure.GetDataset(spGroupGetAll, objListGroupParam);
            return objDs;
        }

        public static GroupBE GetElementById(int intGroupId)
        {
            GroupBE objGroupBE = new GroupBE();
            List<GenralizeParametre> objListGroupParam = new List<GenralizeParametre>();
            objListGroupParam.Add(new GenralizeParametre("GroupId", intGroupId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spGroupGetElementById, objListGroupParam);
            objGroupBE = FillDataRecord(dr);
            return objGroupBE;

        }
        #region Private Methods
        private static GroupBE FillDataRecord(IDataRecord dr)
        {
            GroupBE objGroupBE = new GroupBE();
            if (!dr.IsDBNull(dr.GetOrdinal("GroupId")))
            {
                objGroupBE.GroupId = dr.GetInt32(dr.GetOrdinal("GroupId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("GroupName")))
            {
                objGroupBE.GroupName = dr.GetString(dr.GetOrdinal("GroupName"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("OwnerId")))
            {
                objGroupBE.OwnerId = dr.GetInt32(dr.GetOrdinal("OwnerId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("StartDate")))
            {
                objGroupBE.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("EndDate")))
            {
                objGroupBE.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
            }
            return objGroupBE;
        }

        #endregion
    }
}
