using DepilZone.Api.Controllers;
using DepilZone.Api.Hubs;
using DepilZone.Application.Implement;
using DepilZone.Application.Implement.C360;
using DepilZone.Application.Interface;
using DepilZone.Application.Interface.C360;
using DepilZone.Data;
using DepilZone.Data.Implement;
using DepilZone.Data.ImplementC360;
using DepilZone.Data.Interface;
using DepilZone.Data.Interface.C360;
using DepilZone.Domain;
using DepilZone.Domain.Implement;
using DepilZone.Domain.Implement.C360;
using DepilZone.Domain.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static DepilZone.Api.Controllers.PreferenteController;

namespace DepilZone.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            //usuario
            services.AddTransient<IUsuarioDat, UsuarioDat>();
            services.AddTransient<IUsuarioDom, UsuarioDom>();
            services.AddTransient<IUsuarioApp, UsuarioApp>();

            services.AddTransient<IPerfilDat, PerfilDat>();
            services.AddTransient<IPerfilDom, PerfilDom>();
            services.AddTransient<IPerfilApp, PerfilApp>();

            //cliente
            services.AddTransient<IClienteDat, ClienteDat>();
            services.AddTransient<IClienteDom, ClienteDom>();
            services.AddTransient<IClienteApp, ClienteApp>();

            //maquina
            services.AddTransient<IMaquinaDat, MaquinaDat>();
            services.AddTransient<IMaquinaDom, MaquinaDom>();
            services.AddTransient<IMaquinaApp, MaquinaApp>();

            //Ubicacion 
            services.AddTransient<IUbicacionDat, UbicacionDat>();
            services.AddTransient<IUbicacionDom, UbicacionDom>();
            services.AddTransient<IUbicacionApp, UbicacionApp>();
			
			//ZONAS
            services.AddTransient<IZonaCorporalDat, ZonaCorporalDat>();
            services.AddTransient<IZonaCorporalDom, ZonaCorporalDom>();
            services.AddTransient<IZonaCorporalApp, ZonaCorporalApp>();

            //SEDE
            services.AddTransient<ISedeDat, SedeDat>();
            services.AddTransient<ISedeDom, SedeDom>();
            services.AddTransient<ISedeApp, SedeApp>();

            //Promocion
            services.AddTransient<IPromocionDat, PromocionDat>();
            services.AddTransient<IPromocionDom, PromocionDom>();
            services.AddTransient<IPromocionApp, PromocionApp>();

            //Promocion Categoria
            services.AddTransient<IPromocionCategoriaDat, PromocionCategoriaDat>();
            services.AddTransient<IPromocionCategoriaDom, PromocionCategoriaDom>();
            services.AddTransient<IPromocionCategoriaApp, PromocionCategoriaApp>();

            //Promocion
            services.AddTransient<IPromocionBloqueDat, PromocionBloqueDat>();
            services.AddTransient<IPromocionBloqueDom, PromocionBloqueDom>();
            services.AddTransient<IPromocionBloqueApp, PromocionBloqueApp>();

            //PromocionZona 
            services.AddTransient<IPromocionZonaDat, PromocionZonaDat>();
            services.AddTransient<IPromocionZonaDom, PromocionZonaDom>();
            services.AddTransient<IPromocionZonaApp, PromocionZonaApp>();

            //IPromocionPrecioApp
            services.AddTransient<IPromocionPrecioDat, PromocionPrecioDat>();
            services.AddTransient<IPromocionPrecioDom, PromocionPrecioDom>();
            services.AddTransient<IPromocionPrecioApp, PromocionPrecioApp>();

            //Configuracion
            services.AddTransient<IConfiguracionDat, ConfiguracionDat>();
            services.AddTransient<IConfiguracionDom, ConfiguracionDom>();
            services.AddTransient<IConfiguracionApp, ConfiguracionApp>();

            //ConfiguracionRepl
            services.AddTransient<IConfiguracionReplDat, ConfiguracionReplDat>();
            services.AddTransient<IConfiguracionReplDom, ConfiguracionReplDom>();
            services.AddTransient<IConfiguracionReplApp, ConfiguracionReplApp>();

            //DOCUMENTOS
            services.AddTransient<IDocumentoDat, DocumentoDat>();
            services.AddTransient<IDocumentoDom, DocumentoDom>();
            services.AddTransient<IDocumentoApp, DocumentoApp>();
            //services.AddControllers();

            //TIPOS DE DOCUMENTOS
            services.AddTransient<IDocumentoTipoDat, DocumentoTipoDat>();
            services.AddTransient<IDocumentoTipoDom, DocumentoTipoDom>();
            services.AddTransient<IDocumentoTipoApp, DocumentoTipoApp>();

            //DOCUMENTO PLANTILLAS
            services.AddTransient<IDocumentoPlantillaDat, DocumentoPlantillaDat>();
            services.AddTransient<IDocumentoPlantillaDom, DocumentoPlantillaDom>();
            services.AddTransient<IDocumentoPlantillaApp, DocumentoPlantillaApp>();

            //DOCUMENTOS DEL CLIENTE
            services.AddTransient<IClienteDocumentoDat, ClienteDocumentoDat>();
            services.AddTransient<IClienteDocumentoDom, ClienteDocumentoDom>();
            services.AddTransient<IClienteDocumentoApp, ClienteDocumentoApp>();

            //ENVIO DE CORREO API
            services.AddTransient<IEmailDat, EmailDat>();
            services.AddTransient<IEmailDom, EmailDom>();
            services.AddTransient<IEmailApp, EmailApp>();

            //TIPO DE CITA
            services.AddTransient<ICitaTipoDat, CitaTipoDat>();
            services.AddTransient<ICitaTipoDom, CitaTipoDom>();
            services.AddTransient<ICitaTipoApp, CitaTipoApp>();

            //PROMOCION PLANTILLA
            services.AddTransient<IPromocionPlantillaDat, PromocionPlantillaDat>();
            services.AddTransient<IPromocionPlantillaDom, PromocionPlantillaDom>();
            services.AddTransient<IPromocionPlantillaApp, PromocionPlantillaApp>();

            //Preferente
            services.AddTransient<IPreferenteDat, PreferenteDat>();
            services.AddTransient<IPreferenteDom, PreferenteDom>();
            services.AddTransient<IPreferenteApp, PreferenteApp>();

            //MEDIOCONTACTO
            services.AddTransient<IMedioContactoDat, MedioContactoDat>();
            services.AddTransient<IMedioContactoDom, MedioContactoDom>();
            services.AddTransient<IMedioContactoApp, MedioContactoApp>();

            //COMENTARIO
            services.AddTransient<IComentarioDat, ComentarioDat>();
            services.AddTransient<IComentarioDom, ComentarioDom>();
            services.AddTransient<IComentarioApp, ComentarioApp>();

            //ESTADO
            services.AddTransient<IEstadoDat, EstadoDat>();
            services.AddTransient<IEstadoDom, EstadoDom>();
            services.AddTransient<IEstadoApp, EstadoApp>();

            //Genero
            services.AddTransient<IGeneroDat, GeneroDat>();
            services.AddTransient<IGeneroDom, GeneroDom>();
            services.AddTransient<IGeneroApp, GeneroApp>();

            //Documento Identidad Tipo
            services.AddTransient<IDocumentoIdentidadTipoDat, DocumentoIdentidadTipoDat>();
            services.AddTransient<IDocumentoIdentidadTipoDom, DocumentoIdentidadTipoDom>();
            services.AddTransient<IDocumentoIdentidadTipoApp, DocumentoIdentidadTipoApp>();

            //Documento Identidad Tipo
            services.AddTransient<ICitaTipoDat, CitaTipoDat>();
            services.AddTransient<ICitaTipoDom, CitaTipoDom>();
            services.AddTransient<ICitaTipoApp, CitaTipoApp>();

            //MAQUINASEDE
            services.AddTransient<IMaquinaSedeDat, MaquinaSedeDat>();
            services.AddTransient<IMaquinaSedeDom, MaquinaSedeDom>();
            services.AddTransient<IMaquinaSedeApp, MaquinaSedeApp>();

            //CITA
            services.AddTransient<ICitaDat, CitaDat>();
            services.AddTransient<ICitaDom, CitaDom>();
            services.AddTransient<ICitaApp, CitaApp>();

            //ANUNCIO
            services.AddTransient<IAnuncioDat, AnuncioDat>();
            services.AddTransient<IAnuncioDom, AnuncioDom>();
            services.AddTransient<IAnuncioApp, AnuncioApp>();

            //TIPOCLIENTE
            services.AddTransient<Data.Interface.ITipoClienteDat, Data.Implement.TipoClienteDat>();
            services.AddTransient<Data.Interface.ITipoClienteDom, Domain.Implement.TipoClienteDom>();
            services.AddTransient<Application.Interface.ITipoClienteApp, Application.Implement.TipoClienteApp>();

            //CHAT
            services.AddTransient<IChatDat, ChatDat>(); 
            services.AddTransient<IChatDom, ChatDom>();
            services.AddTransient<IChatApp, ChatApp>();

            //NOTAS
            services.AddTransient<ICitaMensajeNotaDat, CitaMensajeNotaDat>();
            services.AddTransient<ICitaMensajeNotaDom, CitaMensajeNotaDom>();
            services.AddTransient<ICitaMensajeNotaApp, CitaMensajeNotaApp>();

            //AVISOS
            services.AddTransient<ICitaMensajeAvisoDat, CitaMensajeAvisoDat>();
            services.AddTransient<ICitaMensajeAvisoDom, CitaMensajeAvisoDom>();
            services.AddTransient<ICitaMensajeAvisosApp, CitaMensajeAvisoApp>();

            //Detalle
            services.AddTransient<ICitaMensajeDetalleDat, CitaMensajeDetalleDat>();
            services.AddTransient<ICitaMensajeDetalleDom, CitaMensajeDetalleDom>();
            services.AddTransient<ICitaMensajeDetalleApp, CitaMensajeDetalleApp>();

            //Seguimiento Cita
            services.AddTransient<ICitaSeguimientoDat, CitaSeguimientoDat>();
            services.AddTransient<ICitaSeguimientoDom, CitaSeguimientoDom>();
            services.AddTransient<ICitaSeguimientoApp, CitaSeguimientoApp>();

            //DETALLE DE CITAS
            services.AddTransient<ICitaDetalleDat, CitaDetalleDat>();
            services.AddTransient<ICitaDetalleDom, CitaDetalleDom>();
            services.AddTransient<ICitaDetalleApp, CitaDetalleApp>();

            //DETALLE DE CITAS HORARIOS
            services.AddTransient<IDetalleCitaHorarioDat, DetalleCitaHorarioDat>();
            services.AddTransient<IDetalleCitaHorarioDom, DetalleCitaHorarioDom>();
            services.AddTransient<IDetalleCitaHorarioApp, DetalleCitaHorarioApp>();

            //CAJA
            services.AddTransient<ICajaDat, CajaDat>();
            services.AddTransient<ICajaDom, CajaDom>();
            services.AddTransient<ICajaApp, CajaApp>();

            //VENTA
            services.AddTransient<IVentaDat, VentaDat>();
            services.AddTransient<IVentaDom, VentaDom>();
            services.AddTransient<IVentaApp, VentaApp>();

            //EMPRESA
            services.AddTransient<IEmpresaDat, EmpresaDat>();
            services.AddTransient<IEmpresaDom, EmpresaDom>();
            services.AddTransient<IEmpresaApp, EmpresaApp>();

            //HISTORIA CLINICA
            services.AddTransient<IHistoriaClinicaDat, HistoriaClinicaDat>();
            services.AddTransient<IHistoriaClinicaDom, HistoriaClinicaDom>();
            services.AddTransient<IHistoriaClinicaApp, HistoriaClinicaApp>();

            //EVOLUCION DEL TRATAMIENTO
            services.AddTransient<IEvolucionTratamientoDat, EvolucionTratamientoDat>();
            services.AddTransient<IEvolucionTratamientoDom, EvolucionTratamientoDom>();
            services.AddTransient<IEvolucionTratamientoApp, EvolucionTratamientoApp>();

            //ROLES
            services.AddTransient<IRolesDat, RolesDat>();
            services.AddTransient<IRolesDom, RolesDom>();
            services.AddTransient<IRolesApp, RolesApp>();

            //MENU
            services.AddTransient<IMenuDat, MenuDat>();
            services.AddTransient<IMenuDom, MenuDom>();
            services.AddTransient<IMenuApp, MenuApp>();

            //CITA ASIGNADA
            services.AddTransient<ICitaAsignadaDat, CitaAsignadaDat>();
            services.AddTransient<ICitaAsignadaDom, CitaAsignadaDom>();
            services.AddTransient<ICitaAsignadaApp, CitaAsignadaApp>();

            //CLIENTE RECURRENTE
            services.AddTransient<IClienteRecurrenteDat, ClienteRecurrenteDat>();
            services.AddTransient<IClienteRecurrenteDom, ClienteRecurrenteDom>();
            services.AddTransient<IClienteRecurrenteApp, ClienteRecurrenteApp>();

            //REPORTE ZONAS
            services.AddTransient<IReporteZonasDat, ReporteZonasDat>();
            services.AddTransient<IReporteZonasDom, ReporteZonasDom>();
            services.AddTransient<IReporteZonasApp, ReporteZonasApp>();

            //APERTURAYCIERRE
            services.AddTransient<IAperturaDat, AperturaDat>();
            services.AddTransient<IAperturaDom, AperturaDom>();
            services.AddTransient<IAperturaApp, AperturaApp>();

            //TURNO
            services.AddTransient<ITurnoDat, TurnoDat>();
            services.AddTransient<ITurnoDom, TurnoDom>();
            services.AddTransient<ITurnoApp, TurnoApp>();

            //EGRESOS
            services.AddTransient<IEgresoDat, EgresoDat>();
            services.AddTransient<IEgresoDom, EgresoDom>();
            services.AddTransient<IEgresoApp, EgresoApp>();

            //TIPOCOMPROBANTE
            services.AddTransient<ITipoComprobanteDat, TipoComprobanteDat>();
            services.AddTransient<ITipoComprobanteDom, TipoComprobanteDom>();
            services.AddTransient<ITipoComprobanteApp, TipoComprobanteApp>();

            //LIBRORECLAMACION
            services.AddTransient<ILibroReclamacionDat, LibroReclamacionDat>();
            services.AddTransient<ILibroReclamacionDom, LibroReclamacionDom>();
            services.AddTransient<ILibroReclamacionApp, LibroReclamacionApp>();
            //LIBRORECLAMACION
            services.AddTransient<IParametroSistemaDat, ParametroSistemaDat>();
            services.AddTransient<IParametroSistemaDom, ParametroSistemaDom>();
            services.AddTransient<IParametroSistemaApp, ParametroSistemaApp>();
            //PATOLOGIA
            services.AddTransient<IPatologiaDat, PatologiaDat>();
            services.AddTransient<IPatologiaDom, PatologiaDom>();
            services.AddTransient<IPatologiaApp, PatologiaApp>();
            //FICHAADMISION
            services.AddTransient<IFichaAdmisionDat, FichaAdmisionDat>();
            services.AddTransient<IFichaAdmisionDom, FichaAdmisionDom>();
            services.AddTransient<IFichaAdmisionApp, FichaAdmisionApp>();
            //EVOLUCIONCITAMENSUAL
            services.AddTransient<IEvolucionCitaMensualDat, EvolucionCitaMensualDat>();
            services.AddTransient<IEvolucionCitaMensualDom, EvolucionCitaMensualDom>();
            services.AddTransient<IEvolucionCitaMensualApp, EvolucionCitaMensualApp>();


            // EQUIPO LASER
            services.AddTransient<IEquipoLaserDat, EquipoLaserDat>();
            services.AddTransient<IEquipoLaserDom, EquipoLaserDom>();
            services.AddTransient<IEquipoLaserApp, EquipoLaserApp>();

            // CITA MOTIVO ESTADO
            services.AddTransient<ICitaEstadoMotivoDat, CitaEstadoMotivoDat>();
            services.AddTransient<ICitaEstadoMotivoDom, CitaEstadoMotivoDom>();
            services.AddTransient<ICitaEstadoMotivoApp, CitaEstadoMotivoApp>();

            // CITA MOTIVO
            services.AddTransient<ICitaMotivoDat, CitaMotivoDat>();
            services.AddTransient<ICitaMotivoDom, CitaMotivoDom>();
            services.AddTransient<ICitaMotivoApp, CitaMotivoApp>();

            // ALTERNATIVA MEDICION
            services.AddTransient<IAlternativaMedicionDat, AlternativaMedicionDat>();
            services.AddTransient<IAlternativaMedicionDom, AlternativaMedicionDom>();
            services.AddTransient<IAlternativaMedicionApp, AlternativaMedicionApp>();

            // CITA MEDICION
            services.AddTransient<ICitaMedicionDat, CitaMedicionDat>();
            services.AddTransient<ICitaMedicionDom, CitaMedicionDom>();
            services.AddTransient<ICitaMedicionApp, CitaMedicionApp>();

            // TIPO MEDICION
            services.AddTransient<ITipoMedicionDat, TipoMedicionDat>();
            services.AddTransient<ITipoMedicionDom, TipoMedicionDom>();
            services.AddTransient<ITipoMedicionApp, TipoMedicionApp>();

            // CLIENTE CONTRATO
            services.AddTransient<IClienteContratoDat, ClienteContratoDat>();
            services.AddTransient<IClienteContratoDom, ClienteContratoDom>();
            services.AddTransient<IClienteContratoApp, ClienteContratoApp>();

            // CLIENTE ENCUESTA
            services.AddTransient<IClienteEncuestaDat, ClienteEncuestaDat>();
            services.AddTransient<IClienteEncuestaDom, ClienteEncuestaDom>();
            services.AddTransient<IClienteEncuestaApp, ClienteEncuestaApp>();

            // CUPONES
            services.AddTransient<IDescuentoDat, DescuentoDat>();
            services.AddTransient<IDescuentoDom, DescuentoDom>();
            services.AddTransient<IDescuentoApp, DescuentoApp>();

            // FORMULARIO ENCUESTA
            services.AddTransient<IFormularioEncuestaDat, FormularioEncuestaDat>();
            services.AddTransient<IFormularioEncuestaDom, FormularioEncuestaDom>();
            services.AddTransient<IFormularioEncuestaApp, FormularioEncuestaApp>();


            // FORMULARIO ENCUESTA
            services.AddTransient<IReporteCitaDat, ReporteCitaDat>();
            services.AddTransient<IReporteCitaDom, ReporteCitaDom>();
            services.AddTransient<IReporteCitaApp, ReporteCitaApp>();


            // FORMULARIO CLIENTE INCIDENCIA
            services.AddTransient<IClienteIncidenciaDat, ClienteIncidenciaDat>();
            services.AddTransient<IClienteIncidenciaDom, ClienteIncidenciaDom>();
            services.AddTransient<IClienteIncidenciaApp, ClienteIncidenciaApp>();

            // FORMULARIO INCIDENCIA
            services.AddTransient<IIncidenciaDat, IncidenciaDat>();
            services.AddTransient<IIncidenciaDom, IncidenciaDom>();
            services.AddTransient<IIncidenciaApp, IncidenciaApp>();

            // SERVICIOS
            services.AddTransient<Data.Interface.IServicioDat, Data.Implement.ServicioDat>();
            services.AddTransient<Data.Interface.IServicioDom, Domain.Implement.ServicioDom>();
            services.AddTransient<Application.Interface.IServicioApp, Application.Implement.ServicioApp>();

            // CLIENTE ACCESO
            services.AddTransient<IClienteAccesoDat, ClienteAccesoDat>();
            services.AddTransient<IClienteAccesoDom, ClienteAccesoDom>();
            services.AddTransient<IClienteAccesoApp, ClienteAccesoApp>();

            // Tecnologias
            services.AddTransient<ITecnologiaDat, TecnologiaDat>();
            services.AddTransient<ITecnologiaDom, TecnologiaDom>();
            services.AddTransient<ITecnologiaApp, TecnologiaApp>();




            /** 
             * CORPORAL 360 - START
             * **/

            // SERVICIOS
            services.AddTransient<Data.Interface.C360.IServicioDat, Data.ImplementC360.ServicioDat>();
            services.AddTransient<Data.Interface.C360.IServicioDom, Domain.Implement.C360.ServicioDom>();
            services.AddTransient<Application.Interface.C360.IServicioApp, Application.Implement.C360.ServicioApp>();

            // CASOS
            services.AddTransient<ICasoDat, CasoDat>();
            services.AddTransient<ICasoDom, CasoDom>();
            services.AddTransient<ICasoApp, CasoApp>();

            // ZONAS
            services.AddTransient<IZonaDat, ZonaDat>();
            services.AddTransient<IZonaDom, ZonaDom>();
            services.AddTransient<IZonaApp, ZonaApp>();

            // CASOS
            services.AddTransient<ITipoCitaDat, TipoCitaDat>();
            services.AddTransient<ITipoCitaDom, TipoCitaDom>();
            services.AddTransient<ITipoCitaApp, TipoCitaApp>();

            // CATEGORIA
            services.AddTransient<ICategoriaDat, CategoriaDat>();
            services.AddTransient<ICategoriaDom, CategoriaDom>();
            services.AddTransient<ICategoriaApp, CategoriaApp>();

            // SALAS
            services.AddTransient<ISalaDat, SalaDat>();
            services.AddTransient<ISalaDom, SalaDom>();
            services.AddTransient<ISalaApp, SalaApp>();

            // TIPO CLIENTE
            services.AddTransient<Data.Interface.C360.ITipoClienteDat, Data.ImplementC360.TipoClienteDat>();
            services.AddTransient<Data.Interface.C360.ITipoClienteDom, Domain.Implement.C360.TipoClienteDom>();
            services.AddTransient<Application.Interface.C360.ITipoClienteApp, Application.Implement.C360.TipoClienteApp>();

            /** 
             * CORPORAL 360 - END
             * **/

            //SIGNALR
            services.AddTransient<SignalHub, SignalHub>();



            //CONTROLADORES
            services.AddTransient<ChatController, ChatController>();
            services.AddTransient<PreferenteController, PreferenteController>();

            services.AddHostedService<PreferenteMonitor>();

            services.AddControllers();

            string ipCorsClinic = "http://localhost:4201";
            string ipCorsReclamo = "http://localhost:4205";

            //string ipCorsClinic = "https://qa.depilzone.com.pe:5037"; //angular qa
            //string ipCorsReclamo = "https://qa.depilzone.com.pe:4037"; //angular qa

            //string ipCorsClinic = "https://clinic.depilzone.com.pe:6037"; //angular prod
            //string ipCorsReclamo = "https://clinic.depilzone.com.pe:4036"; //angular prod

            services.AddCors(options => options
                    .AddPolicy("AllowAll", p => p.SetIsOriginAllowed(isOriginAllowed: _ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()));

            /*services.AddCors(options => options
                    .AddPolicy("AllowAll", p => p.WithOrigins(new string[] { ipCorsClinic, ipCorsReclamo })
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalHub>("apiSignal");
            });
        }
    }
}

