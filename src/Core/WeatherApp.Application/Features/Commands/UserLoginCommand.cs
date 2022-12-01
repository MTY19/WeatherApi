using System;
using AutoMapper;
using MediatR;
using WeatherApp.Application.Dto;
using WeatherApp.Application.Exception;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Application.Wrappers;

namespace WeatherApp.Application.Features.Commands
{
	public class UserLoginCommand:IRequest<ServiceResponse<Guid>>
	{
		public string Username { get; set; }
        public string Password { get; set; }

        public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ServiceResponse<Guid>>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public UserLoginCommandHandler(IUserRepository userRepository,IMapper mapper)
            {
                this.userRepository = userRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                var user = mapper.Map<WeatherApi.Domain.Entities.User>(request);

                var result =await userRepository.GetAsync(opt => opt.Username == request.Username && opt.Password == request.Password);

                if(result != null)
                {

                    return new ServiceResponse<Guid>(Guid.NewGuid());
                }

                throw new NotFoundUserException("Username or password is not correct");
            }
        }

    }
}

