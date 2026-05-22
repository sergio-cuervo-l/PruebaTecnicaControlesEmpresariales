using PruebaTecnica.Application.DTOs;

namespace PruebaTecnica.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginRequestDto request);

        Task<bool> RegisterAsync(RegisterRequestDto request);
    }
}
