using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    /// <summary>
    /// Contract for users service that contains user cases for users
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Method to handle user login user case and returns an Authintication Response object that contains status of login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
         Task<AuthenticationResponse?> Login(UserLoginRequest userLoginRequest);
        /// <summary>
        /// Method to handle user registration use case and returns an object of AuthenticationResponse type that represents status of user registration
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(UserRegisterRequest userRegisterRequest);
        /// <summary>
        /// Returns UserDTO object based on the given UserID
        /// </summary>
        /// <param name="UserID">UserID to search</param>
        /// <returns>UserDTO object based on the matching UserID</returns>
        Task<UserDTO> GetUserByUserID(Guid UserID);
    }
}
