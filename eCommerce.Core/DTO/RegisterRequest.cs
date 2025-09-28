namespace eCommerce.Core.DTO
{
    public record UserRegisterRequest(
        string? Email,
        string? Password,
        string? PersonName,
        GenderOptions Gender);
     
}
