using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class AvaliacaoUsu
{
    public int IdUsuario { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public DateTime DataVisita { get; set; }

    public string AvaliacaoUsuario { get; set; } = null!;

    public string ComentarioUsuario { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
