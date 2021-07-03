using System;

namespace ManejoExtintores.Infraestructura.Reporte
{
    public interface IProgramacion<T>
    {
        string CronExpresion { get; set; }
        TimeZoneInfo ZonaHoraria { get; set; } 
    }
}
