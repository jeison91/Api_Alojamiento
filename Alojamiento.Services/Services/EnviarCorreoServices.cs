using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Alojamiento.Domain.Exceptions;
using Alojamiento.Services.Services.Interfaces;

namespace Alojamiento.Services.Services
{
    public class EnviarCorreoServices : IEnviarCorreoServices
    {
        private readonly IConfiguration _configuration;

        public EnviarCorreoServices(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task SendEmail(string emailCliente)
        {
            string smtp = _configuration["Correo:smtp"].ToString();
            int port = Convert.ToInt32(_configuration["Correo:port"]);
            string Email = _configuration["Correo:Email"].ToString();
            string Password = _configuration["Correo:Password"].ToString();
            bool ssl = Convert.ToBoolean(_configuration["Correo:ssl"]);

            var smtpClient = new SmtpClient(smtp)
            {
                Port = port,
                Credentials = new NetworkCredential(Email, Password),
                EnableSsl = ssl
            };

            var mensaje = new MailMessage
            {
                From = new MailAddress(Email),
                Subject = "Reserva hospedaje",
                Body = "Se realizo la reserva exitosamente."
            };

            //Destinatario
            mensaje.To.Add(emailCliente);

            try
            {
                // Envía el correo electrónico
                smtpClient.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw new DomainValidateException($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }
    }
}
