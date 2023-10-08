namespace MidnightCityTheater.Utils;
using System.Text.RegularExpressions;

internal class EmailUtils
{
    internal static bool IsValidEmail(string email)
    {
        // Padrão de expressão regular para validar endereços de e-mail
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Use Regex.IsMatch para verificar se o e-mail corresponde ao padrão
        return Regex.IsMatch(email, pattern);
    }
}