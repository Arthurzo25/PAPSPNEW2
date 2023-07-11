using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class Bairro
{
    public int IdBairro { get; set; }

    public int IdPontoTuristico { get; set; }

    public string? NomeBairro { get; set; }

    public virtual PontoTuristico IdPontoTuristicoNavigation { get; set; } = null!;
}
