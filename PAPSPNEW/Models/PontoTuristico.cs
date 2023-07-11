using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class PontoTuristico
{
    public int IdPontoTuristico { get; set; }
    public string NomePontoTuristico { get; set; } = "Nome do Ponto Turístico";

    public string DescricaoPontoTuristico { get; set; } = "Ponto Turístico";

    public virtual ICollection<Bairro> Bairros { get; set; } = new List<Bairro>();

    public virtual ICollection<HorarioAtendimento> HorarioAtendimentos { get; set; } = new List<HorarioAtendimento>();

    public virtual ICollection<TipoCategorium> TipoCategoria { get; set; } = new List<TipoCategorium>();

    public virtual ICollection<TipoContato> TipoContatos { get; set; } = new List<TipoContato>();
}
