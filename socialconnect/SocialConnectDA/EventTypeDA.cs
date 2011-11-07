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
    public class EventTypeDA
    {
        private const string spEventTypeSave = "spEventType_save";
        private const string spEventTypeDelete = "spEventType_Delee";
        private const string spEventTypeGetAll = "spEventType_GetAll";
        private const string spEventTypeGetElementById = "spEventType_SelectByEventTypeId";
        public static int Save(EventTypeBE objEventTypeBE)
        {
            List<GenralizeParametre> objListEventTypeParam = new List<GenralizeParametre>();
            objListEventTypeParam.Add(new GenralizeParametre("EventTypeId", objEventTypeBE.EventTypeId, DbType.Int32));
            objListEventTypeParam.Add(new GenralizeParametre("EventTypeName", objEventTypeBE.EventTypeName, DbType.String));
            objEventTypeBE.EventTypeId = GenralizeStoredProcedure.GetInt(spEventTypeSave, objListEventTypeParam);
            return objEventTypeBE.EventTypeId;
        }

        public static bool Delete(int intEventTypeId)
        {
            List<GenralizeParametre> objListEventTypeParam = new List<GenralizeParametre>();
            objListEventTypeParam.Add(new GenralizeParametre("EventTypeId", intEventTypeId, DbType.Int32));
            int intTemp = GenralizeStoredProcedure.GetInt(spEventTypeDelete, objListEventTypeParam);
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
            List<GenralizeParametre> objListEventTypeParam = new List<GenralizeParametre>();
            DataSet objDs = GenralizeStoredProcedure.GetDataset(spEventTypeGetAll, objListEventTypeParam);
            return objDs;
        }

        public static EventTypeBE GetElementById(int intEventTypeId)
        {
            EventTypeBE objEventTypeBE = new EventTypeBE();
            List<GenralizeParametre> objListEventTypeParam = new List<GenralizeParametre>();
            objListEventTypeParam.Add(new GenralizeParametre("EventTypeId", intEventTypeId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spEventTypeGetElementById, objListEventTypeParam);
            objEventTypeBE = FillDataRecord(dr);
            return objEventTypeBE;

        }
        #region Private Methods
        private static EventTypeBE FillDataRecord(IDataRecord dr)
        {
            EventTypeBE objEventTypeBE = new EventTypeBE();
            if (!dr.IsDBNull(dr.GetOrdinal("EventTypeId")))
            {
                objEventTypeBE.EventTypeId = dr.GetInt32(dr.GetOrdinal("EventTypeId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("EventTypeName")))
            {
                objEventTypeBE.EventTypeName = dr.GetString(dr.GetOrdinal("EventTypeName"));
            }
            return objEventTypeBE;
        }

        #endregion
    }
}
