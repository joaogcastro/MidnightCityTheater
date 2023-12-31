namespace MidnightCityTheater.Utils;

internal class CPFUtils
{
    internal static string FormatCPF(string cpf)
    {
        // Remove todos os caracteres não numéricos do CPF
        string numericCPF = new string(cpf.Where(char.IsDigit).ToArray());
        return numericCPF;
    }

    internal static bool IsCpfValid(string cpf)
    {
        if(cpf == null) return false;

        // Remove caracteres não numéricos do CPF
        cpf = CPFUtils.FormatCPF(cpf);

        // Verifica se o CPF possui 11 dígitos
        if (cpf.Length != 11)
        {
            return false;
        }

        // Verifica se todos os dígitos do CPF são iguais (CPF inválido)
        if (cpf.All(c => c == cpf[0]))
        {
            return false;
        }

        // Calcula o primeiro dígito verificador
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (cpf[i] - '0') * (10 - i);
        }
        int remainder = sum % 11;
        int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

        // Verifica se o primeiro dígito verificador está correto
        if (firstDigit != (cpf[9] - '0'))
        {
            return false;
        }

        // Calcula o segundo dígito verificador
        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += (cpf[i] - '0') * (11 - i);
        }
        remainder = sum % 11;
        int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

        // Verifica se o segundo dígito verificador está correto
        if (secondDigit != (cpf[10] - '0'))
        {
            return false;
        }

        return true;
    }
    
}