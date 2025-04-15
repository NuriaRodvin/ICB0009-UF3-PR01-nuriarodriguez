namespace Modelo;


using System.Net.Sockets;
using System;

public class NetworkStreamClass
{
    public static void EscribirDatosVehiculoNS(NetworkStream ns, Vehiculo v)
    {
        byte[] datos = v.SerializarVehiculo();
        byte[] tamaño = BitConverter.GetBytes(datos.Length);
        ns.Write(tamaño, 0, 4);
        ns.Write(datos, 0, datos.Length);
    }

    public static Vehiculo LeerDatosVehiculoNS(NetworkStream ns)
    {
        byte[] tamaño = new byte[4];
        ns.Read(tamaño, 0, 4);
        int longitud = BitConverter.ToInt32(tamaño, 0);

        byte[] datos = new byte[longitud];
        int leido = ns.Read(datos, 0, longitud);
        return Vehiculo.DeserializarVehiculo(datos);
    }

    public static void EscribirDatosCarreteraNS(NetworkStream ns, Carretera c)
    {
        byte[] datos = c.SerializarCarretera();
        byte[] tamaño = BitConverter.GetBytes(datos.Length);
        ns.Write(tamaño, 0, 4);
        ns.Write(datos, 0, datos.Length);
    }

    public static Carretera LeerDatosCarreteraNS(NetworkStream ns)
    {
        byte[] tamaño = new byte[4];
        ns.Read(tamaño, 0, 4);
        int longitud = BitConverter.ToInt32(tamaño, 0);

        byte[] datos = new byte[longitud];
        int leido = ns.Read(datos, 0, longitud);
        return Carretera.DeserializarCarretera(datos);
    }
}