using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Implement
{
    public class ClienteContratoApp : IClienteContratoApp
    {
        private readonly IClienteContratoDom _IClienteContratoDom;
        private readonly IClienteDom _IClienteDom;
        private readonly IParametroSistemaDom _IParametroSistemaDom;
        private readonly IEmailDom _IEmailDom;

        public ClienteContratoApp(IClienteContratoDom IClienteContratoDom, IEmailDom IEmailDom, IClienteDom IClienteDom, IParametroSistemaDom IParametroSistemaDom)
        {
            _IClienteContratoDom = IClienteContratoDom;
            _IEmailDom = IEmailDom;
            _IClienteDom = IClienteDom;
            _IParametroSistemaDom = IParametroSistemaDom;
        }

        public async Task<Respuesta<ClienteContratoDTO>> GuardarContrato(ClienteContratoDTO model)
        {
            Respuesta<ClienteContratoDTO> Contrato = await _IClienteContratoDom.GuardarContrato(model);
            /*if (Contrato.Exito)
            {
                if (model.EnviarCorreo) {
                    if (Contrato.Response.ClienteEmail != "")
                    {
                        EmailEnvioDTO envioEmail = new EmailEnvioDTO
                        {
                            Asunto = Contrato.Response.TituloContrato,
                            Contenido = "Estimado Cliente se envia una copia de su " + Contrato.Response.TituloContrato,
                            EmailCopiaOculta = Contrato.Response.EmailCC,
                            EmailDestino = Contrato.Response.ClienteEmail,
                            Adjunto = model.Contrato,
                            NombreAdjunto = Contrato.Response.TituloContrato.Replace(" ", "_") + " ( CTT-" + Contrato.Response.Id.ToString().PadLeft(8, '0') + " ) .pdf"
                        };
                        bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                        if (enviado)
                        {
                            Contrato.Mensaje = "Email enviado al cliente";
                            Contrato.Response.EmailEnviado = true;
                        }
                        else
                        {
                            Contrato.Mensaje = "No se pudo enviar el email";
                            Contrato.Response.EmailEnviado = false;
                        }
                    }
                    else
                    {
                        Contrato.Mensaje = "Cliente no tiene email registrado";
                        Contrato.Response.EmailEnviado = false;
                    }
                }
            }*/

            return Contrato;
        }

        public async Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model)
        {
            return await _IClienteContratoDom.AnularContrato(id, model);
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdCliente(int id)
        {
            return await _IClienteContratoDom.ListarByIdCliente(id);
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int id, int idServicio)
        {
            return await _IClienteContratoDom.ListarByIdClientePorServicio(id, idServicio);
        }

        public async Task<ClienteContratoDTO> verContrato(int idContrato)
        {
            return await _IClienteContratoDom.verContrato(idContrato);
        }

        public async Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model)
        {
            ClienteDTO cliente = await _IClienteDom.ObtenerById(model.IdCliente);
            Respuesta<ParametroSistemaEnt> emailCC = await _IParametroSistemaDom.ObtenerById(10);

            if (cliente.Correo == "" || cliente.Correo == null)
            {
                throw new AlertException("El cliente no tiene correo registrado.");
            }

            EmailEnvioDTO envioEmail = new EmailEnvioDTO
            {
                Asunto = model.TituloContrato + (model.IdEstado == 0 ? " (ANULADO)" : ""),
                Contenido = "Estimado Cliente se envia una copia del documento " + model.TituloContrato,
                EmailCopiaOculta = emailCC.Response.Valor,
                EmailDestino = cliente.Correo,
                Adjunto = model.Contrato,
                NombreAdjunto = "CTT-" + model.Id.ToString().PadLeft(8, '0') + " " + model.TituloContrato.Replace(" ", "_") + (model.IdEstado == 0 ? " (ANULADO)" : "") + ".pdf"
            };
            bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);

            if (!enviado)
            {
                throw new AlertException("No se pudo enviar el email" + cliente.Correo);
            }

            await _IClienteContratoDom.SeEnvioContrato(model.Id);

            return true;
        }
    }
}