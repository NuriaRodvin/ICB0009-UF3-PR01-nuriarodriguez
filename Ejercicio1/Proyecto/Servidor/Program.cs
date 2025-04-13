using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
    static int siguienteId = 1;
    static object lockId = new object();
    static Random rnd = new Random();

    static void Main()
    {
        TcpListener servidor = new TcpListener(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🟢 Servidor en espera de conexiones...");

        while (true)
        {
            try
            {
                TcpClient cliente = servidor.AcceptTcpClient();

                Thread hiloCliente = new Thread(() =>
                {
                    int idVehiculo;
                    string direccion;

                    lock (lockId)
                    {
                        idVehiculo = siguienteId++;
                        direccion = rnd.Next(2) == 0 ? "norte" : "sur";
                    }

                    Console.WriteLine($"🚗 Vehículo ID {idVehiculo} conectado desde {cliente.Client.RemoteEndPoint?.ToString()} y va hacia el {direccion.ToUpper()}");

                    // Obtener el NetworkStream del cliente
                    NetworkStream stream = cliente.GetStream();
                    Console.WriteLine($"📡 Stream de red abierto para el vehículo ID {idVehiculo}.");
                });

                hiloCliente.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al aceptar cliente: " + ex.Message);
            }
        }
    }
}



