using Microsoft.Data.SqlClient;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp.Data;

public sealed class TallerRepository
{
    public IReadOnlyList<Vehiculo> ObtenerVehiculos()
    {
        const string sql =
            """
            SELECT Id, Placa, Cliente, Telefono, Modelo, Problema
            FROM dbo.Vehiculos
            ORDER BY FechaRegistro DESC, Id DESC;
            """;

        var vehiculos = new List<Vehiculo>();

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            vehiculos.Add(new Vehiculo(
                lector.GetInt32(0),
                lector.GetString(1),
                lector.GetString(2),
                lector.GetString(4),
                lector.GetString(5),
                lector.GetString(3)));
        }

        return vehiculos;
    }

    public bool ExistePlaca(string placa)
    {
        const string sql =
            """
            SELECT 1
            FROM dbo.Vehiculos
            WHERE Placa = @placa;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", placa);
        return comando.ExecuteScalar() is not null;
    }

    public void RegistrarVehiculo(Vehiculo vehiculo)
    {
        const string sql =
            """
            INSERT INTO dbo.Vehiculos (Placa, Cliente, Telefono, Modelo, Problema)
            VALUES (@placa, @cliente, @telefono, @modelo, @problema);
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
        comando.Parameters.AddWithValue("@cliente", vehiculo.Cliente);
        comando.Parameters.AddWithValue("@telefono", vehiculo.Telefono);
        comando.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
        comando.Parameters.AddWithValue("@problema", vehiculo.Problema);
        comando.ExecuteNonQuery();
    }

    public IReadOnlyList<Trabajo> ObtenerTrabajos()
    {
        const string sql =
            """
            SELECT Id, Placa, Mecanico, Descripcion, Estado, ServicioNombre, PrecioBase, TiempoBaseMinutos,
                   CambioRefrigerante, CambioLiquidoFrenos, CambioBujias, TotalPagar, TiempoEstimadoMinutos
            FROM dbo.Trabajos
            ORDER BY FechaRegistro DESC, Id DESC;
            """;

        var trabajos = new List<Trabajo>();

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            trabajos.Add(new Trabajo
            {
                Id = lector.GetInt32(0),
                Placa = lector.GetString(1),
                Mecanico = lector.GetString(2),
                Descripcion = lector.GetString(3),
                Estado = lector.GetString(4),
                ServicioNombre = lector.GetString(5),
                PrecioBase = lector.GetDecimal(6),
                TiempoBase = TimeSpan.FromMinutes(lector.GetInt32(7)),
                CambioRefrigerante = lector.GetBoolean(8),
                CambioLiquidoFrenos = lector.GetBoolean(9),
                CambioBujias = lector.GetBoolean(10),
                TotalPagar = lector.GetDecimal(11),
                TiempoEstimado = TimeSpan.FromMinutes(lector.GetInt32(12))
            });
        }

        return trabajos;
    }

    public void RegistrarTrabajo(Trabajo trabajo)
    {
        const string sql =
            """
            INSERT INTO dbo.Trabajos
            (
                Placa, Mecanico, Descripcion, Estado, ServicioNombre, PrecioBase, TiempoBaseMinutos,
                CambioRefrigerante, CambioLiquidoFrenos, CambioBujias, TotalPagar, TiempoEstimadoMinutos
            )
            VALUES
            (
                @placa, @mecanico, @descripcion, @estado, @servicioNombre, @precioBase, @tiempoBaseMinutos,
                @cambioRefrigerante, @cambioLiquidoFrenos, @cambioBujias, @totalPagar, @tiempoEstimadoMinutos
            );
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", trabajo.Placa);
        comando.Parameters.AddWithValue("@mecanico", trabajo.Mecanico);
        comando.Parameters.AddWithValue("@descripcion", trabajo.Descripcion);
        comando.Parameters.AddWithValue("@estado", trabajo.Estado);
        comando.Parameters.AddWithValue("@servicioNombre", trabajo.ServicioNombre);
        comando.Parameters.AddWithValue("@precioBase", trabajo.PrecioBase);
        comando.Parameters.AddWithValue("@tiempoBaseMinutos", (int)trabajo.TiempoBase.TotalMinutes);
        comando.Parameters.AddWithValue("@cambioRefrigerante", trabajo.CambioRefrigerante);
        comando.Parameters.AddWithValue("@cambioLiquidoFrenos", trabajo.CambioLiquidoFrenos);
        comando.Parameters.AddWithValue("@cambioBujias", trabajo.CambioBujias);
        comando.Parameters.AddWithValue("@totalPagar", trabajo.TotalPagar);
        comando.Parameters.AddWithValue("@tiempoEstimadoMinutos", (int)trabajo.TiempoEstimado.TotalMinutes);
        comando.ExecuteNonQuery();
    }

    private static SqlConnection AbrirConexion()
    {
        var conexion = new SqlConnection(DatabaseConnection.Obtener());
        conexion.Open();
        return conexion;
    }
}
