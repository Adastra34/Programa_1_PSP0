using Programa1.Estadistica.Dominio;
using Programa1.Estadistica.Infraestructura;
using Programa1.Estadistica.Presentacion;

namespace Programa1.Estadistica;

/// <summary>
/// Orquesta el flujo: ruta, lectura, cálculo y salida. Traduce las excepciones a código de salida.
/// </summary>
public static class Aplicacion
{
    private const int CodigoExito = 0;
    private const int CodigoError = 1;

    /// <summary>Ejecuta el programa y devuelve 0 si todo salió bien o 1 si hubo un error.</summary>
    public static int Ejecutar(string[] args, TextReader entrada, TextWriter salida)
    {
        var ui = new ConsolaUI(entrada, salida);

        try
        {
            string ruta = args.Length > 0 ? args[0] : ui.PedirRuta();
            ListaEnlazada lista = new LectorArchivoNumeros().Leer(ruta);
            ResultadoEstadistico resultado = new CalculadoraEstadistica().Calcular(lista);

            if (resultado.Desviacion is null)
            {
                ui.MostrarAviso("se necesitan al menos 2 datos para la desviación estándar.");
            }

            ui.MostrarResultado(resultado, ruta);
            return CodigoExito;
        }
        catch (Exception e) when (e is DatosInvalidosException or DatosInsuficientesException)
        {
            ui.MostrarError(e.Message);
            return CodigoError;
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            ui.MostrarError("no se pudo leer el archivo. Revisa los permisos y la ruta.");
            return CodigoError;
        }
    }
}
