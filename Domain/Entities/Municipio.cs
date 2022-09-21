using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Municipio
{
    public int Id {get; set;}
    
    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(40,ErrorMessage="El campo {0}, no puede contener mas de 40 caracteres")]
    [MinLength(4,ErrorMessage="El campo {0}, debe contener al menos 4 caracteres")]
    public string Nombre {get; set;}
    public List<Torneo> Torenos {get; set;}
}
