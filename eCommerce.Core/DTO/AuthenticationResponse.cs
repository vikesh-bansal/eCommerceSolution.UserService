namespace eCommerce.Core.DTO
{
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success
        )
    {
        // Parameter less construction: it was created because it is required for automapper to work
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {

        }
    }
}
