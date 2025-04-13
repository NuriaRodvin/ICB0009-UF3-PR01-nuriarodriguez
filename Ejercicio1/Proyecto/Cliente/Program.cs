using System;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        try
        {
            TcpClient cliente = new TcpClient("127.0.0.1", 5000);
            Console.WriteLine("🔌 Cliente conectado desde " + cliente.Client.RemoteEndPoint?.ToString());

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar: " + ex.Message);
        }
    }
}
