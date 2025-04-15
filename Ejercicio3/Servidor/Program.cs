using System.Net;
using System.Net.Sockets;
using Modelo;

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
                    bool puedeCruzar = false;

                    lock (carretera)
                    {
                        // Si el puente está libre
                        if (carretera.VehiculoEnPuente == null)
                        {
                            // Turno y dirección coinciden + es primero en su cola
                            if (actualizado.Direccion == carretera.TurnoActual)
                            {
                                var cola = (actualizado.Direccion == "Norte") ? carretera.ColaNorte : carretera.ColaSur;
                                if (cola.Count > 0 && cola.Peek().Id == actualizado.Id)
                                {
                                    carretera.VehiculoEnPuente = actualizado;
                                    puedeCruzar = true;
                                    cola.Dequeue();
                                }
                            }
                        }
                        else if (carretera.VehiculoEnPuente.Id == actualizado.Id)
                        {
                            puedeCruzar = true;
                        }

                        actualizado.Parado = !puedeCruzar;

                        if (actualizado.Pos >= 100 && actualizado.Acabado)
                        {
                            carretera.VehiculoEnPuente = null;

                            // Cambiar turno
                            carretera.TurnoActual = carretera.TurnoActual == "Norte" ? "Sur" : "Norte";
                        }

                        carretera.ActualizarVehiculo(actualizado);
                        carretera.MostrarCarretera();
                    }

                    EnviarCarreteraATodos();

                    Thread.Sleep(50);
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

