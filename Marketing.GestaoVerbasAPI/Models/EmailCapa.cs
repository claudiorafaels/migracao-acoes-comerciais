using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class EmailCapa
    {
        /// <summary>
        /// TipMsgCreEtn - Código do tipo de email
        /// </summary>
        public int? TipoMensagem { get; set; }

        /// <summary>
        /// Numseqmsgcreetn - Número sequencial do email
        /// </summary>
        public int? NumSeqEmail { get; set; }

        /// <summary>
        /// Dateenvmsgcreetn - Data de envio do email
        /// </summary>
        public DateTime? DataEnvio { get; set; }

        /// <summary>
        /// DesAssCreEtn - Assunto do email
        /// </summary>
        public string Assunto { get; set; }

        /// <summary>
        /// Lista de destinatários
        /// </summary>
        public List<EmailDestinatario> Destinatarios { get; set; }

        /// <summary>
        /// Lista de conteudo
        /// </summary>
        public List<EmailConteudo> Conteudo { get; set; }

        public void AddConteudo(string pConteudo)
        {
            if (this.Conteudo == null)
                this.Conteudo = new List<EmailConteudo>();

            if (pConteudo != null)
            {
                int i = 0;
                while (i <= pConteudo.Length)
                {
                    int j = 0;
                    if (pConteudo.Length > (i + 120))
                        j = 120;
                    else
                        j = (pConteudo.Length - i);

                    Conteudo.Add(new EmailConteudo() {TextoLinha = pConteudo.Substring(i, j) });
                    i += 120;
                }
            }
        }
        public void AddRemetente(string pEmailRemetente)
        {
            if (this.Destinatarios == null)
                this.Destinatarios = new List<EmailDestinatario>();

            Destinatarios.Add(new EmailDestinatario() { DesEmail = pEmailRemetente, TipoEndereco = 1 });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmailDestinatario"></param>
        /// <param name="pTipo">2 - Destinatario, 3 - copia, 4 - copia oculta</param>
        public void AddDestinatario(string pEmailDestinatario, int pTipo = 2)
        {
            if (this.Destinatarios == null)
                this.Destinatarios = new List<EmailDestinatario>();

            Destinatarios.Add(new EmailDestinatario() {DesEmail = pEmailDestinatario, TipoEndereco = pTipo });
        }
    }
}