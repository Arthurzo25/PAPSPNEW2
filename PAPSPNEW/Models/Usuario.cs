using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string SobrenomeUsuario { get; set; } = null!;

    public string EmailUsuario { get; set; } = null!;

    public string UserUsuario { get; set; } = null!;

    public string SenhaUsuario { get; set; } = null!;

    public virtual ICollection<AvaliacaoUsu> AvaliacaoUsus { get; set; } = new List<AvaliacaoUsu>();
}
