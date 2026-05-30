using System.Text.RegularExpressions;

namespace TallerMecanicoApp.Helpers;

public static partial class PlacaValidator
{
    [GeneratedRegex("^[A-Z0-9-]{4,15}$", RegexOptions.CultureInvariant)]
    private static partial Regex FormatoPlacaRegex();

    public static bool EsValida(string placa, out string mensaje)
    {
        if (string.IsNullOrWhiteSpace(placa))
        {
            mensaje = "La placa es obligatoria.";
            return false;
        }

        var placaNormalizada = placa.Trim().ToUpperInvariant();

        if (!FormatoPlacaRegex().IsMatch(placaNormalizada))
        {
            mensaje = "La placa debe tener entre 4 y 15 caracteres (letras, números o guion).";
            return false;
        }

        if (!placaNormalizada.Any(char.IsDigit))
        {
            mensaje = "La placa debe incluir al menos un número (ejemplo: AWS2022).";
            return false;
        }

        mensaje = string.Empty;
        return true;
    }

    public static string Normalizar(string placa) => placa.Trim().ToUpperInvariant();
}
