using Programa1.Estadistica;
using Xunit;

namespace Programa1.Pruebas;

public class AplicacionTests : IDisposable
{
    private readonly ArchivosTemporales _archivos = new();

    public void Dispose()
    {
        _archivos.Dispose();
    }

    private static (int Codigo, string Salida) Ejecutar(string[] args, string entrada = "")
    {
        using var lector = new StringReader(entrada);
        using var escritor = new StringWriter();

        int codigo = Aplicacion.Ejecutar(args, lector, escritor);

        return (codigo, escritor.ToString());
    }

    [Fact] // CP-11
    public void Ejecutar_ConRutaComoArgumento_NoPideLaRuta()
    {
        string ruta = _archivos.Crear(DatosPrueba.ComoTexto(DatosPrueba.Columna1));

        var (codigo, salida) = Ejecutar(new[] { ruta });

        Assert.Equal(0, codigo);
        Assert.DoesNotContain("Ruta del archivo:", salida);
    }

    [Fact] // CP-12
    public void Ejecutar_SinArgumento_PideLaRutaPorConsola()
    {
        string ruta = _archivos.Crear(DatosPrueba.ComoTexto(DatosPrueba.Columna1));

        var (codigo, salida) = Ejecutar(Array.Empty<string>(), ruta + Environment.NewLine);

        Assert.Equal(0, codigo);
        Assert.Contains("Ruta del archivo:", salida);
        Assert.Contains("Media           : 550.60", salida);
    }

    [Fact] // CP-14
    public void Ejecutar_Columna1_MuestraDosDecimalesConPunto()
    {
        string ruta = _archivos.Crear(DatosPrueba.ComoTexto(DatosPrueba.Columna1));

        var (_, salida) = Ejecutar(new[] { ruta });

        Assert.Contains("n               : 10", salida);
        Assert.Contains("Media           : 550.60", salida);
        Assert.Contains("Desv. estándar  : 572.03", salida);
    }

    [Fact] // CP-05
    public void Ejecutar_UnSoloDato_MuestraAvisoYDesviacionNoDisponible()
    {
        string ruta = _archivos.Crear("7\n");

        var (codigo, salida) = Ejecutar(new[] { ruta });

        Assert.Equal(0, codigo);
        Assert.Contains("AVISO:", salida);
        Assert.Contains("Desv. estándar  : n/d", salida);
    }

    [Fact] // CP-07
    public void Ejecutar_ArchivoInexistente_DevuelveCodigo1ConMensaje()
    {
        string ruta = Path.Combine(Path.GetTempPath(), $"no_existe_{Guid.NewGuid()}.txt");

        var (codigo, salida) = Ejecutar(new[] { ruta });

        Assert.Equal(1, codigo);
        Assert.StartsWith("ERROR:", salida);
        Assert.Contains("no se encontró el archivo", salida);
    }

    [Fact] // CP-08
    public void Ejecutar_ArchivoVacio_DevuelveCodigo1ConMensaje()
    {
        string ruta = _archivos.Crear(string.Empty);

        var (codigo, salida) = Ejecutar(new[] { ruta });

        Assert.Equal(1, codigo);
        Assert.StartsWith("ERROR:", salida);
        Assert.Contains("no contiene datos", salida);
    }

    [Fact] // CP-09
    public void Ejecutar_LineaNoNumerica_DevuelveCodigo1IndicandoLaLinea()
    {
        string ruta = _archivos.Crear("3\nabc\n4\n");

        var (codigo, salida) = Ejecutar(new[] { ruta });

        Assert.Equal(1, codigo);
        Assert.StartsWith("ERROR:", salida);
        Assert.Contains("línea 2", salida);
    }
}
