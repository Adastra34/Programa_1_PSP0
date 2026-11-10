# Estimación de tiempo (PSP0 · mejor estimación)

Método: descomponer el trabajo en tareas y estimar cada una por juicio, sin datos históricos propios.
Los tiempos son mayores que los de un desarrollador con experiencia porque es la primera vez que se usa
PSP, se implementa una lista enlazada propia y se configura xUnit. Se agrega 15 % de contingencia
por la curva de aprendizaje y el llenado de los registros de tiempo y defectos.

| Fase PSP | Tarea | Minutos |
|---|---|---|
| Planificación | Leer el kit, resolver preguntas, RF/RNF, estimar | 60 |
| Diseño | Pseudocódigo, UML de clases, interfaz de consola | 90 |
| Código | Lista enlazada + nodo | 45 |
| Código | Calculadora (media y desviación) | 30 |
| Código | Lector de archivo con validaciones | 45 |
| Código | Interfaz de consola y programa principal | 35 |
| Compilación | Compilar hasta 0 errores y 0 advertencias | 25 |
| Pruebas | Configurar xUnit, casos de prueba y corregir defectos | 120 |
| Postmortem | Resumen del plan, revisión de registros, PIP | 40 |
| | **Subtotal** | **490** |
| | Contingencia 15 % | 75 |
| | **Tiempo total planeado** | **565** |

Este total (565 min ≈ 9 h 25 min) se escribe como **tiempo planeado** al crear el proyecto en PSP Tracker,
antes de iniciar el cronómetro de cualquier otra fase. El reparto por fase es sólo una guía personal:
en PSP0 el resumen del plan pide únicamente el total.
