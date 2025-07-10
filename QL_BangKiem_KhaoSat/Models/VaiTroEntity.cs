using System.ComponentModel.DataAnnotations;

namespace QL_BangKiem_KhaoSat.Models
{
    public class VaiTroEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TenVaiTro { get; set; }
    }
}
