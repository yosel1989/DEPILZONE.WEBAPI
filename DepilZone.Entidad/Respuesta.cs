using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad
{
    public class Respuesta<T>
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorDetalle { get; set; }
        public T Response { get; set; }
    }

    public class MensajeSignalR
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public string DatosJSON { get; set; }
        public int IdPerfil { get; set; }
        public TipoAlerta Tipo { get; set; }
    }





    public enum TipoAlerta
    {
        Actividad = 1,
        RespuestaActividad = 2,
        PreferenteAsignado = 3,
        RetornoPreferente = 4,
        ConnectionId = 5,
        ConexionNueva = 6,
        ConexionRechazada = 7,
        ConexionListaUsuario = 8,
        DesconexionUsuario = 9,
        NuevoMensaje = 10,
        CitaReservada = 11,
        ReservaEliminada = 12,
        AvisoGeneral = 13,
        MenuActualizado = 14,
        CerrarSesion = 15,
        ActualizarSistema = 16
    }
}
