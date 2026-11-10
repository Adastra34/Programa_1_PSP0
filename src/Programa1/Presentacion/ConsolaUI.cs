using System.Globalization;
using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Presentacion;

/// <summary>Interfaz de consola: pide la ruta y muestra resultados, avisos y errores.</summary>
public class ConsolaUI
{
    private const int AnchoRotulo = 16;
    private const int AnchoSeparador = 34;

    private readonly TextReader _entrada;
    private readonly TextWriter _salida;

    public ConsolaUI(TextReader entrada, TextWriter salida)
    {
        _entrada = entrada;
        _salida = salida;
    }

    /// <summary>Pide la ruta del archivo; devuelve cadena vacía si no se escribe nada.</summary>
    public string PedirRuta()
    {
        _salida.Write("Ruta del archivo: ");
        string? texto = _entrada.ReadLine();
        return texto?.Trim() ?? string.Empty;
    }

    /// <summary>Muestra n, la media y la desviación con dos decimales y punto decimal.</summary>
    public void MostrarResultado(ResultadoEstadistico resultado, string ruta)
    {
        string desviacion = resultado.Desviacion is double valor ? Formato2(valor) : "n/d";

        _salida.WriteLine("=== Estadística básica · PSP0 ===");
        _salida.WriteLine(Linea("Archivo", ruta));
        _salida.WriteLine(new string('-', AnchoSeparador));
        _salida.WriteLine(Linea("n", resultado.N.ToString(CultureInfo.InvariantCulture)));
        _salida.WriteLine(Linea("Media", Formato2(resultado.Media)));
        _salida.WriteLine(Linea("Desv. estándar", desviacion));
    }

    public void MostrarAviso(string mensaje)
    {
        _salida.WriteLine($"AVISO: {mensaje}");
    }

    public void MostrarError(string mensaje)
    {
        _salida.WriteLine($"ERROR: {mensaje}");
    }

    private static string Linea(string etiqueta, string valor)
    {
        return $"{etiqueta.PadRight(AnchoRotulo)}: {valor}";
    }

    private static string Formato2(double valor)
    {
        return valor.ToString("F2", CultureInfo.InvariantCulture);
    }
}
