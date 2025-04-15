using System;
using System.Net.Sockets;
using System.Threading;
using Program;


namespace Cliente;

class Program
{
    static void Main(string[] args)
    {
        TcpClient cliente = new("localhost", 5000);
        NetworkStream ns = cliente.GetStream();

        Random rnd = new();
        Vehiculo v = new()
        {
            Id = rnd.Next(100000, 999999),
            Velocidad = rnd.Next(100, 300),
            Direccion = "Norte"
        };

        Console.WriteLine($"🚗 Vehículo creado: ID={v.Id}, Velocidad={v.Velocidad}");

        // Enviar vehículo inicial al servidor
        NetworkStreamClass.EscribirDatosVehiculoNS(ns, v);
        Carretera c = NetworkStreamClass.LeerDatosCarreteraNS(ns);

        bool finCarrera = false;

        // Hilo para escuchar constantemente la carretera
        Thread hiloEscucha = new(() =>
        {
            while (!finCarrera)
            {
                try
                {
                    Carretera datos = NetworkStreamClass.LeerDatosCarreteraNS(ns);
                    Console.Clear();
                    Console.WriteLine("🛣️ Estado de la carretera actualizado:");
                    datos.MostrarCarretera();

                    if (datos.VehiculoEnPuente?.Id == v.Id)
                    {
                        Console.WriteLine("✅ Estás cruzando el puente...");
                    }
                    else if (!v.Acabado)
                    {
                        Console.WriteLine("⛔ Esperando turno: puente ocupado...");
                    }

                    if (v.Acabado)
                    {
                        Console.WriteLine("🏁 Has finalizado tu recorrido.");
                        finCarrera = true;
                    }
                }
                catch
                {
                    Console.WriteLine("❌ Error en hilo escucha. Posible desconexión.");
                    break;
                }
            }
        });
        hiloEscucha.Start();

        // Bucle principal de movimiento del vehículo
        while (!v.Acabado)
        {
            if (!v.Parado)
            {
                v.Pos++;
                if (v.Pos >= 100)
                {
                    v.Acabado = true;
                    Console.WriteLine("✅ Vehículo ha terminado su recorrido.");
                }
            }

            NetworkStreamClass.EscribirDatosVehiculoNS(ns, v);
            Thread.Sleep(v.Velocidad);
        }

        cliente.Close();
        Console.WriteLine("🔌 Conexión cerrada.");
    }
}

