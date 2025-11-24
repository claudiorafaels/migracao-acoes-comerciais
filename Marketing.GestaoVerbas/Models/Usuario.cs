using System;
using System.Configuration;

public class Usuario
{
    public string Nome { get; set; }
    public string IdRede { get; set; }
    public Int32 Matricula { get; set; }
    public string Email { get; set; }
    public bool Admin { get; set; }
    public string CentroCusto { get; set; }
    public decimal CodEmpresa { get; set; }
    public decimal CodFilial { get; set; }

    public bool PermiteAprovacao
    {
        get
        {
            bool permite = false;

            string adminPodeAprovar = ConfigurationManager.AppSettings["adminPodeAprovar"];
            Boolean.TryParse(adminPodeAprovar, out permite);

            return (!Admin || permite);
        }
    }
}