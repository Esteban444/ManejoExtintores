using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Reporte
{
    public class ReporteCron :TrabajoCronService
    {
        private readonly ILogger<ReporteCron> _logger;
        public ReporteCron(IProgramacion<ReporteCron> configuracion, ILogger<ReporteCron> logger)
            :base(configuracion.CronExpresion, configuracion.ZonaHoraria)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Inicio reporte");
            return base.StartAsync(cancellationToken);
        }
        public override Task HacerTrabajo(CancellationToken cancellationToken) 
        {
            _logger.LogInformation($"{DateTime.Now:12:00:00} CronJob  is working.");
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Detener reporte");
            return base.StopAsync(cancellationToken);
        }
    }
}
