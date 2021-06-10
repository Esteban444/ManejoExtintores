using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.ServiciosEmail
{
    public interface IEmailSender
    {
        void SendEmail(Mensaje mensaje); 
        Task SendEmailAsync(Mensaje mensaje);
    }
}
