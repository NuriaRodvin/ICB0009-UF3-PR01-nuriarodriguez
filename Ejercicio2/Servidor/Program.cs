﻿using System;
using System.Net;
using System.Net.Sockets;
using Program;

class ProgramServidor
{
    static void Main(string[] args)
    {
        // Crear carretera vacía
        Carretera carretera = new Carretera();

        // Crear listener en el puerto 5000
        TcpListener servidor = new TcpListener(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🚦 Servidor escuchando en el puerto 5000...");

        while (true)
        {
            Console.WriteLine("📡 Esperando conexión de un cliente...");
            TcpClient cliente = servidor.AcceptTcpClient();
            Console.WriteLine("✅ Cliente conectado.");

            NetworkStream ns = cliente.GetStream();

            // Leer Vehiculo del cliente
            Vehiculo v = NetworkStreamClass.LeerDatosVehiculoNS(ns);

            if (v != null)
            {
                Console.WriteLine($"🚗 Vehículo recibido: ID={v.Id}, Pos={v.Pos}, Dir={v.Direccion}");
                carretera.AñadirVehiculo(v);
            }

            // Mostrar estado de la carretera
            Console.WriteLine("🛣️ Estado de la carretera:");
            carretera.MostrarCarretera();

            // Enviar carretera al cliente como respuesta (opcional)
            NetworkStreamClass.EscribirDatosCarreteraNS(ns, carretera);

            // Cerrar conexión con este cliente
            cliente.Close();
            Console.WriteLine("🔌 Cliente desconectado.\n");
        }
    }
}
