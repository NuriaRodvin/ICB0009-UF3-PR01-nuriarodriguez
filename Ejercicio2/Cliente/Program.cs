﻿using System;
using System.Net.Sockets;
using Program;

class ProgramCliente
{
    static void Main(string[] args)
    {
        try
        {
            // Crear conexión al servidor
            TcpClient cliente = new TcpClient("127.0.0.1", 5000);
            Console.WriteLine("🔗 Conectado al servidor");

            NetworkStream ns = cliente.GetStream();

            // Crear vehículo
            Vehiculo v = new Vehiculo()
            {
                Id = int.Parse(DateTime.Now.ToString("HHmmssfff")), // HoraMinutoSegundoMilisegundo
                Pos = 0,
                Velocidad = 0,
                Acabado = false,
                Direccion = "Norte", // o "Sur"
                Parado = false
            };

            Console.WriteLine($"🚗 Enviando vehículo: ID={v.Id}, Dir={v.Direccion}");

            // Enviar al servidor
            NetworkStreamClass.EscribirDatosVehiculoNS(ns, v);

            // Leer respuesta (opcional: carretera actualizada)
            Carretera c = NetworkStreamClass.LeerDatosCarreteraNS(ns);

            Console.WriteLine("🛣️ Carretera recibida:");
            c.MostrarCarretera();

            cliente.Close();
            Console.WriteLine("🔌 Conexión cerrada");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error en el cliente: " + ex.Message);
        }
    }
}
