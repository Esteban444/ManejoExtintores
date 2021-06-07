using ManejoExtintores.Core.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ManejoExtintores.Infraestructura.Filtros 
{
    public class Filtro_Excepciones : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception.GetType() == typeof(Excepcion_Servidor))
            {
                var excepcion = (Excepcion_Servidor)context.Exception;
                var validacion = new
                {
                    Estado = 500,
                    Titulo = "Error en el servidor",
                    Detalle = excepcion.Message

                };
                var json = new
                {
                    errors = new[] { validacion }
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
        }
    }
}
