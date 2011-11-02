using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SocialConnectDA
{
    public class GenralizeParametre
    {
        public string ParamName;
        public object ParamValue;
        public DbType ParamDbType;
        
        /// <summary>
        /// The function creates the Parametre class instance to be used for the 
        /// genralize parametre sp
        /// </summary>
        /// <param name="ParamName">Name of the Parametre of stored procedure in database</param>
        /// <param name="ParamValue">Value of the Parametre</param>
        /// <param name="ParamType">Type of the parametre in databse \n ex: DbType.Int32;</param>
        public GenralizeParametre(string ParamName, object ParamValue, DbType ParamDbType)
        {
            this.ParamName = ParamName;
            this.ParamValue = ParamValue;
            this.ParamDbType = ParamDbType;
        }

    }
}
