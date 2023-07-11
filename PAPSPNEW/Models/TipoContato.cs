using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class TipoContato
{
    public int IdContato { get; set; }

    public string? Email { get; set; }

    public string? TelefoneComer { get; set; }

    public string? Celular { get; set; }

    public int IdPontoTuristico { get; set; }

    public string? Telefone1 { get; set; }

    public string? Whatsapp { get; set; }

    public virtual PontoTuristico IdPontoTuristicoNavigation { get; set; } = null!;
}
