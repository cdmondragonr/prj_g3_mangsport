using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Espacio
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(50,ErrorMessage="El campo {0}, no puede contener mas de 50 caracteres")]
    [MinLength(10,ErrorMessage="El campo {0}, debe contener al menos 10 caracteres")]
    public string Disciplina {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [Range(1, 999999, ErrorMessage="Ingrese la capacidad maxima del numero de espectadores")]
    public int Epectadores {get; set;}
    
    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public int EsenarioId {get; set;}
}
