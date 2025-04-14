using System.Net.Sockets;

public class Cliente
{
    public int Id { get; set; }
    public NetworkStream Stream { get; set; }

    public Cliente(int id, NetworkStream stream)
    {
        Id = id;
        Stream = stream;
    }
}
