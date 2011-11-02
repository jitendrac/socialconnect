using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
//using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace SocialConnectDA
{
    class GenralizeStoredProcedure
    {
        /// <summary>
        /// The function returns the dataset from the database .
        /// </summary>
        /// <param name="SpName">Name of the Stored Procedure</param>
        /// <param name="ParametreList">List of the Parametres</param>
        /// <returns>Returns DataSet</returns>
        public static DataSet GetDataset(string SpName, System.Collections.Generic.List<GenralizeParametre> ParametreList)//Created by Jitendra Shah 2-nov-2011 2:57PM 
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = db.GetStoredProcCommand(SpName))
            {
                foreach (GenralizeParametre param in ParametreList)
                {
                    db.AddInParameter(dbCommand, param.ParamName, param.ParamDbType, param.ParamValue);
                }
                ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// The function returns the dataset from the database .
        /// </summary>
        /// <param name="SpName">Name of the Stored Procedure</param>
        /// <returns>Returns the DataSet</returns>
        public static DataSet GetDataset(string SpName)
        { 
            System.Collections.Generic.List<GenralizeParametre> ParamList = new List<GenralizeParametre>();
            return GetDataset(SpName,ParamList);        
        }

        /// <summary>
        /// The function returns the int from the database.
        /// </summary>
        /// <param name="SpName">Name of the Stored Procedure</param>
        /// <param name="ParametreList">List of the Parametres</param>
        /// <returns>Returns int</returns>
        public static int GetInt(string SpName, System.Collections.Generic.List<GenralizeParametre> ParametreList)
        {

            int intReturn = 0;
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = db.GetStoredProcCommand(SpName))
            {
                foreach (GenralizeParametre param in ParametreList)
                {
                    db.AddInParameter(dbCommand, param.ParamName, param.ParamDbType, param.ParamValue);
                }
                intReturn = Convert.ToInt32(db.ExecuteScalar(dbCommand));

                dbCommand.Dispose();
            }
            return intReturn;
        }

        /// <summary>
        /// The function returns the IDataRecord got from the database.
        /// </summary>
        /// <param name="SpName">Name of the Stored Procedure</param>
        /// <param name="ParametreList">List of the Parametres</param>
        /// <returns>Returns the IDataRecord</returns>
        public static IDataRecord GetIDataRecord(string SpName, System.Collections.Generic.List<GenralizeParametre> ParametreList)
        {
            IDataRecord objIDataRecord = null;
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = db.GetStoredProcCommand(SpName))
            {
                foreach (GenralizeParametre param in ParametreList)
                {
                    db.AddInParameter(dbCommand, param.ParamName, param.ParamDbType, param.ParamValue);
                }
                IDataReader dr = db.ExecuteReader(dbCommand);
                while (dr.Read())
                {
                    objIDataRecord = dr;
                }
                dbCommand.Dispose();
            }
            return objIDataRecord;
        }

    }
}
