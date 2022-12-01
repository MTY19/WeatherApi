using System;
using AutoMapper;
using MediatR;
using WeatherApp.Application.Dto;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Application.Wrappers;

namespace WeatherApp.Application.Features.Queries
{
	public class GetAllUsersQuery:IRequest<ServiceResponse<List<UserViewDto>>>
	{

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResponse<List<UserViewDto>>>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public GetAllUsersQueryHandler(IUserRepository userRepository,IMapper mapper)
            {
                this.userRepository = userRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<UserViewDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await userRepository.GetAllAsync();

                var viewModel = mapper.Map<List<UserViewDto>>(users);

                return new ServiceResponse<List<UserViewDto>>(viewModel);
            }
        }
    }
}

