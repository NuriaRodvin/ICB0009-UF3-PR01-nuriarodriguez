using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Program;

public static class NetworkStreamClass
{
    // ✏️ ENVÍA CARRETERA
    public static void EscribirDatosCarreteraNS(NetworkStream NS, Carretera C)
    {
        try
        {
            byte[] datos = C.SerializarCarretera();
            NS.Write(datos, 0, datos.Length);
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
            return Carretera.DeserializarCarretera(datosRecibidos);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al leer datos de Carretera: " + ex.Message);
            return null!;
        }
    }

    // ✏️ ENVÍA VEHICULO
    public static void EscribirDatosVehiculoNS(NetworkStream NS, Vehiculo V)
    {
        try
        {
            byte[] datos = V.SerializarVehiculo();
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
            return Vehiculo.DeserializarVehiculo(datosRecibidos);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al leer datos de Vehiculo: " + ex.Message);
            return null!;
        }
    }
}
