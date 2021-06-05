using AutoMapper;
using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.Enums;
using Library.DAL.Stores;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignInResult = Library.BLL.Models.SignInResult;

namespace Library.BLL.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(Guid id);
        Task<SignInResult> SignIn(AuthModel model);
        Task<IdentityResult> SignUp(SignUpModel model);
        Task<UserDTO> UpdateUser(UserDTO userDTO, Guid userId);
    }

    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserStore _userStore;
        private readonly IMapper _mapper;

        public UserService(ITokenService tokenService,
                           IUserStore userStore,
                           IMapper mapper)
        {
            _tokenService = tokenService;
            _userStore = userStore;
            _mapper = mapper;
        }

        public async Task<SignInResult> SignIn(AuthModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var existingUser = await _userStore.FindByEmail(model.Login);

            if (existingUser != null)
            {
                if (await _userStore.CheckPassword(existingUser, model.Password))
                {
                    return new SignInResult
                    {
                        IsSuccess = true,
                        Token = _tokenService.GenerateJwtToken(existingUser),
                        ErrorCode = null
                    };
                }

                return new SignInResult
                {
                    IsSuccess = false,
                    ErrorCode = ErrorCode.InvalidPassword
                };
            }

            return new SignInResult
            {
                IsSuccess = false,
                ErrorCode = ErrorCode.InvalidLogin
            };
        }

        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var newUser = new User
            {
                Email = model.LastName + " " + model.FirstName + " " + model.Patronymic,
                UserName = model.Number,
                Number = model.Number,
                Status = model.Status,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                Faculty = model.Faculty,
                Course = model.Course,
                Speciality = model.Speciality,
                Department = model.Department,
                Position = model.Position,
                Gender = model.Gender,
                RoleId = await _userStore.GetBasicRoleId()
            };

            return await _userStore.Create(newUser, model.Number);
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            var user = await _userStore.GetById(id);

            if (user == null)
                throw new NullReferenceException();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO, Guid userId)
        {
            if (userDTO == null || userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userDTO));

            var userToUpdate = await _userStore.GetById(userId);

            if (userToUpdate == null)
                throw new NullReferenceException();

            var existingUser = await _userStore.FindByEmail(userDTO.LastName + " " + userDTO.FirstName + " " + userDTO.Patronymic);

            if (existingUser != null && existingUser.Id != userToUpdate.Id)
            {
                throw new Exception("duplicate login");
            }

            userToUpdate.Email = userDTO.LastName + " " + userDTO.FirstName + " " + userDTO.Patronymic;
            userToUpdate.LastName = userDTO.LastName;
            userToUpdate.FirstName = userDTO.FirstName;
            userToUpdate.Patronymic = userDTO.Patronymic;
            userToUpdate.PhoneNumber = userDTO.PhoneNumber;
            userToUpdate.NormalizedEmail = userToUpdate.Email.ToUpper(CultureInfo.InvariantCulture);
            userToUpdate.NormalizedUserName = userToUpdate.UserName.ToUpper(CultureInfo.InvariantCulture);

            await _userStore.Update(userToUpdate);

            return _mapper.Map<UserDTO>(await _userStore.GetById(userId));
        }
    }
}
