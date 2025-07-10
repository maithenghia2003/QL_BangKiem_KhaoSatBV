using System.ComponentModel.DataAnnotations;

namespace QL_BangKiem_KhaoSat.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HoTen { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MatKhauHash { get; set; }

        public int VaiTroId { get; set; }
        public VaiTroEntity VaiTro { get; set; }

        public bool DaDuyet { get; set; } = false;
        public DateTime NgayDangKy { get; set; } = DateTime.Now;
    }
}
