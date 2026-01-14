using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApp _cliente;
        public ClienteController(IClienteApp ClienteApp)
        {
            _cliente = ClienteApp;
        }

        [HttpPost]
        public async Task<Respuesta<ClienteEnt>> Post(ClienteEnt model)
        {
            return await _cliente.Insertar(model);
        }
        [HttpPut]
        public async Task<Respuesta<ClienteEnt>> Put(ClienteEnt model)
        {
            try
            {
                return await _cliente.Modificar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpPut("{action}")]
        public async Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model)
        {
            return await _cliente.ModificarFirma(model);
        }
        [HttpGet]
        public async Task<IEnumerable<ClienteGridDTO>> Get()
        {
           return await _cliente.Obtener(0);
        }
        [HttpGet("listar10Ultimos")]
        public async Task<IEnumerable<ClienteGridDTO>> Listar10Ultimos()
        {
            return await _cliente.Obtener(10);
        }
        [HttpGet("buscar/{str}")]
        public async Task<IEnumerable<ClienteGridDTO>> LikeNombre(string str = "")
        {
            return await _cliente.ObtenerByLikeNombre(str);
        }
        [HttpGet("{id}")]
        public async Task<ClienteDTO> Get(int id)
        {
            return await _cliente.ObtenerById(id);
        }
        [HttpGet("perfil/{id}")]
        public async Task<ClienteDTO> GetPerfil(int id)
        {
            return await _cliente.ObtenerPerfilById(id);
        }
        [HttpGet("zonasCorporalesAtendidas/{id}")]
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> GetTodasLasZonasCorporales(int id)
        {
            return await _cliente.ObtenerTodasLasZonasCorporales(id);

        }
        [HttpGet("zonasCorporalesAtendidas/{idCliente}/servicio/{idServicio}")]
        public async Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> GetTodasLasZonasCorporalesPorServicio(int idCliente, int idServicio)
        {
            return await _cliente.ObtenerTodasLasZonasCorporalesPorServicio(idCliente, idServicio);

        }

        [HttpGet("buscar/preferente/{nombres}/{apellidos}/{numeros}/{email}")]
        public async Task<IEnumerable<ClienteGridDTO>> GetPorPreferente(string nombres, string apellidos, string numeros, string email)
        {
            return await _cliente.ObtenerPorPreferente(nombres, apellidos, numeros, email);
        }
        [HttpGet("firma/{id}")]
        public async Task<ClienteEnt> GetFirmaById(int id)
        {
            return await _cliente.ObtenerFirmaById(id);
        }
        [HttpGet("datosMaestros")]
        public async Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros()
        {
            return await _cliente.ObtenerDatosMaestros();
        }
        [HttpGet("validarCelular/{idCliente},{numeroCelular1},{numeroCelular2}")]
        public async Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2)
        {
            return await _cliente.ValidarNumeroCelular(idCliente, numeroCelular1, numeroCelular2);
        }
        [HttpGet("obtenerFichaAdmisionByIdCliente/{idCliente}")]
        public async Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente)
        {
            try
            {
                return await _cliente.ObtenerFichaAdmisionByIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("byNumeroCelularSinCodigo/{numero1}/{numero2}")]
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelularSinCodigo(string numero1, string numero2)
        {
            try
            {
                return await _cliente.ObtenerByNumeroCelular("", numero1, "", numero2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("byNumeroCelular/{telefonoPais}/{telefono}")]
        public async Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string telefonoPais, string telefono)
        {
            try
            {
                return await _cliente.ObtenerByNumeroCelular(telefonoPais, telefono, "", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("buscarPorDNIOnline/{dni}")]
        public async Task<ClienteConsultaDniDTO> BuscarPorDNIOnline(string dni)
        {
            return await _cliente.BuscarPorDNIOnline(dni);
        }

        [HttpPut("fichaRegistro")]
        public async Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model)
        {
            return await _cliente.ActualizarFicha(model);
        }


        [HttpGet("buscarParametros/{p}")]
        public async Task<ActionResult> BuscarParametros(string p)
        {
            try
            {
                var collection = await _cliente.BuscarParametros(p);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }

        [HttpGet("citasAtendidas/{idCliente}")]
        public async Task<ActionResult> BuscarCitasAtendidas(int idCliente)
        {
            try
            {
                var collection = await _cliente.BuscarCitasAtendidas(idCliente);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }


























        [HttpGet("numeroTelefonico/{telefono}")]
        public async Task<ActionResult> buscarTelefono(string telefono)
        {
            try
            {
                //int tipoRespuesta = 2;
                string mensajeRespuesta = "";

                if (string.IsNullOrWhiteSpace(telefono))
                {
                    return null;
                }

                Stopwatch oCronometro = new Stopwatch();
                oCronometro.Start();

                List<RClienteConsultaTelefonoDTO> output = new List<RClienteConsultaTelefonoDTO>();


                ClienteConsultaTelefonoDTO datos = new ClienteConsultaTelefonoDTO();
                CookieContainer Cookies = new CookieContainer();
                var handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                handler.UseProxy = false;
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, error) =>
                {
                    /// Access cert object.
                    return true;
                };
                handler.CookieContainer = Cookies;
                handler.UseCookies = true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Add("Host", "numeracionyoperadores.cnmc.es");
                    client.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                    client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                    client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                           SecurityProtocolType.Tls12;

                    using (HttpResponseMessage response = await client.GetAsync("https://numeracionyoperadores.cnmc.es/portabilidad/movil"))
                    {
                        using (HttpContent content = response.Content)
                        {
                            mensajeRespuesta = await response.Content.ReadAsStringAsync();
                            
                            if (response.IsSuccessStatusCode)
                            {
                                string token = ExtraerContenidoEntreNombreString(mensajeRespuesta, 0, "name=\"_token\" type=\"hidden\" value=\"", "\">");

                                client.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                                client.DefaultRequestHeaders.Add("Origin", "https://numeracionyoperadores.cnmc.es");
                                client.DefaultRequestHeaders.Add("Referer", "https://numeracionyoperadores.cnmc.es/portabilidad/movil");
                                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                                datos._token = token;
                                datos.numero = telefono;
                                datos.reCaptchaToken = "03ADUVZwCFhPE1pR5iNAICG4GlKEovGZeNXTfViWk9ZGnxikBHi07OIOChE4GZHXWJZ5HowvDUFIX5xlTPkBRURTjO4DFhPcps4TjBu-UnWE5ut0NGe80jWMp-crX5udm0r-3utXl6xNxIPpP5zv_DmCxXFe379zzjg3PAutw1EGVE9Tk13LYTtt9ceEFE_QtjG1EdoBHdRCtjDFVkraF6w36HrP1W06A5FFqUnjaAt2k4v_uQrDhI6WO19A1PVAQOmKOFfJCXEuw-pAcIIZ23HMIpwjS6_3UUScESFZwzUKnDvGTtiJqIBvYXjXpYe02pySMF_sF9Yvudqcd53czXMTrdfdeJRwfybLCESqAzDtg3xZiRPIWgX9cJE5dtzXrMs35pj-ujZ7KL8fo-HczCSybVzolei8_O_KvMdEk4IH4IAKYwpVti58DgrJqMhW8Y3mMrtSa97O4fw7FLSegq-l6TRtMdj9Q7VsLKvbu_1vIwVqa5VBdMw2FJoT28TeyrAkyLC0DCUXFf26A7k90i4JGFdCkDHWjC0qgTGT6wkFs4t5iUyNbUF-gDqwRIQ8fZePjlkuus1NBBxE2kHmYDXEp-NqMiMxax3kjd6ZuLlE7wixvxMNw0ABuSDHV8mSGjd_gowN-1pf4l";




                                // Consultar datos
                                using (HttpResponseMessage resultadoConsultaDatos = await client.PostAsync("https://numeracionyoperadores.cnmc.es/portabilidad/movil/operador", new StringContent(
                                    "{'_token':'" + token  + "','numero':'"+telefono+ "','reCaptchaToken':'','g-recaptcha-response':'03ADUVZwCuPPaK0I4mY4inDAYAvkEFOuZI2e_pmz2uPZ-kjfzwXJzivKoDF-TmdrKbETeqVklTu5NQC2kv1W0rj2B1qxDsmnrfOMtMMm8J2W_wyAybSpHc6LNfwfVsYeLKeDOxVMQxk79ui9vigXN2WADc_PDIR4CIP51yVKEWxhCpDDuqszg1tBJ8ReETT9o5I_FZR9P7hMDXEfPC6wIWovvw0IUed8Zkuzi-0_lU1agD5YZw8HvzttT-kcX93kCGiuaRdJP2-IaBlJl5MPe_KaIXycgf1sZy6SNHvMSyFrbzjTlgxmR5FIRf77U-ljhdsyPTEgXYqYQ1fz_RxH6nLmD5me9JS4hq6bYqkXzAgmaRg7N2OUbX4-y5GpECtFrkninuCGM9FreRHfm2QxTYx3_lOEDIUDeEgCq_DCZex6Ua5jqKXqiYlt6cBHt8mEI9dDfVSWizpIGVsy_7CryOTvMAlCWC0RML7fDXQbcTh8iJ4PVdvnpCE6STshlJR-8UQLjx51boF57OoezTQ9YIjk0USZABx7smvYQSqQsKrDdsWr5iIvHyZfqFMj1yy6BKn_S2rvfaPBYjk_LsYgsbLHKCCvL3J_afYEqqN-TaO5Ef9hWn0qnAyTGtxj9EB6upChtIvQ0CI8VTEMpPNqOzxactYsUL1pJmlw' }", Encoding.UTF8, "application/json")))
                                {
                                    if (resultadoConsultaDatos.IsSuccessStatusCode )
                                    {
                                        string contenidoHTML = await resultadoConsultaDatos.Content.ReadAsStringAsync();

                                        string nombreDesde = "</form>";
                                        string nombreInicio = "<div class=\"col-md-12\">";
                                        string nombreFin = "</div>";
                                        string contenidoFormulario = ExtraerContenidoString(contenidoHTML, nombreDesde, nombreInicio, nombreFin);


                                        // Buscar si hay mensajes de error
                                        string error = ObtenerMensajeError(contenidoFormulario, "alert-danger");
                                        if(  error != "" )
                                        {
                                            DateTime now = DateTime.Now;
                                            return Ok(new
                                            {
                                                data = new {
                                                    number = telefono,
                                                    operador = "",
                                                    dateConsult = now.ToString("dd-MM-yyyy HH:mm:ss")
                                                },
                                                mensaje = error,
                                                status = 400
                                            });
                                        }

                                        string operador = ExtraerOperadorActual(contenidoFormulario,"Operador actual</p>", "<p>","</p>");

                                        return Ok(new{
                                            data = new {
                                                number = telefono,
                                                operador = operador,
                                                dateConsult = ""
                                            },
                                            mensaje = "",
                                            status = 200
                                        });
                                    }
                                    else
                                    {
                                        mensajeRespuesta = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                        return BadRequest(new
                                        {
                                            data = new { },
                                            mensaje = mensajeRespuesta,
                                            status = 400
                                        });
                                    }
                                }
                            }
                            else
                            {
                                return BadRequest(new{
                                    data = new { },
                                    mensaje = mensajeRespuesta,
                                    status = 400
                                });
                            }
                        }
                    }
                }

                oCronometro.Stop();
                //datos.TiempoProcesamiento = oCronometro.Elapsed.TotalSeconds;


                return Ok(new{
                    data = datos,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new{
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }







        private string ExtraerContenidoString(string cadena, string nombreDesde, string nombreInicio, string nombreFin, int numeroFinEncontrado = 1 , StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            int encontradoFin = 0;


            // obtenemos la posición desde donde inicia la busqueda
            int posicionDesde = cadena.IndexOf(nombreDesde, 0, reglaComparacion);
            if( posicionDesde > -1)
            {
                // actualizamos la posicion desde
                posicionDesde += nombreDesde.Length;

                // obtenemos la posición de la primera coincidencia
                int posicionInicio = cadena.IndexOf(nombreInicio, posicionDesde, reglaComparacion);
                if (posicionInicio > -1)
                {
                    posicionInicio += nombreInicio.Length;


                    int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                    if (posicionFin > -1)
                    {
                        respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                    }

                }

            }

            return respuesta;
        }

        private string ObtenerMensajeError( string cadena, string claseGuia )
        {
            string output = "";
            int posicionInicio = cadena.IndexOf(claseGuia, 0, StringComparison.OrdinalIgnoreCase);
            if (posicionInicio > -1)
            {
                int posicionMensajeInicio = cadena.IndexOf("<li>", 0, StringComparison.OrdinalIgnoreCase);
                posicionMensajeInicio += "<li>".Length;
                int posicionMensajeFin = cadena.IndexOf("</li>", posicionMensajeInicio, StringComparison.OrdinalIgnoreCase);
                if(posicionMensajeFin > -1)
                {
                    output = cadena.Substring(posicionMensajeInicio, posicionMensajeFin - posicionMensajeInicio);
                }
            }
            return output;
        }

        private string ExtraerOperadorActual(string cadena, string primerNombre, string segundoNombre, string final , StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            int posicionInicio = cadena.IndexOf(primerNombre, 0, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += primerNombre.Length;
                posicionInicio = cadena.IndexOf(segundoNombre, posicionInicio, reglaComparacion);

                if (posicionInicio > -1) {
                    posicionInicio += segundoNombre.Length;

                    int posicionFin = cadena.IndexOf(final, posicionInicio, reglaComparacion);
                    if (posicionFin > -1)
                        respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                }
                
            }

            return respuesta;
        }

        private string ExtraerContenidoEntreNombreString(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string respuesta = "";
            int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += nombreInicio.Length;
                int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                if (posicionFin > -1)
                    respuesta = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
            }

            return respuesta;
        }

        private string[] ExtraerContenidoEntreNombre(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.OrdinalIgnoreCase)
        {
            string[] arrRespuesta = null;
            int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
            if (posicionInicio > -1)
            {
                posicionInicio += nombreInicio.Length;
                int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                if (posicionFin > -1)
                {
                    posicion = posicionFin + nombreFin.Length;
                    arrRespuesta = new string[2];
                    arrRespuesta[0] = posicion.ToString();
                    arrRespuesta[1] = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                }
            }

            return arrRespuesta;
        }
    
    
    
        
    }
}