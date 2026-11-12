namespace Programa1.Pruebas;

/// <summary>Crea archivos temporales para las pruebas y los borra al terminar.</summary>
public sealed class ArchivosTemporales : IDisposable
{
    private readonly List<string> _rutas = new();

    public string Crear(string contenido)
    {
        string ruta = Path.Combine(Path.GetTempPath(), $"psp0_{Guid.NewGuid()}.txt");
        File.WriteAllText(ruta, contenido);
        _rutas.Add(ruta);
        return ruta;
    }

    public void Dispose()
    {
        foreach (string ruta in _rutas)
        {
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
        }
    }
}
