﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.DTOs 
{
    public class GastosBase
    {
        
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        public int? Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
