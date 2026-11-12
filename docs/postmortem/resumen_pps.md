# Resumen del plan del proyecto (PPS) · Programa 1

| Dato | Valor |
|---|---|
| Estudiante | Cristinne Jhoanna Roa Gaona |
| Programa | 1 · Media y desviación estándar |
| Nivel PSP | PSP0 |
| Lenguaje | C# (.NET 9) |
| Fecha | 2026-11-12 |

Fuentes: tiempos del PSP Tracker, Defect Log de Compilación y Defect Log de `docs/pruebas/informe_pruebas.md`.
Como este es el primer programa, **A la fecha = Real** y el porcentaje a la fecha se calcula sobre el total real.

## 1. Tiempo por fase (minutos)

| Fase | Plan | Real | A la fecha | % a la fecha |
|---|---|---|---|---|
| Planeación | 60 | 47 | 47 | 25.3 % |
| Diseño | 90 | 24 | 24 | 12.9 % |
| Código | 155 | 57 | 57 | 30.6 % |
| Compilación | 25 | 11 | 11 | 5.9 % |
| Pruebas | 120 | 37 | 37 | 19.9 % |
| Postmortem | 40 | 10 | 10 | 5.4 % |
| Contingencia (15 %) | 75 | n/a | n/a | n/a |
| **Total** | **565** | **186** | **186** | **100 %** |

* El reparto por fase del plan es una guía personal; en PSP0 el plan pide únicamente el total. Si registraste otro total en PSP Tracker, cambia la columna Plan.
* La contingencia solo existe en el plan; la comparación final es el total planeado contra el total real.
* % a la fecha = Real de la fase ÷ Total real × 100.
* **Error de estimación** = (Total real − Total plan) ÷ Total plan × 100 = (186 − 565) ÷ 565 × 100 = **-67.1 %**
  *(Nota: En PSP Tracker se colocaron 60 h al crear el proyecto, mostrando -95 % de error en su panel. Comparado contra el plan formal de 565 min / ~9.4 h, el error de estimación real es de -67.1 %, o -62.0 % si se compara contra el subtotal de 490 min sin contingencia).*

## 2. Defectos inyectados

| Fase donde se inyectó | Real | A la fecha | % a la fecha |
|---|---|---|---|
| Planeación | 0 | 0 | 0 % |
| Diseño | 0 | 0 | 0 % |
| Código | 0 | 0 | 0 % |
| Compilación | 0 | 0 | 0 % |
| Pruebas | 0 | 0 | 0 % |
| **Total** | **0** | **0** | **100 %** |

## 3. Defectos eliminados

| Fase donde se eliminó | Real | A la fecha | % a la fecha |
|---|---|---|---|
| Compilación | 0 | 0 | 0 % |
| Pruebas | 0 | 0 | 0 % |
| Postmortem | 0 | 0 | 0 % |
| **Total** | **0** | **0** | **100 %** |

**Verificación:** el total de defectos inyectados debe ser igual al total de defectos eliminados. Ambos totales coinciden en 0 (0 inyectados = 0 eliminados), cumpliendo la regla de consistencia de PSP0.

## 4. Resumen de la fase de pruebas

| Dato | Valor |
|---|---|
| Casos diseñados | 17 |
| Pruebas automatizadas | 25 (25 superadas) |
| Ejecuciones manuales | 8 (todas correctas) |
| Defectos encontrados en pruebas | 0 |
| Evidencias | `docs/pruebas/evidencias/` |

## 5. Observaciones

- **Comparación con el plan:** Ninguna fase superó el tiempo estimado. Todas las fases requirieron considerablemente menos tiempo del proyectado (186 minutos reales vs. 565 minutos planeados). Esto ocurrió debido a que la estimación inicial fue deliberadamente conservadora al ser la primera experiencia con PSP0, la codificación de una lista enlazada propia y la configuración de xUnit.
- **Distribución del tiempo:** La fase con mayor consumo de tiempo fue **Código** (57 min, representando el 30.6 % del total real), seguida por **Planeación** (47 min, 25.3 %) y **Pruebas** (37 min, 19.9 %). Una fase de diseño sólida y estructurada (24 min) permitió avanzar en código y pruebas con agilidad y sin introducir defectos.
- **Interrupciones en PSP Tracker:** Según las métricas del dashboard de PSP Tracker, las interrupciones representaron el 45 % del tiempo bruto registrado. Este dato es prioritario para el plan de mejora del Programa 2 (organizar bloques de tiempo ininterrumpidos).
- **Evidencias Postmortem:** Se guardaron las capturas del PSP Tracker en la carpeta `docs/postmortem/evidencias/` (`psp_tracker_dashboard.jpg` y `psp_tracker_analisis.jpg`).
