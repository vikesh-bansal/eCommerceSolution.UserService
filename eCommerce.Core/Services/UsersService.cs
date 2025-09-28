using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(UserLoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null) {
            return null;
        }
       // return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
       return _mapper.Map<AuthenticationResponse>(user) with { Success=true, Token="token" }; // with is used to set additional properties

    }

    public async Task<AuthenticationResponse?> Register(UserRegisterRequest userRegisterRequest)
    {
        //Create a new applicationuser object from register request
        ApplicationUser user = new ApplicationUser()
        {
            PersonName= userRegisterRequest.PersonName,
            Email= userRegisterRequest.Email,
            Password= userRegisterRequest.Password,
            Gender= userRegisterRequest.Gender.ToString()
        };
        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);
        if (registeredUser == null) {
            return null;
        }
        //Return success response
        //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Success=true, Token="token" };// with is used to set additional properties
    }
}

