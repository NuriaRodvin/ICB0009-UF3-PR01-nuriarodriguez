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

![Servidor](./capturas/servidor-iniciado.png)

---

### 2️⃣ 2 Terminales abiertas en VS Code

Una terminal para el servidor y otra para el cliente. Se comprueba el entorno antes de lanzar el cliente:

![Terminales](./capturas/2-terminales.png)

---

### 3️⃣ Cliente conectando

El cliente intenta conectarse y lo consigue:

![Cliente](./capturas/cliente-ok.png)

---

### 4️⃣ Resultado final

¡Cliente conectado! El servidor muestra el mensaje indicando la IP del cliente:

![Final](./capturas/final-conexion.png)

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

## 🔗 Navegación

[⬅️ Volver al README general](../README.md)
