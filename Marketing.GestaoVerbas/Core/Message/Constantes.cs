using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Marketing.GestaoVerbas.Core.Message
{
    public class Constantes
    {
        public const string TEMP_DATA_KEY = "TEMP_DATA_KEY";
        public const string VIEW_ALERTAS = "~/Views/Shared/_Alerts.cshtml";
        public const string VIEW_MENU = "~/Views/Shared/_Menu.cshtml";
        public const string VIEW_NAVBAR_BUTTONS = "~/Views/Shared/_NavbarButtons.cshtml";

        public const string NENHUM_REGISTRO_ENCONTRADO = "Nenhum registro encontrado para esse filtro.";
        public const string REGISTRO_INCLUIDO_SUCESSO = "Registro Incluído com sucesso!";
        public const string REGISTRO_ALTERADO_SUCESSO = "Registro Alterado com sucesso!";
        public const string REGISTRO_EXCLUIDO_SUCESSO = "Registro Excluído com sucesso!";
        public const string REGISTROS_EXCLUIDOS_SUCESSO = "Registros Excluídos com sucesso!";
        public const string REGISTRO_DUPLICADO = "Este registro já foi incluído e não pode ser duplicado!";
        public const string FILTRO_OBRIGATORIO = "Entre com algum filtro para a pesquisa!";
        public const string ARQUIVO_INEXISTENTE = "Arquivo inexistente";
        public const string NAO_EXISTEM_REGISTROS_REMOVER = "Não existem registros para serem removidos.";
        public const string INFORME_FILTRO = "Informe o filtro!";
    }
}
