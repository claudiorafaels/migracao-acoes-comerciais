using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class NegociacaoVerbaHistoricoViewModel
    {
        [Display(Name = "Observação")]
        [StringLength(2400)]
        [Required()]
        public string DesJustificativaReprovacao { get; set; }

        [Key]
        [Display(Name = "Cod. Negociação")]
        public int? CodNegociacaoVerba { get; set; }

        [Key]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Dt. Registro")]
        [DataType(DataType.Text)]
        public DateTime? DtHistorico { get; set; }

        [Display(Name = "Status")]
        public int? CodStatusNegociacaoVenda { get; set; }

        [Display(Name = "Funcionário")]
        public int? CodFuncionario { get; set; }


        #region "campos auxiliares"

        [Display(Name = "Funcionário")]
        public string NomFuncionario { get; set; }

        [Display(Name = "Status")]
        public string NomStatusNegociacaoVenda
        {
            get
            {
                switch (CodStatusNegociacaoVenda)
                {
                    case 1:
                        return "Nova";
                    case 2:
                        return "Aguardando Aprovação";
                    case 3:
                        return "Aprovado";
                    case 4:
                        return "Reprovado";
                    case null:
                        return "";
                    default:
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodStatusNegociacaoVenda);
                }
            }
        }
        #endregion
    }
}