namespace MidnightCityTheater.Utils;

internal class TelefoneUtils
{
    internal static string FormatPhoneNumber(string phoneNumber)
    {
        if(phoneNumber == null || phoneNumber == "string") return "";
        // Remove todos os caracteres não numéricos do número de telefone
        string numericPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());
        return numericPhoneNumber;
    }

    internal static bool IsValidPhoneNumber(string phoneNumber)
    {
        // Formate o número de telefone
        string formattedPhoneNumber = FormatPhoneNumber(phoneNumber);

        // Verifique se o número de telefone tem entre 9 e 12 dígitos
        return formattedPhoneNumber.Length >= 9 && formattedPhoneNumber.Length <= 12;
    }
}