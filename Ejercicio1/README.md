# Ejercicio 1 - Etapa 1: Conexión servidor-cliente

## ✅ Objetivo

Establecer una conexión básica entre un **servidor** y un **cliente** usando sockets TCP en C#.  
El servidor espera conexiones en el puerto 5000, y el cliente se conecta a `127.0.0.1`.

---

## 📂 Estructura del proyecto

```
Ejercicio1/
├── Proyecto/
│   ├── Servidor/
│   │   ├── Program.cs
│   │   └── Servidor.csproj
│   └── Cliente/
│       ├── Program.cs
│       └── Cliente.csproj
└── README.md
```

---

## 🧪 Capturas del proceso

### 1️⃣ Servidor iniciado

El servidor se ejecuta correctamente y espera conexiones:

![Servidor](./Capturas/servidor-iniciado.png)

---

### 2️⃣ 2 Terminales abiertas en VS Code

Una terminal para el servidor y otra para el cliente. Se comprueba el entorno antes de lanzar el cliente:

![Terminales](./Capturas/2-terminales.png)

---

### 3️⃣ Cliente conectando

El cliente intenta conectarse y lo consigue:

![Cliente](./Capturas/cliente-ok.png)

---

### 4️⃣ Resultado final

¡Cliente conectado! El servidor muestra el mensaje indicando la IP del cliente:

![Final](./Capturas/final-conexion.png)

---

## 🧠 Comentarios personales

> En esta primera etapa, he comprobado cómo funciona el sistema cliente-servidor con sockets TCP en C#.  
> Aprendí a usar dos terminales de Visual Studio Code, a compilar y ejecutar proyectos con `dotnet run` y a manejar errores si el servidor no está activo.

---

## ✅ Estado de la Etapa 1

| Elemento                       | Estado     |
|--------------------------------|------------|
| Servidor funcionando           | ✅         |
| Cliente funcionando            | ✅         |
| Conexión exitosa               | ✅         |
| Documentación y capturas       | ✅         |

---


## ✅ Verificación de mejoras aplicadas

### 🔹 Cliente tras mejora de mensaje
Se ha mejorado el mensaje de error para que sea más claro si la conexión falla.

![Cliente mejorado](./Capturas/verificacion-cliente.png)

### 🔹 Servidor tras mejora visual
El mensaje en consola del servidor también se ha mejorado.

![Servidor mejorado](./Capturas/verificacion-servidor.png)

---

# 🧩 Etapa 2: Aceptación de múltiples clientes

## 🚀 Objetivo

El servidor ahora acepta múltiples clientes utilizando **hilos** para gestionar cada uno sin bloquear al principal.

## 🔄 Cambios implementados

- El servidor usa `Thread` para manejar cada cliente en segundo plano.
- Cada vez que se conecta un cliente, aparece el mensaje:  
  `🚗 Gestionando nuevo vehículo desde ...`

---

## 🖼️ Capturas de prueba de múltiples clientes

### 🔹 Servidor ejecutándose en Etapa 2

![Servidor etapa 2 activo](./Capturas/servidor-etapa2-activo.png)

### 🔹 Varios clientes conectados correctamente

![Múltiples clientes](./Capturas/multiples-clientes.png)

---

## ✅ Estado de la Etapa 2

| Elemento                               | Estado     |
|----------------------------------------|------------|
| Conexión múltiples clientes            | ✅         |
| Gestión concurrente con hilos          | ✅         |
| Mensaje "Gestionando nuevo vehículo..."| ✅         |
| Capturas de verificación               | ✅         |

---

# 🧩 Etapa 3: Asignación de ID único y dirección aleatoria

## 🚀 Objetivo

El servidor asigna un **ID único** y una **dirección aleatoria (NORTE/SUR)** a cada cliente que se conecta.

## 🧠 Conceptos aplicados

