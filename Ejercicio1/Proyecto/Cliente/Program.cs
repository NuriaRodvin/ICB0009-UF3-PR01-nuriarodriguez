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

            // Obtener el NetworkStream
            NetworkStream stream = cliente.GetStream();
            Console.WriteLine("📡 Stream de red abierto en el cliente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ No se pudo conectar al servidor. Verifica que esté en ejecución. Detalles: " + ex.Message);
        }
    }
}

