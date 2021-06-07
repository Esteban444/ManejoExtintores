
namespace ManejoExtintores.Api.Respuestas 
{
    public class Respuesta<T>
    {
        public Respuesta(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
