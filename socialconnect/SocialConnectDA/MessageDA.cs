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
    public class MessageDA
    {
        private const string spMessageSave = "spMessage_Save";
        private const string spMessageDelete = "spMessage_Delete";
        private const string spMessageGetAll = "spMessage_GetAll";
        private const string spMessageGetElementById = "spMessage_SelectByMessageId";


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
        /// <param name="objMessageBE"></param>
        /// <returns></returns>
        public static int Save(MessageBE objMessageBE)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("MessageId", objMessageBE.MessageId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("MessageContent", objMessageBE.MessageContent, DbType.String));
            ObjListUserParam.Add(new GenralizeParametre("SenderId", objMessageBE.SenderId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("ReceiverId", objMessageBE.ReceiverId, DbType.Int32));
            ObjListUserParam.Add(new GenralizeParametre("DateTime", objMessageBE.DateTime, DbType.DateTime));
            
            objMessageBE.MessageId = GenralizeStoredProcedure.GetInt(spMessageSave, ObjListUserParam);
            return objMessageBE.MessageId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intMessageId"></param>
        /// <returns></returns>
        public static bool Delete(int intMessageId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("MessageId", intMessageId, DbType.Int32));
            int tempInt = GenralizeStoredProcedure.GetInt(spMessageDelete, ObjListUserParam);
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
            DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spMessageGetAll, ObjListUserParam);
            return objDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intMessageId"></param>
        /// <returns></returns>
        public static MessageBE GetElementById(int intMessageId)
        {
            List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
            ObjListUserParam.Add(new GenralizeParametre("MessageId", intMessageId, DbType.Int32));
            IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spMessageGetElementById, ObjListUserParam);
            return FillDataRecord(dr);
        }

        #region Private Methods
        private static MessageBE FillDataRecord(IDataRecord dr)
        {
            MessageBE objMessageBE = new MessageBE();
            if (!dr.IsDBNull(dr.GetOrdinal("MessageId")))
            {
                objMessageBE.MessageId = dr.GetInt32(dr.GetOrdinal("MessageId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("MessageContent")))
            {
                objMessageBE.MessageContent = dr.GetString(dr.GetOrdinal("MessageContent"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("SenderId")))
            {
                objMessageBE.SenderId = dr.GetInt32(dr.GetOrdinal("SenderId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ReceiverId")))
            {
                objMessageBE.ReceiverId = dr.GetInt32(dr.GetOrdinal("ReceiverId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("DateTime")))
            {
                objMessageBE.DateTime = dr.GetDateTime(dr.GetOrdinal("DateTime"));
            }
            return objMessageBE;
        }

        #endregion
    }
}
