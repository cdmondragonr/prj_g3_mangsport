using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Torneo
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(80,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    [MinLength(3,ErrorMessage="El campo {0}, debe contener al menos 3 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(50,ErrorMessage="El campo {0}, no puede contener mas de 50 caracteres")]
    [MinLength(10,ErrorMessage="El campo {0}, debe contener al menos 10 caracteres")]
    public string Categoria {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(50,ErrorMessage="El campo {0}, no puede contener mas de 50 caracteres")]
    [MinLength(10,ErrorMessage="El campo {0}, debe contener al menos 10 caracteres")]
    public string Deporte {get; set;}
    
    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public DateTime FechaInicial {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public DateTime FechaFinal {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public int MunicipioId {get; set;}
    public List<TorneoEquipo> TorneoEquipos {get; set;}
    public List<Escenario> Escenarios {get; set;}
    public List<Arbitro> Arbitros {get; set;}
}
