using System;
using AutoMapper;
using MediatR;
using WeatherApp.Application.Exception;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Application.Interfaces.Token;
using WeatherApp.Application.Wrappers;

namespace WeatherApp.Application.Features.Commands.LoginUser
{
	public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITokenHandler tokenHandler;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.tokenHandler = tokenHandler;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<WeatherApi.Domain.Entities.User>(request);

            var result = await userRepository.GetAsync(opt => opt.Username == request.Username && opt.Password == request.Password);

            if (result == null)
            {
                throw new NotFoundUserException("Username or password is not correct");            
            }
                         
            return new LoginUserSuccessCommandResponse() { Token = tokenHandler.CreateAccessToken() };
        }
    }
}

