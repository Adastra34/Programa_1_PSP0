using Programa1.Estadistica.Dominio;
using Xunit;

namespace Programa1.Pruebas;

public class ListaEnlazadaTests
{
    [Fact] // CP-13
    public void Agregar_TresValores_ConservaOrdenYCantidad()
    {
        var lista = new ListaEnlazada();

        lista.Agregar(3);
        lista.Agregar(1);
        lista.Agregar(2);

        Assert.Equal(3, lista.Cantidad);
        Assert.Equal(new[] { 3.0, 1.0, 2.0 }, lista.ToArray());
    }

    [Fact] // CP-13
    public void ListaNueva_EstaVacia()
    {
        var lista = new ListaEnlazada();

        Assert.Equal(0, lista.Cantidad);
        Assert.Empty(lista);
    }
}
