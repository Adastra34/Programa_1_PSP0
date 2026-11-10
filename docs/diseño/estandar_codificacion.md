# Estándar de codificación · Programa 1 (C# .NET 9)

Se aplica en la fase de código y se revisa en compilación y pruebas (REQ-NF-08).

## 1. Nombres

| Elemento | Convención | Ejemplo |
|---|---|---|
| Clases, records, excepciones, métodos, propiedades | PascalCase en español | `ListaEnlazada`, `Calcular`, `Cantidad` |
| Parámetros y variables locales | camelCase | `numeroLinea`, `sumaCuadrados` |
| Campos privados | `_camelCase` | `_primero`, `_salida` |
| Constantes | PascalCase con `const` | `AnchoRotulo` |
| Excepciones | terminan en `Exception` | `DatosInvalidosException` |

Los nombres dicen qué hace o qué guarda; sin abreviaturas ambiguas (`n` solo para la cantidad de datos en comentarios).

## 2. Formato

* Una clase por archivo; el archivo se llama igual que la clase.
* Sangría de 4 espacios, sin tabulaciones.
* Llaves en línea propia (estilo Allman), incluso en un `if` de una sola instrucción.
* Líneas de máximo 120 caracteres.
* Orden en el archivo: `using` (primero `System`), `namespace` de archivo, tipo, constantes, campos, constructor, propiedades, métodos públicos, métodos privados.

## 3. Estructura y tamaño

* Cada método hace una sola cosa y tiene **máximo 30 líneas**.
* Las capas respetan la regla de dependencia: el dominio no usa consola ni archivos.
* Sin números ni textos repetidos "mágicos": se usan constantes.
* Sin `List<T>`, `LinkedList<T>` ni otras colecciones de .NET para guardar los datos; se usa `ListaEnlazada`.

## 4. Errores y cultura

* Los errores de datos se lanzan con `DatosInvalidosException` o `DatosInsuficientesException`; solo `Aplicacion.Ejecutar` los captura.
* No se captura `Exception` sin filtro.
* Todo número se lee y se escribe con `CultureInfo.InvariantCulture`.
* Mensajes en español, en una línea, con el formato `ERROR: causa. Acción.` o `AVISO: ...`.

## 5. Comentarios y calidad

* Comentario `///` breve en cada clase pública y en los métodos cuyo propósito no sea obvio.
* Los comentarios explican el *por qué*, no repiten el código.
* `Nullable` activado; el proyecto debe compilar con 0 errores y 0 advertencias.
* No se deja código comentado ni `using` sin usar.
