using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appmascota.Models
{

    [Table("t_adoptante")]
    public class Adoptante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 70, ErrorMessage = "La edad debe ser válida.")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string? Telefono { get; set; }

        public ICollection<MascotaAdoptante>? MascotasAdoptadas { get; set; }
    }
}