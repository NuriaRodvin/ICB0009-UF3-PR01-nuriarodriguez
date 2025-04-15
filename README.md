# 🚗 Proyecto ICB0009-UF3-PR01 - Simulación de Tráfico TCP/IP

Este repositorio contiene la práctica de red compuesta por **3 ejercicios** realizados como parte del módulo ICB0009-UF3. Cada ejercicio simula aspectos distintos de una red cliente-servidor utilizando **Sockets TCP en C#**.

---

## 📦 Estructura del repositorio

```
ICB0009-UF3-PR01-nuriarodriguez/
├── Ejercicio1/     # Conexión básica y multicliente
├── Ejercicio2/     # Simulación de carrera y objetos Vehiculo/Carretera
├── Ejercicio3/     # Control de tráfico en puente con BONUS turnos
└── README.md       # Este archivo resumen
```

---

## 🧩 Ejercicio 1 - Conexión Servidor-Cliente

> 🧠 Aprendimos a aceptar múltiples conexiones TCP usando hilos.

### ✅ Objetivos:
- Crear un servidor que acepte múltiples clientes.
- Asignar un ID y dirección aleatoria a cada cliente.
- Implementar un sistema de mensajes (handshake).

📸 **Capturas incluidas en `/Ejercicio1/Capturas`**

📄 **Detalles completos en** [`Ejercicio1/README.md`](./Ejercicio1/README.md)

---

## 🐎 Ejercicio 2 - Simulación de Carrera

> 🔁 Se implementa el avance de vehículos, sincronización con el servidor y visualización del estado.

### ✅ Objetivos:
- Programar clases `Vehiculo` y `Carretera` con métodos de serialización.
- Permitir movimiento de vehículos en bucle.
- Mostrar el estado de la carretera en servidor y cliente.
- Implementar hilo de escucha para recibir actualizaciones.
- Detectar y mostrar el **ganador de la carrera**.

📸 **Capturas incluidas en `/Ejercicio2/Capturas`**

📄 **Detalles completos en** [`Ejercicio2/README.md`](./Ejercicio2/README.md)

---

## 🌉 Ejercicio 3 - Control de Tráfico en el Puente

> 🚦 Solo un vehículo puede cruzar el puente a la vez, con lógica de espera y BONUS de turnos Norte-Sur.

### ✅ Objetivos:
- Implementar lógica para evitar colisiones en un recurso compartido (el puente).
- Mostrar estados en los clientes: `Esperando`, `Cruzando`, `Finalizado`.
- BONUS: Alternancia de turnos por dirección (`Norte`, `Sur`).

### 💡 También se respondieron 2 preguntas teóricas sobre:
- ¿Dónde es mejor controlar el puente? ¿Cliente o servidor?
- ¿Cómo gestionar colas de espera por dirección?

📸 **Capturas incluidas en `/Ejercicio3/Capturas`**

📄 **Detalles completos en** [`Ejercicio3/README.md`](./Ejercicio3/README.md)

---

## 🏁 Estado final del proyecto

| Ejercicio   | Descripción                        | Estado |
|-------------|------------------------------------|--------|
| Ejercicio 1 | Conexión y comunicación básica     | ✅     |
| Ejercicio 2 | Simulación de carrera              | ✅     |
| Ejercicio 3 | Control de tráfico en el puente    | ✅     |
| Bonus       | Turnos alternos Norte/Sur          | ✅     |

---

## 👩‍💻 Autor

**Nuria Rodríguez Vindel**  
📁 Repositorio: [ICB0009-UF3-PR01-nuriarodriguez](https://github.com/NuriaRodvin/ICB0009-UF3-PR01-nuriarodriguez)

---

## 📁 Navegación

- [Ejercicio 1](./Ejercicio1/README.md)
- [Ejercicio 2](./Ejercicio2/README.md)
- [Ejercicio 3](./Ejercicio3/README.md)
