using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class EmailConteudo
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
        /// Numseqlnhfiscreetn - Número Sequencial Linha do Conteudo
        /// </summary>
        public int? NumSeqLinha { get; set; }

        /// <summary>
        /// DESTXTLNHFISCREETN
        /// </summary>
        public string TextoLinha { get; set; }


    }
}