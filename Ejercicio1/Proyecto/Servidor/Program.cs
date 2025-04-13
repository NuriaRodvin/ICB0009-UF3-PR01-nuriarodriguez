using System;
using System.Net;
using System.Net.Sockets;

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
                Console.WriteLine("Cliente conectado desde " + cliente?.Client?.RemoteEndPoint?.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al aceptar cliente: " + ex.Message);
            }
        }
    }
}

