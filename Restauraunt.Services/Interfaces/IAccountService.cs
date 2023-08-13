﻿using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<Response<ClaimsIdentity>> Login(LoginViewModel model);
        Task<Response<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
