using AutoMapper;
using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Core.Constants;
using HSPExpenseTracker.Core.DAL.UnitOfWork;
using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.DAL.Abstract;
using HSPExpenseTracker.Entities.Dtos;
using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Business.Concreate
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }

        public async Task<ResponseModel<NoDataResponse>> AddNewUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                await _userRepository.Save(user);
                await _unitOfWorkService.CommitAsync();
                return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };

            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }
    }
}
