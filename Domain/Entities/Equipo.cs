using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Equipo
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(80,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(50,ErrorMessage="El campo {0}, no puede contener mas de 50 caracteres")]
    [MinLength(10,ErrorMessage="El campo {0}, debe contener al menos 10 caracteres")]
    public string Deporte {get; set;}
    public Entrenador Tecnico {get; set;}
    public List<TorneoEquipo> TorneoEquipos {get; set;}
    public List<Deportista> Deportistas {get; set;}
}
