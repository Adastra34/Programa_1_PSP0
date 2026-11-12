using Programa1.Estadistica.Dominio;
using Xunit;

namespace Programa1.Pruebas;

public class CalculadoraEstadisticaTests
{
    private readonly CalculadoraEstadistica _calculadora = new();

    private static ListaEnlazada CrearLista(params double[] valores)
    {
        var lista = new ListaEnlazada();

        foreach (double valor in valores)
        {
            lista.Agregar(valor);
        }

        return lista;
    }

    [Fact] // CP-01
    public void Calcular_Columna1_DaMediaYDesviacionDeLaTabla()
    {
        ResultadoEstadistico r = _calculadora.Calcular(CrearLista(DatosPrueba.Columna1));

        Assert.Equal(10, r.N);
        Assert.Equal(550.60, r.Media, 2);
        Assert.Equal(572.03, r.Desviacion!.Value, 2);
    }

    [Fact] // CP-02
    public void Calcular_Columna2_DaMediaYDesviacionDeLaTabla()
    {
        ResultadoEstadistico r = _calculadora.Calcular(CrearLista(DatosPrueba.Columna2));

        Assert.Equal(10, r.N);
        Assert.Equal(60.32, r.Media, 2);
        Assert.Equal(62.26, r.Desviacion!.Value, 2);
    }

    [Fact] // CP-03
    public void Calcular_ConNegativos_DaMediaCeroYDesviacionDosPuntoOchentaYTres()
    {
        ResultadoEstadistico r = _calculadora.Calcular(CrearLista(-2, 2));

        Assert.Equal(0.00, r.Media, 2);
        Assert.Equal(2.83, r.Desviacion!.Value, 2);
    }

    [Fact] // CP-04
    public void Calcular_ValoresIguales_DesviacionEsCero()
    {
        ResultadoEstadistico r = _calculadora.Calcular(CrearLista(5, 5, 5));

        Assert.Equal(5.00, r.Media, 2);
        Assert.Equal(0.00, r.Desviacion!.Value, 2);
    }

    [Fact] // CP-05
    public void Calcular_UnSoloDato_DesviacionNoDisponible()
    {
        ResultadoEstadistico r = _calculadora.Calcular(CrearLista(7));

        Assert.Equal(1, r.N);
        Assert.Equal(7.00, r.Media, 2);
        Assert.Null(r.Desviacion);
    }

    [Fact] // CP-16
    public void Calcular_ListaVacia_LanzaDatosInsuficientes()
    {
        Assert.Throws<DatosInsuficientesException>(() => _calculadora.Calcular(new ListaEnlazada()));
    }
}
