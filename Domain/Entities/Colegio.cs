using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Colegio
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(10,ErrorMessage="El campo {0}, no puede contener mas de 10 caracteres")]
    [MinLength(6,ErrorMessage="El campo {0}, debe contener al menos 6 caracteres")]
    public int Nit {get; set;}
    
    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 120 caracteres")]
    public int RazonSocial {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 120 caracteres")]
    public int Direccion {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 120 caracteres")]
    public int Correo {get; set;}
    public List<Arbitro> Arbitros {set; get;}
}
