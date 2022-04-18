using MiPortafolioWeb.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MiPortafolioWeb.Servicess
{
	public interface IEmailRepository
	{
		Task Enviar(ContactModel contactoModel);
	}
	public class EmailRepository : IEmailRepository
	{
		private readonly IConfiguration configuration;

		public EmailRepository(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task Enviar(ContactModel contacto)
		{
			//obtener las credenciales para los permisos del api de twillo sendgrid
			var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
			var Email = configuration.GetValue<string>("SENDGRID_FROM");
			var Nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

			//armamos las credenciales
			var cliente = new SendGridClient(apiKey);
			var from = new EmailAddress(Email, Nombre);
			var subjet = $"El Cliente {contacto.Nombre} quiere contactarte";
			var to = new EmailAddress(Email, Nombre);
			var mensajeTextoPlano = contacto.Message;
			//armamos el mensaje
			var contenidoHtml = @$"De: {contacto.Nombre} - Email {contacto.Email}
										Mensaje {contacto.Message}";
			var singleEmail = MailHelper.CreateSingleEmail(from, to, subjet, mensajeTextoPlano, contenidoHtml);
			//obtenemos la respuesta
			var respuesta = await cliente.SendEmailAsync(singleEmail);



		}
	}
}
