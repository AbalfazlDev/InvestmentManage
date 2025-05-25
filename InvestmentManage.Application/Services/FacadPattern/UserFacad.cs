using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.BusinessLogic.Services.ReadFromSql.Class;
using InvestmentManage.BusinessLogic.Services.ReadFromSql.Interface;

namespace InvestmentManage.BusinessLogic.Services.FacadPattern
{
    public class UserFacad
    {
        private IGetUserService _GetUser;

        public IGetUserService GetUser
        {
            get { return _GetUser = _GetUser ?? new GetUserSevice(); }
        }

    }
}
