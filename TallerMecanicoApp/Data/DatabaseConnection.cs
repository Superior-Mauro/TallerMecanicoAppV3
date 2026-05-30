using Microsoft.Extensions.Configuration;

namespace TallerMecanicoApp.Data;

public static class DatabaseConnection
{
    private static readonly Lazy<string> ConnectionString = new(ObtenerCadenaConexion);

    public static string Obtener() => ConnectionString.Value;

    private static string ObtenerCadenaConexion()
    {
        var configuracion = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var cadena = configuracion.GetConnectionString("TallerMecanico");
        if (string.IsNullOrWhiteSpace(cadena))
        {
            throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'TallerMecanico' en appsettings.json.");
        }

        return cadena;
    }
}
