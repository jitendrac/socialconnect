using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SocialConnectBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Collections;

namespace SocialConnectDA
{
    public class NotificationDA
    {
        private const string spNotificationSave = "spNotification_Save";
        private const string spNotificationDelete = "spNotification_Delete";
        private const string spNotificationGetAll = "spNotification_GetAll";
        private const string spNotificationGetElementById = "spNotification_GetElementById";

        public static int Save(NotificationBE objNotificationBE)
        {
            List<GenralizeParametre> objListNotificationParam = new List<GenralizeParametre>();
            objListNotificationParam.Add(new GenralizeParametre("NotificationId",objNotificationBE.NotificationId,DbType.Int32));
            objListNotificationParam.Add(new GenralizeParametre("UserId",objNotificationBE.UserId,DbType.Int32));
            objListNotificationParam.Add(new GenralizeParametre("DateTime",objNotificationBE.DateTime,DbType.DateTime));
            objListNotificationParam.Add(new GenralizeParametre("NotificationDescription",objNotificationBE.NotificationDescription,DbType.String));

            objNotificationBE.NotificationId = GenralizeStoredProcedure.GetInt(spNotificationSave,objListNotificationParam);
            return objNotificationBE.NotificationId;
        }

        public static Boolean Delete(int intNotificationId)
        {
            List<GenralizeParametre> objListNotificationParam = new List<GenralizeParametre>();
            objListNotificationParam.Add(new GenralizeParametre("NotificationId", intNotificationId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spNotificationDelete, objListNotificationParam);

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
            List<GenralizeParametre> objListNotificationParam = new List<GenralizeParametre>();
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spNotificationGetAll, objListNotificationParam);
            return objDataSet;
        }

        public static NotificationBE GetElementById(int intNotificationId)
        {
            List<GenralizeParametre> objListNotificationParam = new List<GenralizeParametre>();
            objListNotificationParam.Add(new GenralizeParametre("NotificationId", intNotificationId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spNotificationGetElementById, objListNotificationParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static NotificationBE FillDataRecord(IDataRecord dr)
        {
            NotificationBE objNotificationBE = new NotificationBE();
            if (!dr.IsDBNull(dr.GetOrdinal("NotificationId")))
            {
                objNotificationBE.NotificationId = dr.GetInt32(dr.GetOrdinal("NotificationId"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("UserId")))
            {
                objNotificationBE.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("DateTime")))
            {
                objNotificationBE.DateTime = dr.GetDateTime(dr.GetOrdinal("DateTime"));
            }

            if (!dr.IsDBNull(dr.GetOrdinal("NotificationDescription")))
            {
                objNotificationBE.NotificationDescription = dr.GetString(dr.GetOrdinal("NotificationDescription"));
            }

            return objNotificationBE;
        }

        #endregion
    }
}
