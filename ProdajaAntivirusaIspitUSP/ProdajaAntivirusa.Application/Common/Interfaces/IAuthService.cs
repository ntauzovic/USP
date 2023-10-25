using ProdajaAntivirusa.Application.Common.Dto.Auth;

namespace ProdajaAntivirusa.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}
