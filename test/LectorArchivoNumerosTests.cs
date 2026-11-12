using System.Globalization;
using Programa1.Estadistica.Dominio;
using Programa1.Estadistica.Infraestructura;
using Xunit;

namespace Programa1.Pruebas;

public class LectorArchivoNumerosTests : IDisposable
{
    private readonly ArchivosTemporales _archivos = new();
    private readonly LectorArchivoNumeros _lector = new();

    public void Dispose()
    {
        _archivos.Dispose();
    }

    [Fact] // CP-06
    public void Leer_ConLineasEnBlancoYComentarios_IgnoraEsasLineas()
    {
        string ruta = _archivos.Crear("# nota\n\n3\n\n  4  \n# fin\n");

        ListaEnlazada lista = _lector.Leer(ruta);

        Assert.Equal(2, lista.Cantidad);
        Assert.Equal(new[] { 3.0, 4.0 }, lista.ToArray());
    }

    [Fact] // CP-07
    public void Leer_ArchivoInexistente_LanzaDatosInvalidos()
    {
        string ruta = Path.Combine(Path.GetTempPath(), $"no_existe_{Guid.NewGuid()}.txt");

        var error = Assert.Throws<DatosInvalidosException>(() => _lector.Leer(ruta));

        Assert.Contains("no se encontró el archivo", error.Message);
    }

    [Fact] // CP-08
    public void Leer_ArchivoVacio_LanzaDatosInvalidos()
    {
        string ruta = _archivos.Crear(string.Empty);

        var error = Assert.Throws<DatosInvalidosException>(() => _lector.Leer(ruta));

        Assert.Contains("no contiene datos", error.Message);
    }

    [Fact] // CP-09
    public void Leer_LineaNoNumerica_IndicaElNumeroDeLinea()
    {
        string ruta = _archivos.Crear("3\nabc\n4\n");

        var error = Assert.Throws<DatosInvalidosException>(() => _lector.Leer(ruta));

        Assert.Contains("línea 2", error.Message);
        Assert.Contains("abc", error.Message);
    }

    [Fact] // CP-10
    public void Leer_ConCulturaEsCO_LeePuntoComoSeparadorDecimal()
    {
        CultureInfo original = CultureInfo.CurrentCulture;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-CO");
            string ruta = _archivos.Crear("15.0\n");

            ListaEnlazada lista = _lector.Leer(ruta);

            Assert.Equal(15.0, lista.First());
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    [Theory] // CP-17
    [InlineData("NaN")]
    [InlineData("Infinity")]
    [InlineData("1,5")]
    [InlineData("abc")]
    public void Leer_ValorNoValido_LanzaDatosInvalidos(string texto)
    {
        string ruta = _archivos.Crear(texto + "\n");

        Assert.Throws<DatosInvalidosException>(() => _lector.Leer(ruta));
    }
}
