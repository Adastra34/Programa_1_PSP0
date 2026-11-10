namespace Programa1.Estadistica.Dominio;

/// <summary>Resultado del cálculo. La desviación es null cuando hay menos de 2 datos.</summary>
public record ResultadoEstadistico(int N, double Media, double? Desviacion);
