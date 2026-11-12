using System.Globalization;

namespace Programa1.Pruebas;

/// <summary>Datos de la Tabla 1 del kit y utilidades para armar el contenido de archivos de prueba.</summary>
public static class DatosPrueba
{
    public static readonly double[] Columna1 = { 160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503 };

    public static readonly double[] Columna2 = { 15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2 };

    /// <summary>Convierte los valores a texto, uno por línea y con punto decimal.</summary>
    public static string ComoTexto(IEnumerable<double> valores)
    {
        return string.Join("\n", valores.Select(v => v.ToString(CultureInfo.InvariantCulture)));
    }
}
