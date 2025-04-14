using System;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        try
        {
            TcpClient cliente = new TcpClient("127.0.0.1", 5000);
            Console.WriteLine("🔌 Cliente conectado desde " + cliente.Client.RemoteEndPoint);

            NetworkStream stream = cliente.GetStream();
            Console.WriteLine("📡 Stream de red abierto en el cliente.");

            // Handshake
            NetworkStreamClass.EscribirMensajeNetworkStream(stream, "INICIO");

            string idRecibido = NetworkStreamClass.LeerMensajeNetworkStream(stream);
            Console.WriteLine("🆔 ID recibido del servidor: " + idRecibido);

            NetworkStreamClass.EscribirMensajeNetworkStream(stream, idRecibido);
            Console.WriteLine("✅ ID confirmado al servidor.");

            cliente.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ No se pudo conectar al servidor. Verifica que esté en ejecución. Detalles: " + ex.Message);
        }
    }
}


