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
   public  class EventDA
    {
       private const string spEventSave = "spEvent_Save";
       private const string spEventDelete = "spEvent_Delete";
       private const string spEventGetAll = "spEvent_GetAll";
       private const string spEventGetElementById = "spEvent_SelectByEventId";


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
      /// <param name="objEventBE"></param>
      /// <returns></returns>
       public static int Save(EventBE objEventBE)
       {
           List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
           ObjListUserParam.Add(new GenralizeParametre("EventId", objEventBE.EventId, DbType.Int32));
           ObjListUserParam.Add(new GenralizeParametre("Title", objEventBE.Title, DbType.String));
           ObjListUserParam.Add(new GenralizeParametre("Description", objEventBE.Description, DbType.String));
           ObjListUserParam.Add(new GenralizeParametre("OwnerId", objEventBE.OwnerId, DbType.Int32));
           ObjListUserParam.Add(new GenralizeParametre("OwnerTypeId", objEventBE.OwnerTypeId, DbType.Int32));
           ObjListUserParam.Add(new GenralizeParametre("EventTypeId", objEventBE.EventTypeId, DbType.Int32));
           ObjListUserParam.Add(new GenralizeParametre("StartDateTime", objEventBE.StartDateTime, DbType.DateTime));
           ObjListUserParam.Add(new GenralizeParametre("EndDateTime", objEventBE.EndDateTime, DbType.DateTime));
           objEventBE.EventId = GenralizeStoredProcedure.GetInt(spEventSave, ObjListUserParam);
           return objEventBE.EventId;
       }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="intEventId"></param>
      /// <returns></returns>
       public static bool Delete(int intEventId)
       {
           List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
           ObjListUserParam.Add(new GenralizeParametre("EventId", intEventId, DbType.Int32));
           int tempInt = GenralizeStoredProcedure.GetInt(spEventDelete, ObjListUserParam);
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
           DataSet objDataSet = GenralizeStoredProcedure.GetDataset(spEventGetAll, ObjListUserParam);
           return objDataSet;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="intEventId"></param>
       /// <returns></returns>
       public static EventBE GetElementById(int intEventId)
       {
           List<GenralizeParametre> ObjListUserParam = new List<GenralizeParametre>();
           ObjListUserParam.Add(new GenralizeParametre("EventId", intEventId, DbType.Int32));
           IDataRecord dr = GenralizeStoredProcedure.GetIDataRecord(spEventGetElementById, ObjListUserParam);
           return FillDataRecord(dr);
       }

       #region Private Methods
       private static EventBE FillDataRecord(IDataRecord dr)
       {
           EventBE objEventBE = new EventBE();
           if (!dr.IsDBNull(dr.GetOrdinal("EventId")))
           {
               objEventBE.EventId = dr.GetInt32(dr.GetOrdinal("EventId"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("Title")))
           {
               objEventBE.Title = dr.GetString(dr.GetOrdinal("Title"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("Description")))
           {
               objEventBE.Description = dr.GetString(dr.GetOrdinal("Description"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("OwnerId")))
           {
               objEventBE.OwnerId = dr.GetInt32(dr.GetOrdinal("OwnerId"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("OwnerTypeId")))
           {
               objEventBE.OwnerTypeId = dr.GetInt32(dr.GetOrdinal("OwnerTypeId"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("EventTypeId")))
           {
               objEventBE.EventTypeId = dr.GetInt32(dr.GetOrdinal("EventTypeId"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("StartDateTime")))
           {
               objEventBE.StartDateTime = dr.GetDateTime(dr.GetOrdinal("StartDateTime"));
           }
           if (!dr.IsDBNull(dr.GetOrdinal("EndDateTime")))
           {
               objEventBE.EndDateTime = dr.GetDateTime(dr.GetOrdinal("EndDateTime"));
           }

           return objEventBE;
       }

       #endregion
   }
}
