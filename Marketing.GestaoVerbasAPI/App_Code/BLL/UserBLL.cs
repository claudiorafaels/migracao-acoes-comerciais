using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class UserBLL
    {
        public static Usuario GetUserByLogin(String login)
        {
            return UserDAL.GetUserByLogin(login);

        }

        public static Usuario GetUserByCodFunc(int? codFunc)
        {
            return UserDAL.GetUserByCodFunc(codFunc);
        }
    }
}