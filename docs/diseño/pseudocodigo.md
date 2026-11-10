# Pseudocódigo · Programa 1 (media y desviación estándar)

Entradas de esta fase: `diseno_programa1.md` (clases, flujo e interfaz) y `requisitos_programa1_estadistica.md`.
Convenciones: palabras clave en mayúscula, `←` para asignar, `n` es la cantidad de datos y `∅` es "sin valor" (`null`).
Cada bloque indica los requisitos que cubre y su costo.

## 1. Programa principal

```
ALGORITMO Programa
    codigo ← Aplicacion.Ejecutar(args, ENTRADA_ESTANDAR, SALIDA_ESTANDAR)
    TERMINAR con codigo
```

*Cubre:* REQ-F-01 (la consola se inyecta para poder probar con `StringReader` y `StringWriter`).

## 2. Capa de aplicación

```
FUNCION Aplicacion.Ejecutar(args, entrada, salida) → entero
    ui ← NUEVA ConsolaUI(entrada, salida)
    lector ← NUEVO LectorArchivoNumeros
    calculadora ← NUEVA CalculadoraEstadistica

    INTENTAR
        SI args tiene al menos 1 elemento ENTONCES
            ruta ← args[0]                              // REQ-F-01
        SINO
            ruta ← ui.PedirRuta()                       // REQ-F-02
        FIN SI

        lista ← lector.Leer(ruta)                       // REQ-F-03 a REQ-F-06, REQ-F-12 a 14
        resultado ← calculadora.Calcular(lista)         // REQ-F-07 a REQ-F-09

        SI resultado.Desviacion = ∅ ENTONCES
            ui.MostrarAviso("se necesitan al menos 2 datos para la desviación estándar.")   // REQ-F-15
        FIN SI
        ui.MostrarResultado(resultado, ruta)            // REQ-F-10, REQ-F-11
        RETORNAR 0

    CAPTURAR DatosInvalidosException como e
        ui.MostrarError(e.Mensaje)
        RETORNAR 1
    CAPTURAR DatosInsuficientesException como e
        ui.MostrarError(e.Mensaje)
        RETORNAR 1
    CAPTURAR cualquier otro error de lectura como e    // permisos, archivo bloqueado
        ui.MostrarError("no se pudo leer el archivo. Revisa los permisos y la ruta.")
        RETORNAR 1
    FIN INTENTAR
FIN FUNCION
```

*Cubre:* REQ-F-01, REQ-F-02, REQ-F-12 a 15, REQ-NF-04 (ninguna entrada inválida termina en excepción sin controlar).

## 3. Capa de infraestructura

```
FUNCION LectorArchivoNumeros.Leer(ruta) → ListaEnlazada
    SI ruta está vacía O el archivo NO existe ENTONCES
        LANZAR DatosInvalidosException("no se encontró el archivo \"" + ruta + "\". Revisa la ruta.")
    FIN SI

    lista ← NUEVA ListaEnlazada
    numeroLinea ← 0

    PARA CADA texto EN LeerLineas(ruta)
        numeroLinea ← numeroLinea + 1
        texto ← QuitarEspacios(texto)
        SI texto está vacío O texto empieza por "#" ENTONCES
            CONTINUAR                                   // REQ-F-04
        FIN SI
        lista.Agregar(Convertir(texto, numeroLinea))    // REQ-F-03
    FIN PARA

    SI lista.Cantidad = 0 ENTONCES
        LANZAR DatosInvalidosException("el archivo no contiene datos. Agrega un número por línea.")
    FIN SI
    RETORNAR lista
FIN FUNCION
```

```
FUNCION LectorArchivoNumeros.LeerLineas(ruta) → secuencia de texto
    abrir el archivo en UTF-8
    MIENTRAS haya líneas
        ENTREGAR la siguiente línea          // lectura perezosa: no carga todo el archivo a la vez
    FIN MIENTRAS
FIN FUNCION
```

```
FUNCION LectorArchivoNumeros.Convertir(texto, numeroLinea) → real
    // Cultura invariante: el punto es siempre el separador decimal (REQ-NF-02)
    SI NO ConvertirAReal(texto, formato=número real, cultura=INVARIANTE, salida=valor) ENTONCES
        LANZAR DatosInvalidosException("la línea " + numeroLinea + " no es un número válido (\"" + texto + "\"). Corrígela.")
    FIN SI
    SI valor es NaN O valor es infinito ENTONCES
        LANZAR DatosInvalidosException("la línea " + numeroLinea + " no es un número válido (\"" + texto + "\"). Corrígela.")
    FIN SI
    RETORNAR valor
FIN FUNCION
```

*Cubre:* REQ-F-03, REQ-F-04, REQ-F-12, REQ-F-13, REQ-F-14, REQ-NF-02. Costo de `Leer`: O(n).

## 4. Capa de dominio

### 4.1 Lista enlazada

```
CLASE Nodo
    Valor     : real
    Siguiente : Nodo       // ∅ en el último nodo
FIN CLASE

CLASE ListaEnlazada
    primero  : Nodo ← ∅
    ultimo   : Nodo ← ∅
    Cantidad : entero ← 0

    PROCEDIMIENTO Agregar(valor)
        nuevo ← NUEVO Nodo(valor, Siguiente = ∅)
        SI primero = ∅ ENTONCES
            primero ← nuevo
        SINO
            ultimo.Siguiente ← nuevo
        FIN SI
        ultimo ← nuevo
        Cantidad ← Cantidad + 1
    FIN PROCEDIMIENTO

    FUNCION Recorrer() → secuencia de reales            // GetEnumerator
        actual ← primero
        MIENTRAS actual ≠ ∅
            ENTREGAR actual.Valor
            actual ← actual.Siguiente
        FIN MIENTRAS
    FIN FUNCION
FIN CLASE
```

