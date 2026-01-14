using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenteController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IPreferenteApp _preferente;

        public PreferenteController(IPreferenteApp PreferenteApp, IHubContext<SignalHub> hubContext)
        {
            _preferente = PreferenteApp;
            _hubContext = hubContext;
        }


        [HttpGet("{fechaDesde}/{fechaHasta}/{idEstado}/{idTeleoperador}/{IdMedioContacto}/{idUsuarioSistema}")]
        public async Task<IEnumerable<PreferenteGrillaDTO>> Get(DateTime fechaDesde, DateTime fechaHasta, int idEstado, int idTeleoperador, int IdMedioContacto, int IdUsuarioSistema)
        {
            return await _preferente.Obtener(fechaDesde, fechaHasta, idEstado, idTeleoperador, IdMedioContacto, IdUsuarioSistema);
        }
        [HttpGet("{id}/{idUsuarioSistema}")]
        public async Task<PreferenteDTO> Get(int id, int IdUsuarioSistema)
        {
            return await _preferente.ObtenerById(id, IdUsuarioSistema);
        }
        [HttpPost]
        public async Task<Respuesta<PreferenteEnt>> Post(PreferenteEnt model)
        {
            return await _preferente.Insertar(model);
        }
        [HttpPut]
        public async Task<Respuesta<PreferenteEnt>> Put(PreferenteEnt model)
        {
            return await _preferente.Modificar(model);
        }
        [HttpPut("actualizaEstadoVisto")]
        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _preferente.ActualizaEstadoVisto(idsPreferente);
        }

        [HttpPut("{action}")]
        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
            {
            var resultado = await _preferente.Asignar(model);

            MensajeSignalR mensajeSignalR = new MensajeSignalR()
            {
                Exito = true,
                Mensaje = TipoAlerta.PreferenteAsignado.ToString(),
                DatosJSON = JsonSerializer.Serialize(resultado),
                Tipo = TipoAlerta.PreferenteAsignado
            };
            await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

            return resultado;
        }


        [HttpPut("atendido")]
        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            var resultado = await _preferente.Atendido(model);

            //MensajeSignalR mensajeSignalR = new MensajeSignalR()
            //{
            //    Exito = true,
            //    Mensaje = TipoAlerta.PreferenteAsignado.ToString(),
            //    DatosJSON = JsonSerializer.Serialize(resultado),
            //    Tipo = TipoAlerta.PreferenteAsignado
            //};
            //await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

            return resultado;
        }


        [HttpPost("importarExcel")]
        public async Task<ActionResult> ImportarExcel(List<PreferenteImportarDTO> list)
        {
            try
            {
                var resultado = await _preferente.ImportarExcel(list);
                return Ok(new {
                    data = resultado,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpPost("asignarLista")]
        public async Task<ActionResult> AsignarLista(List<PreferenteAsignarListaDTO> list)
        {
            try
            {
                await _preferente.AsignarLista(list);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }



        public class PreferenteMonitor : BackgroundService
        {
            private readonly IPreferenteApp _preferenteApp;
            private readonly IHubContext<SignalHub> _hubContext;
            public PreferenteMonitor(IPreferenteApp IPreferenteApp, IHubContext<SignalHub> hub)
            {
                _preferenteApp = IPreferenteApp;
                _hubContext = hub;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    int preferentesSinAtender = await _preferenteApp.ObtenerSinAtender();
                    if (preferentesSinAtender > 0)
                    {
                        MensajeSignalR mensajeSignalR = new MensajeSignalR()
                        {
                            Exito = true,
                            Mensaje = TipoAlerta.RetornoPreferente.ToString(),
                            DatosJSON = JsonSerializer.Serialize(preferentesSinAtender),
                            Tipo = TipoAlerta.RetornoPreferente
                        };
                        await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                    }

                    await Task.Delay(60000);
                    }
            }
        }
    }

}

