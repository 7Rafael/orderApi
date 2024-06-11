using System.ComponentModel.DataAnnotations;

namespace orderApi.Model
{
    public class Chamado
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
        public int ClienteId {  get; set; }
        public Cliente? Cliente { get; set; }
        [Required]
        public int SetorId { get; set; }
        public Setor? Setor { get; set; }
    }

}
