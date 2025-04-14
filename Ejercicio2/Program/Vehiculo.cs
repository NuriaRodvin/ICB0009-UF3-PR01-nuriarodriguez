namespace Program;

using System.Text.Json;

public class Vehiculo
{
    public int Id { get; set; }
    public int Pos { get; set; }
    public int Velocidad { get; set; }
    public bool Acabado { get; set; }
    public string Direccion { get; set; } = "Norte"; // o "Sur"
    public bool Parado { get; set; }

    public Vehiculo() { }

    public byte[] SerializarVehiculo()
    {
        string json = JsonSerializer.Serialize(this);
        return System.Text.Encoding.UTF8.GetBytes(json);
    }

    public static Vehiculo DeserializarVehiculo(byte[] datos)
    {
        string json = System.Text.Encoding.UTF8.GetString(datos);
        return JsonSerializer.Deserialize<Vehiculo>(json)!;
    }
}
