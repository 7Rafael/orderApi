using System.ComponentModel.DataAnnotations;

namespace orderApi.Model
{
    public class Role
    {

        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}
