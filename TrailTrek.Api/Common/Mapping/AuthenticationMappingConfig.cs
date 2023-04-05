using Mapster;
using TrailTrek.Application.Authentication.Commands.Register;
using TrailTrek.Application.Authentication.Common;
using TrailTrek.Application.Authentication.Queries.Login;
using TrailTrek.Contracts.Authentication;

namespace TrailTrek.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();  
            
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
