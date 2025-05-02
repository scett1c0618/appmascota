using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appmascota.Models
{
    [Table("t_mascota")]
    public class Mascota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 30, ErrorMessage = "La edad debe ser positiva.")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [StringLength(50)]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20)]
        public string? Estado { get; set; } // "Disponible" o "Adoptada"

        public MascotaAdoptante? MascotaAdoptante { get; set; } // Relación 1 a 1
    }
}