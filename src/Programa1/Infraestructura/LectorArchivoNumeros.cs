using System.Globalization;
using System.Text;
using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Infraestructura;

/// <summary>Lee un archivo de texto (un número por línea) y lo guarda en una lista enlazada.</summary>
public class LectorArchivoNumeros
{
    private const char MarcaComentario = '#';

    /// <summary>Lee todos los datos válidos del archivo; lanza DatosInvalidosException si hay un problema.</summary>
    public ListaEnlazada Leer(string ruta)
    {
        if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
        {
            throw new DatosInvalidosException($"no se encontró el archivo \"{ruta}\". Revisa la ruta.");
        }

        var lista = new ListaEnlazada();
        int numeroLinea = 0;

        foreach (string linea in LeerLineas(ruta))
        {
            numeroLinea++;
            string texto = linea.Trim();

            if (texto.Length == 0 || texto[0] == MarcaComentario)
            {
                continue;
            }

            lista.Agregar(Convertir(texto, numeroLinea));
        }

        if (lista.Cantidad == 0)
        {
            throw new DatosInvalidosException("el archivo no contiene datos. Agrega un número por línea.");
        }

        return lista;
    }

    private static IEnumerable<string> LeerLineas(string ruta)
    {
        return File.ReadLines(ruta, Encoding.UTF8);
    }

    // Cultura invariante: el punto es siempre el separador decimal, sin importar la configuración regional.
    private static double Convertir(string texto, int numeroLinea)
    {
        bool esNumero = double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor);

        if (!esNumero || !double.IsFinite(valor))
        {
            throw new DatosInvalidosException(
                $"la línea {numeroLinea} no es un número válido (\"{texto}\"). Corrígela.");
        }

        return valor;
    }
}
