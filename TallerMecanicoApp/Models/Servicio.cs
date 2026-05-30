namespace TallerMecanicoApp.Models;

public class Servicio
{
    public Servicio(string nombre, decimal precioBase, TimeSpan tiempoBase, string detalle)
    {
        Nombre = nombre;
        PrecioBase = precioBase;
        TiempoBase = tiempoBase;
        Detalle = detalle;
    }

    public string Nombre { get; set; }
    public decimal PrecioBase { get; set; }
    public TimeSpan TiempoBase { get; set; }
    public string Detalle { get; set; }
}
