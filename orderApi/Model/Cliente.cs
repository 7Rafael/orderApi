using orderApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace orderApi.Model
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(50)]
        [UserVallidations]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string Senha { get; set; }
        public ICollection<Setor>? Setores { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
