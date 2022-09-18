using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class TorneoEquipo
{
    public int EquipoId { get; set; }
    public int TorneoId { get; set; }
    public Equipo Equipo { get; set; }
    public Torneo Torneo { get; set; }
}
