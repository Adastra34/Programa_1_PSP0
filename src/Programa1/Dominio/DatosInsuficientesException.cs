namespace Programa1.Estadistica.Dominio;

/// <summary>Se lanza cuando se intenta calcular con una lista vacía.</summary>
public class DatosInsuficientesException : Exception
{
    public DatosInsuficientesException(string mensaje) : base(mensaje)
    {
    }
}
