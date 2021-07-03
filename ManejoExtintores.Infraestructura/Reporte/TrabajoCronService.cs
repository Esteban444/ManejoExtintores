using Cronos;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Reporte
{
    public abstract class TrabajoCronService : IHostedService, IDisposable
    {
        private System.Timers.Timer _Temporizador;
        private readonly CronExpression _expresion;
        private readonly TimeZoneInfo _InformacionzonaHoraria;
        protected TrabajoCronService(string cronExpression,TimeZoneInfo zonaHoraria)
        {
            _expresion = CronExpression.Parse(cronExpression);
            _InformacionzonaHoraria = zonaHoraria;
        }
       

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await CalendarioTrabajo(cancellationToken);
        }
        protected virtual async Task CalendarioTrabajo(CancellationToken cancellationToken)
        {
            var siguiente = _expresion.GetNextOccurrence(DateTimeOffset.Now, _InformacionzonaHoraria);
            if (siguiente.HasValue)
            {
                var demora = siguiente.Value - DateTimeOffset.Now;
                if(demora.TotalMilliseconds <= 0)// Para evitar que se pasen valores negativos al temporizador
                {
                    await CalendarioTrabajo(cancellationToken);
                }
                _Temporizador = new System.Timers.Timer(demora.TotalMilliseconds);
                _Temporizador.Elapsed += async (sender, args) =>
                {
                    _Temporizador.Dispose();//Reinicie el temporizador
                    _Temporizador = null;
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await HacerTrabajo(cancellationToken);
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await CalendarioTrabajo(cancellationToken); //Reprogramar siguiente
                    }
                };
                _Temporizador.Start();
            }
            await Task.CompletedTask;
        }

        public virtual async Task HacerTrabajo(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);// Hacer el trabajo
        }
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _Temporizador?.Stop();
            await Task.CompletedTask;
        }

        public virtual void Dispose()
        {
            _Temporizador?.Dispose();
        }
    }
}
