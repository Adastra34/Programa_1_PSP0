using System.Diagnostics;
using Programa1.Estadistica.Dominio;
using Programa1.Estadistica.Infraestructura;
using Xunit;

namespace Programa1.Pruebas;

public class RendimientoTests : IDisposable
{
    private const int CantidadDatos = 100_000;
    private const long LimiteMilisegundos = 1000;

    private readonly ArchivosTemporales _archivos = new();

    public void Dispose()
    {
        _archivos.Dispose();
    }

    [Fact] // CP-15
    public void LeerYCalcular_CienMilDatos_TardaMenosDeUnSegundo()
    {
        var aleatorio = new Random(42);
        IEnumerable<double> valores = Enumerable.Range(0, CantidadDatos).Select(_ => aleatorio.NextDouble() * 1000);
        string ruta = _archivos.Crear(DatosPrueba.ComoTexto(valores));

        var cronometro = Stopwatch.StartNew();
        ListaEnlazada lista = new LectorArchivoNumeros().Leer(ruta);
        ResultadoEstadistico resultado = new CalculadoraEstadistica().Calcular(lista);
        cronometro.Stop();

        Assert.Equal(CantidadDatos, resultado.N);
        Assert.True(cronometro.ElapsedMilliseconds < LimiteMilisegundos,
            $"Tardó {cronometro.ElapsedMilliseconds} ms");
    }
}
