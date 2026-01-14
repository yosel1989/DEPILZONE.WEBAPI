using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class EmailDom : IEmailDom
    {
        private readonly IEmailDat _IEnvioEmailDat;
        private readonly IParametroSistemaDat _IParametroSistemaDat;
        public EmailDom(IEmailDat IEnvioEmailDat, IParametroSistemaDat IParametroSistemaDat)
        {
            _IEnvioEmailDat = IEnvioEmailDat;
            _IParametroSistemaDat = IParametroSistemaDat;
        }
        public async Task<int> EnvioEmail(EmailEnvioDTO model)
        {
            return await _IEnvioEmailDat.EnvioEmail(model);
        }

        public async Task<bool> SendEmailAsync(EmailEnvioDTO model)
        {
            try
            {
                List<ParametroSistemaEnt> parametros = (List<ParametroSistemaEnt>)await _IParametroSistemaDat.ObtenerParametrosEmail();

                string EmailRemitente = parametros.Where(x => x.Parametro == "EmailRemitente").FirstOrDefault().Valor;
                string PasswordMail = parametros.Where(x => x.Parametro == "EmailPassword").FirstOrDefault().Valor;

                SmtpClient Cliente = new SmtpClient()
                {
                    Host = parametros.Where(x => x.Parametro == "EmailHost").FirstOrDefault().Valor,
                    Port = int.Parse(parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(EmailRemitente, PasswordMail),
                    EnableSsl = parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor == "1" ? true : false,
                };

                MailAddress de = new MailAddress(EmailRemitente, "DEPILZONE - Documentos");
                MailAddress para = new MailAddress(model.EmailDestino);
                MailMessage correo = new MailMessage(de, para)
                {
                    Subject = model.Asunto,
                    Body = model.Contenido,
                    IsBodyHtml = true
                };

                correo.Bcc.Add(model.EmailCopiaOculta);
                Stream content = new MemoryStream(Convert.FromBase64String(model.Adjunto));
                Attachment adjunto = new Attachment(content, model.NombreAdjunto, "application/pdf");
                correo.Attachments.Add(adjunto);
                await Cliente.SendMailAsync(correo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}