using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Patrocinador
{
    public int Id {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(10,ErrorMessage="El campo {0}, no puede contener mas de 10 caracteres")]
    [MinLength(6,ErrorMessage="El campo {0}, debe contener al menos 6 caracteres")]
    public string Documento {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(80,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    [MinLength(3,ErrorMessage="El campo {0}, debe contener al menos 3 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(1,ErrorMessage="El campo {0}, no puede contener mas de 80 caracteres")]
    public string TipoPersona {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [MaxLength(120,ErrorMessage="El campo {0}, no puede contener mas de 120 caracteres")]
    public string Direccion {get; set;}

    [Required(ErrorMessage="El campo {0}, es obligatorio")]
    [Range(300000000, 390000000, ErrorMessage="Ingrese un numero de telefono")]
    public string Telefono {get; set;}
    public List<Equipo> Equipos {get;set;}
}