*Cubre:* REQ-F-05, REQ-F-06, REQ-NF-05. `Agregar` es O(1) porque se conserva el puntero al último nodo.

### 4.2 Cálculo estadístico

```
FUNCION CalculadoraEstadistica.Calcular(lista) → ResultadoEstadistico
    SI lista.Cantidad = 0 ENTONCES
        LANZAR DatosInsuficientesException("no hay datos para calcular.")
    FIN SI

    media ← Media(lista)
    SI lista.Cantidad < 2 ENTONCES
        desviacion ← ∅                                  // REQ-F-15
    SINO
        desviacion ← DesviacionEstandar(lista, media)
    FIN SI
    RETORNAR NUEVO ResultadoEstadistico(N = lista.Cantidad, Media = media, Desviacion = desviacion)
FIN FUNCION
```

```
FUNCION CalculadoraEstadistica.Media(lista) → real
    suma ← 0
    PARA CADA x EN lista.Recorrer()
        suma ← suma + x
    FIN PARA
    RETORNAR suma / lista.Cantidad
FIN FUNCION
```

```
FUNCION CalculadoraEstadistica.DesviacionEstandar(lista, media) → real
    sumaCuadrados ← 0
    PARA CADA x EN lista.Recorrer()
        diferencia ← x − media
        sumaCuadrados ← sumaCuadrados + diferencia × diferencia
    FIN PARA
    RETORNAR RAIZ_CUADRADA(sumaCuadrados / (lista.Cantidad − 1))     // muestral: n − 1
FIN FUNCION
```

*Cubre:* REQ-F-07, REQ-F-08, REQ-F-09, REQ-F-15, REQ-NF-03. Costo: O(n) por cada recorrido, dos recorridos en total. Si todos los valores son iguales, `sumaCuadrados` es 0 y la desviación sale 0.00.

## 5. Capa de presentación

```
CLASE ConsolaUI(entrada, salida)

    FUNCION PedirRuta() → texto
        ESCRIBIR en salida "Ruta del archivo: "
        texto ← LEER LINEA de entrada
        SI texto = ∅ ENTONCES RETORNAR ""
        RETORNAR QuitarEspacios(texto)
    FIN FUNCION

    PROCEDIMIENTO MostrarResultado(resultado, ruta)
        ESCRIBIR LINEA "=== Estadística básica · PSP0 ==="
        ESCRIBIR LINEA Rotular("Archivo") + ": " + ruta
        ESCRIBIR LINEA "----------------------------------"
        ESCRIBIR LINEA Rotular("n") + ": " + resultado.N
        ESCRIBIR LINEA Rotular("Media") + ": " + Formato2(resultado.Media)
        SI resultado.Desviacion = ∅ ENTONCES
            ESCRIBIR LINEA Rotular("Desv. estándar") + ": n/d"
        SINO
            ESCRIBIR LINEA Rotular("Desv. estándar") + ": " + Formato2(resultado.Desviacion)
        FIN SI
    FIN PROCEDIMIENTO

    PROCEDIMIENTO MostrarAviso(mensaje)
        ESCRIBIR LINEA "AVISO: " + mensaje
    FIN PROCEDIMIENTO

    PROCEDIMIENTO MostrarError(mensaje)
        ESCRIBIR LINEA "ERROR: " + mensaje
    FIN PROCEDIMIENTO

    FUNCION Rotular(etiqueta) → texto
        RETORNAR etiqueta rellenada con espacios a la derecha hasta 16 caracteres
    FIN FUNCION

    FUNCION Formato2(valor) → texto
        RETORNAR valor con 2 decimales y punto decimal, cultura INVARIANTE
    FIN FUNCION
FIN CLASE
```

*Cubre:* REQ-F-02, REQ-F-10, REQ-F-11, REQ-NF-06.

## 6. Seguimiento a mano (prueba de escritorio)

Datos: `-2` y `2` (CP-03).

| Paso | Operación | Valor |
|---|---|---|
| 1 | `Leer`: dos líneas válidas, `Cantidad` | 2 |
| 2 | `Media`: suma = −2 + 2 | 0 |
| 3 | `Media` = 0 / 2 | 0.00 |
| 4 | `DesviacionEstandar`: (−2 − 0)² + (2 − 0)² | 8 |
| 5 | 8 / (2 − 1) | 8 |
| 6 | Raíz cuadrada de 8 | 2.83 |
| 7 | Salida | `Media: 0.00`, `Desv. estándar: 2.83` |

Con la columna 1 de la Tabla 1 (10 datos) se espera media 550.60 y desviación 572.03 (CP-01).

## 7. Trazabilidad pseudocódigo → requisito

| Bloque | Requisitos |
|---|---|
| `Aplicacion.Ejecutar` | REQ-F-01, REQ-F-02, REQ-F-12 a 15, REQ-NF-04 |
| `LectorArchivoNumeros` | REQ-F-03, REQ-F-04, REQ-F-12 a 14, REQ-NF-02 |
| `ListaEnlazada` | REQ-F-05, REQ-F-06, REQ-NF-05 |
| `CalculadoraEstadistica` | REQ-F-07 a 09, REQ-F-15, REQ-NF-03 |
| `ConsolaUI` | REQ-F-02, REQ-F-10, REQ-F-11, REQ-NF-06 |
