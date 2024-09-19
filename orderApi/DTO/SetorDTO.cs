using orderApi.Model;
using orderApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace orderApi.DTO
{
    public class SetorDTO
    {
        [Key]
        public int SetorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
