namespace Programa1.Estadistica.Dominio;

/// <summary>Calcula la media aritmética y la desviación estándar muestral (divide entre n − 1).</summary>
public class CalculadoraEstadistica
{
    public ResultadoEstadistico Calcular(ListaEnlazada lista)
    {
        if (lista.Cantidad == 0)
        {
            throw new DatosInsuficientesException("no hay datos para calcular.");
        }

        double media = Media(lista);
        double? desviacion = lista.Cantidad < 2 ? null : DesviacionEstandar(lista, media);

        return new ResultadoEstadistico(lista.Cantidad, media, desviacion);
    }

    private static double Media(ListaEnlazada lista)
    {
        double suma = 0;

        foreach (double x in lista)
        {
            suma += x;
        }

        return suma / lista.Cantidad;
    }

    private static double DesviacionEstandar(ListaEnlazada lista, double media)
    {
        double sumaCuadrados = 0;

        foreach (double x in lista)
        {
            double diferencia = x - media;
            sumaCuadrados += diferencia * diferencia;
        }

        return Math.Sqrt(sumaCuadrados / (lista.Cantidad - 1));
    }
}
