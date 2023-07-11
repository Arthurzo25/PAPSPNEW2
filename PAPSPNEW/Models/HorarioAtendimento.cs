using System;
using System.Collections.Generic;

namespace PAPSPNEW.Models;

public partial class HorarioAtendimento
{
    public int IdPontoTuristico { get; set; }

    public int IdHorarioAtendimento { get; set; }

    public TimeSpan? HorarioIntervalo { get; set; }

    public TimeSpan? HorarioIntervalo2 { get; set; }

    public TimeSpan? HorarioIntervalo3 { get; set; }

    public TimeSpan? HorarioIntervalo4 { get; set; }

    public TimeSpan HorarioInicio { get; set; }

    public TimeSpan HorarioFim { get; set; }

    public string? DiaSemana { get; set; }

    public virtual PontoTuristico IdPontoTuristicoNavigation { get; set; } = null!;
}
