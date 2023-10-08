namespace MidnightCityTheater.Utils;

internal class ErrorResponse
{
    private string Message { get; set; }
    private string ErrorCode { get; set; }

    internal ErrorResponse(string message, string errorCode)
    {
        Message = message;
        ErrorCode = errorCode;
    }

    //Frequently used Error Messages:
    internal static ErrorResponse DBisUnavailable = new ErrorResponse("Há um problema com o banco de dados, informe aos administradores do sistema.", "DATABASE_UNAVAILABLE");
    internal static ErrorResponse CPFisNull = new ErrorResponse("O campo CPF está em branco, preencha o campo antes de prosseguir.", "CPF_IS_NULL");
    internal static ErrorResponse CPFisInvalid = new ErrorResponse("CPF inválido. Por favor, insira um CPF válido.", "INVALID_CPF");
    internal static ErrorResponse EmailisInvalid = new ErrorResponse("Email inválido. Por favor, insira um Email válido.", "INVALID_EMAIL");
    internal static ErrorResponse PhoneisInvalid = new ErrorResponse("Telefone inválido. Por favor, insira um número de telefone válido.", "INVALID_PHONE_NUMBER");
    internal static ErrorResponse EntityNotFound = new ErrorResponse("Nenhum registro foi encontrado com este ID.", "NO_ENTITY_FOUND");
}