namespace Modelo;

using System;
using System.Collections.Generic;
using System.Text.Json;

public class Carretera
{
    public List<Vehiculo> VehiculosEnCarretera { get; set; } = new();
    public int NumVehiculosEnCarrera { get; set; } = 0;

    public Vehiculo? VehiculoEnPuente { get; set; } = null;

    // BONUS: Colas por dirección
    public Queue<Vehiculo> ColaNorte { get; set; } = new();
    public Queue<Vehiculo> ColaSur { get; set; } = new();

    public string TurnoActual { get; set; } = "Norte"; // Empieza Norte

    public byte[] SerializarCarretera()
    {
        string json = JsonSerializer.Serialize(this);
        return System.Text.Encoding.UTF8.GetBytes(json);
    }

    public static Carretera DeserializarCarretera(byte[] datos)
    {
        string json = System.Text.Encoding.UTF8.GetString(datos);
        return JsonSerializer.Deserialize<Carretera>(json)!;
    }

    public void AñadirVehiculo(Vehiculo v)
    {
        VehiculosEnCarretera.Add(v);
        NumVehiculosEnCarrera++;

        if (v.Direccion == "Norte")
            ColaNorte.Enqueue(v);
        else
            ColaSur.Enqueue(v);
    }

    public void ActualizarVehiculo(Vehiculo v)
    {
        for (int i = 0; i < VehiculosEnCarretera.Count; i++)
        {
            if (VehiculosEnCarretera[i].Id == v.Id)
            {
                VehiculosEnCarretera[i] = v;
                return;
            }
        }
    }

    public void MostrarCarretera()
    {
        foreach (Vehiculo v in VehiculosEnCarretera)
        {
            string estado = v.Parado ? "Esperando" : v.Acabado ? "Finalizado" : "Circulando";
            string barra = GenerarBarra(v.Pos);
            Console.WriteLine($"[{v.Direccion}] Vehículo #{v.Id}: {barra} (km {v.Pos} - {estado})");
        }
    }

    private string GenerarBarra(int posicion)
    {
        int bloques = posicion / 10;
        return new string('|', bloques) + new string('.', 10 - bloques);
    }
}
