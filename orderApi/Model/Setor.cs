using System.ComponentModel.DataAnnotations;

namespace orderApi.Model
{
    public class Setor
    {
        [Key]
        public int SetorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set;}
    }
}
