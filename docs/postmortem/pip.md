# Propuesta de mejora del proceso (PIP) · Programa 1

| Dato | Valor |
|---|---|
| Estudiante | Cristinne Jhoanna Roa Gaona |
| Programa | 1 · Media y desviación estándar (PSP0) |
| Fecha | 2026-11-12 |

## 1. Problema → propuesta

| N.º | Fase | Problema | Causa probable | Propuesta | Cómo sabré que funcionó |
|---|---|---|---|---|---|
| 1 | Planeación | La estimación de tiempo se hizo solo por juicio, sin datos propios, resultando en una sobrestimación (-67.1 %). | Es el primer programa con PSP y se estimó de manera muy conservadora. | Usar los tiempos reales de este programa como base histórica y ajustar las horas estimadas a la baja para tareas similares. | El error de estimación del Programa 2 es menor en magnitud que el del Programa 1 (más cercano a 0 %). |
| 2 | Diseño | Hubo inconsistencias entre el diseño, los diagramas y el pseudocódigo (la firma de `MostrarResultado` y el encabezado de la salida con un solo dato). | No se revisó la coherencia entre documentos antes de pasar a código. | Hacer una revisión corta de consistencia entre requisitos, diseño y pseudocódigo antes de iniciar la fase de código. | Ningún defecto de diseño aparece en código o pruebas. |
| 3 | Pruebas | Las tildes salieron dañadas en la evidencia de `ejecucion1`. | No se configuró UTF-8 en la terminal antes de guardar la salida. | Ejecutar `[Console]::OutputEncoding = [System.Text.Encoding]::UTF8` antes de generar evidencias. | Todas las evidencias se leen sin caracteres dañados. |
| 4 | Postmortem | No se mide el tamaño del programa, así que no se puede calcular productividad ni defectos por KLOC. | PSP0 no incluye medición de tamaño formal (se introduce en PSP0.1). | Contar las líneas de código al cerrar la fase de código y registrarlas en el resumen (en este proyecto fueron 300 LOC en `src` y 381 en `test`). | El PPS del Programa 2 incluye LOC reales y métricas de productividad/defectos por KLOC. |
| 5 | General / Todas | Alto porcentaje de interrupciones (45 % del tiempo bruto registrado en PSP Tracker) y discrepancia de unidades en el plan del Tracker (60 h vs 565 min). | Falta de bloques de trabajo continuo protegidos y un error tipográfico al ingresar las horas estimadas en la herramienta al crear el proyecto. | Aplicar sesiones de enfoque continuo (técnica Pomodoro de 25-30 min sin distracciones) y verificar minuciosamente las unidades al configurar el proyecto en PSP Tracker. | En el PSP Tracker del Programa 2 las interrupciones se reducen a menos del 20 % y el plan en el Tracker coincide exactamente con la estimación. |

## 2. Lecciones aprendidas

| Qué funcionó | Qué mejorar |
|---|---|
| Separar el programa en capas permitió probar el dominio y la aplicación sin archivos reales ni consola: 25 pruebas automatizadas, 0 defectos. | Ajustar las estimaciones a la baja usando los datos reales de este proyecto (se sobrestimó un 67.1 %). |
| Diseñar los casos de prueba a partir de los requisitos dejó cada requisito con al menos un caso garantizando 100 % de cobertura de requerimientos. | Disminuir las interrupciones externas (fueron el 45 % del tiempo bruto) mediante bloques de concentración dedicados. |
| La codificación y compilación fueron rápidas y limpias gracias a un pseudocódigo y diseño detallados previos. | Mantener alineadas las unidades entre la documentación y la herramienta de seguimiento (PSP Tracker). |
