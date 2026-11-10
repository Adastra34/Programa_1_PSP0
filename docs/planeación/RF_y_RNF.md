# Especificación de requisitos — Programa 1 (PSP0)

**Programa:** Calculadora de media aritmética y desviación estándar
**Proceso:** PSP0 · **Lenguaje:** C# (.NET 9) · **Versión del documento:** 1.0

---

## 1. Propósito y alcance

El programa lee un conjunto de *n* números reales desde un archivo de texto, los guarda en una **lista enlazada implementada por el estudiante** y calcula dos estadísticos: la **media aritmética** y la **desviación estándar muestral**. El resultado se muestra por consola.

**Fuera de alcance:** interfaz gráfica, lectura por teclado dato a dato, otros estadísticos (mediana, moda, varianza), escritura de resultados en archivo.

## 2. Fórmulas de referencia

| Estadístico | Fórmula |
|---|---|
| Media | x̄ = (Σ xᵢ) / n |
| Desviación estándar muestral | s = √( Σ (xᵢ − x̄)² / (n − 1) ) |

## 3. Supuestos y decisiones de diseño

| Código | Decisión | Justificación |
|---|---|---|
| D-01 | Se usa la desviación **muestral** (divide entre n − 1). | Es la que reproduce los resultados esperados del kit. |
| D-02 | Los datos vienen de un **archivo de texto**, un número por línea. | La entrada por teclado es poco práctica para conjuntos grandes. |
| D-03 | El separador decimal es el **punto**, sin importar la configuración regional. | Evita errores como leer «15.0» como 150 con cultura es-CO. |
| D-04 | Se ignoran líneas en blanco y líneas que empiecen por `#`. | Permite documentar los archivos de prueba. |
| D-05 | No se usa `List<T>` ni otras colecciones de .NET para almacenar los datos. | El enunciado exige una lista enlazada propia. |
| D-06 | Se muestran **2 decimales**. | Coincide con la precisión de los resultados esperados. |

## 4. Requisitos funcionales

### 4.1 Entrada de datos

| Id | Requisito | Prioridad | Criterio de aceptación |
|---|---|---|---|
| REQ-F-01 | El sistema debe aceptar la ruta del archivo como argumento de línea de comandos. | Alta | `dotnet run -- datos/col1.txt` procesa el archivo sin pedir nada más. |
| REQ-F-02 | Si no se pasa argumento, el sistema debe solicitar la ruta por consola. | Media | Se muestra un mensaje que pide la ruta y se procesa la ingresada. |
| REQ-F-03 | El sistema debe leer cada línea del archivo como un número real. | Alta | Lee los 10 valores de cada columna de la Tabla 1. |
| REQ-F-04 | El sistema debe omitir líneas vacías y comentarios (`#`). | Media | Un archivo con líneas en blanco da el mismo resultado que sin ellas. |

### 4.2 Almacenamiento

| Id | Requisito | Prioridad | Criterio de aceptación |
|---|---|---|---|
| REQ-F-05 | Los valores deben guardarse en una lista enlazada propia, en el orden de lectura. | Alta | Recorrer la lista devuelve los valores en el orden del archivo. |
| REQ-F-06 | La lista debe llevar el conteo *n* de elementos. | Alta | `Cantidad` coincide con la cantidad de datos válidos leídos. |

### 4.3 Cálculo

| Id | Requisito | Prioridad | Criterio de aceptación |
|---|---|---|---|
| REQ-F-07 | El sistema debe calcular la media aritmética. | Alta | Col. 1 → 550.60; col. 2 → 60.32 (±0.01). |
| REQ-F-08 | El sistema debe calcular la desviación estándar muestral. | Alta | Col. 1 → 572.03; col. 2 → 62.26 (±0.01). |
| REQ-F-09 | Si todos los valores son iguales, la desviación debe ser 0.00. | Media | Archivo con `5`, `5`, `5` → desviación 0.00. |

### 4.4 Salida

