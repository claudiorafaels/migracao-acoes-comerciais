using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class NegociacaoVerbaDestinoViewModel
    {
        [Display(Name = "Negociação")]
        public int? CodNegociacaoVerba { get; set; }

        [Display(Name = "Empenho")]
        [Required()]
        public int CodDestinoObjetivo { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        [Required()]
        public decimal? VlrVerba { get; set; }

        [Display(Name = "Observação")]
        [StringLength(2400)]
        public string DesObservacao { get; set; }

        [Display(Name = "Acordo")]
        public int? CodPromessa { get; set; }

        //Auxiliares
        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }

        [Display(Name = "Destino")]
        public int? CodDestino { get; set; }

        [Display(Name = "Objetivo")]
        public int? CodObjetivo { get; set; }

        [Display(Name = "Destino")]
        [StringLength(500)]
        public string NomDestino
        {
            get
            {
                switch (CodDestino)
                {
                    case 1:
                        return "Ações Comerciais";
                    case 2:
                        return "Ações em Preço";
                    case null:
                        return "";
                    default:
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodDestino);
                }
            }
        }

        [Display(Name = "Objetivo")]
        [StringLength(500)]
        public string NomObjetivo { get; set; }


        [Display(Name = "Carimbo")]
        public int? CodCarimbo { get; set; }

    }
}