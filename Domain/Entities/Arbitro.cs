using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Arbitro
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(10,ErrorMessage="El campo {0}, no puede contener mas de 10 caracteres")]
    [MinLength(6,ErrorMessage="El campo {0}, debe contener al menos 6 caracteres")]
    public string Documento {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(80,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    [MinLength(3,ErrorMessage="El campo {0}, debe contener al menos 3 caracteres")]
    public string Nombres {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(80,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    [MinLength(3,ErrorMessage="El campo {0}, debe contener al menos 3 caracteres")]
    public string Apellidos {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(50,ErrorMessage="El campo {0}, no puede contener mas de 50 caracteres")]
    [MinLength(3,ErrorMessage="El campo {0}, debe contener al menos 3 caracteres")]
    public string Deporte {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(3,ErrorMessage="El campo {0}, no puede contener mas de 3 caracteres")]
    [MinLength(2,ErrorMessage="El campo {0}, debe contener al menos 2 caracteres")]
    public string Rh {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public int ColegioId {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    public int TorneoId {get; set;}

}
