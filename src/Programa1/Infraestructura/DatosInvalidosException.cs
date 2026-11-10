namespace Programa1.Estadistica.Infraestructura;

/// <summary>Se lanza cuando el archivo no existe, está vacío o tiene una línea que no es un número.</summary>
public class DatosInvalidosException : Exception
{
    public DatosInvalidosException(string mensaje) : base(mensaje)
    {
    }
}
