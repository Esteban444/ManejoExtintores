using System;

namespace ManejoExtintores.Core.Excepciones 
{
    public class Excepcion_Servidor: Exception
    {
        public Excepcion_Servidor()
        {

        }

        public Excepcion_Servidor(string message): base(message)
        {

        }
    }
}
