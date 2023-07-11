using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public string Logradouro { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string NroEnd { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public int IdBairro { get; set; }

    public int IdPontoTuristico { get; set; }

    public virtual Bairro IdBairroNavigation { get; set; } = null!;

    public virtual PontoTuristico IdPontoTuristicoNavigation { get; set; } = null!;
}
