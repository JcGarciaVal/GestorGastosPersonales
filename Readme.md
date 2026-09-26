# Control de Gastos Personales

Aplicación de consola desarrollada en C# y .NET para registrar, consultar y eliminar gastos personales.

La aplicación permite almacenar los gastos de forma persistente utilizando un archivo JSON, consultar los gastos realizados durante el día y obtener un resumen agrupado por categoría.

## Funcionalidades

- Agregar gastos.
- Asignar una categoría a cada gasto.
- Registrar una descripción.
- Registrar automáticamente la fecha del gasto.
- Generar un ID único para cada gasto.
- Mostrar todos los gastos registrados.
- Calcular el total gastado durante el día.
- Mostrar los gastos agrupados por categoría.
- Calcular el total gastado por categoría.
- Eliminar un gasto mediante su ID.
- Persistir la información en un archivo JSON.
- Validar los datos ingresados por el usuario.

## Categorías

Los gastos pueden clasificarse en:

- Fijos
- Variables
- Emergencia
- Hormiga

## Tecnologías utilizadas

- C#
- .NET
- LINQ
- JSON
- `System.Text.Json`
- `System.IO`

## Estructura del proyecto

```text
ControlGastosPersonales/
│
├── Data/
│   └── gastos.json
│
├── Gasto.cs
├── Categoria.cs
├── GastosServices.cs
├── GastosRepository.cs
└── Program.cs
```

### `Gasto`

Representa un gasto individual.

Contiene:

- ID
- Costo
- Categoría
- Descripción
- Fecha

### `Categoria`

Enum que define las categorías disponibles para los gastos.

### `GastosRepository`

Se encarga de la persistencia de los datos.

Responsabilidades:

- Leer `gastos.json`.
- Guardar la lista de gastos.
- Crear y utilizar el directorio de datos.

El resto de la aplicación no necesita conocer cómo se almacenan físicamente los datos.

### `GastosServices`

Contiene la lógica de negocio de la aplicación.

Responsabilidades:

- Validar gastos.
- Crear nuevos IDs.
- Agregar gastos.
- Mostrar gastos.
- Calcular totales.
- Agrupar gastos por categoría.
- Eliminar gastos.

### `Program`

Contiene la interfaz de usuario de la aplicación.

Se encarga de:

- Mostrar el menú.
- Leer las opciones del usuario.
- Solicitar los datos.
- Mostrar los resultados.
- Invocar las operaciones de `GastosServices`.

## Flujo de la aplicación

```text
Usuario
   │
   ▼
Program
   │
   ▼
GastosServices
   │
   ▼
GastosRepository
   │
   ▼
gastos.json
```

La aplicación separa la interfaz de consola de la lógica de negocio y de la persistencia.

## Ejemplo de uso

Al iniciar:

```text
¡Bienvenido a tu CLI de Gastos!

¿Que desea hacer?
1. Agregar gasto.
2. Mostrar gastos.
3. Mostrar gastos diarios.
4. Ver categorías diarias.
5. Eliminar gasto.
6. Salir
```

Un gasto puede verse de la siguiente manera:

```text
1 - Café           - 2500  - Hormiga     - 26/09/2026
2 - Internet       - 30000 - Fijos       - 26/09/2026
3 - Supermercado   - 45000 - Variables   - 26/09/2026
```

## Persistencia

Los datos se almacenan en:

```text
Data/gastos.json
```

Ejemplo:

```json
[
  {
    "Id": 1,
    "Costo": 2500,
    "Categoria": 3,
    "Descripcion": "Café",
    "Fecha": "2026-09-26T00:00:00"
  }
]
```

De esta manera, los gastos permanecen disponibles aunque la aplicación se cierre.

## Validaciones

La aplicación valida:

- Que el monto sea un número válido.
- Que el monto sea mayor que cero.
- Que la categoría sea válida.
- Que la descripción no esté vacía.
- Que el ID utilizado para eliminar un gasto sea válido.
- Que el gasto que se intenta eliminar exista.

## Objetivos de aprendizaje

Este proyecto fue desarrollado para practicar los fundamentos de C# y .NET:

- Programación orientada a objetos.
- Clases y propiedades.
- Enumeraciones.
- Colecciones.
- LINQ.
- CRUD.
- Persistencia de información.
- Serialización y deserialización JSON.
- Entrada y salida por consola.
- Validación de datos.
- Separación de responsabilidades.
- Patrón básico Repository + Service.

## Ejecución

Desde la carpeta del proyecto:

```bash
dotnet run
```

La aplicación se ejecutará directamente en la terminal.

## Posibles mejoras futuras

Algunas funcionalidades que podrían agregarse posteriormente:

- Editar un gasto.
- Buscar gastos por descripción.
- Filtrar por rango de fechas.
- Mostrar estadísticas mensuales.
- Exportar información a CSV.
- Permitir configurar la moneda.
- Agregar pruebas unitarias.
- Incorporar una configuración externa.

Estas funcionalidades no son necesarias para la versión actual.