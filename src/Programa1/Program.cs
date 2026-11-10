using System.Text;
using Programa1.Estadistica;

// Punto de entrada: la consola real se inyecta en Aplicacion para poder probarla con StringReader/StringWriter.
Console.OutputEncoding = Encoding.UTF8;
return Aplicacion.Ejecutar(args, Console.In, Console.Out);
