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


## 🔗 Navegación

[⬅️ Volver al README general](../README.md)
