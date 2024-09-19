using orderApi.Model;
using orderApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace orderApi.DTO
{
    public class ChamadoDTO
    {

        [Key]
        public int ChamadoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        public bool Situacao { get; set; }
        [StringLength(500)]
        public string? Descricao { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int SetorId { get; set; }
        public Setor? Setor { get; set; }
    }
}
