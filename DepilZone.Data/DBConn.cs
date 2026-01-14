using System;
using System.Data.SqlClient;

namespace DepilZone.Data
{
    class DBConn
    {
        public static SqlConnection ConexionSQL()
        {
            try
            {
                  SqlConnection ConectString = new SqlConnection("");
                  return ConectString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ParametroCripto()
        {
            return "d/3%P.1@l?z!0&N(3";
        }
    }
}
