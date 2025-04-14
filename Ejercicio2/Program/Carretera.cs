namespace Program;

using System;
using System.Collections.Generic;
using System.Text.Json;

public class Carretera
{
    public List<Vehiculo> VehiculosEnCarretera { get; set; } = new List<Vehiculo>();
    public int NumVehiculosEnCarrera { get; set; } = 0;

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
            string barra = GenerarBarra(v.Pos);
            Console.WriteLine($"[{v.Direccion}] Vehículo #{v.Id}: {barra} (km {v.Pos} - {(v.Parado ? "Esperando" : (v.Acabado ? "Finalizado" : "Circulando"))})");
        }
    }

    private string GenerarBarra(int posicion)
    {
        int bloques = posicion / 10;
        return new string('|', bloques) + new string('.', 10 - bloques);
    }
}
