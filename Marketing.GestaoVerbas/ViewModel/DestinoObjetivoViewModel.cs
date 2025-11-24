using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class DestinoObjetivoViewModel
    {
        [Display(Name = "Empenho")]
        public int? CodDestinoObjetivo { get; set; }

        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }

        [Display(Name = "Objetivo")]
        public string NomObjetivo { get; set; }

        [Display(Name = "Objetivo")]
        public int? CodObjetivo { get; set; }

        [Display(Name = "Destino")]
        public int? CodDestino { get; set; }

        [Display(Name = "Destino")]
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
        public string CodNomObjetivo
        {
            get
            {
                return string.Format("{0} - {1}", this.CodObjetivo, this.NomObjetivo);
            }
        }
    }
}