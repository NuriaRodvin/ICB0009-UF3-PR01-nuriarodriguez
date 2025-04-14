using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

public static class NetworkStreamClass
{
    // ✏️ ENVÍA CARRETERA
    public static void EscribirDatosCarreteraNS(NetworkStream NS, Carretera C)
    {
        try
        {
            byte[] datos = C.Serializar(); // Convertimos Carretera a byte[]
            NS.Write(datos, 0, datos.Length); // Enviamos por el stream
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al enviar datos de Carretera: " + ex.Message);
        }
    }

    // 📥 RECIBE CARRETERA
    public static Carretera LeerDatosCarreteraNS(NetworkStream NS)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesLeidos = NS.Read(buffer, 0, buffer.Length);
            byte[] datosRecibidos = new byte[bytesLeidos];
            Array.Copy(buffer, datosRecibidos, bytesLeidos);
            return Carretera.Deserializar(datosRecibidos);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al leer datos de Carretera: " + ex.Message);
            return null;
        }
    }

    // ✏️ ENVÍA VEHICULO
    public static void EscribirDatosVehiculoNS(NetworkStream NS, Vehiculo V)
    {
        try
        {
            byte[] datos = V.Serializar();
            NS.Write(datos, 0, datos.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al enviar datos de Vehiculo: " + ex.Message);
        }
    }

    // 📥 RECIBE VEHICULO
    public static Vehiculo LeerDatosVehiculoNS(NetworkStream NS)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesLeidos = NS.Read(buffer, 0, buffer.Length);
            byte[] datosRecibidos = new byte[bytesLeidos];
            Array.Copy(buffer, datosRecibidos, bytesLeidos);
            return Vehiculo.Deserializar(datosRecibidos);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al leer datos de Vehiculo: " + ex.Message);
            return null;
        }
    }
}
