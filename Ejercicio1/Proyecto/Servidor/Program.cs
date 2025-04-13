using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
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

                // Se lanza un nuevo hilo para cada cliente
                Thread hiloCliente = new Thread(() =>
                {
                    Console.WriteLine("🚗 Gestionando nuevo vehículo desde " + cliente.Client.RemoteEndPoint?.ToString());
                    // Aquí podrías añadir más lógica por cliente si se requiere
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


