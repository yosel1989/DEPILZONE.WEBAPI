using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DepilZone.Data.Implement
{
    public class EmailDat : IEmailDat
    {
        public async Task<int> EnvioEmail(EmailEnvioDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Email_EnvioExternal", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pEmailDestino", model.EmailDestino);
                cmd.Parameters.AddWithValue("pEmailCopiaOculta", model.EmailCopiaOculta);
                cmd.Parameters.AddWithValue("pAsunto", model.Asunto);
                cmd.Parameters.AddWithValue("pContenido", model.Contenido);
                cmd.Parameters.AddWithValue("pAdjunto", model.Adjunto);
                var output = await cmd.ExecuteNonQueryAsync();

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}