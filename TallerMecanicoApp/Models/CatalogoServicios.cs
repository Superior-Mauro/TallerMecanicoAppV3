namespace TallerMecanicoApp.Models;

public static class CatalogoServicios
{
    public static readonly Servicio MantenimientoSimple = new(
        "Mantenimiento Simple",
        240m,
        TimeSpan.FromHours(2),
        "Aceite, filtros y revisión de líquidos.");

    public static readonly Servicio MantenimientoRegular = new(
        "Mantenimiento Regular",
        350m,
        TimeSpan.FromMinutes(160),
        "Incluye Simple + limpieza de obturador y revisión de bujías.");

    public static readonly Servicio MantenimientoCompleto = new(
        "Mantenimiento Completo",
        450m,
        TimeSpan.FromMinutes(220),
        "Incluye Regular + revisión de pastillas/zapatas y escáner.");

    public static readonly Servicio Afinamiento = new(
        "Afinamiento",
        250m,
        TimeSpan.FromHours(2),
        "Escáner, obturador, inyectores, filtro de gasolina y bujías.");

    public static List<Servicio> ObtenerTodos()
    {
        return
        [
            MantenimientoSimple,
            MantenimientoRegular,
            MantenimientoCompleto,
            Afinamiento
        ];
    }
}
