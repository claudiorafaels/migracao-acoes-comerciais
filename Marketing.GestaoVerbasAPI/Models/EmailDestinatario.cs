using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class EmailDestinatario
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
        /// TipEndCreEtn - Tipo de endereço de email
        /// </summary>
        public int? TipoEndereco { get; set; }

        /// <summary>
        /// Numseqendcreetn - Número Sequencial do endereço de email
        /// </summary>
        public int? NumSeqEndereco { get; set; }

        /// <summary>
        /// IdtEndCreEtn - Email do destinatário
        /// </summary>
        public string DesEmail { get; set; }



    }
}