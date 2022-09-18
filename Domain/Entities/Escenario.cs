using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Escenario
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    public string Direccion {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public int TorneoId {get; set;}
    public List<Espacio> Espacios {get; set;}

}
