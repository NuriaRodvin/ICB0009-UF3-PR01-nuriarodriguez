using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
    static int siguienteId = 1;
    static object lockId = new object();
    static Random rnd = new Random();

    static void Main()
    {
        TcpListener servidor = new TcpListener(IPAddress.Any, 5000);
        servidor.Start();
        Console.WriteLine("🟢 Servidor en espera de conexiones...");

        while (true)
        {
            try
            {
                TcpClient cliente = servidor.AcceptTcpClient();

                Thread hiloCliente = new Thread(() =>
                {
                    int idVehiculo;
                    string direccion;

                    lock (lockId)
                    {
                        idVehiculo = siguienteId++;
                        direccion = rnd.Next(2) == 0 ? "norte" : "sur";
                    }

                    Console.WriteLine($"🚗 Vehículo ID {idVehiculo} conectado desde {cliente.Client.RemoteEndPoint} y va hacia el {direccion.ToUpper()}");

                    NetworkStream stream = cliente.GetStream();
                    Console.WriteLine($"📡 Stream de red abierto para el vehículo ID {idVehiculo}.");

                    // Handshake
                    string mensajeInicio = NetworkStreamClass.LeerMensajeNetworkStream(stream);
                    if (mensajeInicio == "INICIO")
                    {
                        Console.WriteLine("🤝 Inicio de handshake recibido.");
                        NetworkStreamClass.EscribirMensajeNetworkStream(stream, idVehiculo.ToString());

                        string confirmacion = NetworkStreamClass.LeerMensajeNetworkStream(stream);
                        if (confirmacion == idVehiculo.ToString())
                        {
                            Console.WriteLine($"✅ Cliente {idVehiculo} ha confirmado su ID correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Confirmación de ID incorrecta.");
                        }
                    }

                    cliente.Close();
                });

                hiloCliente.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al aceptar cliente: " + ex.Message);
            }
        }
    }
}




