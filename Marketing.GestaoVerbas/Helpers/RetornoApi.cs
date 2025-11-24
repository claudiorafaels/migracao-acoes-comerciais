using System;

public class RetornoApi
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Resultado { get; set; }
    public Enumeradores.TipoAlerta TpAlerta { get; set; }
    public string Stacktrace { get; set; }
    public string InnerException { get; set; }

    public RetornoApi()
    {
        Sucesso = true;
        TpAlerta = Enumeradores.TipoAlerta.Sucesso;
    }

    public RetornoApi(string msgSucesso)
    {
        Sucesso = true;
        Mensagem = msgSucesso;
        TpAlerta = Enumeradores.TipoAlerta.Sucesso;
    }

    public static RetornoApi RetornoAlerta(string msg)
    {
        RetornoApi retorno = new RetornoApi();
        retorno.SetaAlerta(msg);

        return retorno;
    }

    public static RetornoApi RetornoErro(string msg)
    {
        RetornoApi retorno = new RetornoApi
        {
            Sucesso = false,
            Mensagem = msg,
            TpAlerta = Enumeradores.TipoAlerta.Erro
        };

        Util.EnviarEmailErro(msg, null, null);

        return retorno;
    }

    public void SetaAlerta(string msg, bool enviaEmail = false)
    {
        Sucesso = false;
        TpAlerta = Enumeradores.TipoAlerta.Alerta;
        Mensagem = msg;

        if (enviaEmail)
        {
            Util.EnviarEmailErro(Mensagem, null, null);
        }
    }

    public void SetaExcecao(Exception ex, string mensagemPrefixo = null)
    {
        Sucesso = false;
        TpAlerta = Enumeradores.TipoAlerta.Erro;
        Mensagem = ex.Message;
        Stacktrace = ex.StackTrace;

        if (ex.InnerException != null)
        {
            InnerException = ex.InnerException.ToString();
            Mensagem += InnerException;
        }

        if (mensagemPrefixo != null)
        {
            Mensagem = mensagemPrefixo + Mensagem;
        }

        Util.EnviarEmailErro(Mensagem, Stacktrace, InnerException);
    }

    public string TituloAlerta
    {
        get
        {
            switch (TpAlerta)
            {
                case Enumeradores.TipoAlerta.Sucesso:
                    return "Sucesso!";

                case Enumeradores.TipoAlerta.Alerta:
                    return "Atenção!";

                case Enumeradores.TipoAlerta.Erro:
                    return "Erro!";

                case Enumeradores.TipoAlerta.Informativo:
                    return "Informação!";

                default:
                    return "";
            }
        }
    }

    public string CssAlerta
    {
        get
        {
            switch (TpAlerta)
            {
                case Enumeradores.TipoAlerta.Sucesso:
                    return "success";

                case Enumeradores.TipoAlerta.Alerta:
                    return "warning";

                case Enumeradores.TipoAlerta.Erro:
                    return "danger";

                case Enumeradores.TipoAlerta.Informativo:
                    return "info";

                default:
                    return "";
            }
        }
    }
}