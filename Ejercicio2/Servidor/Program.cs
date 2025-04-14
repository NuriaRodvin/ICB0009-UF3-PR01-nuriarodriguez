using System;
using System.Net;
using System.Net.Sockets;
using Program;

class ProgramServidor
{
    static void Main(string[] args)
    {
        // Crear carretera vacía
        Carretera carretera = new Carretera();

        // Crear listener en el puerto 5000
        TcpListener servidor = new TcpListener(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🚦 Servidor escuchando en el puerto 5000...");

        while (true)
        {
            Console.WriteLine("📡 Esperando conexión de un cliente...");
            TcpClient cliente = servidor.AcceptTcpClient();
            Console.WriteLine("✅ Cliente conectado.");

            NetworkStream ns = cliente.GetStream();

            Vehiculo v;

            // Recibir actualizaciones hasta que el vehículo termine
            while (true)
            {
                v = NetworkStreamClass.LeerDatosVehiculoNS(ns);
                if (v == null) break;

                carretera.ActualizarVehiculo(v);

                Console.WriteLine($"🛠️ Actualización recibida: ID={v.Id}, Pos={v.Pos}, Acabado={v.Acabado}");
                carretera.MostrarCarretera();

                if (v.Acabado)
                {
                    Console.WriteLine($"✅ Vehículo {v.Id} ha finalizado su recorrido.");
                    break;
                }
            }

            // Cerrar conexión con este cliente
            cliente.Close();
            Console.WriteLine("🔌 Cliente desconectado.\n");
        }
    }
}
