# Casos de prueba · Programa 1 (media y desviación estándar)

Fase PSP: Pruebas. Entradas: `requisitos_programa1_estadistica.md` (REQ-F y REQ-NF) y `diseno_programa1.md` (CP-01 a CP-15 de la trazabilidad).
Los casos CP-16 y CP-17 se agregaron al diseñar las pruebas para cubrir validaciones del código que el diseño no probaba.

## 1. Casos

| Id | Requisito | Caso | Entrada | Resultado esperado | Prueba automatizada |
|---|---|---|---|---|---|
| CP-01 | REQ-F-03, 07, 08, REQ-NF-03 | Columna 1 de la Tabla 1 | 160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503 | n = 10; media 550.60; desviación 572.03 | `CalculadoraEstadisticaTests` |
| CP-02 | REQ-F-03, 07, 08, REQ-NF-03 | Columna 2 de la Tabla 1 | 15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2 | n = 10; media 60.32; desviación 62.26 | `CalculadoraEstadisticaTests` |
| CP-03 | REQ-F-07, 08 | Números negativos | -2, 2 | Media 0.00; desviación 2.83 | `CalculadoraEstadisticaTests` |
| CP-04 | REQ-F-09 | Valores iguales | 5, 5, 5 | Media 5.00; desviación 0.00 | `CalculadoraEstadisticaTests` |
| CP-05 | REQ-F-15 | Un solo dato | 7 | Media 7.00; `AVISO:`; `Desv. estándar : n/d`; código 0 | `CalculadoraEstadisticaTests`, `AplicacionTests` |
| CP-06 | REQ-F-04 | Líneas en blanco y comentarios | `# nota`, línea en blanco, `3`, línea en blanco, `  4  `, `# fin` | Lista con 3 y 4; n = 2 | `LectorArchivoNumerosTests` |
| CP-07 | REQ-F-12, REQ-NF-04 | Archivo inexistente | Ruta que no existe | `ERROR: no se encontró el archivo ...`; código 1 | `LectorArchivoNumerosTests`, `AplicacionTests` |
| CP-08 | REQ-F-13, REQ-NF-04 | Archivo vacío | Archivo sin contenido | `ERROR: el archivo no contiene datos ...`; código 1 | `LectorArchivoNumerosTests`, `AplicacionTests` |
| CP-09 | REQ-F-14, REQ-NF-04 | Línea no numérica | `3`, `abc`, `4` | `ERROR:` que indica la línea 2 y el texto `abc`; código 1 | `LectorArchivoNumerosTests`, `AplicacionTests` |
| CP-10 | REQ-NF-02 | Cultura regional es-CO | `15.0` | Se lee como 15.0 (no 150) | `LectorArchivoNumerosTests` |
| CP-11 | REQ-F-01 | Ruta como argumento | `dotnet run -- datos/col1.txt` | Procesa sin pedir la ruta; código 0 | `AplicacionTests` |
| CP-12 | REQ-F-02 | Ruta por consola | Sin argumento; se escribe la ruta | Muestra `Ruta del archivo:` y procesa; código 0 | `AplicacionTests` |
| CP-13 | REQ-F-05, 06 | Orden y cantidad de la lista | Agregar 3, 1, 2 | Recorrido 3, 1, 2; `Cantidad` = 3 | `ListaEnlazadaTests` |
| CP-14 | REQ-F-10, 11 | Formato de salida | Columna 1 | Etiquetas a 16 caracteres; 2 decimales con punto | `AplicacionTests` |
| CP-15 | REQ-NF-05 | Rendimiento | 100 000 números | Leer y calcular en menos de 1 000 ms | `RendimientoTests` |
| CP-16 | Robustez (DD-05) | Cálculo con lista vacía | Lista sin elementos | `DatosInsuficientesException` | `CalculadoraEstadisticaTests` |
| CP-17 | REQ-F-14, REQ-NF-02 | Valores no válidos | `NaN`, `Infinity`, `1,5`, `abc` | `DatosInvalidosException` | `LectorArchivoNumerosTests` |

## 2. Archivos de datos para las pruebas manuales

Ejecuta estos comandos en PowerShell desde la carpeta del proyecto (`src\Programa1`):

```powershell
mkdir datos -Force
Set-Content datos/col1.txt "160","591","114","229","230","270","128","1657","624","1503"
Set-Content datos/col2.txt "15.0","69.9","6.5","22.4","28.4","65.9","19.4","198.7","38.8","138.2"
Set-Content datos/uno.txt "7"
Set-Content datos/comentarios.txt "# nota","","3","","  4  ","# fin"
Set-Content datos/mala.txt "3","abc","4"
New-Item datos/vacio.txt -ItemType File -Force
```

| Ejecución manual | Comando | Caso |
|---|---|---|
| M-1 | `dotnet run -- datos/col1.txt` | CP-01, CP-11, CP-14 |
| M-2 | `dotnet run -- datos/col2.txt` | CP-02 |
| M-3 | `dotnet run` y escribir `datos/col1.txt` | CP-12 |
| M-4 | `dotnet run -- datos/uno.txt` | CP-05 |
| M-5 | `dotnet run -- datos/comentarios.txt` | CP-06 (n = 2, media 3.50, desviación 0.71) |
| M-6 | `dotnet run -- datos/vacio.txt` | CP-08 |
| M-7 | `dotnet run -- datos/mala.txt` | CP-09 |
| M-8 | `dotnet run -- datos/no_existe.txt` | CP-07 |

Después de cada ejecución revisa el código de salida con `$LASTEXITCODE`.

## 3. Criterios

* Un caso **pasa** si el resultado obtenido coincide con el esperado (±0.01 en los números).
* Cada caso que falla se registra como defecto en el informe, se corrige y se vuelve a ejecutar.
* La fase termina cuando los 17 casos pasan y el informe tiene el Defect Log completo.
