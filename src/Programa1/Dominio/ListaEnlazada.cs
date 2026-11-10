using System.Collections;

namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Lista enlazada propia de números reales. Conserva el puntero al último nodo para que agregar sea O(1).
/// </summary>
public class ListaEnlazada : IEnumerable<double>
{
    private Nodo? _primero;
    private Nodo? _ultimo;

    public int Cantidad { get; private set; }

    public void Agregar(double valor)
    {
        var nuevo = new Nodo(valor);

        if (_primero is null)
        {
            _primero = nuevo;
        }
        else
        {
            _ultimo!.Siguiente = nuevo;
        }

        _ultimo = nuevo;
        Cantidad++;
    }

    public IEnumerator<double> GetEnumerator()
    {
        Nodo? actual = _primero;

        while (actual is not null)
        {
            yield return actual.Valor;
            actual = actual.Siguiente;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
