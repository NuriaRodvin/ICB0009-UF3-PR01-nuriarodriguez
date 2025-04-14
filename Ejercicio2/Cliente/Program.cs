using System;
using System.Net.Sockets;
using System.Threading;
using Program;

class ProgramCliente
{
    static void Main(string[] args)
    {
        try
        {
            // Crear conexión al servidor
            TcpClient cliente = new TcpClient("127.0.0.1", 5000);
            Console.WriteLine("🔗 Conectado al servidor");

            NetworkStream ns = cliente.GetStream();

            // Crear vehículo
            Vehiculo v = new Vehiculo()
            {
                Id = int.Parse(DateTime.Now.ToString("HHmmssfff")),
                Pos = 0,
                Velocidad = new Random().Next(100, 500),
                Acabado = false,
                Direccion = "Norte", // o "Sur"
                Parado = false
            };

            Console.WriteLine($"🚗 Vehículo creado: ID={v.Id}, Vel={v.Velocidad}, Dir={v.Direccion}");

            // Bucle de movimiento
            while (v.Pos <= 100)
            {
                NetworkStreamClass.EscribirDatosVehiculoNS(ns, v);
                Thread.Sleep(v.Velocidad);
                v.Pos++;

                Console.WriteLine($"➡️ Avanzando: ID={v.Id}, Pos={v.Pos}");

                if (v.Pos >= 100)
                {
                    v.Acabado = true;
                    NetworkStreamClass.EscribirDatosVehiculoNS(ns, v);
                    Console.WriteLine($"✅ Vehículo {v.Id} ha terminado su recorrido.");
                    break;
                }
            }

            cliente.Close();
            Console.WriteLine("🔌 Conexión cerrada");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error en el cliente: " + ex.Message);
        }
    }
}