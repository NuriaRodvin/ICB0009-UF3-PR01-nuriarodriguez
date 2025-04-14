# Ejercicio 2 - Etapa 0: Clases Vehículo y Carretera

## ✅ Objetivo

Familiarizarse con las clases base `Vehiculo` y `Carretera`, que serán esenciales para el intercambio de información entre el **cliente** y el **servidor** durante la simulación.

---

## 🚗 Clase Vehiculo

Define los datos de un vehículo en la simulación.

### Propiedades:
- `Id`: Identificador único del vehículo.
- `Pos`: Posición actual del vehículo (0 a 100).
- `Velocidad`: Velocidad aleatoria entre 100 y 500 (controla el `Thread.Sleep`).
- `Acabado`: Si el vehículo ha llegado a destino.
- `Direccion`: "Norte" o "Sur".
- `Parado`: Indica si el vehículo está esperando.

La clase también incluye métodos de **serialización** y **deserialización**.

---

## 🛣️ Clase Carretera

Representa el estado global de la simulación.

### Propiedades:
- `VehiculosEnCarretera`: Lista con todos los vehículos activos.
- `NumVehiculosEnCarrera`: Número de vehículos conectados actualmente.

### Funcionalidades:
- **AñadirVehiculo**: Agrega un nuevo vehículo a la lista.
- **ActualizarVehiculo**: Actualiza los datos de un vehículo.
- **MostrarCarretera**: Muestra visualmente el estado de la carretera.
- **Serializar / Deserializar**: Convierte la clase a bytes y viceversa.

---

## ✅ Estado de la Etapa 0

| Elemento                  | Estado |
|---------------------------|--------|
| Clase Vehiculo creada     | ✅     |
| Clase Carretera creada    | ✅     |
| Métodos de serialización  | ✅     |
| Métodos de gestión        | ✅     |
| Estructura inicial lista  | ✅     |

---

# 🧩 Etapa 1: Programación de los métodos de la clase NetworkStreamClass

## ✅ Objetivo

Implementar los métodos que permiten **enviar y recibir objetos de tipo `Vehiculo` y `Carretera`** a través de un `NetworkStream`.

---

## 🧠 Métodos implementados

### 🚗 Vehiculo
- `EscribirDatosVehiculoNS(NetworkStream NS, Vehiculo V)`
- `LeerDatosVehiculoNS(NetworkStream NS)`

### 🛣️ Carretera
- `EscribirDatosCarreteraNS(NetworkStream NS, Carretera C)`
- `LeerDatosCarreteraNS(NetworkStream NS)`

---

## 🔄 Funcionamiento

- Los métodos de escritura (`Escribir...`) **serializan** el objeto y lo envían como bytes.
- Los métodos de lectura (`Leer...`) **reciben bytes** y los **deserializan** para reconstruir el objeto.

---

## ✅ Estado de la Etapa 1

| Elemento                              | Estado |
|---------------------------------------|--------|
| Métodos de Vehiculo implementados     | ✅     |
| Métodos de Carretera implementados    | ✅     |
| Uso de Serialización/Deserialización  | ✅     |

---

## 🔗 Navegación

[⬅️ Volver al README general](../README.md)