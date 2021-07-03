using ManejoExtintores.Infraestructura.Reporte;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManejoExtintores.Infraestructura.Extensiones
{
    public static class ExtencionesServiceProgramadas
    {
        public static IServiceCollection AddCronJob<T>(this IServiceCollection services, Action<IProgramacion<T>> options) where T : TrabajoCronService
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"Proporcione configuraciones de programacion.");
            }
            var configuracion = new Programacion<T>();
            options.Invoke(configuracion);
            if (string.IsNullOrWhiteSpace(configuracion.CronExpresion))
            {
                throw new ArgumentNullException(nameof(Programacion<T>.CronExpresion), @"No se permite la expresion de cron vacía.");
            }
            services.AddSingleton<IProgramacion<T>>(configuracion);
            services.AddHostedService<T>();
            return services;
        }
    }
}
