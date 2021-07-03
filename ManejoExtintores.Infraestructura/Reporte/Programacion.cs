using System;

namespace ManejoExtintores.Infraestructura.Reporte
{
    public class Programacion<T> : IProgramacion<T>
    {
        public string CronExpresion { get; set; }
        public TimeZoneInfo ZonaHoraria { get; set; } 
    }
}
