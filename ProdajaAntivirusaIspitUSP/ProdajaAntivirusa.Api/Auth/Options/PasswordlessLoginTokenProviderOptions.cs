using Microsoft.AspNetCore.Identity;

namespace ProdajaAntivirusa.Api.Auth.Options;

public class PasswordlessLoginTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public PasswordlessLoginTokenProviderOptions()
    {
        Name = "PasswordlessLoginTokenProvider";
        TokenLifespan = TimeSpan.FromMinutes(15);
    }
}
