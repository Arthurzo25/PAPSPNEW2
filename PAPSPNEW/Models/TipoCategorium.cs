using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class TipoCategorium
{
    public int IdCategoria { get; set; }

    public int IdPontoTuristico { get; set; }

    public string Categoria { get; set; } = null!;

    public virtual PontoTuristico IdPontoTuristicoNavigation { get; set; } = null!;
}