- Uso de una variable `siguienteId` autoincremental.
- Uso de `lock` para proteger el acceso desde múltiples hilos.
- Uso de `Random` para asignar una dirección al azar.

---

## 🖼️ Captura de prueba

### 🔹 Identificación de vehículos conectados

![ID y dirección](./Capturas/asignacion-id-vehiculos.png)

---
# 🧩 Etapa 4: Obtener NetworkStream

## 🚀 Objetivo

Obtener el `NetworkStream` tanto en el servidor como en el cliente después de establecer la conexión.

## 🔄 Cambios implementados

- En el servidor, tras aceptar un cliente, se obtiene el stream: `cliente.GetStream()`.
- En el cliente, tras conectarse, también se obtiene el stream.
- Se muestra un mensaje de confirmación en consola.

---

## 🖼️ Capturas

### 🔹 NetworkStream en el Servidor

![Stream servidor](./Capturas/stream-servidor.png)

### 🔹 NetworkStream en el Cliente

![Stream cliente](./Capturas/stream-cliente.png)

---

## ✅ Estado de la Etapa 4

| Elemento                      | Estado     |
|-------------------------------|------------|
| NetworkStream en servidor     | ✅         |
| NetworkStream en cliente      | ✅         |
| Capturas añadidas             | ✅         |

---
# 🧩 Etapa 5: Métodos de lectura y escritura con NetworkStream

## 🚀 Objetivo

Centralizar la lógica de envío y recepción de mensajes entre cliente y servidor a través de `NetworkStream`, usando una clase compartida.

## 🧠 Conceptos aplicados

- Programación de métodos genéricos reutilizables para leer y escribir datos.
- Uso de codificación UTF-8.
- Estructura modular: los métodos están en la clase `NetworkStreamClass` para que los usen tanto cliente como servidor.

## 🧾 Métodos implementados

- `EscribirMensajeNetworkStream(NetworkStream stream, string mensaje)`  
  Envía un mensaje a través del stream.

- `LeerMensajeNetworkStream(NetworkStream stream)`  
  Lee un mensaje desde el stream y lo retorna como `string`.

## 📁 Ubicación del archivo

La clase está en la raíz del proyecto, compartida entre Cliente y Servidor:
```
Ejercicio1/
└── Proyecto/
    ├── Cliente/
    ├── Servidor/
    └── NetworkStreamClass.cs  ✅
```

---

## ✅ Estado de la Etapa 5

| Elemento                                     | Estado     |
|----------------------------------------------|------------|
| Métodos de escritura y lectura funcionales   | ✅         |
| Clase reutilizable y accesible desde ambos   | ✅         |
| Compilación sin errores                      | ✅         |

---
# 🧩 Etapa 6: Handshake entre cliente y servidor

## 🤝 Objetivo del Handshake

Antes de que el cliente comience su ejecución, debe establecer un **handshake** con el servidor para recibir su ID asignado.

## 🔄 Flujo del Handshake

1. El cliente envía un mensaje `"INICIO"` al servidor.
2. El servidor responde con el **ID del vehículo**.
3. El cliente confirma enviando el mismo ID de vuelta al servidor.
4. El servidor muestra el mensaje indicando que el cliente ha sido verificado correctamente.

---

## 🖼️ Capturas del Handshake funcionando

### 🔹 Servidor mostrando el proceso de handshake

![Servidor Handshake](./Capturas/servidor-handshake.png)

### 🔹 Cliente mostrando el intercambio de mensajes

![Cliente Handshake](./Capturas/cliente-handshake.png)

---

## ✅ Estado de la Etapa 6

| Elemento                             | Estado     |
|--------------------------------------|------------|
| Cliente envía mensaje de inicio      | ✅         |
| Servidor responde con ID             | ✅         |
| Cliente confirma ID recibido         | ✅         |
| Mensajes de verificación en consola  | ✅         |
| Capturas guardadas                   | ✅         |


---

## 🔗 Navegación

[⬅️ Volver al README general](../README.md)
