using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Program;

class ProgramServidor
{
    static List<Cliente> clientesConectados = new List<Cliente>();
    static Carretera carretera = new Carretera();
    static object lockObject = new object();

    static void Main(string[] args)
    {
        TcpListener servidor = new TcpListener(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🚦 Servidor escuchando en el puerto 5000...");

        while (true)
        {
            Console.WriteLine("📡 Esperando conexión de un cliente...");
            TcpClient tcpCliente = servidor.AcceptTcpClient();
            Console.WriteLine("✅ Cliente conectado. Gestionando nuevo vehículo...");

            // Crear hilo por cliente
            Thread hiloCliente = new Thread(() => GestionarCliente(tcpCliente));
            hiloCliente.Start();
        }
    }

    static void GestionarCliente(TcpClient tcpCliente)
    {
        NetworkStream ns = tcpCliente.GetStream();

        // ✅ Crear cliente con ID y Stream
        int id = int.Parse(DateTime.Now.ToString("HHmmssfff"));
        Cliente cliente = new Cliente(id, ns);

        lock (clientesConectados)
        {
            clientesConectados.Add(cliente);
        }

        try
        {
            while (true)
            {
                Vehiculo vehiculo = NetworkStreamClass.LeerDatosVehiculoNS(ns);
                if (vehiculo == null) break;

                lock (lockObject)
                {
                    carretera.ActualizarVehiculo(vehiculo);
                }

                Console.WriteLine("🛣️ Estado de la carretera actualizado:");
                carretera.MostrarCarretera();

                EnviarCarreteraATodos();
                if (vehiculo.Acabado) break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error con cliente: " + ex.Message);
        }

        lock (clientesConectados)
        {
            clientesConectados.Remove(cliente);
        }

        tcpCliente.Close();
        Console.WriteLine("🔌 Cliente desconectado.");
    }

    static void EnviarCarreteraATodos()
    {
        lock (clientesConectados)
        {
            foreach (Cliente c in clientesConectados)
            {
                try
                {
                    NetworkStreamClass.EscribirDatosCarreteraNS(c.Stream, carretera);
                }
                catch
                {
                    Console.WriteLine("⚠️ Error enviando carretera a un cliente");
                }
            }
        }
    }
}
