using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class TipoEntradum
{
    public int IdEntrada { get; set; }

    public int IdPontoTuristico { get; set; }

    public decimal? ValorEstudante { get; set; }

    public decimal? ValorProfessor { get; set; }

    public decimal? ValorAdulto { get; set; }

    public decimal? ValorMaior60 { get; set; }

    public decimal? ValorAcompanhantePcd { get; set; }

    public string? EntradaGratuita { get; set; }

    public string? EntradaGratuita1 { get; set; }

    public string? EntradaGratuita2 { get; set; }

    public string? EntradaGratuita3 { get; set; }
}
