using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

public static class NetworkStreamClass
{
    public static void EscribirMensajeNetworkStream(NetworkStream stream, string mensaje)
    {
        try
        {
            byte[] datos = Encoding.UTF8.GetBytes(mensaje + "\n");
            stream.Write(datos, 0, datos.Length);
        }
        catch (IOException ex)
        {
            Console.WriteLine("❌ Error al enviar mensaje: " + ex.Message);
        }
    }

    public static string LeerMensajeNetworkStream(NetworkStream stream)
    {
        try
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true))
            {
                return reader.ReadLine();
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("❌ Error al leer mensaje: " + ex.Message);
            return null;
        }
    }
}
