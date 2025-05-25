using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.BusinessLogic.Services.ReadFromSql.Interface;
using InvestmentManage.Domain.Model.User;

namespace InvestmentManage.BusinessLogic.Services.ReadFromSql.Class
{
    internal class GetUserSevice : IGetUserService
    {
        public List<UserM> Execute()
        {
            UserM dev = new UserM()
            {
                Id = 1,
                Name = "Dev",
                LastName = "Developer"
            };
            UserM abalfazl = new UserM()
            {
                Id = 2,
                Name = "Abalfazl",
                LastName = "Eskandari",
                Age = 19
            };
            return new List<UserM>() { dev, abalfazl };
        }
    }
}
