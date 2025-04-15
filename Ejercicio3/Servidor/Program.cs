using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using Program;

namespace Servidor;

class Program
{
    static List<Cliente> clientesConectados = new();
    static Carretera carretera = new();

    static void Main(string[] args)
    {
        TcpListener servidor = new(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🚦 Servidor escuchando en el puerto 5000...");

        while (true)
        {
            TcpClient clienteTCP = servidor.AcceptTcpClient();
            NetworkStream ns = clienteTCP.GetStream();
            Console.WriteLine("✅ Cliente conectado.");

            Thread t = new(() =>
            {
                Vehiculo v = NetworkStreamClass.LeerDatosVehiculoNS(ns);
                carretera.AñadirVehiculo(v);

                Cliente c = new(v.Id, ns);
                lock (clientesConectados) clientesConectados.Add(c);

                NetworkStreamClass.EscribirDatosCarreteraNS(ns, carretera);

                while (!v.Acabado)
                {
                    Vehiculo actualizado = NetworkStreamClass.LeerDatosVehiculoNS(ns);
                    carretera.ActualizarVehiculo(actualizado);

                    // Lógica del puente
                    if (carretera.VehiculoEnPuente == null || carretera.VehiculoEnPuente.Id == actualizado.Id)
                    {
                        carretera.VehiculoEnPuente = actualizado;
                        actualizado.Parado = false;
                    }
                    else
                    {
                        actualizado.Parado = true;
                    }

                    if (actualizado.Pos >= 100 && actualizado.Acabado)
                    {
                        carretera.VehiculoEnPuente = null;
                    }

                    carretera.ActualizarVehiculo(actualizado);
                    carretera.MostrarCarretera();
                    EnviarCarreteraATodos();
                }

                lock (clientesConectados) clientesConectados.RemoveAll(c => c.Id == v.Id);
                Console.WriteLine("🔌 Cliente desconectado.");
            });
            t.Start();
        }
    }

    static void EnviarCarreteraATodos()
    {
        lock (clientesConectados)
        {
            foreach (var c in clientesConectados)
            {
                try
                {
                    NetworkStreamClass.EscribirDatosCarreteraNS(c.Stream, carretera);
                }
                catch
                {
                    Console.WriteLine($"❌ Error al enviar a cliente {c.Id}");
                }
            }
        }
    }
}

