using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class AcordoRecebimento
    {

        /// <summary>
        /// DESFRMDSCBNF CHAR(30 BYTE)
        /// </summary>
        public string NomFormaRecebimento { get; set; }

        /// <summary>
        /// CODEMP
        /// </summary>
        public int? CodEmpresa { get; set; }

        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodFilialEmpresa { get; set; }

        /// <summary>
        /// CODPMS
        /// </summary>
        public int? CodPromessa { get; set; }

        /// <summary>
        /// DATPRVRCBPMS
        /// </summary>
        public DateTime? DtPrevisaoRecebimento { get; set; }

        /// <summary>
        /// TIPFRMDSCBNF
        /// </summary>
        public int? CodFormaRecebimento { get; set; }


        /// <summary>
        /// TIPDSNDSCBNF - TIPO DESTINO / DESCONTO BONIFICADO                                    
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// DATNGCPMS
        /// </summary>
        public DateTime? DtNegociacaoAcordo { get; set; }

        /// <summary>
        /// VLRNGCPMS                               
        /// </summary>
        public decimal? VlrNegociado{ get; set; }

        /// <summary>
        /// VLRPGOPMS                               
        /// </summary>
        public decimal? VlrPago{ get; set; }

        /// <summary>
        /// VLREFTPMS                               
        /// </summary>
        public decimal? VlrEfetivo{ get; set; }

        /// <summary>
        /// VLRNGCPMSANTARR                               
        /// </summary>
        public decimal? VLRNGCPMSANTARR { get; set; }

        /// <summary>
        /// VLRPDAPMS                               
        /// </summary>
        public decimal? VLRPDAPMS { get; set; }

        /// <summary>
        /// VLRRCTPMS                               
        /// </summary>
        public decimal? VLRRCTPMS { get; set; }

        /// <summary>
        /// INDASCARDFRNPMS                               
        /// </summary>
        public int? INDASCARDFRNPMS { get; set; }


        //auxiliares
        /// <summary>
        /// Nome do empenho ( destino objetivo)
        /// </summary>
        public string NomDestinoObjetivo { get; set; }
    }
}