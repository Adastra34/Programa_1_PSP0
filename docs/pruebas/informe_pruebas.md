# Informe de pruebas · Programa 1 (media y desviación estándar)

Casos: `casos_prueba.md` · Evidencias: carpeta `evidencias/` (una por ejecución, con el nombre `ejecucionN_AAAA-MM-DD_HHmm.txt`).

## 1. Resumen

| Dato | Valor |
|---|---|
| Fecha de las pruebas | 2026-11-12 |
| Versión de .NET | .NET 9 (`net9.0`), xUnit con VSTest 17.14.1 |
| Sistema operativo | Windows |
| Casos diseñados | 17 |
| Pruebas automatizadas ejecutadas | 25 (25 superadas, 0 con error, 0 omitidas) |
| Ejecuciones manuales | 8 (todas con el resultado esperado) |
| Casos que pasaron al final | 17 de 17 |
| Defectos encontrados en pruebas | 0 |
| Tiempo de la fase (min) | *(escribe aquí el tiempo final de PSP Tracker)* |

## 2. Ejecuciones

| N.º | Archivo de evidencia | Qué se ejecutó | Aprobados | Fallidos | Observación |
|---|---|---|---|---|---|
| 1 | `ejecucion1_2026-11-12_0027.txt` | `dotnet test test` (pruebas automatizadas) | 25 | 0 | Duración total de la serie: 345 ms. Las tildes salen dañadas en el archivo por la codificación de la consola; no afecta al programa. |
| 2 | `ejecucion2_2026-11-12_HHmm.txt` | Pruebas manuales M-1 a M-8 con `dotnet run` | 8 | 0 | Todas las salidas y códigos de salida coinciden con lo esperado. En la ejecución sin argumento, la ruta llega por la tubería y no se muestra el salto de línea después de `Ruta del archivo:`. |

Cambia `HHmm` por la hora real del nombre de tu archivo de evidencia.

## 3. Resultados por caso

| Id | Resultado esperado | Resultado obtenido | Estado | Ejecución |
|---|---|---|---|---|
| CP-01 | n = 10; media 550.60; desviación 572.03 | n = 10; media 550.60; desviación 572.03 | Pasó | 1, 2 (M-1) |
| CP-02 | n = 10; media 60.32; desviación 62.26 | n = 10; media 60.32; desviación 62.26 | Pasó | 1, 2 (M-2) |
| CP-03 | Media 0.00; desviación 2.83 | Prueba automatizada superada | Pasó | 1 |
| CP-04 | Media 5.00; desviación 0.00 | Prueba automatizada superada | Pasó | 1 |
| CP-05 | Media 7.00; aviso; desviación n/d; código 0 | `AVISO:` mostrado; media 7.00; desviación n/d; código 0 | Pasó | 1, 2 (M-4) |
| CP-06 | Lista con 3 y 4; n = 2 | n = 2; media 3.50; desviación 0.71; código 0 | Pasó | 1, 2 (M-5) |
| CP-07 | `ERROR:` archivo no encontrado; código 1 | `ERROR: no se encontró el archivo "datos/no_existe.txt". Revisa la ruta.`; código 1 | Pasó | 1, 2 (M-8) |
| CP-08 | `ERROR:` archivo sin datos; código 1 | `ERROR: el archivo no contiene datos. Agrega un número por línea.`; código 1 | Pasó | 1, 2 (M-6) |
| CP-09 | `ERROR:` línea 2 con `abc`; código 1 | `ERROR: la línea 2 no es un número válido ("abc"). Corrígela.`; código 1 | Pasó | 1, 2 (M-7) |
| CP-10 | «15.0» se lee como 15.0 con es-CO | Prueba automatizada superada | Pasó | 1 |
| CP-11 | Procesa sin pedir la ruta; código 0 | No pidió la ruta; código 0 | Pasó | 1, 2 (M-1) |
| CP-12 | Pide la ruta y procesa; código 0 | Mostró `Ruta del archivo:` y procesó `col1`; código 0 | Pasó | 1, 2 (M-3) |
| CP-13 | Orden 3, 1, 2; `Cantidad` = 3 | Prueba automatizada superada | Pasó | 1 |
| CP-14 | Etiquetas a 16 caracteres; 2 decimales con punto | Etiquetas alineadas; valores con 2 decimales y punto | Pasó | 1, 2 |
| CP-15 | 100 000 datos en menos de 1 000 ms | Prueba superada; las 25 pruebas juntas duraron 345 ms | Pasó | 1 |
| CP-16 | `DatosInsuficientesException` | Prueba automatizada superada | Pasó | 1 |
| CP-17 | `DatosInvalidosException` para `NaN`, `Infinity`, `1,5`, `abc` | Las 4 pruebas superadas | Pasó | 1 |

## 4. Defect Log (fase Pruebas)

| Fecha | N.º | Tipo | Fase de inyección | Fase de eliminación | Tiempo de corrección (min) | Fix Ref | Caso | Descripción |
|---|---|---|---|---|---|---|---|---|
| | | | | Pruebas | | | | Sin defectos en esta fase |

Total de defectos de la fase: **0**.

## 5. Conclusiones

| Pregunta | Respuesta |
|---|---|
| ¿Se cumplieron todos los criterios de aceptación de los REQ-F y REQ-NF? | Sí: los 17 casos pasaron y cubren los requisitos de la matriz de trazabilidad del diseño. |
| ¿Qué fase inyectó más defectos? | En esta fase no se encontraron defectos. *(Completa con los datos de tu Defect Log de Compilación.)* |
| ¿Qué harías distinto en el Programa 2? | *(Borrador, edítalo con tus palabras)* Comparar el tiempo real de cada fase contra el planeado para ajustar la estimación, y diseñar los casos de prueba antes de escribir el código. |
