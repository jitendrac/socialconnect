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
    public class EventParticipantDA
    {
        public const string spEventParticipantSave = "spEventParticipant_Save";
        public const string spEventParticipantDelete = "spEventParticipant_Delete";
        public const string spEventParticipantGetAll = "spEventParticipant_GetAll";
        public const string spEventParticipantGetElementById = "spEventParticipant_SelectByEventParticipantId";

        public static int Save(EventParticipantBE ObjEventParticipant)
        {
            List<GenralizeParametre> objListEventParticipantParam = new List<GenralizeParametre>();
            objListEventParticipantParam.Add(new GenralizeParametre("EventParticipantId", ObjEventParticipant.EventParticipantId, DbType.Int32));
            objListEventParticipantParam.Add(new GenralizeParametre("EventId", ObjEventParticipant.EventId, DbType.Int32));
            objListEventParticipantParam.Add(new GenralizeParametre("SubbmissionStatusId", ObjEventParticipant.SubmissionStatusId, DbType.Int32));
            objListEventParticipantParam.Add(new GenralizeParametre("Description", ObjEventParticipant.Description, DbType.String));
            objListEventParticipantParam.Add(new GenralizeParametre("ParticipantParentId", ObjEventParticipant.ParticipantParentId, DbType.Int32));
            objListEventParticipantParam.Add(new GenralizeParametre("AddedDateTime", ObjEventParticipant.AddedDateTime, DbType.DateTime));
            ObjEventParticipant.EventParticipantId = GenralizeStoredProcedure.GetInt(spEventParticipantSave, objListEventParticipantParam);
            return ObjEventParticipant.EventParticipantId;
        }

        public static bool Delete(int intEventParticipantId)
        {
            List<GenralizeParametre> objListEventParticipantParam = new List<GenralizeParametre>();
            objListEventParticipantParam.Add(new GenralizeParametre(spEventParticipantDelete,intEventParticipantId,DbType.Int32));
            int intTemp = GenralizeStoredProcedure.GetInt(spEventParticipantDelete,objListEventParticipantParam);
            if(intTemp ==0 )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataSet GetAll()
        {
            List<GenralizeParametre> objListEventParticipantParam = new List<GenralizeParametre>();
            DataSet objDS = GenralizeStoredProcedure.GetDataset(spEventParticipantGetAll, objListEventParticipantParam);
            return objDS;
        }

        public EventParticipantBE GetElementById(int intEventParticipantId)
        {
            EventParticipantBE objEventParticipant = new EventParticipantBE();
            List<GenralizeParametre> objListEventParticipantParam = new List<GenralizeParametre>();
            objListEventParticipantParam.Add(new GenralizeParametre(spEventParticipantDelete,intEventParticipantId,DbType.Int32));
            IDataRecord dr=GenralizeStoredProcedure.GetIDataRecord(spEventParticipantGetElementById,objListEventParticipantParam);
            objEventParticipant = FillDataRecord(dr);
            return objEventParticipant;
        }
        #region Private Methods
        private static EventParticipantBE FillDataRecord(IDataRecord dr)
        {
            EventParticipantBE objEventParticipantBE = new EventParticipantBE();
            if (!dr.IsDBNull(dr.GetOrdinal("EventParticipantId")))
            {
                objEventParticipantBE.EventParticipantId = dr.GetInt32(dr.GetOrdinal("EventParticipantId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("EventId")))
            {
                objEventParticipantBE.EventId = dr.GetInt32(dr.GetOrdinal("EventId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("SubmissionStatusId")))
            {
                objEventParticipantBE.SubmissionStatusId = dr.GetInt32(dr.GetOrdinal("SubmissionStatusId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("Description")))
            {
                objEventParticipantBE.Description = dr.GetString(dr.GetOrdinal("Description"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("ParticipantParentId")))
            {
                objEventParticipantBE.ParticipantParentId = dr.GetInt32(dr.GetOrdinal("ParticipantParentId"));
            }
            if (!dr.IsDBNull(dr.GetOrdinal("AddedDateTime")))
            {
                objEventParticipantBE.AddedDateTime = dr.GetDateTime(dr.GetOrdinal("AddedDateTime"));
            }
            return objEventParticipantBE;
        }

        #endregion
    }
}
