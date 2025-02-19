﻿

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Errors;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //1. Validate the user doesn't exist
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException("User with given email already exists");
            }

            //2. Create the user (generate unique id) & Persist to DB 
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.CreateUser(user);

            //3. Create JWT Token


            //Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }

        public AuthenticationResult Login(string email, string password)
        {
            //1. Validate the user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email doesn't exist");
            }

            //2. Validate the password
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            //3. Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}