| Id | Requisito | Prioridad | Criterio de aceptación |
|---|---|---|---|
| REQ-F-10 | El sistema debe mostrar en consola *n*, la media y la desviación, cada una en su línea y rotulada. | Alta | Ejemplo: `n = 10`, `Media = 550.60`, `Desviación estándar = 572.03`. |
| REQ-F-11 | Los números deben mostrarse con 2 decimales y punto decimal. | Media | La salida es idéntica en Windows y Linux. |

### 4.5 Manejo de errores

| Id | Situación | Comportamiento esperado |
|---|---|---|
| REQ-F-12 | El archivo no existe o no se puede abrir. | Mensaje en español con la ruta; código de salida 1. |
| REQ-F-13 | El archivo está vacío o no tiene datos válidos. | Mensaje «el archivo no contiene datos»; código de salida 1. |
| REQ-F-14 | Una línea no es numérica. | Mensaje con el **número de línea** y su contenido; código de salida 1. |
| REQ-F-15 | Hay un solo dato (n = 1). | Se muestra la media; para la desviación se avisa que se necesitan al menos 2 datos. |

## 5. Requisitos no funcionales

| Id | Categoría | Requisito | Criterio de aceptación |
|---|---|---|---|
| REQ-NF-01 | Portabilidad | Aplicación de consola en C# sobre .NET 9. | Compila y corre con `dotnet run` en Windows y Linux. |
| REQ-NF-02 | Portabilidad | Resultados independientes de la cultura del sistema. | Con `es-CO` y con `en-US` la salida es la misma. |
| REQ-NF-03 | Exactitud | Error máximo de ±0.01 frente a los valores esperados. | Se cumple en ambas columnas de la Tabla 1. |
| REQ-NF-04 | Fiabilidad | Ninguna entrada inválida debe terminar en excepción sin controlar. | Probado con archivo inexistente, vacío y con texto. |
| REQ-NF-05 | Rendimiento | Procesar 100 000 datos en menos de 1 segundo. | Medición con un archivo generado de ese tamaño. |
| REQ-NF-06 | Usabilidad | Mensajes de error claros que indiquen causa y acción. | Cada mensaje dice qué falló y cómo corregirlo. |
| REQ-NF-07 | Mantenibilidad | Código separado en clases (lista, lector, calculadora, programa principal). | Cada clase tiene una sola responsabilidad. |
| REQ-NF-08 | Mantenibilidad | Cumplir el estándar de codificación y métodos de máximo 30 líneas. | Revisión de código sin incumplimientos. |
| REQ-NF-09 | Verificabilidad | Pruebas automatizadas con xUnit. | Cubren REQ-F-03 a REQ-F-15 y REQ-NF-02, 03 y 05. |
| REQ-NF-10 | Trazabilidad PSP | Registrar tiempos y defectos en cada fase y versionar con Git. | Al menos un commit al cerrar cada fase; registros de tiempo y defectos completos. |

## 6. Datos de prueba de referencia

| Columna | Valores | Media | Desv. estándar |
|---|---|---|---|
| 1 | 160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503 | 550.60 | 572.03 |
| 2 | 15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2 | 60.32 | 62.26 |

### Casos adicionales

| Caso | Entrada | Resultado esperado |
|---|---|---|
| Un solo dato | `7` | Media 7.00; aviso por desviación |
| Valores iguales | `5`, `5`, `5` | Media 5.00; desviación 0.00 |
| Con negativos | `-2`, `2` | Media 0.00; desviación 2.83 |
| Línea inválida | `3`, `abc`, `4` | Error en la línea 2 |
| Archivo vacío | (sin contenido) | Error de archivo sin datos |

## 7. Matriz de trazabilidad (requisito → verificación)

| Requisitos | Se verifica con |
|---|---|
| REQ-F-01, 02 | Prueba manual de ejecución con y sin argumento |
| REQ-F-03 a 06 | Pruebas unitarias del lector y de la lista enlazada |
| REQ-F-07 a 09 | Pruebas unitarias de la calculadora con los datos de la sección 6 |
| REQ-F-10, 11 | Prueba de salida en consola |
| REQ-F-12 a 15 | Pruebas de casos de error |
| REQ-NF-02, 03, 05 | Pruebas automatizadas específicas |
| REQ-NF-07, 08, 10 | Revisión de código y del repositorio |
