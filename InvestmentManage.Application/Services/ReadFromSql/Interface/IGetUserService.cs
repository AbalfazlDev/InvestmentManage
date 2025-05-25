using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Domain.Model.User;

namespace InvestmentManage.BusinessLogic.Services.ReadFromSql.Interface
{
    public interface IGetUserService
    {
        public List<UserM> Execute();
    }
}
