namespace Programa1.Estadistica.Dominio;

/// <summary>Nodo de la lista enlazada: guarda un valor y apunta al siguiente nodo.</summary>
public class Nodo
{
    public Nodo(double valor)
    {
        Valor = valor;
    }

    public double Valor { get; }

    public Nodo? Siguiente { get; set; }
}
