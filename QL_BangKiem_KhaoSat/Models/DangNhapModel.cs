using System.ComponentModel.DataAnnotations;

namespace QL_BangKiem_KhaoSat.Models
{
    public class DangNhapModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}
