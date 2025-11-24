using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    /// <summary>
    /// Controlador responvavel pela entidade Histórico da Negociação de Verba
    /// </summary>
    public class UserController : ApiController
    {



        /// <summary>
        /// Consulta usuário por Id de rede
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        [Route("user/{Login}/User")]
        [HttpGet]
        public Usuario GetUserByLoginAD(string Login)
        {
            if (string.IsNullOrWhiteSpace(Login))
            {
                throw new Exception("Favor informar os parâmetros corretamente.");
            }
            return UserBLL.GetUserByLogin(Login);
        }

        ///// <summary>
        ///// Consulta usuário por código
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[Route("User/{id}/User")]
        //[HttpGet]
        //public Usuario GetUserByCodUsuario(int id)
        //{
        //    try
        //    {
        //        return UserBLL.GetUserByCodFunc(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro: Id: " + id.ToString() + ". Erro: " + ex.Message);
        //    }
        //}
    }
}
