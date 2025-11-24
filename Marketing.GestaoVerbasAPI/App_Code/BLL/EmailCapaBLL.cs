using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class EmailCapaBLL
    {

        public static EmailCapa Insert(EmailCapa obj)
        {
            obj.DataEnvio = DateTime.Now;

            obj = EmailCapaDAL.Insert(obj);

            if (obj.Destinatarios != null)
            {
                int numDestinatario = 1;
                foreach (EmailDestinatario dest in obj.Destinatarios)
                {
                    dest.TipoMensagem = obj.TipoMensagem;
                    dest.NumSeqEmail = obj.NumSeqEmail;
                    dest.NumSeqEndereco = numDestinatario;

                    EmailDestinatarioBLL.Insert(dest);
                    numDestinatario += 1;
                }
            }

            if (obj.Conteudo != null)
            {
                int numeroLinha = 1;
                foreach (EmailConteudo cont in obj.Conteudo)
                {
                    cont.TipoMensagem = obj.TipoMensagem;
                    cont.NumSeqEmail = obj.NumSeqEmail;
                    cont.NumSeqLinha = numeroLinha;

                    EmailConteudoBLL.Insert(cont);
                    numeroLinha += 1;
                }
            }

            return obj;
        }
    }
}