using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appmascota.Models
{
    [Table("t_mascota_adoptante")]
    public class MascotaAdoptante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public int AdoptanteId { get; set; }

        [ForeignKey("MascotaId")]
        public Mascota Mascota { get; set; } = null!;

        [ForeignKey("AdoptanteId")]
        public Adoptante Adoptante { get; set; } = null!;
    }

}