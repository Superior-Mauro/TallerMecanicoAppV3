namespace TallerMecanicoApp.Models;

public class Vehiculo
{
    public Vehiculo(string placa, string cliente, string modelo, string problema, string telefono = "")
        : this(0, placa, cliente, modelo, problema, telefono)
    {
    }

    public Vehiculo(int id, string placa, string cliente, string modelo, string problema, string telefono = "")
    {
        Id = id;
        Placa = placa;
        Cliente = cliente;
        Modelo = modelo;
        Problema = problema;
        Telefono = telefono;
    }

    public int Id { get; set; }
    public string Placa { get; set; }
    public string Cliente { get; set; }
    public string Modelo { get; set; }
    public string Problema { get; set; }
    public string Telefono { get; set; }
}
